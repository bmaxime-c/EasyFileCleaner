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
            if (int.TryParse(fi.Extension, out int numSuffix))
            {
                string[] fileParts = fi.Name.Split('.');
                FileExtension = fileParts.Last();
                FileName = string.Join('.', fileParts.SkipLast(1));
                FileNumber = numSuffix;
            }
            else
            {
                FileExtension = fi.Extension;
                FileName = fi.Name;
            }
        }

        public bool Equals([AllowNull] NumberedFileInfo x, [AllowNull] NumberedFileInfo y)
        {
            if(x == null || y == null)
            {
                return false;
            }

            return x.FullPath == y.FullPath && x.FileNumber.GetValueOrDefault(int.MinValue) == y.FileNumber.GetValueOrDefault(int.MinValue);
        }

        public int GetHashCode([DisallowNull] NumberedFileInfo obj)
        {
            return (obj.FullPath.GetHashCode() * 17) + FileNumber.GetValueOrDefault(0);
        }
    }
}
