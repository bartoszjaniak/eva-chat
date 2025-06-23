using BackendApi.Data.Models;
using BackendApi.DTOs.Enums;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.Data.Repositories
{
    public interface IChatRepository
    {
        Task<Message> AddMessageAsync(Message message, CancellationToken ct);
        Task<bool> RateMessageAsync(Guid messageId, RatingEnum rating, CancellationToken ct);
    }
}
