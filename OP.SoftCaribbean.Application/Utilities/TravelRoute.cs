using OP.Newshore.Application.DTOs;
using OP.Newshore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Utilities
{
    public class TravelRoute
    {
        public List<Fligth> GenerateFlightRoute(string Origin, string Destination, List<ResponseFligthsDto> fligths)
        {
            List<ResponseFligthsDto> fligthsRoute = new();
            fligthsRoute = fligths.Where(f => f.DepartureStation == Origin && f.ArrivalStation == Destination).ToList();
            if (!fligthsRoute.Any())
            {
                List<ResponseFligthsDto> fligthsRouteOrigin = fligths.Where(f => f.DepartureStation == Origin).ToList();
                List<ResponseFligthsDto> fligthsRouteDestination = fligths.Where(f => f.ArrivalStation == Destination).ToList();
                foreach (var itemOrigin in fligthsRouteOrigin)
                    foreach (var itemDestination in fligthsRouteDestination)
                        if (itemOrigin.ArrivalStation == itemDestination.DepartureStation)
                        {
                            fligthsRoute.Add(itemOrigin);
                            fligthsRoute.Add(itemDestination);
                        }
            }
            List<Domain.Entities.Fligth> fligth = new();
            foreach (var item in fligthsRoute)
            {
                Domain.Entities.Fligth fli = new()
                {
                    Origin = item.DepartureStation,
                    Destination = item.ArrivalStation,
                    Price = item.Price,
                    Transport = new Domain.Entities.Transport() { FlightCarrier = item.FlightCarrier, FlightNumber = item.FlightNumber }
                };
                fligth.Add(fli);
            }
            return fligth;
        }
    }
}
