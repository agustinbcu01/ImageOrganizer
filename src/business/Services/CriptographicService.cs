using Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CriptographicService : ICriptographicService
    {
        public Task<string> Hash(string data, ECriptographicAlgorithms algorithm = ECriptographicAlgorithms.sha512)
        {
            return Hash(new MemoryStream(Encoding.UTF32.GetBytes(data)));
        }

        public Task<string> Hash(byte[] data, ECriptographicAlgorithms algorithm = ECriptographicAlgorithms.sha512)
        {
            return Hash(new MemoryStream(data));
        }

        public Task<string> Hash(Stream data, ECriptographicAlgorithms algorithm = ECriptographicAlgorithms.sha512)
        {
            return Task.Run(() =>
            {
                switch (algorithm)
                {
                    case ECriptographicAlgorithms.md5:
                        // Compute the MD5 hash of the fileStream.
                        return BytesToHexString(MD5.Create().ComputeHash(data));

                    case ECriptographicAlgorithms.sha1:
                        // Compute the SHA1 hash of the fileStream.
                        return BytesToHexString(SHA1.Create().ComputeHash(data));

                    case ECriptographicAlgorithms.sha2:
                        // Compute the SHA256 hash of the fileStream.
                        return BytesToHexString(SHA256.Create().ComputeHash(data));

                    case ECriptographicAlgorithms.sha384:
                        // Compute the SHA384 hash of the fileStream.
                        return BytesToHexString(SHA384.Create().ComputeHash(data));

                    case ECriptographicAlgorithms.sha512:
                        // Compute the SHA512 hash of the fileStream.
                        return BytesToHexString(SHA512.Create().ComputeHash(data));

                    case ECriptographicAlgorithms.base64:
                        // Compute the BASE64 hash of the fileStream.
                        byte[] binaryData = new Byte[data.Length];
                        long bytesRead = data.Read(binaryData, 0, (int)data.Length);
                        if (bytesRead != data.Length)
                        {
                            throw new Exception(String.Format("Number of bytes read ({0}) does not match file size ({1}).", bytesRead, data.Length));
                        }
                        return System.Convert.ToBase64String(binaryData, 0, binaryData.Length);

                    default:
                        // Display the help message if an unrecognized hash algorithm was specified.
                        throw new ArgumentException("No valid algirith provided", nameof(algorithm));
                }
            });
        }

        public async Task<string> HashFile(string path, ECriptographicAlgorithms algorithm = ECriptographicAlgorithms.sha512)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                fileStream.Position = 0;
                return await Hash(fileStream, algorithm);
            }

        }

        public string BytesToHexString(byte[] data)
        {
            StringBuilder strBuilder = new StringBuilder();
            if ((data?.Length ?? 0) > 0)
            {
                foreach (var value in data)
                {
                    strBuilder.Append(string.Format("{0:X2}", value));
                }
            }

            return strBuilder.ToString();
        }

    }
}
