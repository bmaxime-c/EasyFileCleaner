using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;

namespace EasyFileCleanerLib
{
    public static class FileParser
    {
        public static IList<INumberedFileInfo> SearchForFiles(ISearchParams sp, int? nbToKeep = null)
        {
            return SearchForFiles(sp.Criterias.ToArray(), sp.SearchDirs.ToArray(), nbToKeep);
        }

        public static IList<INumberedFileInfo> SearchForFiles(ICriteria[] searchCriterias, ISearchDir[] searchDirs, int? nbToKeep = null)
        {
            List<INumberedFileInfo> files = new List<INumberedFileInfo>();
            foreach (ISearchDir searchDir in searchDirs)
            {
                files.AddRange(SearchForFiles(searchCriterias, searchDir, nbToKeep));
            }

            return files;
        }

        public static IList<INumberedFileInfo> SearchForFiles(ICriteria[] searchCriterias, ISearchDir searchDir, int? nbToKeep = null)
        {
            return SearchForFiles(searchCriterias, searchDir.Path, searchDir.IncludeSubDirs, searchDir.NbToKeep.GetValueOrDefault(nbToKeep??1));
        }

        /// <summary>
        /// Permet d'obtenir la liste des fichiers d'un répertoire correspondant aux critères donnés
        /// </summary>
        /// <param name="searchCriterias">Liste de critères de correspondance pour les fichiers à trouver</param>
        /// <param name="dirPath">Répertoire à partir duquel lancer la recherche</param>
        /// <param name="includeSubdirs">Indique s'il faut également parcourir les sous-dossiers</param>
        /// <returns>Liste des fichiers correspondant aux critères</returns>
        public static IList<INumberedFileInfo> SearchForFiles(ICriteria[] searchCriterias, string dirPath, bool includeSubdirs = true, int nbToKeep = 1)
        {
            INumberedFileInfo nFileInfo;
            IList<INumberedFileInfo> result = new List<INumberedFileInfo>();
            Dictionary<string, IFileGroup> dico = new Dictionary<string, IFileGroup>();

            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            SearchOption searchOption = includeSubdirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            if(!directoryInfo.Exists)
            {
                return result;
            }

            foreach (FileInfo fi in directoryInfo.EnumerateFiles("*.*", searchOption))
            {
                nFileInfo = new NumberedFileInfo(fi);
                
                foreach (var criteria in searchCriterias)
                {
                    if (nFileInfo.Match(criteria))
                    {
                        if (!dico.ContainsKey(nFileInfo.FullPath))
                        {
                            dico.Add(nFileInfo.FullPath, new FileGroup(criteria.NbToKeep ?? nbToKeep));
                        }

                        dico[nFileInfo.FullPath].Add(nFileInfo);
                        result.Add(nFileInfo);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
