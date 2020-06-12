using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFileCleanerLib
{
    /// <summary>
    /// Définit l'implémentation d'un critère de recherche de fichiers
    /// </summary>
    public interface ICriteria
    {
        /// <summary>
        /// Condition sur le nom du fichier.
        /// (hors extension ou suffixe de numérotation)
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        /// Extension du fichier
        /// (si le fichier est numéroté, correspond à la partie avant le suffixe)
        /// </summary>
        string Extension { get; set; }

        /// <summary>
        /// Nombre d'occurences de fichier à garder s'il a été matché via ce critère
        /// </summary>
        int? NbToKeep { get; set; }
    }
}
