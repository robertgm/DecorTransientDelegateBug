using DecorTransientDelegateBug.BLL;
using Microsoft.AspNetCore.Mvc;

namespace DecorTransientDelegateBug.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Func<string, IServiceBLL> serviceBLL;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Func<string, IServiceBLL> serviceBLL)
        {
            _logger = logger;
            this.serviceBLL = serviceBLL;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                var serviceValueB = this.serviceBLL("countryA").GetValueB();
            }
            catch(Exception exp)
            {

            }
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
