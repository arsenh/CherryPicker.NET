using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.collector;

public class Collect
{
    private IEnumerable<string>? domains;

    public Collect(IEnumerable<string>? domains, string repoPath)
    {
        this.domains = domains;
    }

    public void Process()
    {
        throw new NotImplementedException();
    }
}
