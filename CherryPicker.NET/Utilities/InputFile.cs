using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.Utilities;

public class InputFile
{
    public string Name { get; init; }

    public InputFile(string name)
    {
        Name = name;
        if (! File.Exists(Name))
        {
            throw new FileNotFoundException($"{Name} is not exist");
        }
    }

    public string AllContent()
    {
        return File.ReadAllText(Name);
    }
}
