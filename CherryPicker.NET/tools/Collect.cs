using CherryPicker.NET.jsonserializer;
using CherryPicker.NET.repository;
using CherryPicker.NET.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Commit> commits = gitRepo.GetAllCommits(domains);
        string output = JsonListSerializer.Serialize(commits);
        Console.WriteLine($"json serialize output: {output}");
        OutputFile file = new OutputFile();
        file.Write(output);
    }
}
