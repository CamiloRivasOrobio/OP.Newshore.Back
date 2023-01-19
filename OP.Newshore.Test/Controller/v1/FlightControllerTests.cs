
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Domain.Entities;
using OP.Newshore.WebAPI.Controllers.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OP.Newshore.Test.Controller.v1
{
    public class FlightControllerTests
    {
        private readonly IRepositoryAsyncService<Journey> _journeyRepository;
        private readonly IMediator _mediator;
        public FlightControllerTests(IMediator mediator)
        {
            _journeyRepository = A.Fake<IRepositoryAsyncService<Journey>>();
            _mediator = mediator;
        }

        [Fact]
        public async Task PokemonController_GetPokemons_ReturnOK()
        {
            //Arrange
            var controller = new FlightController();
            var filter = new GetTravelRouteParameters() { Origin = "MZL", Destination = "BCN", Currency = "USD" };

            //Act
            var result = await controller.Get(filter);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}