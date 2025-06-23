using System.Runtime.CompilerServices;
using BackendApi.Interfaces;
using System.Text.RegularExpressions;

namespace BackendApi.Services.Mocks
{
    public class FakeChatService : IChatService
    {
        public async IAsyncEnumerable<string> StreamResponseAsync(string input, [EnumeratorCancellation] CancellationToken ct = default)
        {
            var lorem = new Bogus.DataSets.Lorem();
            var random = new Random();
            int type = random.Next(3); // 0: jedno zdanie, 1: akapit, 2: kilka akapitów


            string response;
            if (type == 2)
            {
                int paraCount = random.Next(2, 5);
                var paragraphs = new List<string>();
                for (int i = 0; i < paraCount; i++)
                {
                    paragraphs.Add(lorem.Paragraph());
                }
                response = string.Join("\n\n", paragraphs);
            }
            else
            {
                response = type == 0 ? lorem.Sentence() : lorem.Paragraph();
            }

            // Split na słowa z zachowaniem separatorów (spacja lub \n)
            var matches = Regex.Matches(response, @"[^ \n]+([ \n]+)?");
            foreach (Match match in matches)
            {
                int delay = random.Next(10, 201);
                await Task.Delay(delay, ct);
                yield return match.Value;
            }
        }
    }
}
