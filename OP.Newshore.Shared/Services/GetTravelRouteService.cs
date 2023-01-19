using Microsoft.Extensions.Configuration;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Exceptions;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Application.Wrappers;

namespace OP.Newshore.Shared.Services
{
    public class GetTravelRouteService : IGetTravelRouteService
    {
        private readonly IGenericClientHttpService _genericlient;
        private readonly ITravelRouteService _travelRoute;
        public IConfiguration _configuration { get; set; }

        public GetTravelRouteService(IGenericClientHttpService genericlient, ITravelRouteService travelRoute, IConfiguration configuration)
        {
            this._genericlient = genericlient;
            this._travelRoute = travelRoute;
            this._configuration = configuration;
        }
        public async Task<JourneyDto> Get(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            List<ResponseFlightsDto> ResponseFlightsDto = await this._genericlient.GetRequestAsync<List<ResponseFlightsDto>>(
                this._configuration["ServiceUrls:NewshoreRecruiting"], cancellationToken, string.Empty);
            var Flights = await this._travelRoute.GenerateFlightRoute(request.Origin, request.Destination,
                request.Currency, ResponseFlightsDto, cancellationToken);

            return new JourneyDto()
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Price = Flights.Select(s => s.Price).Sum(),
                Flights = Flights
            };
        }
    }
}
