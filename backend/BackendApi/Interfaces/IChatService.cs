public interface IChatService
{
    Task<string> GetResponseAsync(string input, CancellationToken ct = default);
    IAsyncEnumerable<string> StreamResponseAsync(string input, CancellationToken ct = default);
}
