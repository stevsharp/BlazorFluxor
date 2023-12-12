using BlazorFluxor.Shared;

namespace BlazorFluxor.Client.State.Weather;

public class FetchDataResultAction
{
    public IEnumerable<WeatherForecast> Forecasts { get; }

    public FetchDataResultAction(IEnumerable<WeatherForecast> forecasts)
    {
        Forecasts = forecasts;
    }
}