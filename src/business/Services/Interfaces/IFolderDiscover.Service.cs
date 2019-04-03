using Business.DB.Dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IFolderDiscoverService
    {
        Task<bool> Run(string path);

        Task<IEnumerable<Folder>> GetDiscoveringFolders();
    }
}
