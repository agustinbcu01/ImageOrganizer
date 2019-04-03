using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SyncService : ISyncService
    {
        public Task StartAsync()
        {
            return Task.CompletedTask;
        }
    }
}
