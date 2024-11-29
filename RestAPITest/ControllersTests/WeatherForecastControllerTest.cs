using Newtonsoft.Json;
using RestAPI;
using System.Web;

namespace RestAPITest.ControllersTests
{
    public class WeatherForecastControllerTest : IClassFixture<RestAPIFactory>
    {
        private readonly HttpClient _client;
        public WeatherForecastControllerTest(RestAPIFactory factory)
        {
            _client = factory.HttpClient;
        }

        [Fact]
        public async Task Get_ShouldReturnForecasts()
        {
            var uriBuilder = new UriBuilder("https://localhost:7059/WeatherForecast");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = query.ToString();
            var requestUri = uriBuilder.ToString();
            var response = await _client.GetAsync(requestUri);

            var responseContent = await response.Content.ReadAsStringAsync();
            var forecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(responseContent);

            Assert.NotNull(forecasts);
            Assert.Equal(5, forecasts.Count);
            Assert.True(forecasts.All(f => f.Date != default));
            Assert.True(forecasts.All(f => f.TemperatureC >= -20 && f.TemperatureC <= 55));
        }

        [Fact]
        public async Task Get_ShouldReturnForecasts_WhenDataValid()
        {
            var uriBuilder = new UriBuilder("https://localhost:7059/WeatherForecast");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            uriBuilder.Query = query.ToString();
            var requestUri = uriBuilder.ToString();
            var response = await _client.GetAsync(requestUri);

            var responseContent = await response.Content.ReadAsStringAsync();
            var forecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(responseContent);

            Assert.NotNull(forecasts);
            Assert.Equal(5, forecasts.Count);
            Assert.True(forecasts.All(f => f.Date != default));
            Assert.True(forecasts.All(f => f.TemperatureC >= -20 && f.TemperatureC <= 55));
        }       
    }
}
