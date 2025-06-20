using MediatR;
using BackendApi.MediatR.Commands;

namespace BackendApi.MediatR.Handlers
{
    public class RateMessageHandler : IRequestHandler<RateMessageCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        public RateMessageHandler(ApplicationDbContext db) => _db = db;

        public async Task<bool> Handle(RateMessageCommand req, CancellationToken ct)
        {
            var msg = await _db.Messages.FindAsync(new object[]{ req.MessageId }, ct);

            if (msg == null) return false;
            msg.Rating = req.Rating;

            await _db.SaveChangesAsync(ct);

            return true;
        }
    }
}
