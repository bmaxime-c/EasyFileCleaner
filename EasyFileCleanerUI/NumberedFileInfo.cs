using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace EasyFileCleaner
{
    public class NumberedFileInfo : IEqualityComparer<NumberedFileInfo>
    {
        public string FileExtension { get; set; }

        public string FileName { get; set; }

        public int? FileNumber { get; set; }

        public FileInfo Info { get; private set; }

        public string FilePath { get => Info.DirectoryName; }

        public string FullPath { get => FilePath + Path.DirectorySeparatorChar + FileName + "." + FileExtension; }

        public NumberedFileInfo(FileInfo fi)
        {
            Info = fi;

            //Si le fichier est numéroté, on ne peut pas extraire 
            //directement le nom et l'extension à partir du FileInfo
            if (int.TryParse(fi.Extension.Replace(".", ""), out int numSuffix))
            {
                string[] fileParts = fi.Name.Split('.');
                FileExtension = (fileParts.Length > 2) ? fileParts[fileParts.Length - 2] : "";
                FileName = (fileParts.Length > 2) ? string.Join(".", fileParts.Take(fileParts.Length - 2)) : fi.Name;
                FileNumber = numSuffix;
            }
            else
            {
                FileExtension = fi.Extension;
                FileName = fi.Name;
            }
        }

        public bool Equals(NumberedFileInfo x, NumberedFileInfo y)
        {
            if(x == null || y == null)
            {
                return false;
            }

            return x.FullPath == y.FullPath && x.FileNumber.GetValueOrDefault(int.MinValue) == y.FileNumber.GetValueOrDefault(int.MinValue);
        }

        public int GetHashCode(NumberedFileInfo obj)
        {
            return (obj.FullPath.GetHashCode() * 17) + FileNumber.GetValueOrDefault(0);
        }
    }
}
