using CherryPicker.NET.Utilities;
using CherryPicker.NET.Messages;
using CherryPicker.NET.GITRepository;
using CherryPicker.NET.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.Tools;

public class CherryPick
{
    private string jsonFilePath;
    private GitRepositoy gitRepo;

    public CherryPick(string? jsonFilePath, string? repoPath)
    {
        this.jsonFilePath = jsonFilePath!;
        this.gitRepo = new GitRepositoy(repoPath!);
    }

    public void Process()
    {
        StartMessage();
        InputFile inputFile = new(jsonFilePath);
        string content = inputFile.AllContent();
        if (string.IsNullOrEmpty(content))
        {
            throw new FileLoadException(string.Format(UserMessages.FileIsEmpty, jsonFilePath));
        }
        List<Commit> commits = JsonListSerializer.Deserialize(content)!;
        foreach (Commit commit in commits)
        {
            HandleCommit(commit);
        }
    }

    private void StartMessage()
    {
        Console.WriteLine(UserMessages.CherryPickModeStarted);
        Console.Write("selected ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(jsonFilePath);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" file.\n");
    }

    private void ProcessCommitHashMessage(Commit commit)
    {
        Console.Write("Process: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(commit.Hash);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" commit\n");
    }

    private void HandleCommit(Commit commit)
    {
        ProcessCommitHashMessage(commit);
        if (UserInputValidator.YesAndNoQuestion(UserMessages.GitShow))
        {
            ShowGitChanges(commit);
        }
        Console.WriteLine("Process cherry-pick");
    }

    private void ShowGitChanges(Commit commit)
    {
        string changes = gitRepo.GetCommitChanges(commit);
        Console.WriteLine(changes);
    }
}
