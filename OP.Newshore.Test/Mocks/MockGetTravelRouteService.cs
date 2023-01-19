using Moq;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Interfaces;
using System.Threading;

namespace OP.Newshore.Test.Mocks
{
    public class MockGetTravelRouteService
    {
        public static Mock<IGetTravelRouteService> Get(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            var mockClient = new Mock<IGetTravelRouteService>();
            mockClient.Setup(r => r.Get(request, cancellationToken));

            return mockClient;
        }
    }
}
