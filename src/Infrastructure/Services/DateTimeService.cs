using newnew.Application.Common.Interfaces;

namespace newnew.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
