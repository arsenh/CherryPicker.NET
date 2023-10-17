using CherryPicker.NET.jsonserializer;
using CherryPicker.NET.messages;
using CherryPicker.NET.repository;
using CherryPicker.NET.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.collector;

public class Collect
{
    private IEnumerable<string>? domains;
    private GitRepositoy gitRepo;

    public Collect(IEnumerable<string>? domains, string? repoPath)
    {
        this.domains = domains;
        this.gitRepo = new GitRepositoy(repoPath!);
    }

    public void Process()
    {
        Console.WriteLine("Selected 'collect' mode.");
        List<Commit> commits = gitRepo.GetAllCommits(domains);
        string output = JsonListSerializer.Serialize(commits);
        OutputFile file = new OutputFile();
        file.Write(output);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(String.Format(UserMessages.JsonFileIsCreated, file.Name));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(UserMessages.UseCherryPick);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
