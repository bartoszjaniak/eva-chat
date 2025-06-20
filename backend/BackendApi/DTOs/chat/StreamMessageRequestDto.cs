namespace BackendApi.DTOs.Chat
{
    public class StreamMessageRequestDto
    {
        public Guid? SessionId { get; set; } = null; // Nullable to allow start of new session

        public string Content { get; set; } = string.Empty;
    }
}
