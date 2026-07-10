using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Git.Object
{
    internal class ObjectDatabase
    {
        

        private string BuildPath(string hash)
        {
            string pathObj = Path.Combine(Directory.GetCurrentDirectory(), ".git", "objects");

            string hashDir = Path.Combine(pathObj, hash.Substring(0, 2));
            string objectPath = Path.Combine(hashDir, hash.Substring(2));

            return objectPath;

        }
        public string StoreBlob(byte[] blob)
        {
            byte[] hashBytes = SHA1.HashData(blob);
            string shaHex = Convert.ToHexString(hashBytes).ToLower();


           
            string objectPath = BuildPath(shaHex);

            if(File.Exists(objectPath))
            {
                return shaHex;

            }

            Directory.CreateDirectory(Path.GetDirectoryName(objectPath)!);
          
            byte[] compressedBlob;

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (DeflateStream deflateStream =
                       new DeflateStream(outputStream, CompressionLevel.Optimal))
                {
                    deflateStream.Write(blob, 0, blob.Length);
                }

                compressedBlob = outputStream.ToArray();
            }

            File.WriteAllBytes(objectPath, compressedBlob);

            return shaHex;

        }

        public string ReadObject(string hash)
        {
            string objectPath = BuildPath(hash);

            if (!File.Exists(objectPath))
            {
                throw new FileNotFoundException("Object not found.", objectPath);
            }

            byte[] compressedBytes = File.ReadAllBytes(objectPath);
            byte[] decompressedBlob;

            using (MemoryStream compressedStream = new MemoryStream(compressedBytes))
            {
                using (DeflateStream deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        deflateStream.CopyTo(resultStream);
                        decompressedBlob = resultStream.ToArray();
                    }

                }
            }

            string objectData = Encoding.UTF8.GetString(decompressedBlob);

            int separatorIndex = objectData.IndexOf('\0');

            if (separatorIndex == -1)
            {
                throw new InvalidDataException("Invalid Git object format.");
            }

            string content = objectData.Substring(separatorIndex + 1);


            return content;

        }
    }
}
