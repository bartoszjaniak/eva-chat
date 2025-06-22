using BackendApi.Data.Models;
using BackendApi.Data.Repositories;
using BackendApi.DTOs;
using BackendApi.DTOs.Chat;
using BackendApi.DTOs.Sessions;
using BackendApi.MediatR.Queries;
using MediatR;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionHistoryHandler :  IRequestHandler<GetSessionHistoryQuery, SessionHistoryResponseDto>
    {
        private readonly IChatRepository _chatRepository;
        public GetSessionHistoryHandler(IChatRepository chatRepository) => _chatRepository = chatRepository;

        public async Task<SessionHistoryResponseDto> Handle(GetSessionHistoryQuery request, CancellationToken cancellationToken)
        {
            var session = await _chatRepository.GetSessionAsync(request.SessionId, cancellationToken);
            if (session == null)
                throw new InvalidOperationException("Nie znaleziono sesji");

            var response = new SessionHistoryResponseDto
            {
                StartedAt = session.StartedAt,
                Messages = session.Messages
                    .OrderBy(m => m.CreatedAt)
                    .Select(m => new MessageDto
                    {
                        Id = m.Id,
                        SessionId = session.Id,
                        Content = m.Content,
                        IsFromBot = m.IsFromBot,
                        Rating = (RatingDto)m.Rating,
                        CreatedAt = m.CreatedAt
                    }).ToList()
            };
            return response;
        }
    }
}
