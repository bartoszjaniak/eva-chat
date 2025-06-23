using BackendApi.DTOs.Sessions.Results;
using MediatR;

namespace BackendApi.MediatR.Queries
{
    public record GetSessionHistoryQuery(Guid SessionId) : IRequest<SessionHistoryResultDto>;
}
