using BackendApi.Data.Repositories;
using BackendApi.DTOs.Sessions.Results;
using BackendApi.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Services
{
    public class SessionHistoryService : ISessionHistoryService
    {
        private readonly IChatSessionRepository _sessionRepository;
        public SessionHistoryService(IChatSessionRepository sessionRepository) => _sessionRepository = sessionRepository;

        public async Task<SessionHistoryResultDto> GetSessionHistoryAsync(Guid sessionId, CancellationToken ct)
        {
            var session = await _sessionRepository.GetSessionAsync(sessionId, ct);
            if (session == null)
                throw new InvalidOperationException("Nie znaleziono sesji");

            var response = new SessionHistoryResultDto
            {
                StartedAt = session.StartedAt,
                Messages = session.Messages
                    .OrderBy(m => m.CreatedAt)
                    .Select(m => new DTOs.Chat.Items.MessageItemDto
                    {
                        Id = m.Id,
                        SessionId = session.Id,
                        Content = m.Content,
                        IsFromBot = m.IsFromBot,
                        Rating = (DTOs.Enums.RatingEnum)m.Rating,
                        CreatedAt = m.CreatedAt
                    }).ToList()
            };
            return response;
        }
    }
}
