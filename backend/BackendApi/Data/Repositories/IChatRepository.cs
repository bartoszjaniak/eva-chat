using BackendApi.Data.Models;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.Data.Repositories
{
    public interface IChatRepository
    {
        Task<List<SessionListItemDto>> GetSessionsAsync(CancellationToken ct);
        Task<ChatSession> CreateSessionAsync(string userMessage, CancellationToken ct);
        Task<ChatSession> GetSessionAsync(Guid sessionId, CancellationToken ct);
        Task<Message> AddMessageAsync(Message message, CancellationToken ct);
    }
}
