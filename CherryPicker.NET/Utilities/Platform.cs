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

    public static string GetExecuteAndTerminateCommand() => Environment.OSVersion.Platform switch
    {
        PlatformID.Unix => " ",
        PlatformID.Win32NT => "/C",
        _ => throw new PlatformNotSupportedException(UserMessages.PlatformNotSupported)
    };

    public static string RunExternalCommand(string command, string workingDir)
    {
        StringBuilder output = new StringBuilder();
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = Platform.GetPlatformShell(),
            Arguments = $"{Platform.GetExecuteAndTerminateCommand()} {command}",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = workingDir
        };

        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.OutputDataReceived += (sender, e) => output.AppendLine(e.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
        return output.ToString();
    }
}
