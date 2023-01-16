using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Features.Fligth.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteParameters
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Currency { get; set; } = "USD";
    }
}
