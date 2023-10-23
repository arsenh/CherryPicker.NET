using CherryPicker.NET.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.Utilities;

public class Platform
{
    public static string GetPlatformShell() => Environment.OSVersion.Platform switch
    {
        PlatformID.Unix => "/bin/bash",
        PlatformID.Win32NT => "cmd.exe",
        _ => throw new PlatformNotSupportedException(UserMessages.PlatformNotSupported)
    };

    public static ProcessStartInfo GetProcessInfoForWindows(string hash, string workingDir)
    {
        return new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/C git show {hash}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = workingDir
        };
    }

    public static ProcessStartInfo GetProcessInfoForUnix(string hash, string workingDir)
    {
        return new ProcessStartInfo
        {
            FileName = "/usr/bin/git",
            Arguments = $"show {hash}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = workingDir
        };
    }

    public static string RunExternalCommand(string hash, string workingDir)
    {
        StringBuilder output = new StringBuilder();
        ProcessStartInfo? info = null;
        if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
            info = GetProcessInfoForWindows(hash, workingDir);
        } else if(Environment.OSVersion.Platform == PlatformID.Unix) {
            info = GetProcessInfoForUnix(hash, workingDir);
        } else {
            throw new PlatformNotSupportedException(UserMessages.PlatformNotSupported);
        }

        using (Process process = new Process())
        {
            process.StartInfo = info;
            process.OutputDataReceived += (sender, e) => output.AppendLine(e.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
        return output.ToString();
    }
}
