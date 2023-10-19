using CherryPicker.NET.Messages;
using System;
using System.Collections.Generic;
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
}
