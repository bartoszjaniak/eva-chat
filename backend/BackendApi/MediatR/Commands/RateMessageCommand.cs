using MediatR;

namespace BackendApi.MediatR.Commands
{
    public record RateMessageCommand(int MessageId, Rating Rating) : IRequest<bool>;
}
