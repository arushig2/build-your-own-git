using System.Text;
using Git.Object;
namespace Git.Commands
{
    public class HashObjectCommand
    {
        private readonly ObjectDatabase objectDb = new ObjectDatabase();
        public void Execute(string[] args)
        {
            //validate
            if(args.Length != 2)
            {
                Console.WriteLine("Usage: mygit hash-object < file >");
                return;
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), args[1]);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{args[1]}' not found.");
                return;
            }

            byte[] content = File.ReadAllBytes(filePath);

            byte[] header = Encoding.UTF8.GetBytes($"blob {content.Length}\0");

            byte[] blob =header.Concat(content).ToArray();

            string hash = objectDb.StoreBlob(blob);

            Console.WriteLine(hash);

        }
    }
}
