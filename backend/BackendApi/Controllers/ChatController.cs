using BackendApi.DTOs.Chat;
using BackendApi.MediatR.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChatController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Wysyła wiadomość do chatbota i zwraca odpowiedź w formie streamu.
        /// Jeśli SessionId jest null, tworzy nową sesję.
        /// </summary>
        [HttpPost("message")]
        public IAsyncEnumerable<StreamMessageResultDto> SendMessage(
            [FromBody] StreamMessageCommand cmd,
            CancellationToken ct)
        {
            return _mediator.CreateStream(cmd, ct);
        }
    }
}
