using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class PreferrenceEstimationWnd : Form
    {
        private PreferrenceEstimationEventArgs progressStatus;
        public PreferrenceEstimationWnd()
        {
            InitializeComponent();
            this.Owner = MAPresApplication.MainFrame;
        }

        

        public void OnPreferrenceEstimationProgressUpdate(object sender, EventArgs e)
        {
            progressStatus = (PreferrenceEstimationEventArgs)e;
            lblStatus.Text = progressStatus.Status;
            progressBar1.Value = progressStatus.Progress;
            Text = progressStatus.TargetOfStudy;
            progressStatus = null;
            Application.DoEvents();   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }

}