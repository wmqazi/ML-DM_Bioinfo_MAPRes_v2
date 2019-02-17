namespace MAPRes
{
    partial class DataTableSelectorWnd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataTableSelectorWnd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstOfTableName = new System.Windows.Forms.ListBox();
            this.lblDataTableFor = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstOfTableName);
            this.groupBox1.Controls.Add(this.lblDataTableFor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select datatable for";
            // 
            // lstOfTableName
            // 
            this.lstOfTableName.FormattingEnabled = true;
            this.lstOfTableName.Location = new System.Drawing.Point(7, 49);
            this.lstOfTableName.Name = "lstOfTableName";
            this.lstOfTableName.Size = new System.Drawing.Size(251, 95);
            this.lstOfTableName.TabIndex = 1;
            // 
            // lblDataTableFor
            // 
            this.lblDataTableFor.Location = new System.Drawing.Point(7, 19);
            this.lblDataTableFor.Name = "lblDataTableFor";
            this.lblDataTableFor.Size = new System.Drawing.Size(252, 21);
            this.lblDataTableFor.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Ok.ico");
            this.imageList1.Images.SetKeyName(1, "Delete.ico");
            this.imageList1.Images.SetKeyName(2, "TableFile.ico");
            // 
            // btnNext
            // 
            this.btnNext.ImageIndex = 0;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(185, 178);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 33);
            this.btnNext.TabIndex = 20;
            this.btnNext.Text = "&Ok";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // DataTableSelectorWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 221);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataTableSelectorWnd";
            this.Text = "Data Table Selector";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDataTableFor;
        private System.Windows.Forms.ListBox lstOfTableName;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ImageList imageList1;
    }
}