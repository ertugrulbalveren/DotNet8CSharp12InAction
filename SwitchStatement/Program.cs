// See https://aka.ms/new-console-template for more information
Console.WriteLine(GetWeatherDescription(200));
Console.WriteLine(GetWeatherDescriptionCSharp12(200));

string GetWeatherDescription(int code)
{
    // Traditional switch statement
    switch (code)
    {
        case 200:
        case 201:
        case 202:
            return "Thunderstorm";
        case 300:
        case 301:
        case 302:
            return "Drizzle";
        case 500:
        case 501:
        case 502:
            return "Rain";
        default:
            return "Not a valid weather code";
    }
}


string GetWeatherDescriptionCSharp12(int code)
{
    // In C# 12, you can use switch expressions for a more compact and expressive form.
    // This also demonstrates the use of pattern matching with relational patterns and logical patterns.
    var description = code switch
    {
        >= 200 and < 300 => "Thunderstorm", // 'and' logical pattern with relational patterns
        >= 300 and < 400 => "Drizzle",
        >= 500 and < 600 => "Rain",
        _ => "Not a valid weather code" // '_' is the discard pattern, matching anything not already matched
    };

    return description;
}


string day = "Monday";

string dayType = day.ToLower() switch
{
    "monday" or "tuesday" or "wednesday" or "thursday" or "friday" => "Weekday",
    "saturday" or "sunday" => "Weekend",
    _ => "Unknown"
};

Console.WriteLine($"The type of day is: {dayType}");