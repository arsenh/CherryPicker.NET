using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.utilities;

public class OutputFile
{
    public string FileName { get; init; }
    public OutputFile()
    {
        FileName = GenerateNameForFile();
    }

    public void Write(string data)
    {
        using (FileStream fs = File.Create(FileName))
        {
            byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(data);
            fs.Write(contentBytes, 0, contentBytes.Length);
        }
    }

    private string GenerateNameForFile()
    {
        return new StringBuilder()
        .Append("collect_")
        .Append(DateTime.Now.ToString("MM_dd_yyyy_h_mm_ss"))
        .Append(".json").ToString();
    }
}
