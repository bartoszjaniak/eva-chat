public class ChatSession
{
    public int Id { get; set; }
    public DateTime StartedAt { get; set; }
    public List<Message> Messages { get; set; }
}
