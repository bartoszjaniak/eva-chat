using BackendApi.Data.Models;
using BackendApi.DTOs.Enums;
using BackendApi.DTOs.Sessions.Items;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _db;
        public ChatRepository(ApplicationDbContext db) => _db = db;

        public async Task<Message> AddMessageAsync(Message message, CancellationToken ct)
        {
            _db.Messages.Add(message);
            await _db.SaveChangesAsync(ct);
            return message;
        }

        public async Task<bool> RateMessageAsync(Guid messageId, RatingEnum rating, CancellationToken ct)
        {
            var msg = await _db.Messages.FirstOrDefaultAsync(m => m.Id == messageId, ct);
            if (msg == null) return false;
            msg.Rating = (Rating)rating;
            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
