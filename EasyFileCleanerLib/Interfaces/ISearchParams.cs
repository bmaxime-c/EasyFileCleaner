using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    public interface ISearchParams
    {
        IList<ICriteria> Criterias { get; set; }
        IList<ISearchDir> SearchDirs { get; set; }
    }
}
