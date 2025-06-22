namespace BackendApi.Data.Models
{
    public class ChatSession
    {
        public Guid Id { get; set; }
        public DateTime StartedAt { get; set; }
        public List<Message> Messages { get; set; } = new();
        public required string Title { get; set; }
    }
}
