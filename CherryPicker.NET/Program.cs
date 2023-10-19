using CherryPicker.NET.Messages;
using CherryPicker.NET.Tools;
using CherryPicker.NET.Validator;
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
        Console.WriteLine(UserMessages.WorkingCollectMode);
        Collect collector = new(o.Domains, o.RepoPath);
        collector.Process();
    }
    else if (validator.IsCherryPickEnabled())
    {
        Console.WriteLine(UserMessages.WorkingCherryPickMode);
        CherryPick cherryPick = new(o.JsonFilePath, o.RepoPath);
        try
        {
            cherryPick.Process();
        } catch(FileNotFoundException ex) {
            Console.WriteLine(ex.Message);
            Console.WriteLine(UserMessages.UseHelpForInfo);
        } catch (FileLoadException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
});


public class Options
{
    [Option('m', "mode", Required = true, HelpText = UserMessages.OptionMode)]
    public string? Mode { get; set; }

    [Option('r', "repo", Required = true, HelpText = UserMessages.OptionRepo)]
    public string? RepoPath { get; set; }

    [Option('d', "domains", Required = false, HelpText = UserMessages.OptionDomains)]
    public IEnumerable<string>? Domains { get; set; }

    [Option('f', "file", Required = false, HelpText = UserMessages.OptionFile)]
    public string? JsonFilePath { get; set; }
}