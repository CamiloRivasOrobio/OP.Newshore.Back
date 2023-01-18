using MediatR;
using Microsoft.Extensions.Configuration;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Exceptions;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Application.Utilities;
using OP.Newshore.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteQuery : IRequest<Response<JourneyDto>>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Currency { get; set; }
    }
    public class GetTravelRouteQueryHandler : IRequestHandler<GetTravelRouteQuery, Response<JourneyDto>>
    {
        private readonly IGenericClientHttp _genericlient;
        private readonly ICurrencyConvert _currencyConvert;

        public GetTravelRouteQueryHandler(IGenericClientHttp genericlient, ICurrencyConvert currencyConvert)
        {
            this._genericlient = genericlient;
            this._currencyConvert = currencyConvert;
        }
        public async Task<Response<JourneyDto>> Handle(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            if (request.Origin == request.Destination)
                throw new ApiException($"El origen y el destino deben ser diferentes.");

            CancellationTokenSource token = new();
            List<ResponseFlightsDto> ResponseFlightsDto = await this._genericlient.GetRequestAsync<List<ResponseFlightsDto>>("https://recruiting-api.newshore.es/api/flights/0", token, "");
            TravelRoute travelRoute = new TravelRoute(this._currencyConvert);
            var Flights = await travelRoute.GenerateFlightRoute(request.Origin, request.Destination,
                (request.Currency == null || request.Currency == "" ? "USD" : request.Currency), ResponseFlightsDto, token);
            JourneyDto journeyDto = new()
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Price = Flights.Select(s => s.Price).Sum(),
                Flights = Flights
            };
            return new Response<JourneyDto>()
            {
                Succeeded = Flights.Any() ? true : false,
                Message = Flights.Any() ? "Consulta procesada exitosamente." : "Su consulta no pudo ser procesada.",
                Journey = journeyDto
            };
        }
    }
}
