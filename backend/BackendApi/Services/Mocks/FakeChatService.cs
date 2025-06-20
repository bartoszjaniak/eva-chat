using System.Runtime.CompilerServices;
using BackendApi.Interfaces;

namespace BackendApi.Services.Mocks
{
    public class FakeChatService : IChatService
    {
        public async IAsyncEnumerable<string> StreamResponseAsync(string input, [EnumeratorCancellation] CancellationToken ct = default)
        {
            foreach (var part in new[] { "Fejk", "owa ", "odpowiedź" })
            {
                await Task.Delay(100, ct);
                yield return part;
            }
        }
    }
}
