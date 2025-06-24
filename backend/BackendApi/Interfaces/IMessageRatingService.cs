using System;
using System.Threading;
using System.Threading.Tasks;
using BackendApi.DTOs.Enums;

namespace BackendApi.Interfaces
{
    public interface IMessageRatingService
    {
        Task<bool> RateMessageAsync(Guid messageId, RatingEnum rating, CancellationToken ct);
    }
}
