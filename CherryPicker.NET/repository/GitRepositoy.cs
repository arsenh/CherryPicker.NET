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

    public List<Commit> GetAllCommits(IEnumerable<string>? domains)
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
            if(IsCommitNeedToAdd(commit, domains))
                commits.Add(commit);
        });
        return commits;
    }

    private bool IsCommitNeedToAdd(Commit commit, IEnumerable<string>? domains)
    {
        string email = commit.Email;
        string[] parts = email.Split('@');
        string commitDomain = parts[1].Split('.')[0];
        if (domains == null || !domains.Any())
        {
            return true;
        }
        return !(null == domains.FirstOrDefault(domain => domain.Equals("all") || domain.Equals(commitDomain)));
    }
}