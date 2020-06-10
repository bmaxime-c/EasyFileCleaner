using EasyFileCleaner;
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

        public NumberedFileInfo Info { get; private set; }

        public int? FileNumber { get => Info.FileNumber; }

        public string FileName { get => Info.FileName; }

        public string FilePath { get => Info.Info.FullName; }

        public string FileExtension { get => Info.FileExtension; }

        public CleanableFileView(NumberedFileInfo fileInfo, bool toDelete = false)
        {
            ToDelete = toDelete;
            Info = fileInfo;
        }
    }
}
