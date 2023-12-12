using BlazorFluxor.Shared;
using Fluxor;

namespace BlazorFluxor.Client.State.Weather;

[FeatureState]
public class WeatherState
{
    public bool IsLoading { get; }
    public IEnumerable<WeatherForecast> Forecasts { get; }
    public WeatherState() { }

    public WeatherState(bool isLoading, IEnumerable<WeatherForecast> forecasts)
    {
        IsLoading = isLoading;

        Forecasts = forecasts;
    }
}