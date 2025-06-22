public class Message
{
    public Guid Id { get; set; }
    public Guid ChatSessionId { get; set; }
    public required string Content { get; set; }
    public bool IsFromBot { get; set; }
    public Rating Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}

public enum Rating
{
    None = 0, // No rating
    Positive = 1, // 👍
    Negative = -1 // 👎
}
