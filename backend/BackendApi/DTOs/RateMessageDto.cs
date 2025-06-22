using BackendApi.DTOs.Chat;

namespace BackendApi.DTOs
{


    public class RateMessageDto
    {
        /// <summary>
        /// Identyfikator wiadomości
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Ocena wiadomości (Rating enum)
        /// </summary>
        public RatingDto Rating { get; set; }
    }
}
