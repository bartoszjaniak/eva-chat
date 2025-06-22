using System.Text.Json;
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
    public async Task Stream([FromBody] StreamMessageRequestDto data)
        {
            Response.ContentType = "application/json";

            var cmd = new StreamMessageCommand(data.SessionId, data.Content);

            await foreach (var chunk in _mediator.CreateStream(cmd, HttpContext.RequestAborted))
            {
                var json = JsonSerializer.Serialize(chunk);
                await Response.WriteAsync(json + "\n");
                await Response.Body.FlushAsync();
            }
        }
    }
}
