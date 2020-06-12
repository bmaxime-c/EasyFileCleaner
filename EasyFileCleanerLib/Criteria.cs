using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    internal class Criteria : ICriteria
    {
        public string Filename { get; set; }

        public string Extension { get; set; }

        public int? NbToKeep { get; set; }
    }
}
