using System.IO.Compression;
using System.Security.Cryptography;

namespace Git.Object
{
    internal class ObjectDatabase
    {
        string pathObj = Path.Combine(Directory.GetCurrentDirectory(), ".git", "objects");
        public string StoreBlob(byte[] blob)
        {
            byte[] hashBytes = SHA1.HashData(blob);
            string shaHex = Convert.ToHexString(hashBytes).ToLower();

            string hashDir = Path.Combine(pathObj, shaHex.Substring(0, 2));
            string objectPath = Path.Combine(hashDir, shaHex.Substring(2));

            if (File.Exists(objectPath))
            {
                return shaHex;
            }

            Directory.CreateDirectory(hashDir);

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
    }
}
