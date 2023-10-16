using CherryPicker.NET.collector;
using CherryPicker.NET.messages;
using CherryPicker.NET.tools;
using CherryPicker.NET.validator;
using CommandLine;

Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
    CommandLineValidator validator = new CommandLineValidator(o);
    try
    {
        validator.Validate();
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(UserMessages.UseHelpForInfo);
        return;
    }
    if (validator.IsCollectModeEnabled())
    {
        Console.WriteLine("Working in collect mode.");
        Collect collector = new(o.Domains, o.RepoPath);
        collector.Process();
    }
    else if (validator.IsCherryPickEnabled())
    {
        CherryPick cherryPick = new(o.JsonFilePath);
        //cherryPick.Process();
        //Console.WriteLine("Working in cherry-pick mode.");
    }
});


public class Options
{
    [Option('m', "mode", Required = true, HelpText = "Specifies the mode (collect,cherry-pick).")]
    public string? Mode { get; set; }

    [Option('r', "repo", Required = true, HelpText = "Path to GIT repository.")]
    public string? RepoPath { get; set; }

    [Option('d', "domains", Required = false, HelpText = "Domains.")]
    public IEnumerable<string>? Domains { get; set; }

    [Option('f', "file", Required = false, HelpText = "Json file for cherry-pick.")]
    public string? JsonFilePath { get; set; }
}