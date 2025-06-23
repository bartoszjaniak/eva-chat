using BackendApi.DTOs.Chat.Results;
using MediatR;

namespace BackendApi.MediatR.Commands
{
    public record StreamMessageCommand(Guid? SessionId, string Content): IStreamRequest<StreamMessageResultDto>;
}
