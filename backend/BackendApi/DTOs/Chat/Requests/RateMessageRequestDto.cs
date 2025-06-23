using BackendApi.DTOs.Enums;

namespace BackendApi.DTOs.Chat.Requests
{
    public class RateMessageRequestDto
    {
        /// <summary>
        /// Identyfikator wiadomości
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Ocena wiadomości (Rating enum)
        /// </summary>
        public RatingEnum Rating { get; set; }
    }
}
