namespace MAPRes
{
    partial class NewProjectWnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectWnd));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitile = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnViewSelectedUSDDataset = new System.Windows.Forms.Button();
            this.btnBrowerForUSDDataset = new System.Windows.Forms.Button();
            this.lblUSDPath = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkUseStandardAminoAcidCodingScheme = new System.Windows.Forms.CheckBox();
            this.txtSetOfAminoAcids = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkIsSubjectMemberOfPeptide = new System.Windows.Forms.CheckBox();
            this.txtSubjectPosition = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubjects = new System.Windows.Forms.TextBox();
            this.txtPeptideWindowSize = new System.Windows.Forms.TextBox();
            this.txtAnalysistName = new System.Windows.Forms.TextBox();
            this.txtAnalysisDescription = new System.Windows.Forms.TextBox();
            this.txtAnalysisTitile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnSelectProjectFile = new System.Windows.Forms.Button();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.openDlg = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "Save.ico");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitile);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 75);
            this.panel1.TabIndex = 4;
            // 
            // lblTitile
            // 
            this.lblTitile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.Location = new System.Drawing.Point(73, 12);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(520, 49);
            this.lblTitile.TabIndex = 1;
            this.lblTitile.Text = "Create New Project";
            this.lblTitile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MAPRes.Properties.Resources.J0240695;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 399);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 47);
            this.panel3.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageIndex = 1;
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(443, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 33);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageIndex = 0;
            this.btnOK.ImageList = this.imageList1;
            this.btnOK.Location = new System.Drawing.Point(541, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 33);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "&Ok";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnViewSelectedUSDDataset);
            this.tabPage2.Controls.Add(this.btnBrowerForUSDDataset);
            this.tabPage2.Controls.Add(this.lblUSDPath);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(617, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Primary Sites Dataset";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnViewSelectedUSDDataset
            // 
            this.btnViewSelectedUSDDataset.ImageIndex = 5;
            this.btnViewSelectedUSDDataset.ImageList = this.imageList1;
            this.btnViewSelectedUSDDataset.Location = new System.Drawing.Point(190, 137);
            this.btnViewSelectedUSDDataset.Name = "btnViewSelectedUSDDataset";
            this.btnViewSelectedUSDDataset.Size = new System.Drawing.Size(175, 29);
            this.btnViewSelectedUSDDataset.TabIndex = 22;
            this.btnViewSelectedUSDDataset.Text = "View Dataset";
            this.btnViewSelectedUSDDataset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewSelectedUSDDataset.UseVisualStyleBackColor = true;
            this.btnViewSelectedUSDDataset.Click += new System.EventHandler(this.btnViewSelectedUSDDataset_Click);
            // 
            // btnBrowerForUSDDataset
            // 
            this.btnBrowerForUSDDataset.ImageIndex = 4;
            this.btnBrowerForUSDDataset.ImageList = this.imageList1;
            this.btnBrowerForUSDDataset.Location = new System.Drawing.Point(9, 137);
            this.btnBrowerForUSDDataset.Name = "btnBrowerForUSDDataset";
            this.btnBrowerForUSDDataset.Size = new System.Drawing.Size(175, 29);
            this.btnBrowerForUSDDataset.TabIndex = 21;
            this.btnBrowerForUSDDataset.Text = "Browse For Dataset";
            this.btnBrowerForUSDDataset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowerForUSDDataset.UseVisualStyleBackColor = true;
            this.btnBrowerForUSDDataset.Click += new System.EventHandler(this.btnBrowerForUSDDataset_Click);
            // 
            // lblUSDPath
            // 
            this.lblUSDPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUSDPath.Location = new System.Drawing.Point(9, 82);
            this.lblUSDPath.Name = "lblUSDPath";
            this.lblUSDPath.Size = new System.Drawing.Size(599, 52);
            this.lblUSDPath.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "XML Sites Dataset";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkUseStandardAminoAcidCodingScheme);
            this.tabPage3.Controls.Add(this.txtSetOfAminoAcids);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(617, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Amino Acid Set";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkUseStandardAminoAcidCodingScheme
            // 
            this.chkUseStandardAminoAcidCodingScheme.AutoSize = true;
            this.chkUseStandardAminoAcidCodingScheme.Checked = true;
            this.chkUseStandardAminoAcidCodingScheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseStandardAminoAcidCodingScheme.Location = new System.Drawing.Point(128, 71);
            this.chkUseStandardAminoAcidCodingScheme.Name = "chkUseStandardAminoAcidCodingScheme";
            this.chkUseStandardAminoAcidCodingScheme.Size = new System.Drawing.Size(152, 17);
            this.chkUseStandardAminoAcidCodingScheme.TabIndex = 28;
            this.chkUseStandardAminoAcidCodingScheme.Text = "Use Standard Amino Acids";
            this.chkUseStandardAminoAcidCodingScheme.UseVisualStyleBackColor = true;
            this.chkUseStandardAminoAcidCodingScheme.CheckedChanged += new System.EventHandler(this.chkUseStandardAminoAcidCodingScheme_CheckedChanged);
            // 
            // txtSetOfAminoAcids
            // 
            this.txtSetOfAminoAcids.Location = new System.Drawing.Point(16, 91);
            this.txtSetOfAminoAcids.Multiline = true;
            this.txtSetOfAminoAcids.Name = "txtSetOfAminoAcids";
            this.txtSetOfAminoAcids.Size = new System.Drawing.Size(585, 81);
            this.txtSetOfAminoAcids.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Amino Acid Set";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSubjectPosition);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtSubjects);
            this.tabPage1.Controls.Add(this.txtPeptideWindowSize);
            this.tabPage1.Controls.Add(this.txtAnalysistName);
            this.tabPage1.Controls.Add(this.txtAnalysisDescription);
            this.tabPage1.Controls.Add(this.txtAnalysisTitile);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkIsSubjectMemberOfPeptide);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(617, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Project Profile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkIsSubjectMemberOfPeptide
            // 
            this.chkIsSubjectMemberOfPeptide.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsSubjectMemberOfPeptide.Checked = true;
            this.chkIsSubjectMemberOfPeptide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsSubjectMemberOfPeptide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsSubjectMemberOfPeptide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkIsSubjectMemberOfPeptide.Location = new System.Drawing.Point(14, 233);
            this.chkIsSubjectMemberOfPeptide.Name = "chkIsSubjectMemberOfPeptide";
            this.chkIsSubjectMemberOfPeptide.Size = new System.Drawing.Size(587, 47);
            this.chkIsSubjectMemberOfPeptide.TabIndex = 27;
            this.chkIsSubjectMemberOfPeptide.Text = resources.GetString("chkIsSubjectMemberOfPeptide.Text");
            this.chkIsSubjectMemberOfPeptide.UseVisualStyleBackColor = true;
            this.chkIsSubjectMemberOfPeptide.CheckedChanged += new System.EventHandler(this.chkIsSubjectMemberOfPeptide_CheckedChanged);
            // 
            // txtSubjectPosition
            // 
            this.txtSubjectPosition.Location = new System.Drawing.Point(427, 263);
            this.txtSubjectPosition.Name = "txtSubjectPosition";
            this.txtSubjectPosition.Size = new System.Drawing.Size(55, 20);
            this.txtSubjectPosition.TabIndex = 25;
            this.txtSubjectPosition.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(309, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Position In Peptide";
            // 
            // txtSubjects
            // 
            this.txtSubjects.Location = new System.Drawing.Point(140, 207);
            this.txtSubjects.Name = "txtSubjects";
            this.txtSubjects.Size = new System.Drawing.Size(461, 20);
            this.txtSubjects.TabIndex = 23;
            this.txtSubjects.Text = "S,T,Y";
            // 
            // txtPeptideWindowSize
            // 
            this.txtPeptideWindowSize.Location = new System.Drawing.Point(140, 181);
            this.txtPeptideWindowSize.Name = "txtPeptideWindowSize";
            this.txtPeptideWindowSize.Size = new System.Drawing.Size(55, 20);
            this.txtPeptideWindowSize.TabIndex = 22;
            this.txtPeptideWindowSize.Text = "10";
            // 
            // txtAnalysistName
            // 
            this.txtAnalysistName.Location = new System.Drawing.Point(140, 155);
            this.txtAnalysistName.Name = "txtAnalysistName";
            this.txtAnalysistName.Size = new System.Drawing.Size(461, 20);
            this.txtAnalysistName.TabIndex = 21;
            this.txtAnalysistName.Text = "Wajahat";
            // 
            // txtAnalysisDescription
            // 
            this.txtAnalysisDescription.Location = new System.Drawing.Point(140, 68);
            this.txtAnalysisDescription.Multiline = true;
            this.txtAnalysisDescription.Name = "txtAnalysisDescription";
            this.txtAnalysisDescription.Size = new System.Drawing.Size(461, 81);
            this.txtAnalysisDescription.TabIndex = 20;
            this.txtAnalysisDescription.Text = "This is test project";
            // 
            // txtAnalysisTitile
            // 
            this.txtAnalysisTitile.Location = new System.Drawing.Point(140, 42);
            this.txtAnalysisTitile.Name = "txtAnalysisTitile";
            this.txtAnalysisTitile.Size = new System.Drawing.Size(461, 20);
            this.txtAnalysisTitile.TabIndex = 19;
            this.txtAnalysisTitile.Text = "TestProject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Modification Sites";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Peptide Window Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Analysist Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Analysis Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Analysis Title";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 312);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnSelectProjectFile);
            this.tabPage4.Controls.Add(this.txtProjectPath);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(617, 286);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Project Path";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnSelectProjectFile
            // 
            this.btnSelectProjectFile.ImageIndex = 10;
            this.btnSelectProjectFile.ImageList = this.imageList1;
            this.btnSelectProjectFile.Location = new System.Drawing.Point(17, 147);
            this.btnSelectProjectFile.Name = "btnSelectProjectFile";
            this.btnSelectProjectFile.Size = new System.Drawing.Size(129, 29);
            this.btnSelectProjectFile.TabIndex = 31;
            this.btnSelectProjectFile.Text = "Save Project As";
            this.btnSelectProjectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectProjectFile.UseVisualStyleBackColor = true;
            this.btnSelectProjectFile.Click += new System.EventHandler(this.btnSelectProjectFile_Click);
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Location = new System.Drawing.Point(17, 60);
            this.txtProjectPath.Multiline = true;
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(585, 81);
            this.txtProjectPath.TabIndex = 30;
            this.txtProjectPath.Text = "C:\\Documents and Settings\\wajahat.PUMA\\My Documents\\Untitled.MAPRes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Save Project As";
            // 
            // openDlg
            // 
            this.openDlg.FileName = "openFileDialog1";
            this.openDlg.Filter = "XML Files|*.XML";
            // 
            // NewProjectWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 446);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Project Wizard";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnViewSelectedUSDDataset;
        private System.Windows.Forms.Button btnBrowerForUSDDataset;
        private System.Windows.Forms.Label lblUSDPath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtSetOfAminoAcids;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtSubjectPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubjects;
        private System.Windows.Forms.TextBox txtPeptideWindowSize;
        private System.Windows.Forms.TextBox txtAnalysistName;
        private System.Windows.Forms.TextBox txtAnalysisDescription;
        private System.Windows.Forms.TextBox txtAnalysisTitile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox chkUseStandardAminoAcidCodingScheme;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnSelectProjectFile;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog saveDlg;
        private System.Windows.Forms.OpenFileDialog openDlg;
        private System.Windows.Forms.CheckBox chkIsSubjectMemberOfPeptide;



    }
}