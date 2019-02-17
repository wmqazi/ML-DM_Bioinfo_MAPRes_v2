using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class AssociationRulesMiningWnd : Form
    {
        private AssociationRulesMiningProgressArg progressStatus;
      
        public AssociationRulesMiningWnd()
        {
            InitializeComponent();
            this.MdiParent = MAPresApplication.MainFrame;
                        
        }

        private void AssociationRulesMiningWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void btnRunDiscovery_Click(object sender, EventArgs e)
        {
            RunAssociationRulesMining();
        }

        private void RunAssociationRulesMining()
        {

            TypeOfPreferrence typeOfPreferrence = TypeOfPreferrence.Both_PositiveAndNegativePreferrence;

            if (rdoPositive.Checked == true)
                typeOfPreferrence = TypeOfPreferrence.PositivePreferrence;
            else
                if (rdoNegative.Checked == true)
                    typeOfPreferrence = TypeOfPreferrence.NegativePreferrence;
                else
                    if (rdoBoth.Checked == true)
                        typeOfPreferrence = TypeOfPreferrence.Both_PositiveAndNegativePreferrence;

            float supportlevel = float.Parse(txtMinSupportLevel.Text);
            MAPresApplication.Workspace.PerformAssociationRulesMining(OnAssociationRuleMiningProgress, typeOfPreferrence, supportlevel, false);
            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowAllAssociationRules();
            Dispose();
            
        }

        private void OnAssociationRuleMiningProgress(object sender, EventArgs e)
        { 
            progressStatus = ((AssociationRulesMiningProgressArg)e);
            lblGeneration.Text = progressStatus.GenerationNo.ToString();
            lblStatus.Text = progressStatus.status + ": " + progressStatus.Progress.ToString();
            armProgress.Value = (int)progressStatus.Progress;
            genProgress.Value = (int)progressStatus.Progress;
            Text = progressStatus.TargetOfStudy;
            Application.DoEvents();
        }
        
    }

}