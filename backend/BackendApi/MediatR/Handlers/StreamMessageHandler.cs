using BackendApi.Data.Models;
using BackendApi.Interfaces;
using BackendApi.MediatR.Commands;
using MediatR;
using System.Runtime.CompilerServices;
using BackendApi.Data.Repositories;
using BackendApi.DTOs.Chat.Results;

namespace BackendApi.MediatR.Handlers
{
    public class StreamMessageHandler
        : IStreamRequestHandler<StreamMessageCommand, StreamMessageResultDto>
    {
        private readonly IChatSessionRepository _sessionRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IChatService _chatService;

        public StreamMessageHandler(IChatSessionRepository sessionRepository, IChatRepository chatRepository, IChatService chatService)
        {
            _sessionRepository = sessionRepository;
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

            var botResponseBuilder = new System.Text.StringBuilder();
            var messageId = Guid.NewGuid(); // Unique ID for the message, can be used for tracking
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
                if (botResponseBuilder.Length > 0)
                {
                    var botMsg = new Message
                    {
                        Id = messageId,
                        ChatSessionId = session.Id,
                        Content = botResponseBuilder.ToString(),
                        IsFromBot = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    await _chatRepository.AddMessageAsync(botMsg, CancellationToken.None); // Save the complete bot response even if the stream is cancelled
                }
            }
        }
    }
}
