using WebTeamHost.App.Interfaces;

namespace WebTeamHost.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
