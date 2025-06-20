using System;

namespace BackendApi.DTOs.sessions
{
    public class SessionListItemDto
    {
        /// <summary>
        /// Identyfikator sesji
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Data utworzenia sesji
        /// </summary>
        public DateTime StartedAt { get; set; }
    }
}
