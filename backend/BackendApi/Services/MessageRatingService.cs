using BackendApi.Data.Repositories;
using BackendApi.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Services
{
    public class MessageRatingService : IMessageRatingService
    {
        private readonly IChatRepository _chatRepository;
        public MessageRatingService(IChatRepository chatRepository) => _chatRepository = chatRepository;

        public async Task<bool> RateMessageAsync(Guid messageId, DTOs.Enums.RatingEnum rating, CancellationToken ct)
        {
            return await _chatRepository.RateMessageAsync(messageId, rating, ct);
        }
    }
}
