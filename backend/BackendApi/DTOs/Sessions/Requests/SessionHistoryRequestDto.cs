namespace BackendApi.DTOs.Sessions
{
    public class SessionHistoryRequestDto
    {
        /// <summary>
        /// Identyfikator sesji, dla której pobieramy historię
        /// </summary>
        public Guid SessionId { get; set; }
    }
}
