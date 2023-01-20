using Moq;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OP.Newshore.Test.Mocks
{
    public class MockGetTravelRouteService : IGetTravelRouteService
    {
        public Task<JourneyDto> Get(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            var responseFalse = new JourneyDto() { Origin = request.Origin, Destination = request.Destination, Flights = new List<Flight>() };
            var journeyDto = new List<JourneyDto>()
            {
                new JourneyDto()
                {
                    Origin = "MZL",
                    Destination = "MDE",
                    Price = 200,
                    Flights = new List<Flight>()
                    {
                        new Flight() { Origin = "MZL", Destination = "MDE", Price = 200,
                            Transport = new Transport() { FlightCarrier = "CO", FlightNumber = "8001" }
                        }
                    }
                },
                new JourneyDto() {
                    Origin = "MZL",
                    Destination = "BCN",
                    Price = 200,
                    Flights = new List<Flight>()
                    {
                        new Flight() { Origin = "MZL", Destination = "MDE", Price = 200,
                            Transport = new Transport() { FlightCarrier = "CO", FlightNumber = "8001" }
                        },
                        new Flight() { Origin = "MDE", Destination = "BCN", Price = 500,
                            Transport = new Transport() { FlightCarrier = "CO", FlightNumber = "8004" }
                        }
                    }
                },
                new JourneyDto()
                {
                    Origin = "CTG",
                    Destination = "CAN",
                    Price = 200,
                    Flights = new List<Flight>()
                    {
                        new Flight() { Origin = "CTG", Destination = "CAN", Price = 300,
                            Transport = new Transport() { FlightCarrier = "CO", FlightNumber = "8005" }
                        }
                    }
                }
            };
            var response = journeyDto.Find(e => e.Origin == request.Origin && e.Destination == request.Destination);
            return Task.FromResult(response == null ? responseFalse : response);
        }
    }
}
