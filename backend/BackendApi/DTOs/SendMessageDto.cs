namespace BackendApi.DTOs
{
    public class SendMessageDto
    {
        /// <summary>
        /// Identyfikator sesji czatu
        /// </summary>
        public Guid? SessionId { get; set; } = null;

        /// <summary>
        /// Treść wiadomości wysyłanej przez użytkownika
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}
