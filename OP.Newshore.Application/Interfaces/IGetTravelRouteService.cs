using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Wrappers;

namespace OP.Newshore.Application.Interfaces
{
    public interface IGetTravelRouteService
    {
        Task<JourneyDto> Get(GetTravelRouteQuery request, CancellationToken cancellationToken);
    }
}
