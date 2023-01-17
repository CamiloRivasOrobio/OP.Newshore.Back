using AutoMapper;
using FakeItEasy;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.WebAPI.Controllers.v1;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OP.Newshore.Test.Controller.v1
{
    public class FlightControllerTests
    {
        private readonly IRepositoryAsync<Domain.Entities.Flight> _repositoryAsync;
        private readonly IMapper _mapper;

        public FlightControllerTests()
        {
            _repositoryAsync = A.Fake<IRepositoryAsync<Domain.Entities.Flight>>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async void DataMaestraController_GetDataMaestra_ReturnOk()
        {
            //Arrange
            //var dataMaestra = A.Fake<ICollection<DataMaestraDto>>();
            //var dataMaestraList = A.Fake<List<DataMaestraDto>>();
            //A.CallTo(() => _mapper.Map<List<DataMaestraDto>>(dataMaestra)).Returns(dataMaestraList);
            //var controller = new DataMaestraController();
            //var getParameters = new GetAllDataMasterParameters() { PageNumber = 1, PageSize = 10 };

            //Act
            //var result = await controller.Get(getParameters);

            //Assert
            //result;
        }
    }
}
