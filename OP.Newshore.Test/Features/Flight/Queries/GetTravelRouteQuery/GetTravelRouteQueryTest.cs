using Moq;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Test.Mocks;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OP.Newshore.Test.Features.Flight.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteQueryTest
    {
        private readonly GetTravelRouteQueryHandler _handler;
        private readonly IGetTravelRouteService _getTravelRoute;
        private readonly GetTravelRouteQueryValidator _getTravelRouteValidator;
        public GetTravelRouteQueryTest()
        {
            _getTravelRoute = new MockGetTravelRouteService();
            _handler = new GetTravelRouteQueryHandler(_getTravelRoute);
            _getTravelRouteValidator = new GetTravelRouteQueryValidator();
        }
        [Fact]
        public async Task GetTravelRouteTest_SucceededTrue()
        {
            //Arrange
            var filter = new GetTravelRouteParameters { Currency = "COP", Origin = "MZL", Destination = "MDE" };

            //Act
            var response = await _handler.Handle(new Application.Features.Flight.Queries.GetTravelRouteQuery.GetTravelRouteQuery()
            { Currency = filter.Currency, Origin = filter.Origin, Destination = filter.Destination }, CancellationToken.None);

            //Assert
            Assert.True(response.Succeeded == true);
        }

        [Fact]
        public async Task GetTravelRouteTest_SucceededFalse_QueryNotProcessed()
        {
            //Arrange
            var filter = new GetTravelRouteParameters { Currency = "COP", Origin = "MDE", Destination = "MDE" };

            //Act
            var response = await _handler.Handle(new Application.Features.Flight.Queries.GetTravelRouteQuery.GetTravelRouteQuery()
            { Currency = filter.Currency, Origin = filter.Origin, Destination = filter.Destination }, CancellationToken.None);

            //Assert
            Assert.True(response.Succeeded == false && response.Message == "Su consulta no pudo ser procesada.");
        }

        [Fact]
        public async Task GetTravelRouteTest_SameOriginAndDestination()
        {
            //Arrange
            var filter = new Application.Features.Flight.Queries.GetTravelRouteQuery.GetTravelRouteQuery { Currency = "COP", Origin = "MDE", Destination = "MDE" };

            //Act
            var response = _getTravelRouteValidator.Validate(filter);

            //Assert
            Assert.True(response.Errors[0].Severity == FluentValidation.Severity.Error && response.Errors[0].ErrorMessage == "El origen y el destino deben ser diferentes.");
        }
    }
}
