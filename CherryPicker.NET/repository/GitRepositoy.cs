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
        List<Commit> commits = new();
        IQueryableCommitLog gitLog = repository!.Commits;
        gitLog.ToList().ForEach(c => {
            Commit commit = new Commit();
            commit.hash = c.Sha.ToString();
            commit.email = c.Author.Email.ToString();
            commit.author = c.Author.Name.ToString();
            commit.message = c.Message;
            commits.Add(commit);
        });
        return commits;
    }
}