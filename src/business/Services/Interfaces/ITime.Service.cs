using System;

namespace Business.Services.Interfaces
{
    public interface ITimeService
    {
        DateTime CurrentTime { get; }
    }
}