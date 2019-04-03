using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class TimeService : ITimeService
    {
        public DateTime CurrentTime => DateTime.UtcNow;
    }
}
