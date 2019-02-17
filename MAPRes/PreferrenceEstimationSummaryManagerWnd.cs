using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class PreferrenceEstimationSummaryManagerWnd : Form
    {
        public PreferrenceEstimationSummaryManagerWnd()
        {
            InitializeComponent();
        }

        public DataTable CreateSummary()
        {
            string bookmark;
            bookmark = MAPresApplication.Workspace.SelectedSubject;
            
            DataTable dtSummary = new DataTable("Preferrence Estimation Summary");
            dtSummary.Columns.Add("Modification Site");
            dtSummary.Columns.Add("Number of Peptides");
            dtSummary.Columns.Add("Number of Proteins");
            dtSummary.Columns.Add("Number of Positively Preferred Sites");
            dtSummary.Columns.Add("List of Positively Preferred Sites");
            dtSummary.Columns.Add("Number of Negatively Preferred Sites");
            dtSummary.Columns.Add("List of Negatively Preferred Sites");
            int index;
            DataRow newRow;
            string selectedSubject;
            float TotalModificationSites = MAPresApplication.Workspace.SubjectNames.Length;
            for(index = 0; index < TotalModificationSites; index++)
            {
                selectedSubject = MAPresApplication.Workspace.SubjectNames[index];
                MAPresApplication.Workspace.SelectedSubject = selectedSubject;
                newRow = dtSummary.NewRow();
                newRow["Modification Site"] = selectedSubject;
                newRow["Number of Peptides"] = MAPresApplication.Workspace.SubjectsHash[selectedSubject].PeptideDataTable.Rows.Count;
                newRow["Number of Proteins"] = MAPresApplication.Workspace.SubjectsHash[selectedSubject].ProteinDataTable.Rows.Count;
                newRow["Number of Positively Preferred Sites"] =    MAPresApplication.Workspace.PreferrenceEstimationResultSet.PositivelyPreferredSites.Count;
                newRow["List of Positively Preferred Sites"] =      ListToString(MAPresApplication.Workspace.PreferrenceEstimationResultSet.PositivelyPreferredSites);
                newRow["Number of Negatively Preferred Sites"] =    MAPresApplication.Workspace.PreferrenceEstimationResultSet.NegativelyPreferredSites.Count;
                newRow["List of Negatively Preferred Sites"] = ListToString(MAPresApplication.Workspace.PreferrenceEstimationResultSet.NegativelyPreferredSites);
                dtSummary.Rows.Add(newRow);
                progressBar1.Value = ((int)((index+1)/TotalModificationSites) * 100);
                Application.DoEvents();
            }
            MAPresApplication.Workspace.SelectedSubject = bookmark;
            return dtSummary;
        }

        private string ListToString(List<Site> list)
        {
            StringBuilder s = new StringBuilder();
            foreach (Site site in list)
            {
                s.Append(site.ToString());
                s.Append(";");
            }
            return s.ToString();   
        }

        public DataTable CreateCombinedPreferrenceEstimationResultSet()
        {
            string bookmark;
            bookmark = MAPresApplication.Workspace.SelectedSubject;
            MAPresApplication.Workspace.SelectedSubject = MAPresApplication.Workspace.SubjectNames[0];
            DataTable dtComnined = new DataTable("All Modification Sites Preferrence Estimation Results");
            dtComnined = MAPresApplication.Workspace.PreferrenceEstimationResultSet.CombinedResult.Clone();
            
            int index;
            DataRow row;
            int ctr;
            string selectedSubject;
            float TotalModificationSites = MAPresApplication.Workspace.SubjectNames.Length;
            DataTable dt;
            for (index = 0; index < TotalModificationSites; index++)
            {
                selectedSubject = MAPresApplication.Workspace.SubjectNames[index];
                
                MAPresApplication.Workspace.SelectedSubject = selectedSubject;

                dt = MAPresApplication.Workspace.PreferrenceEstimationResultSet.CombinedResult;
                for (ctr = 0; ctr < dt.Rows.Count; ctr++)
                {
                    row = dt.Rows[ctr];
                    dtComnined.ImportRow(row);
                }
                progressBar1.Value = ((int)((index + 1) / TotalModificationSites) * 100);
                Application.DoEvents();
            }
            MAPresApplication.Workspace.SelectedSubject = bookmark;
            return dtComnined;

        }
    }
}