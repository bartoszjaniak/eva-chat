public class MessageDto
{
    public Guid SessionId { get; set; }          // Id sesji czatu
    public int MessageId { get; set; }             // Id wiadomości
    public string Content { get; set; }            // Treść wiadomości
    public bool IsFromBot { get; set; }            // Czy od bota
    public DateTime CreatedAt { get; set; }        // Data wysłania
    public int? Rating { get; set; }               // Ocena (1-👍, -1-👎, null - brak)
}
