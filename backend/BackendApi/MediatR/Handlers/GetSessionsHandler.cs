using MediatR;
using BackendApi.MediatR.Queries;
using BackendApi.Data.Repositories;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, List<SessionListItemDto>>
    {
        private readonly IChatRepository _chatRepository;
        public GetSessionsHandler(IChatRepository chatRepository) => _chatRepository = chatRepository;

        public async Task<List<SessionListItemDto>> Handle(GetSessionsQuery request, CancellationToken ct)
        {
            return await _chatRepository.GetSessionsAsync(ct);
        }
    }
}
