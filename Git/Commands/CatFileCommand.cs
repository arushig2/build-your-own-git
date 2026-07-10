using Git.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Commands
{
    public class CatFileCommand
    {
        private readonly ObjectDatabase obj = new ObjectDatabase();
        public void Execute(string[] args)
        {
            if(args.Length != 3)
            {
                Console.WriteLine("Usage: mygit cat-file -p <hash>");
                return;
            }

            if (args[1] != "-p")
            {

                Console.WriteLine("Usage: mygit cat-file -p <hash>");
                return;
            }

            try
            {
                string content = obj.ReadObject(args[2]);
                Console.Write(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
