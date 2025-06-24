using MediatR;
using BackendApi.MediatR.Queries;
using BackendApi.Interfaces;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, List<SessionListItemDto>>
    {
        private readonly ISessionQueryService _sessionQueryService;
        public GetSessionsHandler(ISessionQueryService sessionQueryService) => _sessionQueryService = sessionQueryService;

        public async Task<List<SessionListItemDto>> Handle(GetSessionsQuery request, CancellationToken ct)
        {
            return await _sessionQueryService.GetSessionsAsync(ct);
        }
    }
}
