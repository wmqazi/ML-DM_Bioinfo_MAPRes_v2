using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class MAPResDatasetViewer : Form
    {
        private Stack<DataTable> dtFilterStack;
        private string mainText;
        
        public MAPResDatasetViewer()
        {
            InitializeComponent();
            dtFilterStack = new Stack<DataTable>();
        }

        private new void Show()
        {
            this.MdiParent = MAPresApplication.MainFrame;
            base.Show();
        }

        public void ShowUSD()
        {
            using (DataTable t = MAPresApplication.Workspace.GetUniversalSitesDataTable())
            {
                dataGridView1.DataSource = t;
                tslblRecordCount.Text = "Record Count : " + t.Rows.Count;
                mainText = "Universal Sites Dataset";
                Text = mainText;
                Show();
            }
        }

        public void ShowProteinDataSet()
        {
            using (DataTable t = MAPresApplication.Workspace.GetProteinsDataTable())
            {
                ShowDataTable(t,"->Proteins Dataset");
            }
        }

        public void ShowPeptideDataSet()
        {
            using (DataTable t = MAPresApplication.Workspace.GetPeptidesDataTable())
            {
                ShowDataTable(t,"->Peptides Dataset");
            }
        }

        public void ShowSiteDataSet()
        {
            using (DataTable t = MAPresApplication.Workspace.GetSitesDataTable())
            {
                ShowDataTable(t,"->Sites Dataset");
            }
        }

        private void MAPResDatasetViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose(true);
        }

        public void ShowDataTable(DataTable t, string title)
        {
            if (t == null)
            {
                MessageBox.Show("No Data in requested data table");
                return;
            }
            dataGridView1.DataSource = t;
            tslblRecordCount.Text = "Record Count : " + t.Rows.Count;
            mainText = MAPresApplication.Workspace.SelectedSubject + title;
            Text = mainText;
            Show();
        }

        public void ShowCombinedResults()
        {
            using (DataTable t = MAPresApplication.Workspace.GetCombinedResults())
            {
                //menuStripForCombinedDataSet.Visible = true;
                //menuStrip1.Visible = true;
                tsmnuCombinedRowFiltering.Visible = true;
                ShowDataTable(t,"->PreferrenceEstimation::AllResults Dataset");
            }
        }

        public void ShowPreferredSites()
        {
            using (DataTable t = MAPresApplication.Workspace.GetPreferredSites())
            {
                ShowDataTable(t, "->PreferrenceEstimation::PreferredSites Dataset");
            }
        }


        public void ShowS_PreferredSites()
        {
            using (DataTable t = MAPresApplication.Workspace.GetS_PreferredSites())
            {
                ShowDataTable(t, "->PreferrenceEstimation::SignificatlyPreferredSites Dataset");
            }
        }

        public void ShowObservedFrequency()
        {
            using (DataTable t = MAPresApplication.Workspace.GetObservedFrequency())
            {
                ShowDataTable(t, "->PreferrenceEstimation::ObservedFrequency% Dataset");
            }
        }

        public void ShowPercentageObservedFrequency()
        {
            using (DataTable t = MAPresApplication.Workspace.GetPercentageObservedFrequency())
            {
                ShowDataTable(t, "->PreferrenceEstimation::ObservedFrequency% Dataset");
            }
        }

        public void ShowObservedCount()
        {
            using (DataTable t = MAPresApplication.Workspace.GetObservedCount())
            {
                ShowDataTable(t, "->PreferrenceEstimation::ObservedCount Dataset");
            }
        }

        public void ShowExpectedFrequency()
        {
            using (DataTable t = MAPresApplication.Workspace.GetExpectedFrequency())
            {
                ShowDataTable(t, "->PreferrenceEstimation::ExpectedFrequency Dataset");
            }
        }

        public void ShowExpectedCount()
        {
            using (DataTable t = MAPresApplication.Workspace.GetExpectedCount())
            {
                ShowDataTable(t, "->PreferrenceEstimation::ExpectedCount Dataset");
            }
        }

        public void ShowPercentageExpectedFrequency()
        {
            using (DataTable t = MAPresApplication.Workspace.GetPercentageExpectedFrequency())
            {
                ShowDataTable(t, "->PreferrenceEstimation::ExpectedFrequency% Dataset");
            }
        }

        public void ShowCountPerAminoAcid()
        {
            using (DataTable t = MAPresApplication.Workspace.GetCountPerAminoAcid())
            {
                ShowDataTable(t, "->PreferrenceEstimation::CountPerAminoAcid Dataset");
            }
        }

        public void ShowDeviationParameters()
        {
            using (DataTable t = MAPresApplication.Workspace.GetDeviationParameters())
            {
                ShowDataTable(t, "->PreferrenceEstimation::DeviationParameter Dataset");
            }
        }

        public void ShowDOEC()
        {
            using (DataTable t = MAPresApplication.Workspace.GetDOEC())
            {
                ShowDataTable(t, "->PreferrenceEstimation::DOEC Dataset");
            }
        }

        public void ShowSigma()
        {
            using (DataTable t = MAPresApplication.Workspace.GetSigma())
            {
                ShowDataTable(t, "->PreferrenceEstimation::Sigma Dataset");
            }
        }


        public void ShowAllAssociationRules()
        {
            using (DataTable t = MAPresApplication.Workspace.GetAllAssociationRules())
            {
                ShowDataTable(t, "->Association Rules");
            }
        }

        public void ShowAminoAcidsAndPreferredPositions()
        {
            using (DataTable t = MAPresApplication.Workspace.GetAminoAcidsAndSignificantlyPreferredPositions())
            {
                ShowDataTable(t, "->PreferrenceEstimation::Amino Acids and Corresponding Significant Preferred Positions Dataset");
            }
        }

        private void filterForPositiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter("[S-Preferred] = '1'");
        }


        private void ApplyFilter(string criteria)
        {
            DataTable t = ((DataTable)this.dataGridView1.DataSource);
            if(t.ExtendedProperties.Contains("Title") == false)
                t.ExtendedProperties.Add("Title", Text);
            else
                t.ExtendedProperties["Title"] = Text;
            
            dtFilterStack.Push(t);
            DataRow[] rows = t.Select(criteria);
            using (DataTable tmp = t.Clone())
            {
                foreach (DataRow r in rows)
                    tmp.ImportRow(r);
                
                ShowDataTable(tmp,Text + "-> Filter (" + criteria + ")");
            }
        }

        private void removeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }
        private void RemoveFilter()
        {
            if (dtFilterStack.Count > 0)
            {
                using (DataTable t = dtFilterStack.Pop())
                {
                    string text = t.ExtendedProperties["Title"].ToString();
                    ShowDataTable(t, text);
                }
            }
        }

        private void RemoveAllFilters()
        {
            if (dtFilterStack.Count > 0)
            {
                using (DataTable t = (dtFilterStack.ToArray())[dtFilterStack.Count-1]) 
                {
                    
                    dtFilterStack.Clear();
                    string text = t.ExtendedProperties["Title"].ToString();
                    ShowDataTable(t, text);
                }
            }
        }

        private void removeAllFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllFilters();
        }

        private void filterForNegativelyPreferredSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter("[S-Preferred] = '-1'");
        }

        private void txtCombinedCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter(txtCombinedCriteria.Text);
                txtCombinedCriteria.Text = "";
            }
        }

        private void txtCombinedCriteria_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            ExportCurrentDataTableAsXML();
        }

        private void ExportCurrentDataTableAsXML()
        {
            saveDLG.ShowDialog(this);
            string fileName;
            fileName = saveDLG.FileName;
            if (fileName == "")
                return;

            DataTable t = ((DataTable)(this.dataGridView1.DataSource));
            t.WriteXml(fileName);
            t = null;
            MessageBox.Show("Data Export Completed");
        }

    }
}