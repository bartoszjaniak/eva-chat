using BackendApi.DTOs.Chat;
using MediatR;

namespace BackendApi.MediatR.Commands
{
    public record RateMessageCommand(Guid MessageId, RatingDto Rating) : IRequest<bool>;
}
