namespace OP.Newshore.Application.Features.Flight.Queries.GetTravelRouteQuery
{
    public class GetTravelRouteParameters
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Currency { get; set; } = "USD";
    }
}
