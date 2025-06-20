using System.Runtime.CompilerServices;

public class FakeChatService : IChatService
{
    public Task<string> GetResponseAsync(string input, CancellationToken ct = default) =>
        Task.FromResult("Fejkowa odpowiedź");

    public async IAsyncEnumerable<string> StreamResponseAsync(string input, [EnumeratorCancellation] CancellationToken ct = default)
    {
        foreach (var part in new[] { "Fejk", "owa ", "odpowiedź" })
        {
            await Task.Delay(100, ct);
            yield return part;
        }
    }
}
