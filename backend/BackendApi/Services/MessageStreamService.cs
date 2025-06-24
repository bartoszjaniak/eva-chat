using BackendApi.Data.Models;
using BackendApi.Data.Repositories;
using BackendApi.DTOs.Chat.Results;
using BackendApi.Interfaces;
using BackendApi.MediatR.Commands;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Services
{
    public class MessageStreamService : IMessageStreamService
    {
        private readonly IChatSessionRepository _sessionRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IChatService _chatService;

        public MessageStreamService(IChatSessionRepository sessionRepository, IChatRepository chatRepository, IChatService chatService)
        {
            _sessionRepository = sessionRepository;
            _chatRepository = chatRepository;
            _chatService = chatService;
        }

        public async IAsyncEnumerable<StreamMessageResultDto> StreamMessageAsync(StreamMessageCommand request, [EnumeratorCancellation] CancellationToken ct)
        {
            ChatSession session;
            if (request.SessionId.HasValue)
            {
                session = await _sessionRepository.GetSessionAsync(request.SessionId.Value, ct);
            }
            else
            {
                session = await _sessionRepository.CreateSessionAsync(request.Content ,ct);
            }

            var userMsg = new Message
            {
                ChatSessionId = session.Id,
                Content       = request.Content,
                IsFromBot     = false,
                CreatedAt     = DateTime.UtcNow
            };
            await _chatRepository.AddMessageAsync(userMsg, ct);

            var botResponseBuilder = new StringBuilder();
            var messageId = Guid.NewGuid();
            try
            {
                await foreach (var chunk in _chatService.StreamResponseAsync(request.Content, ct))
                {
                    botResponseBuilder.Append(chunk);
                    yield return new StreamMessageResultDto
                    {
                        SessionId = session.Id,
                        MessageId = messageId,
                        Chunk = chunk
                    };
                }
            }
            finally
            {
                var botMsg = new Message
                {
                    Id = messageId,
                    ChatSessionId = session.Id,
                    Content = botResponseBuilder.ToString(),
                    IsFromBot = true,
                    CreatedAt = DateTime.UtcNow
                };
                await _chatRepository.AddMessageAsync(botMsg, ct);
            }
        }
    }
}
