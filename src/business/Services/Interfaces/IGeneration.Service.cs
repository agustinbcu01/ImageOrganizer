using Business.DB.Dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IGenerationService
    {
        Task<Generetion> GetCurrent();
        Task<EGenerationStatus> GetCurrentStatus();

        Task<bool> AddFolder(Folder folder);
        Task<bool> AddArchive(Archive archive);

        Task<bool> DeleteCurrent();
        Task<bool> DeleteById(int generationId);
    }
}
