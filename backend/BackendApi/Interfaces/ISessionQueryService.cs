using BackendApi.DTOs.Sessions.Items;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.Interfaces
{
    public interface ISessionQueryService
    {
        Task<List<SessionListItemDto>> GetSessionsAsync(CancellationToken ct);
    }
}
