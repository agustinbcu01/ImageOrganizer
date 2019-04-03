using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FileDiscoverService : IFileDiscoverService
    {
        private IGenerationService _generationService;

        public FileDiscoverService(IGenerationService generationService)
        {
            _generationService = generationService;
        }
        public  Task<bool> PrecessFile(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Run(string path)
        {
            var gerneration = await _generationService.GetCurrent();
          //  var file
            foreach (var fileInfo in Directory.EnumerateFileSystemEntries(path)) {

            }

            return true;
            
        }
    }
}
