using MediatR;
using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.MediatR.Queries
{
    public record GetSessionsQuery() : IRequest<List<SessionListItemDto>>;
}
