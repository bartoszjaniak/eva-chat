using BackendApi.DTOs.Sessions.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Interfaces
{
    public interface ISessionHistoryService
    {
        Task<SessionHistoryResultDto> GetSessionHistoryAsync(Guid sessionId, CancellationToken ct);
    }
}
