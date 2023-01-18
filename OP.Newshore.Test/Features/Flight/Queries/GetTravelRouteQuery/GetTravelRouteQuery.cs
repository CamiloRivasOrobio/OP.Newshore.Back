using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Test.Mocks;
using System.Threading.Tasks;
using Xunit;

namespace OP.Newshore.Test.Features.Flight.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteQueryHandlerTest : ControllerBase
    {
        //private readonly IMapper _mapper;
        //private readonly Mock<IGenericClientHttp> _mockClient;
        //private readonly Mock<ICurrencyConvert> _mockCurrency;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        //public GetTravelRouteQueryHandlerTest(Mock<IGenericClientHttp> mockClient, Mock<ICurrencyConvert> mockCurrency)
        //{
        //    _mockClient = mockClient;
        //    _mockCurrency = mockCurrency;
        //}

        [Fact]
        public async Task GetTravelRouteTest_ReturnOk()
        {
            var filter = new GetTravelRouteParameters() { Origin = "MZL", Destination = "BCN", Currency = "USD" };


            var result = await Mediator.Send(new Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery.GetTravelRouteQuery
            {
                Origin = filter.Origin,
                Destination = filter.Destination,
                Currency = filter.Currency
            });

            Assert.Equal(result.Succeeded, true);

        }
    }
}
