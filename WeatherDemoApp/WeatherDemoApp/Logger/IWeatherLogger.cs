

namespace WeatherDemoApp.Logger
{
    using System.Threading.Tasks;
    public interface IWeatherLogger
    {

        Task Log(string wetherData);
    }
}
