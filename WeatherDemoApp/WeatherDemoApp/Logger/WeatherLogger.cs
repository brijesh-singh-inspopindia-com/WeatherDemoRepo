

namespace WeatherDemoApp.Logger
{
    using Microsoft.AspNetCore.Hosting;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    public class WeatherLogger : IWeatherLogger
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public WeatherLogger(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task Log(string wetherData)
        {
            try
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, $"Output\\Weather{DateTime.Now.ToString("ddMMyyyy")}.json");
                var fileInfo = new FileInfo(filePath);
                if (!fileInfo.Exists)
                {
                    File.WriteAllText(filePath, wetherData);
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
