using BackendApi.Data.Models;
using BackendApi.DTOs.Sessions.Items;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _db;
        public ChatRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<SessionListItemDto>> GetSessionsAsync(CancellationToken ct)
        {
            return await _db.ChatSessions
                .OrderByDescending(s => s.StartedAt)
                .Select(s => new SessionListItemDto
                {
                    SessionId = s.Id,
                    StartedAt = s.StartedAt,
                    Title = s.Title
                })
                .ToListAsync(ct);
        }

        public async Task<ChatSession> CreateSessionAsync(string userMessage,  CancellationToken ct)
        {
            var session = new ChatSession {
                Title = userMessage,
                StartedAt = DateTime.UtcNow };

            _db.ChatSessions.Add(session);
            await _db.SaveChangesAsync(ct);
            return session;
        }

        public async Task<ChatSession> GetSessionAsync(Guid sessionId, CancellationToken ct)
        {
            return await _db.ChatSessions
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(s => s.Id == sessionId, ct)
                ?? throw new InvalidOperationException("Nie znaleziono sesji");
        }

        public async Task<Message> AddMessageAsync(Message message, CancellationToken ct)
        {
            _db.Messages.Add(message);
            await _db.SaveChangesAsync(ct);
            return message;
        }
    }
}
