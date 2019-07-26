

namespace WeatherDemoApp.WeatherService
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class WeatherServiceApi : IWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _apiUrl;
        /// <summary>
        /// WeatherServiceApi
        /// </summary>
        /// <param name="configuration"></param>
        public WeatherServiceApi(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration.GetSection("WeatherApi").GetValue<string>("API_KEY");
            _apiUrl = _configuration.GetSection("WeatherApi").GetValue<string>("API_URL");
        }

        /// <summary>
        /// GetWeatherByCityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<string> GetWeatherByCityId(int cityId)
        {

            try
            {
                using (var _httpClient = new HttpClient())
                {

                    _httpClient.BaseAddress = new Uri(_apiUrl);
                    var response = await _httpClient.GetAsync($"/data/2.5/weather?id={cityId}&appid={_apiKey}");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    return stringResult;
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                throw new Exception($"Error getting weather from OpenWeather: {httpRequestException.Message}");
            }

        }
    }
}
