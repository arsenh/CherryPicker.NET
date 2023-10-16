using CherryPicker.NET.messages;
using CherryPicker.NET.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.validator;

public class CommandLineValidator
{
    private const string CollectMode = "collect";
    private const string CherryPickMode = "cherry-pick";

    private Options options;

    private bool isCollectMode = false;
    private bool isCherryPickMode = false;


    public CommandLineValidator(Options o)
    {
        this.options = o;
    }

    public void Validate()
    {
        if (string.IsNullOrEmpty(options.Mode))
            throw new ArgumentException(UserMessages.ModeIsNotSet);

        if (options.Mode == CollectMode)
            isCollectMode = true;
        else if (options.Mode == CherryPickMode)
            isCherryPickMode = true;
        else
            throw new InvalidDataException(UserMessages.InvalidModeSet);

        if (string.IsNullOrEmpty(options.RepoPath))
            throw new ArgumentException(UserMessages.RepoPathIsNotSet);
        if (! GitRepositoy.IsGitRepository(options.RepoPath))
            throw new ArgumentException(UserMessages.InvalidGitPath);

        ValidateOptionsByMode();
    }

    public bool IsCherryPickEnabled()
    {
        return isCherryPickMode;
    }

    public bool IsCollectModeEnabled()
    {
        return isCollectMode;
    }

    private void ValidateOptionsByMode()
    {
        if (isCollectMode)
        {
            ValidateDomainsPatameter();
        } else if (isCherryPickMode)
        {
            ValidateJsonPathPatameter();
        } else
        {
            throw new InvalidDataException(UserMessages.InvalidModeSet);
        }
    }

    private void ValidateJsonPathPatameter()
    {
        // TODO
        throw new NotImplementedException();
    }

    private void ValidateDomainsPatameter()
    {
        // TODO
        throw new NotImplementedException();
    }
}
