namespace BackendApi.DTOs
{
    public class StreamChunkDto
    {
        /// <summary>
        /// Kolejny fragment odpowiedzi bota
        /// </summary>
        public string Chunk { get; set; } = string.Empty;
    }
}
