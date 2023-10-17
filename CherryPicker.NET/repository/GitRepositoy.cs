using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.repository;

public class GitRepositoy
{
    private readonly IRepository repository;
    public GitRepositoy(string path)
    {
        repository = new Repository(path);
    }

    public List<Commit> GetAllCommits()
    {
        List<Commit> commits = new List<Commit>();
        var filter = new CommitFilter()
        {
            SortBy = CommitSortStrategies.Reverse
        };
        var gitLog = repository.Commits.QueryBy(filter).ToList();
        gitLog.ToList().ForEach(c => {
            Commit commit = new() { 
                Hash = c.Sha.ToString(),
                Email = c.Author.Email.ToString(),
                Author = c.Author.Name.ToString(),
                Message = c.Message
            };
            commits.Add(commit);
        });
        return commits;
    }
}