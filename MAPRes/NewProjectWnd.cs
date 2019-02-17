using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class NewProjectWnd : Form
    {
        //<Declearation>
        private DataTable _usd;
        private bool _projectCreated;
        
        
        //</Declearation>
        public NewProjectWnd()
        {
            InitializeComponent();
            txtSetOfAminoAcids.Text = "A,C,D,E,F,G,H,I,K,L,M,N,P,Q,R,S,T,V,W,Y,-";
        }

        
        private void btnOK_Click(object sender, EventArgs e)
        {
            //check is native or not;
            bool isNative = true;
            using (FinalizeProjectWnd fpw = new FinalizeProjectWnd(this.txtProjectPath.Text, this.txtAnalysisTitile.Text, this.txtAnalysisDescription.Text, this.txtAnalysistName.Text, this.txtSubjects.Text, this.txtSetOfAminoAcids.Text, int.Parse(this.txtPeptideWindowSize.Text), int.Parse(this.txtSubjectPosition.Text), isNative, chkIsSubjectMemberOfPeptide.Checked, this._usd))
            {
                this.Enabled = false;
                fpw.Show(this);
                _projectCreated = fpw.CreateProject();
                this.Enabled = true;
                if (_projectCreated == false)
                    fpw.ShowErrors();
                else
                    CloseWindow();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you certain you want to exit IMSB MAPRes Project Creation Wizard?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _projectCreated = false;
                CloseWindow();
            }
        }

        private void CloseWindow()
        {
            this.Close();
        }

        private void btnSelectProjectFile_Click(object sender, EventArgs e)
        {
            saveDlg.Filter = "MAPRes Project Files (*.MAPRes)|*.MAPRes";
            saveDlg.ShowDialog(this);
            if (saveDlg.FileName == "")
                return;
            txtProjectPath.Text = saveDlg.FileName;
        }

        private void chkUseStandardAminoAcidCodingScheme_CheckedChanged(object sender, EventArgs e)
        {
            if( chkUseStandardAminoAcidCodingScheme.Checked == true )
                txtSetOfAminoAcids.Text = "A,C,D,E,F,G,H,I,K,L,M,N,P,Q,R,S,T,V,W,Y,-";
            else
                txtSetOfAminoAcids.Text = "";
        }

        private void btnBrowerForUSDDataset_Click(object sender, EventArgs e)
        {
            openDlg.ShowDialog(this);
            if (openDlg.FileName == "")
                return;

            lblUSDPath.Text = openDlg.FileName;
            DataSet ds = new DataSet();
            ds.ReadXml(lblUSDPath.Text);
            DataTableSelectorWnd dtsw = new DataTableSelectorWnd("Primary Site DataTable", ds);
            dtsw.ShowDialog(this);
            if(dtsw.TableName == "")
            {
                ds.Dispose();
            }
            else{
                if( _usd != null )
                    _usd.Dispose();
                _usd = ds.Tables[dtsw.TableName].Copy();
                ds.Dispose();
            }
            dtsw.Dispose();
            dtsw =null;
        }

        private void btnViewSelectedUSDDataset_Click(object sender, EventArgs e)
        {
            ShowUSDTable();   
        }

        private void btnPerformSubjectOrientedGroupingOnUSD_Click(object sender, EventArgs e)
        {
            if (_usd == null)
                return;
            if (_usd.Columns.Contains("ModificationSite") == false)
                _usd.Columns.Add("ModificationSite");
            ShowUSDTable();
        }

        private void ShowUSDTable()
        {
            if (_usd != null)
            {
                DataTableWnd dtw = new DataTableWnd(_usd, "Primary Sites Dataset [" + _usd.TableName + "]");
                dtw.ShowDialog(this);
                dtw.Dispose();
                dtw = null;
            }
        }

        private void chkIsSubjectMemberOfPeptide_CheckedChanged(object sender, EventArgs e)
        {
            txtSubjectPosition.Enabled = !txtSubjectPosition.Enabled;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        public bool ProjectCreated
        {
            get {
                return _projectCreated;   
            }
        }
        
    }
}