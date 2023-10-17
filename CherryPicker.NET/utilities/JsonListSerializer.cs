using CherryPicker.NET.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CherryPicker.NET.jsonserializer;

public class JsonListSerializer
{
    public static string Serialize(List<Commit> commits)
    {
        return JsonSerializer.Serialize(commits);
    }

    public static List<Commit>? Deserialize(string json)
    {
        return JsonSerializer.Deserialize<List<Commit>>(json);
    }
}
