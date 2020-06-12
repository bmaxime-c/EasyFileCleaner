using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace EasyFileCleanerLib
{
    internal class NumberedFileInfo : IEqualityComparer<INumberedFileInfo>, INumberedFileInfo
    {
        /// <summary>
        /// Extension du fichier (hors suffixe numéroté s'il existe)
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// Donne le nom du fichier (sans extension ni suffixe numéroté)
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Donne le suffixe numérioté du fichier (0 si le fichier n'est pas numéroté)
        /// </summary>
        public int FileNumber { get; set; }

        /// <summary>
        /// Objet FileInfo du fichier porté par ce NumberedFileInfo
        /// </summary>
        public FileInfo Info { get; private set; }

        /// <summary>
        /// Donne le chemin du répertoire contenant le fichier
        /// </summary>
        public string FilePath { get => Info.DirectoryName; }

        /// <summary>
        /// Chemin complet vers le fichier (hors suffixe numéroté)
        /// </summary>
        public string FullPath { get => FilePath + Path.DirectorySeparatorChar + FileName + "." + FileExtension; }

        public bool ShouldBeDeleted { get; set; }

        /// <summary>
        /// Indique s'il s'agit d'un fichier à supprimer
        /// </summary>
        public bool ToDelete { get; set; }

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
                FileExtension = fi.Extension.Replace(".", "");
                FileName = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
                FileNumber = 0;
            }
        }

        /// <summary>
        /// Indique si ce NumberedFileInfo correspond au critère donné
        /// </summary>
        /// <param name="criteria">Critère a vérifier</param>
        /// <returns>Vrai si le fichier correspond au critère, faux sinon</returns>
        public bool Match(ICriteria criteria)
        {
            if (criteria.Extension != this.FileExtension)
                return false;

            if (!string.IsNullOrEmpty(criteria.Filename) && criteria.Filename != this.FileName)
                return false;

            return true;
        }

        public bool Equals(INumberedFileInfo x, INumberedFileInfo y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return x.FullPath == y.FullPath && x.FileNumber == y.FileNumber;
        }

        public int GetHashCode(INumberedFileInfo obj)
        {
            return (obj.FullPath.GetHashCode() * 17) + FileNumber;
        }
    }
}
