
namespace BackendApi.Interfaces
{
    public interface IChatService
    {
        IAsyncEnumerable<string> StreamResponseAsync(string input, CancellationToken ct = default);
    }

}
