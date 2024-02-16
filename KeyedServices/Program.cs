//Microsoft documentation: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0#keyed-services

using KeyedServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var apiKey = builder.Configuration["OpenWeatherMapApiKey"];

builder.Services.AddKeyedSingleton<IWeatherService>(
    "realweather",
    (sp, key) => new OpenWeatherMapService(
        sp.GetRequiredService<IHttpClientFactory>(),
        apiKey // Assuming apiKey is a string containing your API key
    )
);

builder.Services.AddKeyedSingleton<IWeatherService>(
    "dummyweather",
    (sp, key) => new DummyWeatherService() 
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
