using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public enum ECriptographicAlgorithms { md5, sha1, sha2, sha512, sha384, base64  }
    public interface ICriptographicService
    {
        Task<string> HashFile(string path, ECriptographicAlgorithms algorithm);

        Task<string> Hash(string data, ECriptographicAlgorithms algorithm);

        Task<string> Hash(byte[] data, ECriptographicAlgorithms algorithm);

        Task<string> Hash(Stream data, ECriptographicAlgorithms algorithm);
    }
}
