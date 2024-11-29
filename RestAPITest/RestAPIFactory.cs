using Microsoft.AspNetCore.Mvc.Testing;

namespace RestAPITest
{
    public class RestAPIFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        public HttpClient HttpClient { get; private set; } = default!;

        public async Task InitializeAsync()
        {
            HttpClient = CreateClient();
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}
