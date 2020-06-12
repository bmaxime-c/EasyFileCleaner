namespace EasyFileCleanerUI
{
    partial class EasyFileCleanerMainUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyFileCleanerMainUI));
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ToDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberedFileInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbShowSelectedElements = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberedFileInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(651, 307);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(210, 28);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Supprimer les éléments sélectionnés...";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToDelete,
            this.FileName,
            this.FileExtension,
            this.fileNumberDataGridViewTextBoxColumn,
            this.FilePath});
            this.dataGridView1.DataSource = this.numberedFileInfoBindingSource;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(9, 94);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(852, 209);
            this.dataGridView1.TabIndex = 1;
            // 
            // ToDelete
            // 
            this.ToDelete.DataPropertyName = "ToDelete";
            this.ToDelete.HeaderText = "X";
            this.ToDelete.MinimumWidth = 6;
            this.ToDelete.Name = "ToDelete";
            this.ToDelete.Width = 25;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "Nom";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 125;
            // 
            // FileExtension
            // 
            this.FileExtension.DataPropertyName = "FileExtension";
            this.FileExtension.HeaderText = "Extension";
            this.FileExtension.MinimumWidth = 6;
            this.FileExtension.Name = "FileExtension";
            this.FileExtension.ReadOnly = true;
            this.FileExtension.Width = 125;
            // 
            // fileNumberDataGridViewTextBoxColumn
            // 
            this.fileNumberDataGridViewTextBoxColumn.DataPropertyName = "FileNumber";
            this.fileNumberDataGridViewTextBoxColumn.HeaderText = "#";
            this.fileNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fileNumberDataGridViewTextBoxColumn.Name = "fileNumberDataGridViewTextBoxColumn";
            this.fileNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNumberDataGridViewTextBoxColumn.Width = 50;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "Chemin";
            this.FilePath.MinimumWidth = 6;
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Width = 67;
            // 
            // numberedFileInfoBindingSource
            // 
            this.numberedFileInfoBindingSource.DataSource = typeof(EasyFileCleanerUI.CleanableFileView);
            // 
            // cbShowSelectedElements
            // 
            this.cbShowSelectedElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbShowSelectedElements.AutoSize = true;
            this.cbShowSelectedElements.Location = new System.Drawing.Point(9, 318);
            this.cbShowSelectedElements.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowSelectedElements.Name = "cbShowSelectedElements";
            this.cbShowSelectedElements.Size = new System.Drawing.Size(243, 17);
            this.cbShowSelectedElements.TabIndex = 2;
            this.cbShowSelectedElements.Text = "Afficher uniquement les éléments sélectionnés";
            this.cbShowSelectedElements.UseVisualStyleBackColor = true;
            this.cbShowSelectedElements.CheckedChanged += new System.EventHandler(this.cbShowSelectedElements_CheckedChanged);
            // 
            // EasyFileCleanerMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 346);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbShowSelectedElements);
            this.Controls.Add(this.btnDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EasyFileCleanerMainUI";
            this.Text = "EasyFileCleaner UI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberedFileInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource numberedFileInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileExtensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox cbShowSelectedElements;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
    }
}

