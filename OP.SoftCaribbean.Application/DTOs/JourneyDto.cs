using OP.Newshore.Domain.Entities;

namespace OP.Newshore.Application.DTOs
{
    public class JourneyDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
