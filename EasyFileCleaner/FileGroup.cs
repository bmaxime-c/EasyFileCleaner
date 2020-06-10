using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EasyFileCleaner
{
    public class FileGroup : Collection<NumberedFileInfo>
    {
        private string _directory;

        private string _fileName;

        private string _extension;

        public new NumberedFileInfo this[int index] {
            get => this[index];
            set 
            {
                if (CanInsert(value)) 
                {
                    if (!this.Contains(value) || value.Equals(this[index]))
                    {
                        this[index] = value;
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

        private void InitAttributes(NumberedFileInfo item)
        {
            //Les attributs ne peuvent être initialisés que si la liste est vide
            if (Count == 0)
            {
                _fileName = item.FileName;
                _directory = item.FilePath;
                _extension = item.FileExtension;
            }
            else
            {
                throw new Exception("Impossible d'initialiser la liste, elle contient déjà des éléments.");
            }
        }

        public bool CanInsert(NumberedFileInfo item)
        {
            if (Count == 0) return true;

            return _fileName == item.FileName && _directory == item.FilePath && _extension == item.FileExtension;
        }

        public new void Add(NumberedFileInfo item)
        {
            //C'est le premier élément de la liste, on met à jour les attributs privés
            if(Count == 0)
            {
                InitAttributes(item);
            }

            if(CanInsert(item))
            {
                if (!this.Contains(item))
                {
                    base.Add(item);
                }
            }
            else
            {
                throw new Exception("Impossible d'ajouter l'élément à la liste. Un des composants du fichier (répertoire, nom, extension) est différent des fichiers déjà présents dans la liste");
            }
        }

        public new void Insert(int index, NumberedFileInfo item)
        {
            //C'est le premier élément de la liste, on met à jour les attributs privés
            if (Count == 0)
            {
                InitAttributes(item);
            }

            if (CanInsert(item))
            {
                if (!this.Contains(item))
                {
                    base.Insert(index, item);
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

        public IEnumerable<NumberedFileInfo> SkipLast(int count)
        {
            return this.OrderBy(i => i.FileNumber).SkipLast(count);
        }
    }
}
