

namespace WeatherDemoApp.Data.Repository
{
    using Microsoft.AspNetCore.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LocationRepository : ILocationRepository
    {
        private readonly Dictionary<int, string> _locationList;
      
        public LocationRepository(IHostingEnvironment hostingEnvironment)
        {
            _locationList = new Dictionary<int, string>();
          
        }

        public Dictionary<int, string> GetAllLocation(string fileName)
        {
            // We can use cache to store data 
            if (!_locationList.Any())
            {
               
                string line = string.Empty;
                using (var file = new System.IO.StreamReader(fileName))
                {
                    try
                    {
                        while (!string.IsNullOrEmpty(line = file.ReadLine()))
                        {
                            var locationValue = line.Split('=');
                            _locationList.Add(Convert.ToInt32(locationValue[0]), Convert.ToString(locationValue[1]));

                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }

                }
            }
            return _locationList;
        }
    }
}
