using BackendApi.Data.Repositories;
using BackendApi.DTOs.Chat.Items;
using BackendApi.DTOs.Enums;
using BackendApi.DTOs.Sessions.Results;
using BackendApi.Interfaces;
using BackendApi.MediatR.Queries;
using MediatR;

namespace BackendApi.MediatR.Handlers
{
    public class GetSessionHistoryHandler :  IRequestHandler<GetSessionHistoryQuery, SessionHistoryResultDto>
    {
        private readonly ISessionHistoryService _sessionHistoryService;
        public GetSessionHistoryHandler(ISessionHistoryService sessionHistoryService) => _sessionHistoryService = sessionHistoryService;
        public async Task<SessionHistoryResultDto> Handle(GetSessionHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _sessionHistoryService.GetSessionHistoryAsync(request.SessionId, cancellationToken);
        }
    }
}
