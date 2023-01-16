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

namespace OP.Newshore.Application.Features.Fligth.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteQuery : IRequest<Response<JourneyDto>>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Currency { get; set; } = "USD";
    }
    public class GetTravelRouteQueryHandler : IRequestHandler<GetTravelRouteQuery, Response<JourneyDto>>
    {
        private readonly IGenericClientHttp _genericlient;
        private string NewshoreRecruiting { get; set; }
        public GetTravelRouteQueryHandler(IGenericClientHttp genericlient, IConfiguration configuration)
        {
            this._genericlient = genericlient;
            this.NewshoreRecruiting = configuration.GetSection("ServicesUrls:NewshoreRecruiting").Value;
        }
        public async Task<Response<JourneyDto>> Handle(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            if (request.Origin == request.Destination)
                throw new ApiException($"El origen y el destino deben ser diferentes.");

            CancellationTokenSource token = new();
            List<ResponseFligthsDto> ResponseFligthsDto = await this._genericlient.GetRequestAsync<List<ResponseFligthsDto>>("https://recruiting-api.newshore.es/api/flights/0", token, "");
            TravelRoute travelRoute = new();
            var fligths = travelRoute.GenerateFlightRoute(request.Origin, request.Destination, ResponseFligthsDto);
            JourneyDto journeyDto = new()
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Price = fligths.Select(s => s.Price).Sum(),
                Fligths = fligths
            };
            return new Response<JourneyDto>()
            {
                Succeeded = fligths.Any() ? true : false,
                Message = fligths.Any() ? "Consulta procesada exitosamente." : "Su consulta no pudo ser procesada.",
                Journey = journeyDto
            };
        }
    }
}
