using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    public interface IConfigManager
    {
        ISearchParams Settings { get; set; }

        void Load();

        bool Save();
    }
}
