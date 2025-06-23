
using BackendApi.DTOs.Enums;

namespace BackendApi.DTOs.Chat.Items;
public class MessageItemDto
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsFromBot { get; set; }
    public RatingEnum Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}
