namespace BackendApi.DTOs
{
    public class StartSessionResponseDto
    {
        /// <summary>
        /// Wygenerowany identyfikator nowej sesji
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Odpowiedź chatbota na pierwszą wiadomość
        /// </summary>
        public string BotReply { get; set; } = string.Empty;
    }
}
