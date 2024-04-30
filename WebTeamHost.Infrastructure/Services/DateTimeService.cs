using WebTeamHost.Application.Interfaces;

namespace WebTeamHost.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
