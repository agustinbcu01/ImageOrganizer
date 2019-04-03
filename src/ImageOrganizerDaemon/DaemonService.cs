using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ImageOrganizerDaemon
{
    public class DaemonService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IOptions<DaemonConfig> _config;
        private Task _runnigTask;
      //  private bool _runnig = true;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private IDiscoverService _discoveryService;
        private readonly ISyncService _syncService;

        public DaemonService(
            ILogger<DaemonService> logger, 
            IOptions<DaemonConfig> config,
            IDiscoverService discoveryService,
            ISyncService syncService)
        {
            _logger = logger;
            _config = config;
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _discoveryService = discoveryService;
            _syncService = syncService;
        }

        public  void DoWork() {
            var cancelationWaitource = new CancellationTokenSource();
            while (!_cancellationToken.IsCancellationRequested) {
                
                try
                {
                    var dicoveryTask = _discoveryService.StartAsync();
                    var syncTask = _syncService.StartAsync();
                    Task.WaitAll(dicoveryTask, syncTask);
                }
                catch (Exception) {
                    break;// _cancellationTokenSource.Cancel();
                }
            }
            _logger.LogInformation("Do Work Ends");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting daemon: " + _config.Value.DaemonName);
            _runnigTask = Task.Run(()=> { DoWork(); }, _cancellationToken);
           // _runnigTask.

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping daemon.");
          //  _runnigTask.ter


            _cancellationTokenSource.Cancel();
            _runnigTask.Wait();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing....");

        }
    }
}
