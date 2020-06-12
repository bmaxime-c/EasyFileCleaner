using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    internal class SearchParams : ISearchParams
    {
        public IList<ICriteria> Criterias { get; set; }
        public IList<ISearchDir> SearchDirs { get; set; }
    }
}
