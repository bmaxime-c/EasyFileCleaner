using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    internal class SearchDir : ISearchDir
    {
        public string Path { get; set; }
        public bool IncludeSubDirs { get; set; }

        public int? NbToKeep { get; set; }
    }
}
