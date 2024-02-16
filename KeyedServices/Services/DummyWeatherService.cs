using KeyedServices.Models;

namespace KeyedServices.Services;

public class DummyWeatherService : IWeatherService
{
    private readonly Random _random = new Random();

    public Task<WeatherResponse> GetCurrentWeatherAsync(string location)
    {
        // Return random weather data for the sake of example
        var weatherResponse = new WeatherResponse
        {
            Temperature = _random.Next(-20, 40), // Random temperature between -20 and 40 degrees Celsius
            FeelsLike = _random.Next(-20, 40), // Random 'feels like' temperature
            Location = _random.Next(0, 2) == 0 ? "Hamburg" : "Berlin" // Random location
        };

        return Task.FromResult(weatherResponse);
    }
}
