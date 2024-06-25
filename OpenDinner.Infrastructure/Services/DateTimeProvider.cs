using OpenDinner.Application.Common.Interfaces.Services;

namespace OpenDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}