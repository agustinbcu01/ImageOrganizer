using Business.DB;
using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DiscoverServices : IDiscoverService
    {
        private readonly ImageOrganizerContex _contex;
        private readonly IFileDiscoverService _fileDiscoverService;
        private readonly IFolderDiscoverService _folderDiscoverService;
        private readonly IGenerationService _generationService;
        private readonly IConfigurtationService _configurtationService;

        public DiscoverServices(ImageOrganizerContex contex,
            IFileDiscoverService fileDiscoverService,
            IFolderDiscoverService folderDiscoverService,
            IGenerationService generationService,
            IConfigurtationService configurtationService)
        {
            _contex = contex;
            _fileDiscoverService = fileDiscoverService;
            _folderDiscoverService = folderDiscoverService;
            _generationService = generationService;
            _configurtationService = configurtationService;
        }

        public async Task StartAsync()
        {
            var filesTasks = new List<Task<bool>>();
            var dropLocation = (await _contex.Configurations.FindAsync(DB.Dbo.EConfigurationKey.dropLocation))?.Value;
            var rootPath = (await _contex.Configurations.FindAsync(DB.Dbo.EConfigurationKey.rootPath))?.Value;
            //  var root = _contex.Configurations.Where(c => c.Id == DB.Dbo.EConfigurationKey.rootPath);
            Task<bool> folderTaks = null;
            List<Task<bool>> fileTask = new List<Task<bool>>();
            if (!string.IsNullOrEmpty(dropLocation))
            {
                folderTaks = _folderDiscoverService.Run(dropLocation);
            }
            var generationStatus = DB.Dbo.EGenerationStatus.Discovering;
            do
            {
                var dicoveringFolders = await _folderDiscoverService.GetDiscoveringFolders();
                foreach (var folder in dicoveringFolders)
                {
                    filesTasks.Add(_fileDiscoverService.Run(Path.Combine(dropLocation, folder.Path, folder.Name)));
                }

                generationStatus = await _generationService.GetCurrentStatus();
            } while (generationStatus == DB.Dbo.EGenerationStatus.Discovering);

        }
    }
}
