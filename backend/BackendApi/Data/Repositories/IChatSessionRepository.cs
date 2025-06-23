using BackendApi.Data.Models;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.Data.Repositories
{
    public interface IChatSessionRepository
    {
        Task<List<SessionListItemDto>> GetSessionsAsync(CancellationToken ct);
        Task<ChatSession> GetSessionAsync(Guid sessionId, CancellationToken ct);
        Task<List<Message>> GetSessionMessagesAsync(Guid sessionId, CancellationToken ct);
        Task<ChatSession> CreateSessionAsync(string userMessage, CancellationToken ct);
    }
}
