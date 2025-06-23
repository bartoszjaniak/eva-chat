using MediatR;
using BackendApi.MediatR.Queries;
using BackendApi.Data.Repositories;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, List<SessionListItemDto>>
    {
        private readonly IChatSessionRepository _sessionRepository;
        public GetSessionsHandler(IChatSessionRepository sessionRepository) => _sessionRepository = sessionRepository;

        public async Task<List<SessionListItemDto>> Handle(GetSessionsQuery request, CancellationToken ct)
        {
            return await _sessionRepository.GetSessionsAsync(ct);
        }
    }
}
