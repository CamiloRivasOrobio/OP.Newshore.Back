using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Shared.Services;

namespace OP.Newshore.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenericClientHttpService, GenericClientHttpService>();
            services.AddTransient<ICurrencyConvertService, CurrencyConvertService>();
            services.AddTransient<IGetTravelRouteService, GetTravelRouteService>();
            services.AddTransient<ITravelRouteService, TravelRouteService>();
        }
    }
}
