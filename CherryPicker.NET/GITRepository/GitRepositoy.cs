using CherryPicker.NET.Messages;
using CherryPicker.NET.Utilities;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.GITRepository;

public class GitRepositoy
{
    private readonly Repository repository;
    private readonly string repoPath;
    public GitRepositoy(string path)
    {
        repository = new Repository(path);
        repoPath = path;
    }

    public List<Commit> GetAllCommits(IEnumerable<string>? domains)
    {
        List<Commit> commits = new List<Commit>();
        var filter = new CommitFilter()
        {
            SortBy = CommitSortStrategies.Reverse
        };
        var gitLog = repository.Commits.QueryBy(filter).ToList();
        gitLog.ToList().ForEach(c =>
        {
            Commit commit = new()
            {
                Hash = c.Sha.ToString(),
                Email = c.Author.Email.ToString(),
                Author = c.Author.Name.ToString(),
                Message = c.Message
            };
            if (IsCommitNeedToAdd(commit, domains))
                commits.Add(commit);
        });
        return commits;
    }

    public string GetCommitChanges(Commit commit)
    {
        string workingDir = Path.GetFullPath(repoPath);
        return Platform.RunExternalCommand(commit.Hash, workingDir);
    }

    public bool PerformCherryPick(Commit commit)
    {
        LibGit2Sharp.Commit commitToCherryPick = repository.Lookup<LibGit2Sharp.Commit>(commit.Hash);
        var result = repository.CherryPick(commitToCherryPick, commitToCherryPick.Committer);
        return result.Status == CherryPickStatus.CherryPicked;
    }

    public void PerformCherryPickAbort(Commit commit)
    {
        repository.Reset(ResetMode.Hard, repository.Head.Tip);
    }

    public void PerformCherryPickContinue(Commit commit)
    {
        LibGit2Sharp.Commit commitToCherryPick = repository.Lookup<LibGit2Sharp.Commit>(commit.Hash);
        Commands.Stage(repository, "*");
        repository.Commit(commitToCherryPick.Message, commitToCherryPick.Committer, commitToCherryPick.Committer,
                                                    new CommitOptions() { AllowEmptyCommit = true });
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