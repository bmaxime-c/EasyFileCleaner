using System.IO;

namespace EasyFileCleanerLib
{
    public interface INumberedFileInfo
    {
        string FileExtension { get; set; }
        string FileName { get; set; }
        int FileNumber { get; set; }
        string FilePath { get; }
        string FullPath { get; }
        FileInfo Info { get; }
        bool ShouldBeDeleted { get; set; }
        bool Match(ICriteria criteria);
    }
}