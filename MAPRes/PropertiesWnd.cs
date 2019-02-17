using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class PropertiesWnd : Form
    {
        public PropertiesWnd()
        {
            InitializeComponent();
            this.MdiParent = MAPresApplication.MainFrame;
            MyInit();
        }

        private void MyInit()
        {
            Project project = MAPresApplication.Workspace._Project;
            lblAnalysisTitle.Text = project.AnalysisTitle;
            lblAnalysistName.Text = project.AnalysistName;
            txtAnalysisDescription.Text = project.AnalysisDescription;
            lblPeptideWindowSize.Text = project.SingleSidePeptideSize.ToString();
            lblSubjectsAreTheMemberOfPeptides.Text = project.SubjectPositionIsTheMemberOfPeptide.ToString();
            if (project.SubjectPositionIsTheMemberOfPeptide == true)
                lblSubjectPosition.Text = project.SubjectPosition.ToString();
            else
                lblSubjectPosition.Text = "None";
            string s = "";
            foreach(Subject sub in project.Subjects)
            {
                s = s + sub.SubjectName + ",";
            }
            s = s.Remove(s.Length - 1);
            lblTargetOfStudy.Text = s;

            txtAminoAcidSet.Text = project.SetOfAminoAcids;
            project = null;
        }
    }
}