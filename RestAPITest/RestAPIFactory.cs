using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.MsSql;

namespace RestAPITest
{
    public class RestAPIFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer =
            new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server")
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithEnvironment("SA_PASSWORD", "Password_123#")
            .WithPortBinding(1433, 1433)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))            
            .Build();

        public HttpClient HttpClient { get; private set; } = default!;

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            HttpClient = CreateClient();
        }

        public new Task DisposeAsync() => Task.CompletedTask;
    }
}
