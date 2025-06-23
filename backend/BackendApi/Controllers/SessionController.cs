using BackendApi.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BackendApi.DTOs.Sessions.Results;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/session")]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SessionController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Pobiera listę sesji użytkownika
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<SessionListResponseDto>> GetSessions()
        {
            var sessions = await _mediator.Send(new GetSessionsQuery());
            return Ok(new SessionListResponseDto { Sessions = sessions });
        }

        /// <summary>
        /// Pobiera historię wiadomości w sesji o podanym ID
        /// </summary>
        [HttpGet("{sessionId}/messages")]
        public async Task<ActionResult<SessionHistoryResultDto>> GetSessionMessages(Guid sessionId)
        {
            var result = await _mediator.Send(new GetSessionHistoryQuery(sessionId));
            return Ok(result);
        }
    }
}
