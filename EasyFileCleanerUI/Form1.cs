using EasyFileCleanerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace EasyFileCleanerUI
{
    public partial class EasyFileCleanerMainUI : Form
    {
        public IList<CleanableFileView> AllFiles { get; set; }

        public IConfigManager ConfigManager { get; set; }

        public EasyFileCleanerMainUI()
        {
            InitializeComponent();
            ConfigManager = new XmlConfigManager("SearchParams.xml");
            ConfigManager.Load();

            DetectFiles();
        }

        private void DetectFiles()
        {
            AllFiles = new List<CleanableFileView>();

            foreach (var d in FileParser.SearchForFiles(ConfigManager.Settings).OrderBy(f => f.FullPath).ThenBy(f => f.FileNumber))
            {
                AllFiles.Add(new CleanableFileView(d));

            }
            numberedFileInfoBindingSource.DataSource = AllFiles;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var toDelete = AllFiles.Where(f => f.ToDelete);

            if(toDelete.Count() == 0)
            {
                MessageBox.Show("Il n'y a aucun fichier à supprimer");
                return;
            }

            var res = MessageBox.Show("Confirmer la suppression", $"Vous allez supprimer {toDelete.Count()} fichiers. Etes-vous sûr de vouloir continuer ?", MessageBoxButtons.YesNo);

            if(res == DialogResult.Yes)
            {
                foreach(var d in toDelete)
                {
                    d.Info.Delete();
                }

                DetectFiles();
            }
        }

        private void cbShowSelectedElements_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Checked)
            {
                numberedFileInfoBindingSource.DataSource = AllFiles.Where(f => f.ToDelete);
            }
            else
            {
                numberedFileInfoBindingSource.DataSource = AllFiles;
            }
        }
    }
}
