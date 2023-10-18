using CherryPicker.NET.jsonserializer;
using CherryPicker.NET.repository;
using CherryPicker.NET.utilities;
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
        Console.WriteLine($"Selected {jsonFilePath} file.");
        InputFile inputFile = new(jsonFilePath);
        string content = inputFile.AllContent();
        if (string.IsNullOrEmpty(content))
        {
            throw new FileLoadException($"{jsonFilePath} file is empty. Nothing to do.");
        }
        List<Commit> commits = JsonListSerializer.Deserialize(content)!;
        Console.WriteLine($"commits count: {commits.Count}");
    }
}
