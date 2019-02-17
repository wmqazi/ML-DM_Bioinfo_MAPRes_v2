namespace MAPRes
{
    partial class AssociationRulesMiningWnd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.armProgress = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.genProgress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkVariantSupport = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinSupportLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoBoth = new System.Windows.Forms.RadioButton();
            this.rdoNegative = new System.Windows.Forms.RadioButton();
            this.rdoPositive = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunDiscovery = new System.Windows.Forms.Button();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGeneration);
            this.groupBox1.Controls.Add(this.armProgress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.genProgress);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 87);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Progress";
            // 
            // armProgress
            // 
            this.armProgress.Location = new System.Drawing.Point(7, 63);
            this.armProgress.Name = "armProgress";
            this.armProgress.Size = new System.Drawing.Size(376, 14);
            this.armProgress.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Generation:";
            // 
            // genProgress
            // 
            this.genProgress.Location = new System.Drawing.Point(7, 31);
            this.genProgress.Name = "genProgress";
            this.genProgress.Size = new System.Drawing.Size(376, 14);
            this.genProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.genProgress.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 48);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(377, 12);
            this.lblStatus.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkVariantSupport);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMinSupportLevel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.rdoBoth);
            this.groupBox2.Controls.Add(this.rdoNegative);
            this.groupBox2.Controls.Add(this.rdoPositive);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 124);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // chkVariantSupport
            // 
            this.chkVariantSupport.AutoSize = true;
            this.chkVariantSupport.Location = new System.Drawing.Point(233, 99);
            this.chkVariantSupport.Name = "chkVariantSupport";
            this.chkVariantSupport.Size = new System.Drawing.Size(150, 17);
            this.chkVariantSupport.TabIndex = 8;
            this.chkVariantSupport.Text = "Use Variant Support Level";
            this.chkVariantSupport.UseVisualStyleBackColor = true;
            this.chkVariantSupport.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(199, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "%";
            // 
            // txtMinSupportLevel
            // 
            this.txtMinSupportLevel.Location = new System.Drawing.Point(112, 97);
            this.txtMinSupportLevel.Name = "txtMinSupportLevel";
            this.txtMinSupportLevel.Size = new System.Drawing.Size(81, 20);
            this.txtMinSupportLevel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Min. Support Level";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(13, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 13);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // rdoBoth
            // 
            this.rdoBoth.AutoSize = true;
            this.rdoBoth.Location = new System.Drawing.Point(13, 55);
            this.rdoBoth.Name = "rdoBoth";
            this.rdoBoth.Size = new System.Drawing.Size(233, 17);
            this.rdoBoth.TabIndex = 3;
            this.rdoBoth.TabStop = true;
            this.rdoBoth.Text = "Both (Positive And Negative) Preferred Sites";
            this.rdoBoth.UseVisualStyleBackColor = true;
            // 
            // rdoNegative
            // 
            this.rdoNegative.AutoSize = true;
            this.rdoNegative.Location = new System.Drawing.Point(160, 32);
            this.rdoNegative.Name = "rdoNegative";
            this.rdoNegative.Size = new System.Drawing.Size(147, 17);
            this.rdoNegative.TabIndex = 2;
            this.rdoNegative.TabStop = true;
            this.rdoNegative.Text = "Negatively Preferred Sites";
            this.rdoNegative.UseVisualStyleBackColor = true;
            // 
            // rdoPositive
            // 
            this.rdoPositive.AutoSize = true;
            this.rdoPositive.Location = new System.Drawing.Point(13, 32);
            this.rdoPositive.Name = "rdoPositive";
            this.rdoPositive.Size = new System.Drawing.Size(141, 17);
            this.rdoPositive.TabIndex = 1;
            this.rdoPositive.TabStop = true;
            this.rdoPositive.Text = "Positively Preferred Sites";
            this.rdoPositive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Perform Association Rules Mining Using";
            // 
            // btnRunDiscovery
            // 
            this.btnRunDiscovery.Image = global::MAPRes.Properties.Resources.BD14565_;
            this.btnRunDiscovery.Location = new System.Drawing.Point(314, 235);
            this.btnRunDiscovery.Name = "btnRunDiscovery";
            this.btnRunDiscovery.Size = new System.Drawing.Size(92, 33);
            this.btnRunDiscovery.TabIndex = 19;
            this.btnRunDiscovery.Text = "&Run";
            this.btnRunDiscovery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunDiscovery.UseVisualStyleBackColor = true;
            this.btnRunDiscovery.Click += new System.EventHandler(this.btnRunDiscovery_Click);
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneration.Location = new System.Drawing.Point(81, 16);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(0, 13);
            this.lblGeneration.TabIndex = 7;
            // 
            // AssociationRulesMiningWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 275);
            this.Controls.Add(this.btnRunDiscovery);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AssociationRulesMiningWnd";
            this.Text = "Association Rules Mining";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AssociationRulesMiningWnd_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar genProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoPositive;
        private System.Windows.Forms.RadioButton rdoBoth;
        private System.Windows.Forms.RadioButton rdoNegative;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinSupportLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkVariantSupport;
        private System.Windows.Forms.ProgressBar armProgress;
        private System.Windows.Forms.Button btnRunDiscovery;
        private System.Windows.Forms.Label lblGeneration;

    }
}