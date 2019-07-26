
namespace WeatherDemoApp.Data.Repository
{
    using System.Collections.Generic;

    public interface ILocationRepository
    {
        Dictionary<int, string> GetAllLocation(string fileName);
    }
}
