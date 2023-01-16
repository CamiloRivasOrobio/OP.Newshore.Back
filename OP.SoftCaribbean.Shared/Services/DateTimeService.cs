using OP.Newshore.Application.Interfaces;

namespace OP.Newshore.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.Now;
    }
}
