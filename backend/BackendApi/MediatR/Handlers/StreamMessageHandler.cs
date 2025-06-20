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

namespace BackendApi.MediatR.Handlers
{
    public class StreamMessageHandler
        : IStreamRequestHandler<StreamMessageCommand, StreamMessageResultDto>
    {
        private readonly ApplicationDbContext _db;
        private readonly IChatService _chatService;

        public StreamMessageHandler(ApplicationDbContext db, IChatService chatService)
        {
            _db = db;
            _chatService = chatService;
        }

        public async IAsyncEnumerable<StreamMessageResultDto> Handle(
            StreamMessageCommand request,
            [EnumeratorCancellation] CancellationToken ct)
        {
            // 1. Utworzenie lub pobranie sesji
            ChatSession session;
            if (request.SessionId.HasValue)
            {
                session = await _db.ChatSessions.FindAsync(
                    new object[] { request.SessionId.Value }, ct)
                    ?? throw new InvalidOperationException("Nie znaleziono sesji");
            }
            else
            {
                session = new ChatSession { StartedAt = DateTime.UtcNow };
                _db.ChatSessions.Add(session);
                await _db.SaveChangesAsync(ct);  // zapis nowej sesji
            }

            // 2. Zapis wiadomości użytkownika
            var userMsg = new Message
            {
                ChatSessionId = session.Id,
                Content       = request.Content,
                IsFromBot     = false,
                CreatedAt     = DateTime.UtcNow
            };
            _db.Messages.Add(userMsg);
            await _db.SaveChangesAsync(ct);    // zapis user message

            // 3. Streamowanie odpowiedzi chatbota i zapis fragmentów
            await foreach (var chunk in _chatService.StreamResponseAsync(request.Content, ct))
            {
                // Zapis każdego fragmentu do bazy
                var botMsg = new Message
                {
                    ChatSessionId = session.Id,
                    Content       = chunk,
                    IsFromBot     = true,
                    CreatedAt     = DateTime.UtcNow
                };
                _db.Messages.Add(botMsg);
                await _db.SaveChangesAsync(ct);  // zapis bot message

                // Zwrot fragmentu klientowi z id sesji
                yield return new StreamMessageResultDto
                {
                    SessionId = session.Id,
                    Chunk     = chunk
                };
            }
        }
    }
}
