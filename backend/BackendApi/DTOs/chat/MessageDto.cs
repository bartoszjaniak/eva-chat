
namespace BackendApi.DTOs.Chat;
public class MessageDto
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsFromBot { get; set; }
    public RatingDto Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}
