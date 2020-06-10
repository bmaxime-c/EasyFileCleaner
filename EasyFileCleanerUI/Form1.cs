using EasyFileCleaner;
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
    public partial class Form1 : Form
    {
        public List<CleanableFileView> AllFiles { get; set; }

        public Form1()
        {
            InitializeComponent();

            DetectFiles();
        }

        private void DetectFiles()
        {
            IDictionary<string, FileGroup> dico = FileManager.m();
            CleanableFileView cleanableFile;

            AllFiles = new List<CleanableFileView>();

            foreach (var d in dico.Values)
            {
                //Si les fichiers sont numérotés, on s'assure d'en garder au moins 2 versions
                if (d.IsNumbered)
                {
                    var files = d.GetNumberedFiles();
                    var count = files.Count();
                    for (int i = 0; i < count; i++)
                    {
                        cleanableFile = new CleanableFileView(files.ElementAt(i), i < (count - 2));
                        AllFiles.Add(cleanableFile);
                    }
                }
                else
                {
                    //Fichier non numéroté, de fait la liste ne peut contenir qu'un seul fichier
                    cleanableFile = new CleanableFileView(d[0], true);
                    AllFiles.Add(cleanableFile);
                }

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
                    d.Info.Info.Delete();
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
