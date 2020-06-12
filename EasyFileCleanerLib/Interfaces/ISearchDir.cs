using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    public interface ISearchDir
    {
        string Path { get; set; }

        bool IncludeSubDirs { get; set; }

        int? NbToKeep { get; set; }
    }
}
