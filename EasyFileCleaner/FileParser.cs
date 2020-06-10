using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;

namespace EasyFileCleaner
{
    public static class FileParser
    {
        private static bool MatchCriteria(Criteria criteria, NumberedFileInfo nFileInfo)
        {
            if (criteria.isNumbered && !nFileInfo.FileNumber.HasValue)
                return false;

            if (criteria.extension != nFileInfo.FileExtension)
                return false;

            if (!string.IsNullOrEmpty(criteria.filename) && criteria.filename != nFileInfo.FileName)
                return false;

            return true;
        }

        public static IDictionary<string, FileGroup> SearchForFiles(Criteria[] searchCriterias, DirectoryInfo rootDirectory, bool includeSubdirs = true)
        {
            NumberedFileInfo nFileInfo;
            List<NumberedFileInfo> fileList = new List<NumberedFileInfo>();
            Dictionary<string, FileGroup> dico = new Dictionary<string, FileGroup>();

            SearchOption searchOption = includeSubdirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (FileInfo fi in rootDirectory.EnumerateFiles("*.*", searchOption))
            {
                nFileInfo = new NumberedFileInfo(fi);
                
                foreach (var criteria in searchCriterias)
                {
                    if (MatchCriteria(criteria, nFileInfo))
                    {
                        if (dico.ContainsKey(nFileInfo.FullPath))
                        {
                            dico[nFileInfo.FullPath].Add(nFileInfo);
                        }
                        else
                        {
                            dico.Add(nFileInfo.FullPath, new FileGroup { nFileInfo });
                        }
                    }
                }
            }

            return dico;
        }
    }
}
