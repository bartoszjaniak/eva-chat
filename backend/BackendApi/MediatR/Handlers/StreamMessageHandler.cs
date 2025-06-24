using BackendApi.Data.Models;
using BackendApi.Interfaces;
using BackendApi.MediatR.Commands;
using MediatR;
using System.Runtime.CompilerServices;
using BackendApi.Data.Repositories;
using BackendApi.DTOs.Chat.Results;

namespace BackendApi.MediatR.Handlers
{
    public class StreamMessageHandler
        : IStreamRequestHandler<StreamMessageCommand, StreamMessageResultDto>
    {
        private readonly IMessageStreamService _messageStreamService;
        public StreamMessageHandler(IMessageStreamService messageStreamService)
        {
            _messageStreamService = messageStreamService;
        }
        public async IAsyncEnumerable<StreamMessageResultDto> Handle(
            StreamMessageCommand request,
            [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (var result in _messageStreamService.StreamMessageAsync(request, ct))
            {
                yield return result;
            }
        }
    }
}
