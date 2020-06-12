using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EasyFileCleanerLib
{
    /// <summary>
    /// Collection de fichiers d'un même dossier portant un même nom, une méme extension 
    /// et un numéro incrémental après l'extension du fichier
    /// </summary>
    internal class FileGroup : Collection<INumberedFileInfo>, IFileGroup
    {
        private string _Directory { get => Count > 0 ? this[0].FilePath : null; }

        private string _FileName { get => Count > 0 ? this[0].FileName : null; }

        private string _Extension { get => Count > 0 ? this[0].FileExtension : null; }

        private int NbToKeep { get; set; }

        public new INumberedFileInfo this[int index]
        {
            get => base[index];
            set
            {
                if (CanInsert(value))
                {
                    if (!this.Contains(value) || value.Equals(base[index]))
                    {
                        base[index] = value;
                        UpdateDeleteProperty();
                    }
                    else
                    {
                        throw new Exception("Cet élément est déjà contenu dans la liste. Impossible de modifier la liste avec cette valeur");
                    }
                }
                else
                {
                    throw new Exception("Impossible d'ajouter l'élément à la liste. Un des composants du fichier (répertoire, nom, extension) est différent des fichiers déjà présents dans la liste");
                }
            }
        }

        public FileGroup(int nbToKeep)
        {
            NbToKeep = nbToKeep;
        }

        public void UpdateDeleteProperty()
        {
            int keep = NbToKeep;
            foreach(var f in this.OrderByDescending(i => i.FileNumber))
            {
                f.ShouldBeDeleted = keep <= 0;
                keep--;
            }
        }

        /// <summary>
        /// Indique si l'élément item peut être inséré dans la liste ou non
        /// </summary>
        /// <param name="item">Element à insérer</param>
        /// <returns>Vrai si l'élément peut être inséré. Faux sinon</returns>
        public bool CanInsert(INumberedFileInfo item)
        {
            if (Count == 0) return true;

            return _FileName == item.FileName && _Directory == item.FilePath && _Extension == item.FileExtension;
        }

        /// <summary>
        /// Ajoute un élément dans la liste, s'il n'existe pas déjà
        /// </summary>
        /// <param name="item">Elément à ajouter</param>
        public new void Add(INumberedFileInfo item)
        {
            if (CanInsert(item))
            {
                if (!Contains(item))
                {
                    base.Add(item);
                    UpdateDeleteProperty();
                }
            }
            else
            {
                throw new Exception("Impossible d'ajouter l'élément à la liste. Un des composants du fichier (répertoire, nom, extension) est différent des fichiers déjà présents dans la liste");
            }
        }

        /// <summary>
        /// Insère un élément dans la liste à la position indiquée
        /// </summary>
        /// <param name="index">Position de l'élément à insérer</param>
        /// <param name="item">Elément à insérer</param>
        public new void Insert(int index, INumberedFileInfo item)
        {
            if (CanInsert(item))
            {
                if (!this.Contains(item))
                {
                    base.Insert(index, item);
                    UpdateDeleteProperty();
                }
                else
                {
                    throw new Exception("Cet élément est déjà contenu dans la liste. Impossible de l'ajouter.");
                }
            }
            else
            {
                throw new Exception("Impossible d'ajouter l'élément à la liste. Un des composants du fichier (répertoire, nom, extension) est différent des fichiers déjà présents dans la liste");
            }
        }

        /// <summary>
        /// Retourne la liste des fichiers ordonnée par leur suffixe numéroté
        /// </summary>
        /// <returns></returns>
        public IEnumerable<INumberedFileInfo> GetNumberedFiles()
        {
            return this.OrderBy(i => i.FileNumber);
        }
    }
}
