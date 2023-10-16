using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.validator;

public class CommandLineValidator
{
    private Options options;

    public CommandLineValidator(Options o)
    {
        this.options = o;
    }

    public bool IsCherryPickEnabled()
    {
        throw new NotImplementedException();
    }

    public bool IsCollectModeEnabled()
    {
        throw new NotImplementedException();
    }
}
