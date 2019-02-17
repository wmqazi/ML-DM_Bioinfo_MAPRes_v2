namespace MAPRes
{
    partial class MAPResDatasetViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAPResDatasetViewer));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmnuCombinedRowFiltering = new System.Windows.Forms.ToolStripSplitButton();
            this.filterForNegativelyPreferredSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterForPositiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCombinedCriteria = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.saveDLG = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblRecordCount,
            this.tsmnuCombinedRowFiltering,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 363);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblRecordCount
            // 
            this.tslblRecordCount.Name = "tslblRecordCount";
            this.tslblRecordCount.Size = new System.Drawing.Size(0, 17);
            // 
            // tsmnuCombinedRowFiltering
            // 
            this.tsmnuCombinedRowFiltering.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmnuCombinedRowFiltering.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterForNegativelyPreferredSitesToolStripMenuItem,
            this.filterForPositiveToolStripMenuItem,
            this.txtCombinedCriteria,
            this.toolStripSeparator1,
            this.removeFilterToolStripMenuItem,
            this.removeAllFiltersToolStripMenuItem,
            this.toolStripSeparator2});
            this.tsmnuCombinedRowFiltering.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuCombinedRowFiltering.Image")));
            this.tsmnuCombinedRowFiltering.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmnuCombinedRowFiltering.Name = "tsmnuCombinedRowFiltering";
            this.tsmnuCombinedRowFiltering.Size = new System.Drawing.Size(85, 20);
            this.tsmnuCombinedRowFiltering.Text = "Row Filtering";
            this.tsmnuCombinedRowFiltering.Visible = false;
            // 
            // filterForNegativelyPreferredSitesToolStripMenuItem
            // 
            this.filterForNegativelyPreferredSitesToolStripMenuItem.Name = "filterForNegativelyPreferredSitesToolStripMenuItem";
            this.filterForNegativelyPreferredSitesToolStripMenuItem.Size = new System.Drawing.Size(660, 22);
            this.filterForNegativelyPreferredSitesToolStripMenuItem.Text = "Filter For Negatively Preferred Sites";
            this.filterForNegativelyPreferredSitesToolStripMenuItem.Click += new System.EventHandler(this.filterForNegativelyPreferredSitesToolStripMenuItem_Click);
            // 
            // filterForPositiveToolStripMenuItem
            // 
            this.filterForPositiveToolStripMenuItem.Name = "filterForPositiveToolStripMenuItem";
            this.filterForPositiveToolStripMenuItem.Size = new System.Drawing.Size(660, 22);
            this.filterForPositiveToolStripMenuItem.Text = "Filter For Positively Preferred Sites";
            this.filterForPositiveToolStripMenuItem.Click += new System.EventHandler(this.filterForPositiveToolStripMenuItem_Click);
            // 
            // txtCombinedCriteria
            // 
            this.txtCombinedCriteria.Name = "txtCombinedCriteria";
            this.txtCombinedCriteria.Size = new System.Drawing.Size(600, 21);
            this.txtCombinedCriteria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCombinedCriteria_KeyPress);
            this.txtCombinedCriteria.Click += new System.EventHandler(this.txtCombinedCriteria_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(657, 6);
            // 
            // removeFilterToolStripMenuItem
            // 
            this.removeFilterToolStripMenuItem.Name = "removeFilterToolStripMenuItem";
            this.removeFilterToolStripMenuItem.Size = new System.Drawing.Size(660, 22);
            this.removeFilterToolStripMenuItem.Text = "Remove Filter";
            this.removeFilterToolStripMenuItem.Click += new System.EventHandler(this.removeFilterToolStripMenuItem_Click);
            // 
            // removeAllFiltersToolStripMenuItem
            // 
            this.removeAllFiltersToolStripMenuItem.Name = "removeAllFiltersToolStripMenuItem";
            this.removeAllFiltersToolStripMenuItem.Size = new System.Drawing.Size(660, 22);
            this.removeAllFiltersToolStripMenuItem.Text = "Remove All Filters";
            this.removeAllFiltersToolStripMenuItem.Click += new System.EventHandler(this.removeAllFiltersToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(657, 6);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(487, 363);
            this.dataGridView1.TabIndex = 3;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(89, 20);
            this.toolStripSplitButton1.Text = "Export As XMl";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // saveDLG
            // 
            this.saveDLG.Filter = "XML Files|*.XML";
            this.saveDLG.Title = "Export As";
            // 
            // MAPResDatasetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 385);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MAPResDatasetViewer";
            this.Text = "MAPResDatasetViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAPResDatasetViewer_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblRecordCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSplitButton tsmnuCombinedRowFiltering;
        private System.Windows.Forms.ToolStripMenuItem filterForPositiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterForNegativelyPreferredSitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtCombinedCriteria;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.SaveFileDialog saveDLG;
    }
}