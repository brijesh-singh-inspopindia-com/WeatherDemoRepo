

namespace WeatherDemoApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using WeatherDemoApp.Data.Repository;
    using WeatherDemoApp.Logger;
    using WeatherDemoApp.WeatherService;

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private ILocationRepository _locationRepository;
        private IHostingEnvironment _hostingEnvironment;
        private IWeatherLogger _weatherLogger;
        private readonly List<string> _rootObjects;
        private readonly IWeatherService _weatherService;
        public WeatherController(ILocationRepository locationRepository, IHostingEnvironment hostingEnvironment, IWeatherService weatherService, IWeatherLogger weatherLogger)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository)); ;
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _weatherLogger= weatherLogger  ?? throw new ArgumentNullException(nameof(weatherLogger));
           _rootObjects = new List<string>();
         
        }
        // GET api/values
        [HttpGet()]
        public  async Task<ActionResult> GetAsync()
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "LocationList.txt");
            var list = _locationRepository.GetAllLocation(filePath);
            foreach(var city in list)
            {
                 var citydata= await _weatherService.GetWeatherByCityId(city.Key);
                _rootObjects.Add(citydata);

            }
            var result = JsonConvert.SerializeObject(_rootObjects);
            await _weatherLogger.Log(result);
            return Ok(result);
        }

        
       
    }
}
