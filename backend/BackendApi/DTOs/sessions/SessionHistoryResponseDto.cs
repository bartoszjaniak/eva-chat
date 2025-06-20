namespace BackendApi.DTOs
{
    public class SessionHistoryResponseDto
    {
        /// <summary>
        /// Lista wiadomości w kolejności chronologicznej
        /// </summary>
        public List<ChatMessageDto> Messages { get; set; } = new();

        /// <summary>
        /// Data i czas otwarcia sesji
        /// </summary>
        public DateTime StartedAt { get; set; }
    }

    public class ChatMessageDto
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsFromBot { get; set; }
        public int? Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
