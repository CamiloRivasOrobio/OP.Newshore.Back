using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Test.Mocks;

namespace OP.Newshore.Test
{
    public class ApiWebApplicationFactory : WebApplicationFactory<OP.Newshore.WebAPI.Program>
    {
        public IConfiguration Configuration { get; private set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureAppConfiguration(config =>
                {
                    Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.UnitTest.json", false, false)
                    .Build();
                    config.AddConfiguration(Configuration);
                })
                .UseEnvironment("UnitTest")
                .ConfigureTestServices(services =>
                {
                    services.Replace(ServiceDescriptor.Scoped<IGetTravelRouteService, MockGetTravelRouteService>());
                });

        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder
                .UseEnvironment("UnitTest")
                .ConfigureServices(services =>
                {
                    services.Replace(ServiceDescriptor.Singleton<IGetTravelRouteService, MockGetTravelRouteService>());
                });

            return base.CreateHost(builder);
        }



    }
}
