using KeyedServices.Models;

namespace KeyedServices.Services;

public interface IWeatherService
{
    Task<WeatherResponse> GetCurrentWeatherAsync(string location);
}
