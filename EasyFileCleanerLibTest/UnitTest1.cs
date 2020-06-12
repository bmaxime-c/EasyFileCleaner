using System;
using System.IO;
using System.Linq;
using EasyFileCleanerLib;
using EasyFileCleanerLib.XML;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyFileCleanerLibTest
{
    [TestClass]
    public class FileParserTest
    {
        private static readonly Random _random = new Random();

        private string _tempPath;

        public static string RandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // les charactères possibles dans la chaîne
            return new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Crée le répertoire temporaire utilisé pour stocker les fichiers du test
        /// S'il existe déjà, échoue le test
        /// </summary>
        [TestInitialize]
        public void CreateTempFolder()
        {
            _tempPath = Path.Combine(Path.GetTempPath(), "EasyFileCleanerLibTest_" + RandomString());
            if (Directory.Exists(_tempPath))
            {
                throw new InvalidOperationException("Le répertoire de test existe déjà");
            }

            Directory.CreateDirectory(_tempPath);
        }

        /// <summary>
        /// Supprime le répertoire temporaire utilisé pour les tests
        /// </summary>
        [TestCleanup]
        public void DeleteTempFolder()
        {
            if (Directory.Exists(_tempPath))
            {
                Directory.Delete(_tempPath, true);
            }
        }

        private void CreateDirs(params string[] dirs)
        {
            if (dirs != null)
            {
                foreach (string dir in dirs)
                {
                    Directory.CreateDirectory(Path.Combine(_tempPath, dir));
                }
            }
        }

        private void CreateFiles(params string[] filenames)
        {
            if (filenames != null)
            {
                var directories =
                    from file in filenames
                    where file.Contains(Path.DirectorySeparatorChar)
                    select file.Substring(0, file.LastIndexOf(Path.DirectorySeparatorChar));

                CreateDirs(directories.Distinct().ToArray());

                foreach (string f in filenames)
                {
                    File.WriteAllText(Path.Combine(_tempPath, f), "");
                }
            }
        }

        /// <summary>
        /// Dans un dossier contenant plusieurs fichiers d'extensions différentes, 
        /// ne doit retourner que l'extension .asm (ou .asm.{number})
        /// </summary>
        [TestMethod]
        public void SearchFiles_TwoExtensionsShouldListOne()
        {
            #region Arrange
            CreateFiles(
                "stay.valid",
                "stay.valid.0",
                "stay.valid.1",
                "stayagain.asm.valid",
                "shouldDelete.asm.1",
                "shouldDelete.asm"
            );

            ICriteria[] criterias = new ICriteria[1]
            {
                new DTO.Criteria { Extension="asm" }
            };
            #endregion

            #region Act
            var files = FileParser.SearchForFiles(criterias, _tempPath);
            #endregion

            #region Assert
            /*
             * Le test est valide si :
             * - 2 fichiers sont détectés
             * - les 2 fichiers contiennent shouldDelete.asm
             * */
            Assert.AreEqual(2, files.Count());
            foreach (var f in files)
            {
                StringAssert.Contains(f.Info.Name, "shouldDelete.asm");
            }
            #endregion
        }

        /// <summary>
        /// Vérifie que parmi les fichiers relevés, seul le dernier de chaque nom est marqué comme "à supprimer"
        /// </summary>
        [TestMethod]
        public void SearchFiles_KeepLast()
        {
            #region Arrange
            CreateFiles(
                "shouldDelete.asm.1",
                "shouldDelete.asm",
                "shouldDeleteAgain.asm.30",
                "shouldDeleteAgain.asm.48"
            );

            ISearchParams sp = new DTO.SearchParams()
            {
                Criterias = new ICriteria[1]
                {
                    new DTO.Criteria { Extension="asm" }
                },
                SearchDirs = new ISearchDir[1]
                {
                    new DTO.SearchDir { Path=_tempPath }
                }
            };
            #endregion

            #region Act
            var files = FileParser.SearchForFiles(sp, 1);
            #endregion

            #region Assert
            /*
             * Le test est valide si :
             * - 4 fichiers sont détectés
             * - les fichiers shouldDelete.asm.1 et shouldDeleteAgain.asm.48 sont marqués comme ShouldBeDeleted=false
             * - les autres fichiers sont marqués comme ShouldBeDeleted=true
             * */
            Assert.AreEqual(4, files.Count());
            foreach (var f in files)
            {
                switch(f.Info.Name)
                {
                    case "shouldDelete.asm.1":
                    case "shouldDeleteAgain.asm.48":
                        Assert.IsFalse(f.ShouldBeDeleted);
                        break;
                    
                    case "shouldDelete.asm":
                    case "shouldDeleteAgain.asm.30":
                        Assert.IsTrue(f.ShouldBeDeleted);
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// S'assure que le paramètre de nombre de fichiers a conserver, défini au niveau répertoire est bien overridé par celui au niveau critère
        /// </summary>
        [TestMethod]
        public void SearchFiles_CriteriaKeepOverridesFolderKeep()
        {
            #region Arrange
            CreateFiles(
                "stay.valid",
                "shouldDelete.keep1.11",
                "shouldDelete.keep1.12",
                "shouldDelete.keep1.13",
                "shouldDelete.keep2.30",
                "shouldDelete.keep2.35",
                "shouldDelete.keep2.48"
            );

            ISearchParams sp = new DTO.SearchParams()
            {
                Criterias = new ICriteria[2]
                {
                    new DTO.Criteria { Extension="keep2", NbToKeep=2  },
                    new DTO.Criteria { Extension="keep1"  }
                },
                SearchDirs = new ISearchDir[1]
                {
                    new DTO.SearchDir { Path=_tempPath, NbToKeep = 1 }
                }
            };
            #endregion

            #region Act
            var files = FileParser.SearchForFiles(sp);
            #endregion

            #region Assert
            /*
             * Le test est valide si :
             * - 4 fichiers sont détectés
             * - les fichiers shouldDelete.asm.1 et shouldDeleteAgain.asm.48 sont marqués comme ShouldBeDeleted=false
             * - les autres fichiers sont marqués comme ShouldBeDeleted=true
             * */
            Assert.AreEqual(6, files.Count());
            foreach (var f in files)
            {
                switch (f.Info.Name)
                {
                    case "shouldDelete.keep1.13":
                    case "shouldDelete.keep2.35":
                    case "shouldDelete.keep2.48":
                        Assert.IsFalse(f.ShouldBeDeleted);
                        break;

                    case "shouldDelete.keep1.11":
                    case "shouldDelete.keep1.12":
                    case "shouldDeleteAgain.asm.30":
                        Assert.IsTrue(f.ShouldBeDeleted);
                        break;
                }
            }
            #endregion
        }
    }
}
