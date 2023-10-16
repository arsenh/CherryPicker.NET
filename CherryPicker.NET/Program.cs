﻿using CommandLine;

Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
    //do something
});


public class Options
{
    [Option('m', "mode", Required = true, HelpText = "Specifies the coordinates (x,y).")]
    public string? Mode { get; set; }

    [Option('r', "repo", Required = true, HelpText = "Path to GIT repository.")]
    public string? RepoPath { get; set; }

    [Option('d', "domains", Required = false, HelpText = "Domains.")]
    public IEnumerable<string>? Domains { get; set; }

    [Option('f', "file", Required = false, HelpText = "Json file for cherry-pick.")]
    public string? JsonFilePath { get; set; }
}