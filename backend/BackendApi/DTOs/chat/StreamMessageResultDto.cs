
namespace BackendApi.DTOs.Chat
{
    public class StreamMessageResultDto
    {
        public Guid SessionId { get; set; }

        public Guid MessageId { get; set; }

        public string Chunk { get; set; } = string.Empty;
    }
}
