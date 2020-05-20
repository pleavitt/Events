using Dynamic.Application.Common.Interfaces;
using System;

namespace Dynamic.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
