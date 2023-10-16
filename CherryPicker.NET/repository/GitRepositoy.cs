using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.repository;

public class GitRepositoy
{
    public static bool IsGitRepository(string path)
    {
        try
        {
            using (var repo = new Repository(path))
            {
                return true;
            }
        }
        catch (RepositoryNotFoundException)
        {
            return false;
        }
    }
}
