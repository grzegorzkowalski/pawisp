using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

using WeatherKiota.Generated;

var auth = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(auth)
{
    BaseUrl = "https://localhost:7191"
};

// Utwórz klienta
var client = new WeatherClient(adapter);

var forecasts = await client.WeatherForecast.GetAsync();

foreach (var f in forecasts!)
{
    Console.WriteLine($"{f.Date}: {f.Summary} ({f.TemperatureC}°C)");
}

Console.ReadLine();