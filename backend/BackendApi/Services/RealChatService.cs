using BackendApi.Interfaces;

namespace BackendApi.Services
{
    public class RealChatService : IChatService
    {
        // TODO: Implement real model communication logic here
        public IAsyncEnumerable<string> StreamResponseAsync(string input, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
