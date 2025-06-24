using BackendApi.DTOs.Chat.Results;
using BackendApi.MediatR.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Interfaces
{
    public interface IMessageStreamService
    {
        IAsyncEnumerable<StreamMessageResultDto> StreamMessageAsync(StreamMessageCommand request, CancellationToken ct);
    }
}
