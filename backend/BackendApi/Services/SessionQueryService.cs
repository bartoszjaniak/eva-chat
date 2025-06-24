using BackendApi.Data.Repositories;
using BackendApi.DTOs.Sessions.Items;
using BackendApi.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Services
{
    public class SessionQueryService : ISessionQueryService
    {
        private readonly IChatSessionRepository _sessionRepository;
        public SessionQueryService(IChatSessionRepository sessionRepository) => _sessionRepository = sessionRepository;

        public async Task<List<SessionListItemDto>> GetSessionsAsync(CancellationToken ct)
        {
            return await _sessionRepository.GetSessionsAsync(ct);
        }
    }
}
