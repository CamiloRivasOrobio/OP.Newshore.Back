using Moq;
using OP.Newshore.Application.DTOs;
using OP.Newshore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OP.Newshore.Test.Mocks
{
    public class MockGenericClientHttp
    {
        public static Mock<IGenericClientHttp> GetRequestAsync(string url, CancellationTokenSource cancellationToken,
            string jwtToken, string? keyValue = null, string? keyName = null)
        {

            var mockClient = new Mock<IGenericClientHttp>();
            mockClient.Setup(r => r.GetRequestAsync<JourneyDto>(url, cancellationToken, jwtToken, keyValue, keyName));

            return mockClient;
        }
    }
}
