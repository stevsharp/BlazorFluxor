using BlazorFluxor.Shared;
using Fluxor;
using System.Net.Http.Json;

namespace BlazorFluxor.Client.State.Weather
{
    public class Effects
    {
        private readonly HttpClient Http;

        public Effects(HttpClient http)
        {
            Http = http;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dispatcher"></param>
        /// <returns></returns>
        [EffectMethod]
        public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
        {
            try
            {
                var forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");

                if (forecasts is not null)
                {
                    dispatcher.Dispatch(new FetchDataResultAction(forecasts: forecasts!));
                }
            }
            catch (Exception e)
            {
                var m = e.Message;

                throw;
            }
           
        }
    }
}
