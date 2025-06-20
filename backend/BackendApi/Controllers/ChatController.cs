using System.Runtime.CompilerServices;
using BackendApi.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;


    [HttpGet("{sessionId}/stream")]
    public async IAsyncEnumerable<string> Stream(Guid sessionId, [FromBody] SendMessageDto dto, [EnumeratorCancellation] CancellationToken ct) =>
        _mediator.CreateStream(new SendMessageCommand(sessionId, dto.Content), ct);


    [HttpGet("{sessionId}/history")]
    public async Task<IActionResult> History(Guid sessionId, CancellationToken ct) =>
        Ok(await _mediator.Send(new GetHistoryQuery(sessionId), ct));
}
