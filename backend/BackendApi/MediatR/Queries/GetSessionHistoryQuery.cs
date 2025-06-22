using BackendApi.DTOs;
using BackendApi.DTOs.Sessions;
using MediatR;

namespace BackendApi.MediatR.Queries
{
    public record GetSessionHistoryQuery(Guid SessionId) : IRequest<SessionHistoryResponseDto>;
}
