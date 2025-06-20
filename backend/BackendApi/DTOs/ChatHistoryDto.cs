namespace BackendApi.DTOs
{
    public class ChatHistoryDto
    {
        /// <summary>
        /// Lista wszystkich wiadomości w danej sesji
        /// </summary>
        public List<MessageDto> Messages { get; set; } = new();

        public class MessageDto
        {
            public int Id { get; set; }
            public Guid SessionId { get; set; }
            public string Content { get; set; } = string.Empty;
            public bool IsFromBot { get; set; }
            public int? Rating { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
