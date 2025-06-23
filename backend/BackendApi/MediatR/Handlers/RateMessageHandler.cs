using MediatR;
using BackendApi.MediatR.Commands;
using BackendApi.Data.Repositories;

namespace BackendApi.MediatR.Handlers
{
    public class RateMessageHandler : IRequestHandler<RateMessageCommand, bool>
    {
        private readonly IChatRepository _chatRepository;
        public RateMessageHandler(IChatRepository chatRepository) => _chatRepository = chatRepository;

        public async Task<bool> Handle(RateMessageCommand req, CancellationToken ct)
        {
            return await _chatRepository.RateMessageAsync(req.MessageId, req.Rating, ct);
        }
    }
}
