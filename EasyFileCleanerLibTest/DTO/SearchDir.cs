using EasyFileCleanerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFileCleanerLibTest.DTO
{
    public class SearchDir : ISearchDir
    {
        public string Path { get; set; }
        public bool IncludeSubDirs { get; set; }

        public int? NbToKeep { get; set; }
    }
}
