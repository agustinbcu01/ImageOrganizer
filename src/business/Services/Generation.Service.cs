using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.DB;
using Business.DB.Dbo;
using Business.Services.Interfaces;

namespace Business.Services
{
    public class GenerationService : IGenerationService
    {
        private readonly ImageOrganizerContex _context;

        public GenerationService(ImageOrganizerContex context)
        {
            _context = context;
        }
        public Task<bool> AddArchive(Archive archive)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddFolder(Folder folder)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int generationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCurrent()
        {
            throw new NotImplementedException();
        }

        public Task<Generetion> GetCurrent()
        {
            throw new NotImplementedException();
        }

        public Task<EGenerationStatus> GetCurrentStatus()
        {
            throw new NotImplementedException();
        }
    }
}
