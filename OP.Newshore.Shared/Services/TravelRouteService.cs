using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Domain.Entities;

namespace OP.Newshore.Shared.Services
{
    public class TravelRouteService : ITravelRouteService
    {
        private readonly ICurrencyConvertService _currencyConvert;
        public TravelRouteService(ICurrencyConvertService currencyConvert)
        {
            this._currencyConvert = currencyConvert;
        }
        public async Task<List<Flight>> GenerateFlightRoute(string Origin, string Destination, string currency,
            List<ResponseFlightsDto> Flights, CancellationToken cancellationToken)
        {
            List<ResponseFlightsDto> FlightsRoute = new();
            FlightsRoute = Flights.Where(f => f.DepartureStation == Origin && f.ArrivalStation == Destination).ToList();
            if (!FlightsRoute.Any())
            {
                List<ResponseFlightsDto> FlightsRouteOrigin = Flights.Where(f => f.DepartureStation == Origin).ToList();
                List<ResponseFlightsDto> FlightsRouteDestination = Flights.Where(f => f.ArrivalStation == Destination).ToList();
                foreach (var itemOrigin in FlightsRouteOrigin)
                    foreach (var itemDestination in FlightsRouteDestination)
                        if (itemOrigin.ArrivalStation == itemDestination.DepartureStation)
                        {
                            FlightsRoute.Add(itemOrigin);
                            FlightsRoute.Add(itemDestination);
                        }
            }
            List<Domain.Entities.Flight> Flight = new();
            foreach (var item in FlightsRoute)
            {
                Domain.Entities.Flight fli = new()
                {
                    Origin = item.DepartureStation,
                    Destination = item.ArrivalStation,
                    //Price = await this._currencyConvert.ChangeCurrency(currency, item.Price, cancellationToken, ""),
                    Price = item.Price,
                    Transport = new Domain.Entities.Transport() { FlightCarrier = item.FlightCarrier, FlightNumber = item.FlightNumber }
                };
                Flight.Add(fli);
            }
            return Flight;
        }
    }
}
