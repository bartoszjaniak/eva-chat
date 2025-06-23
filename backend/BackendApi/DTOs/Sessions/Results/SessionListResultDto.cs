using BackendApi.DTOs.Sessions.Items;

namespace BackendApi.DTOs.Sessions.Results
{
    public class SessionListResponseDto
    {
        /// <summary>
        /// Lista sesji użytkownika
        /// </summary>
        public List<SessionListItemDto> Sessions { get; set; } = new();
    }
}
