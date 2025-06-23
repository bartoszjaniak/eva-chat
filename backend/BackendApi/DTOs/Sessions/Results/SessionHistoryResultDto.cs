using BackendApi.DTOs.Chat.Items;

namespace BackendApi.DTOs.Sessions.Results
{
    public class SessionHistoryResultDto
    {
        /// <summary>
        /// Lista wiadomości w kolejności chronologicznej
        /// </summary>
        public List<MessageItemDto> Messages { get; set; } = new();

        /// <summary>
        /// Data i czas otwarcia sesji
        /// </summary>
        public DateTime StartedAt { get; set; }
    }

}
