using MediatR;
using Microsoft.EntityFrameworkCore;
using BackendApi.MediatR.Queries;
using BackendApi.DTOs.sessions;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, List<SessionListItemDto>>
    {
        private readonly ApplicationDbContext _db;
        public GetSessionsHandler(ApplicationDbContext db) => _db = db;

        public async Task<List<SessionListItemDto>> Handle(GetSessionsQuery request, CancellationToken ct)
        {
            return await _db.ChatSessions
                .OrderByDescending(s => s.StartedAt)
                .Select(s => new SessionListItemDto
                {
                    SessionId = s.Id,
                    StartedAt = s.StartedAt
                })
                .ToListAsync(ct);
        }
    }
}
