using BackendApi.Data;
using BackendApi.Data.Models;
using BackendApi.DTOs;
using BackendApi.DTOs.Chat;
using BackendApi.Interfaces;
using BackendApi.MediatR.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BackendApi.Data.Repositories;

namespace BackendApi.MediatR.Handlers
{
    public class StreamMessageHandler
        : IStreamRequestHandler<StreamMessageCommand, StreamMessageResultDto>
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatService _chatService;

        public StreamMessageHandler(IChatRepository chatRepository, IChatService chatService)
        {
            _chatRepository = chatRepository;
            _chatService = chatService;
        }

        public async IAsyncEnumerable<StreamMessageResultDto> Handle(
            StreamMessageCommand request,
            [EnumeratorCancellation] CancellationToken ct)
        {
            ChatSession session;
            if (request.SessionId.HasValue)
            {
                session = await _chatRepository.GetSessionAsync(request.SessionId.Value, ct);
            }
            else
            {
                session = await _chatRepository.CreateSessionAsync(ct);
            }

            var userMsg = new Message
            {
                ChatSessionId = session.Id,
                Content       = request.Content,
                IsFromBot     = false,
                CreatedAt     = DateTime.UtcNow
            };
            await _chatRepository.AddMessageAsync(userMsg, ct);

            await foreach (var chunk in _chatService.StreamResponseAsync(request.Content, ct))
            {
                var botMsg = new Message
                {
                    ChatSessionId = session.Id,
                    Content       = chunk,
                    IsFromBot     = true,
                    CreatedAt     = DateTime.UtcNow
                };
                await _chatRepository.AddMessageAsync(botMsg, ct);

                yield return new StreamMessageResultDto
                {
                    SessionId = session.Id,
                    Chunk     = chunk
                };
            }
        }
    }
}
