using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IFileDiscoverService
    {
        Task<bool> Run(string path);
        Task<bool> PrecessFile(string path);
    }
}
