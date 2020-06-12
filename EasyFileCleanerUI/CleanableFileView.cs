using EasyFileCleanerLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFileCleanerUI
{
    public class CleanableFileView
    {
        public bool ToDelete { get; set; }

        public FileInfo Info { get; set; }

        public int? FileNumber { get; private set; }

        public string FileName { get; private set; }

        public string FilePath { get; private set; }

        public string FileExtension { get; private set; }

        public CleanableFileView(INumberedFileInfo fileInfo)
        {
            ToDelete = fileInfo.ShouldBeDeleted;
            FileNumber = fileInfo.FileNumber;
            FileName = fileInfo.FileName;
            FilePath = fileInfo.FullPath;
            FileExtension = fileInfo.FileExtension;
            Info = fileInfo.Info;
        }
    }
}
