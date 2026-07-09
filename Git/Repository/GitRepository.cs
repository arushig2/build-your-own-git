using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Repository
{
    internal class GitRepository
    {
       
        public void Initialize(string repositoryPath)
        {
            string gitPath = Path.Combine(repositoryPath, ".git");
            if (Directory.Exists(gitPath))
            {
                Console.WriteLine($"Reinitialized existing Git repository in {repositoryPath}");
            } else
            {
                Console.WriteLine($"Initialized empty Git repository in {repositoryPath}");
            }
            CreateDirectoryStructure(gitPath);
            CreateHeadFile(gitPath);
            CreateConfigFile(gitPath);
        }

        private void CreateDirectoryStructure(string gitPath)
        {
            string objDir = Path.Combine(gitPath, "objects");
            string headDir = Path.Combine(gitPath, "refs", "heads");
            Directory.CreateDirectory(gitPath);
            Directory.CreateDirectory(objDir);
            Directory.CreateDirectory(headDir);   
        }

        private void CreateHeadFile(string gitPath)
        {
            string headPath = Path.Combine(gitPath, "HEAD");
            string content = "ref: refs/heads/main";
            File.WriteAllText(headPath, content);
        }

        private void CreateConfigFile(string gitPath)
        {
            string configPath = Path.Combine(gitPath, "config");
            string content = "[core]\r\n    repositoryformatversion = 0";
            File.WriteAllText(configPath, content);
        }
    }

}
