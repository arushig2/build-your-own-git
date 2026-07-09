using Git.Repository;

namespace Git.Commands;

public class InitCommand
{
    GitRepository _repository = new GitRepository();
    public void Execute()
    {
        string path = Directory.GetCurrentDirectory();
        try
        {
            _repository.Initialize(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        
        
    }
}