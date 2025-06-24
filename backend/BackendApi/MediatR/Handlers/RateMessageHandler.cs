using MediatR;
using BackendApi.MediatR.Commands;
using BackendApi.Interfaces;

namespace BackendApi.MediatR.Handlers
{
    public class RateMessageHandler : IRequestHandler<RateMessageCommand, bool>
    {
        private readonly IMessageRatingService _messageRatingService;
        public RateMessageHandler(IMessageRatingService messageRatingService) => _messageRatingService = messageRatingService;
        public async Task<bool> Handle(RateMessageCommand req, CancellationToken ct)
        {
            return await _messageRatingService.RateMessageAsync(req.MessageId, req.Rating, ct);
        }
    }
}
