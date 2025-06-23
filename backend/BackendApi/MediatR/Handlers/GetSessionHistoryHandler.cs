using BackendApi.Data.Repositories;
using BackendApi.DTOs.Chat.Items;
using BackendApi.DTOs.Enums;
using BackendApi.DTOs.Sessions.Results;
using BackendApi.MediatR.Queries;
using MediatR;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionHistoryHandler :  IRequestHandler<GetSessionHistoryQuery, SessionHistoryResultDto>
    {
        private readonly IChatSessionRepository _sessionRepository;
        public GetSessionHistoryHandler(IChatSessionRepository sessionRepository) => _sessionRepository = sessionRepository;

        public async Task<SessionHistoryResultDto> Handle(GetSessionHistoryQuery request, CancellationToken cancellationToken)
        {
            var session = await _sessionRepository.GetSessionAsync(request.SessionId, cancellationToken);
            if (session == null)
                throw new InvalidOperationException("Nie znaleziono sesji");

            var response = new SessionHistoryResultDto
            {
                StartedAt = session.StartedAt,
                Messages = session.Messages
                    .OrderBy(m => m.CreatedAt)
                    .Select(m => new MessageItemDto
                    {
                        Id = m.Id,
                        SessionId = session.Id,
                        Content = m.Content,
                        IsFromBot = m.IsFromBot,
                        Rating = (RatingEnum)m.Rating,
                        CreatedAt = m.CreatedAt
                    }).ToList()
            };
            return response;
        }
    }
}
