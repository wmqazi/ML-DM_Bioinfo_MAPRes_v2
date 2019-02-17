using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class ViewPreferredSitesWnd : Form
    {
        public ViewPreferredSitesWnd()
        {
            InitializeComponent();
            MdiParent = MAPresApplication.MainFrame;
            Text = MAPresApplication.Workspace.SelectedSubject + " -> Significantly Preferred Sites";
            foreach (Site s in MAPresApplication.Workspace.PreferrenceEstimationResultSet.PositivelyPreferredSites)
            {
                if(s.Residue != "-")
                    lstPositive.Items.Add(s.ToString());            
            }

            foreach (Site s in MAPresApplication.Workspace.PreferrenceEstimationResultSet.NegativelyPreferredSites)
            {
                if (s.Residue != "-")
                    this.lstNegative.Items.Add(s.ToString());
            }

            foreach (Site s in MAPresApplication.Workspace.PreferrenceEstimationResultSet.BothPositivelyAndNegativelyPreferredSites)
            {
                if (s.Residue != "-")
                    this.lstBoth.Items.Add(s.ToString());
            }

            lblBothCounts.Text = lstBoth.Items.Count.ToString();
            lblNegativeCount.Text = lstNegative.Items.Count.ToString();
            lblPositiveCounts.Text = lstPositive.Items.Count.ToString();
        }
    }
}