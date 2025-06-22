using MediatR;
using BackendApi.MediatR.Commands;
using Microsoft.EntityFrameworkCore;
using BackendApi.Data.Models;

namespace BackendApi.MediatR.Handlers
{
    public class RateMessageHandler : IRequestHandler<RateMessageCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        public RateMessageHandler(ApplicationDbContext db) => _db = db;

        public async Task<bool> Handle(RateMessageCommand req, CancellationToken ct)
        {
            var msg = await _db.Messages.FirstOrDefaultAsync(m => m.Id == req.MessageId, ct) ?? throw new InvalidOperationException("Nie znaleziono wiadomości");

            if (msg == null) return false;
            msg.Rating = (Rating)req.Rating;

            await _db.SaveChangesAsync(ct);

            return true;
        }
    }
}
