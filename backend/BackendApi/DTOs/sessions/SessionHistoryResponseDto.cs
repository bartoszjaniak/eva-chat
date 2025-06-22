using BackendApi.DTOs.Chat;

namespace BackendApi.DTOs.Sessions
{
    public class SessionHistoryResponseDto
    {
        /// <summary>
        /// Lista wiadomości w kolejności chronologicznej
        /// </summary>
        public List<MessageDto> Messages { get; set; } = new();

        /// <summary>
        /// Data i czas otwarcia sesji
        /// </summary>
        public DateTime StartedAt { get; set; }
    }

}
