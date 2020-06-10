using Microsoft.VisualBasic.MyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EasyFileCleaner
{
    public static class FileManager
    {
        public static IDictionary<string, FileGroup> m()
        {
            XmlSerializer xs = new XmlSerializer(typeof(SearchParams));
            FileSystemProxy fsProxy = new Microsoft.VisualBasic.Devices.Computer().FileSystem;
            SearchParams p;
            IDictionary<string, FileGroup> files = null;
            using (StreamReader rd = new StreamReader("SearchParams.xml"))
            {
                p = xs.Deserialize(rd) as SearchParams;
            }

            foreach(SearchDir sd in p.SearchDirs)
            {
                files = FileParser.SearchForFiles(p.Criterias, new DirectoryInfo(sd.path), sd.includeSubfolders);
            }

            return files;

            //foreach(FileGroup g in files.Values)
            //{
            //    foreach(var f in g.SkipLast(2))
            //    {
            //        //fsProxy
            //        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(f.Info.FullName, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            //    }
            //}

            
        }
    }
}
