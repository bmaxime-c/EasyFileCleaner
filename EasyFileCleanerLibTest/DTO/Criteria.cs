using EasyFileCleanerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFileCleanerLibTest.DTO
{
    internal class Criteria : ICriteria
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public int? NbToKeep { get; set; }
    }
}
