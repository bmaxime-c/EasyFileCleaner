using EasyFileCleanerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFileCleanerLibTest.DTO
{
    public class SearchParams : ISearchParams
    {
        public IList<ICriteria> Criterias { get; set; }
        public IList<ISearchDir> SearchDirs { get; set; }
    }
}
