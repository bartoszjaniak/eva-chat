namespace BackendApi.DTOs
{
    public class BotResponseDto
    {
        /// <summary>
        /// Identyfikator sesji czatu
        /// </summary>
        public Guid SessionId { get; set; }

        /// <summary>
        /// Pełna odpowiedź wygenerowana przez bota
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Flaga określająca, czy odpowiedź jest ukończona
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
