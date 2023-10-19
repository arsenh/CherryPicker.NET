using CherryPicker.NET.jsonserializer;
using CherryPicker.NET.messages;
using CherryPicker.NET.repository;
using CherryPicker.NET.utilities;
using CherryPicker.NET.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.tools;

public class CherryPick
{
    private string jsonFilePath;

    public CherryPick(string? jsonFilePath)
    {
        this.jsonFilePath = jsonFilePath!;
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
            Console.WriteLine("Show git changes");
        }
        Console.WriteLine("Process cherry-pick");
    }
}
