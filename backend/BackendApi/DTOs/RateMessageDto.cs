namespace BackendApi.DTOs
{
    public class RateMessageDto
    {
        /// <summary>
        /// Identyfikator wiadomości
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// Ocena wiadomości (true = like, false = dislike)
        /// </summary>
        public bool IsLiked { get; set; }
    }
}
