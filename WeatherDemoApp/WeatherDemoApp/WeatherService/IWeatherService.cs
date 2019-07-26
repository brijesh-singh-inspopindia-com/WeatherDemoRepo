
namespace WeatherDemoApp.WeatherService
{
    using System.Threading.Tasks;

    public interface IWeatherService
    {
        Task<string> GetWeatherByCityId(int cityId);

    }
}
