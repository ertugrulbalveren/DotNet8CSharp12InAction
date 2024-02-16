using KeyedServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyedServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(
           [FromKeyedServices("dummyweather")] IWeatherService weatherService,
           string city)
        {
            var weather = await weatherService.GetCurrentWeatherAsync(city);
            return weather != null ? Ok(weather) : NotFound();
        }
    }
}
