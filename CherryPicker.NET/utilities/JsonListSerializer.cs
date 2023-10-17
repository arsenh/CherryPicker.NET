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
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public static string Serialize(List<Commit> commits)
    {
        return JsonSerializer.Serialize(commits, options);
    }

    public static List<Commit>? Deserialize(string json)
    {
        return JsonSerializer.Deserialize<List<Commit>>(json, options);
    }
}
