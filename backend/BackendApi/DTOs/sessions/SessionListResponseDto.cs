using System;
using System.Collections.Generic;

namespace BackendApi.DTOs.sessions
{
    public class SessionListResponseDto
    {
        /// <summary>
        /// Lista sesji użytkownika
        /// </summary>
        public List<SessionListItemDto> Sessions { get; set; } = new();
    }
}
