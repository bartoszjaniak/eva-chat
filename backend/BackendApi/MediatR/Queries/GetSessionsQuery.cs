using MediatR;
using BackendApi.DTOs.sessions;

namespace BackendApi.MediatR.Queries
{
    public record GetSessionsQuery() : IRequest<List<SessionListItemDto>>;
}
