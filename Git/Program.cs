using Git.Commands;
static void ShowHelp()
{
    Console.WriteLine("Build Your Own Git");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  mygit init");
    Console.WriteLine("  mygit hash-object");
    Console.WriteLine("  mygit cat-file");
    Console.WriteLine("  mygit add");
    Console.WriteLine("  mygit commit");
}

if (args.Length == 0)
{
    ShowHelp();
    return;
}

switch (args[0])
{
    case "init":
        new InitCommand().Execute();
        break;
    case "hash-object":
        new HashObjectCommand().Execute(args);
        break;
    case "add":
        new AddCommand().Execute(); 
        break;
    case "cat-file":
        new CatFileCommand().Execute(args);
        break;
    case "commit":
        new CommitCommand().Execute();
        break;
    default:
        Console.WriteLine("Unknown command.");
        break;
}