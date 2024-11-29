using Microsoft.AspNetCore.Mvc;
using RestAPI.Database;
using RestAPI.Database.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {        
        private readonly MyDbContext _dbContext;

        public WeatherForecastController(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {            
            return _dbContext.WeatherForecast.ToList();
        }
    }
}
