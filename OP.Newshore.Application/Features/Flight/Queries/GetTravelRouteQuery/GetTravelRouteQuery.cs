using MediatR;
using Microsoft.Extensions.Configuration;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Exceptions;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Application.Wrappers;
using OP.Newshore.Domain.Entities;
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
        private readonly IGetTravelRouteService _getTravelRoute;

        public GetTravelRouteQueryHandler(IGetTravelRouteService getTravelRoute)
        {
            this._getTravelRoute = getTravelRoute;
        }
        public async Task<Response<JourneyDto>> Handle(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            var journeyDto = await this._getTravelRoute.Get(request, cancellationToken);
            var prueba = new Response<JourneyDto>()
            {
                Succeeded = journeyDto.Flights.Any() ? true : false,
                Message = journeyDto.Flights.Any() ? "Consulta procesada exitosamente." : "Su consulta no pudo ser procesada.",
                Journey = journeyDto
            };
            return prueba;
        }
    }
}
