using OP.Newshore.Application.DTOs;
using OP.Newshore.Domain.Entities;

namespace OP.Newshore.Application.Interfaces
{
    public interface ITravelRouteService
    {
        Task<List<Flight>> GenerateFlightRoute(string Origin, string Destination, string currency, List<ResponseFlightsDto> Flights,
            CancellationToken cancellationToken);
    }
}
