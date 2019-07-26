

namespace WeatherDemoApp
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WeatherDemoApp.Data.Repository;
    using WeatherDemoApp.Logger;
    using WeatherDemoApp.WeatherService;
    public class Startup
    {
       
        IServiceProvider ServiceProvider { get; }
        public Startup(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Configuration = configuration;
            ServiceProvider = serviceProvider;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILocationRepository, LocationRepository>();
            services.AddSingleton<IWeatherLogger, WeatherLogger>();           
            services.AddSingleton<IWeatherService, WeatherServiceApi>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();            
          
        }


    }
}
