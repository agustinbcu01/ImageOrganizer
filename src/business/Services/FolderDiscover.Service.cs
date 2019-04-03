using Business.DB.Dbo;
using Business.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FolderDiscoverService : IFolderDiscoverService
    {
        private readonly ICriptographicService _criptographicService;
        private readonly ILogger _logger;
        private readonly IGenerationService _generationService;

        public FolderDiscoverService(
            ICriptographicService criptographicService ,
            ILogger logger, 
            IGenerationService generationService)
        {
            _criptographicService = criptographicService;
            _logger = logger;
            _generationService = generationService;
        }
        public Task<IEnumerable<Folder>> GetDiscoveringFolders()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Run(string path)
        {
            var direcotry =  new DirectoryInfo(path);
            var dirData = string.Join("\r\n", direcotry.EnumerateFileSystemInfos().Select(e => $"{ e.Name}|{e.LastWriteTimeUtc.ToShortDateString()}-{e.LastWriteTimeUtc.ToShortTimeString()}"));
            var siganture = await _criptographicService.Hash(dirData, ECriptographicAlgorithms.sha512);
            _logger.LogInformation($"{siganture} => {path}");
            var currentGeneration = await _generationService.GetCurrent();
            var tasks = new List<Task<bool>>();

            if (!currentGeneration.Folders.Any(f=> f.Crc == siganture))
            {
                 
            }
            foreach(var folder in direcotry.GetDirectories())
            {
                tasks.Add(Run(Path.Combine(path, folder.Name)));
            }

            Task.WaitAll(tasks.ToArray());

            return !tasks.Any(t => t.Result == false);
               
        }
    }
}
