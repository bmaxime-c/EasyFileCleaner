using AutoMapper;
using EasyFileCleanerLib.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EasyFileCleanerLib
{
    public class XmlConfigManager : IConfigManager
    {
        /// <summary>
        /// Emplacement par défaut du fichier de configuration XML
        /// </summary>
        private const string DEFAULT_CONFIG_PATH = "SearchParams.xml";
        
        public ISearchParams Settings { get; set; }

        /// <summary>
        /// Chemin vers le fichier XML de configuration
        /// </summary>
        public string ConfigPath { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance du gestionnaire de configuration
        /// </summary>
        /// <param name="path"></param>
        public XmlConfigManager(string path = null)
        {
            ConfigPath = path ?? DEFAULT_CONFIG_PATH;
        }

        /// <summary>
        /// Charge la configuration à partir du chemin vers le fichier XML situé dans ConfigPath
        /// </summary>
        public void Load()
        {
            XmlSerializer xs = new XmlSerializer(typeof(XML.SearchParams));
            
            List<IFileGroup> files = new List<IFileGroup>();
            using (StreamReader rd = new StreamReader(ConfigPath))
            {
                var xmlParams = xs.Deserialize(rd) as XML.SearchParams;

                Settings = new SearchParams();

                Settings.Criterias = xmlParams.Criterias.Select(c => new Criteria 
                { 
                    Extension = c.extension, 
                    Filename = c.filename, 
                    NbToKeep = c.keepSpecified ? (c.keep as int?) : null 
                }).ToList<ICriteria>();

                Settings.SearchDirs = xmlParams.SearchDirs.Select(c => new SearchDir
                {
                    Path = c.path,
                    IncludeSubDirs = c.includeSubfolders,
                    NbToKeep = c.keepSpecified ? (c.keep as int?) : null
                }).ToList<ISearchDir>();
            }
        }

        /// <summary>
        /// Enregistre la configuration dans le fichier à l'emplacement indiqué par ConfigPath
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
