using System.Collections.Generic;

namespace EasyFileCleanerLib
{
    public interface IFileGroup : ICollection<INumberedFileInfo>
    {
        bool CanInsert(INumberedFileInfo item);
        IEnumerable<INumberedFileInfo> GetNumberedFiles();
    }
}