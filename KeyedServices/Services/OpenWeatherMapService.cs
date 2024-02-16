using KeyedServices.Models;
using System.Text.Json;

namespace KeyedServices.Services;


public class OpenWeatherMapService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;

    public OpenWeatherMapService(IHttpClientFactory httpClientFactory, string apiKey)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = apiKey;
    }

    public async Task<WeatherResponse> GetCurrentWeatherAsync(string location)
    {
        var client = _httpClientFactory.CreateClient();
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={_apiKey}&units=metric";

        var weatherResponse = await client.GetAsync(url);

        if (!weatherResponse.IsSuccessStatusCode)
        {
            return null;
        }

        var weatherData = await weatherResponse.Content.ReadFromJsonAsync<WeatherApiData>();

        return new WeatherResponse
        {
            Temperature = weatherData.Main.Temp,
            FeelsLike = weatherData.Main.FeelsLike,
            Location = weatherData.Name
        };
    }
}
