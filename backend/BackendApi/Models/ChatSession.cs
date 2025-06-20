public class ChatSession
{
    public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public required List<Message> Messages { get; set; }
}
