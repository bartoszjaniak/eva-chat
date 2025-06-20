namespace BackendApi.DTOs
{
    public class StartSessionDto
    {
        /// <summary>
        /// Treść pierwszej wiadomości inicjującej sesję
        /// </summary>
        public string InitialMessage { get; set; } = string.Empty;
    }
}
