using BackendApi.DTOs.Enums;
using MediatR;

namespace BackendApi.MediatR.Commands
{
    public record RateMessageCommand(Guid MessageId, RatingEnum Rating) : IRequest<bool>;
}
