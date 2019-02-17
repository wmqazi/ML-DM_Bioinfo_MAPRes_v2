using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class MAPResWnd : Form
    {
        private readonly string TitleText;
        private MAPResDatasetViewer dsViewerWnd;

        public MAPResWnd()
        {
            InitializeComponent();
            using(AboutBox abox = new AboutBox())
            {
                TitleText = abox.AssemblyTitle;
                Text = TitleText;
            }
        }

        
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewProject();

        }

        private void CreateNewProject()
        {
            if (CloseProject() == false)
                return;

            using (NewProjectWnd npw = new NewProjectWnd())
            {
                npw.ShowDialog(this);
                if( npw.ProjectCreated == true )
                    ProjectOpened();
            }
        }

        private bool CloseProject()
        {
            if (MAPresApplication.Workspace.ProjectOpen == true )
            {
                if (MAPresApplication.Workspace.IsDirty == true)
                {
                    DialogResult dr = MessageBox.Show(this, "Do you want to save changes", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        MAPresApplication.Workspace.Save();
                        MAPresApplication.Workspace.Close();
                        ClearControls();
                        return true;
                    }
                    else if (dr == DialogResult.No)
                    {
                        MAPresApplication.Workspace.Close();
                        ClearControls();
                        return true;
                    }
                }
                else
                { 
                    //in case of workspace is not dirty then simply close the project
                    MAPresApplication.Workspace.Close();
                    ClearControls();
                    return true;
                }

                //becuase its confirm that user has selected cancel button
                return false;
            }

            //becuase if no project is loaded and operation can be performed.
            return true;
        }

        private void viewXMLDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void OpenXMLFile()
        {
            openDlg.Filter = "XML Files|*.XML";
            openDlg.ShowDialog(this);
            string filename = openDlg.FileName;
            if (filename == "")
                return;
            DataSet ds = new DataSet();
            ds.ReadXml(filename);
            DataTableWnd dtw = new DataTableWnd(ds);
            dtw.ShowAsMDIChild(this);
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseProject();
        }

        private void ClearControls()
        {
            cmbTargetsOfStudy.Text = "";
            cmbTargetsOfStudy.Items.Clear();
            Text = TitleText;
            toolStripStatusLabel1.Text = "";
            foreach (Form f in this.MdiChildren)
            {
                f.Dispose();
            }
        }

        

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void OpenProject()
        {
            openDlg.Filter = "MAPRes Project|*.MAPRes";
            openDlg.FileName = "";
            openDlg.ShowDialog(this);
            string fileName = openDlg.FileName;
            if (fileName == "")
                return;

            CloseProject();
            MAPresApplication.Workspace.Open(fileName);
            ProjectOpened();
        }

        private void tbtnNewProject_Click(object sender, EventArgs e)
        {
            CreateNewProject();
        }

        private void tbtnOpenExitingProject_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        public void ProjectOpened()
        {
            //this.Text = TitleText + "[" + MAPresApplication.Workspace.AnalysisTitle + "]";

            foreach (string s in MAPresApplication.Workspace.SubjectNames)
            {
                cmbTargetsOfStudy.Items.Add(s);
            }
            this.toolStripStatusLabel1.Text = "Project Path: " + MAPresApplication.Workspace.FileName;
        }

        private void primaryDatasetUniversalSitesDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dsViewerWnd = new MAPResDatasetViewer();
            dsViewerWnd.ShowUSD();
        }

        private void cmbTargetsOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAPresApplication.Workspace.SelectedSubject = cmbTargetsOfStudy.Text;
        }

        private void proteinsDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            dsViewerWnd = new MAPResDatasetViewer();
            dsViewerWnd.ShowProteinDataSet();
        }

        private void peptidesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            dsViewerWnd = new MAPResDatasetViewer();
            dsViewerWnd.ShowPeptideDataSet();
        }

        private void sitesDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            dsViewerWnd = new MAPResDatasetViewer();
            dsViewerWnd.ShowSiteDataSet();
        }

        

        private void RunPreferrenceEstimation()
        {
            using (PreferrenceEstimationWnd pewnd = new PreferrenceEstimationWnd())
            {
                pewnd.Show();
                MAPresApplication.Workspace.PerformPreferrenceEstimation(pewnd.OnPreferrenceEstimationProgressUpdate);
                MessageBox.Show("Preferrence Estimation Performed");
            }
        }


        private void RunPreferrenceEstimationOnAll()
        {
            PreferrenceEstimationWnd pewnd;
            foreach (string sub in MAPresApplication.Workspace.SubjectNames)
            {
                cmbTargetsOfStudy.Text = sub;
                MAPresApplication.Workspace.SelectedSubject = sub;
                using (pewnd = new PreferrenceEstimationWnd())
                {
                    pewnd.Show();
                    MAPresApplication.Workspace.PerformPreferrenceEstimation(pewnd.OnPreferrenceEstimationProgressUpdate);
                }
                Application.DoEvents();
            }
            MessageBox.Show("Preferrence Estimation Performed");
        }


        private void ShowAllPreferrenceEstimationTables()
        {

            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowCombinedResults();

            dtw = new MAPResDatasetViewer();
            dtw.ShowCountPerAminoAcid();

            dtw = new MAPResDatasetViewer();
            dtw.ShowDeviationParameters();

            dtw = new MAPResDatasetViewer();
            dtw.ShowDOEC();

            dtw = new MAPResDatasetViewer();
            dtw.ShowExpectedFrequency();

            dtw = new MAPResDatasetViewer();
            dtw.ShowObservedCount();

            dtw = new MAPResDatasetViewer();
            dtw.ShowObservedCount();

            dtw = new MAPResDatasetViewer();
            dtw.ShowObservedFrequency();

            dtw = new MAPResDatasetViewer();
            dtw.ShowPercentageExpectedFrequency();

            dtw = new MAPResDatasetViewer();
            dtw.ShowPercentageObservedFrequency();

            dtw = new MAPResDatasetViewer();
            dtw.ShowPreferredSites();

            dtw = new MAPResDatasetViewer();
            dtw.ShowS_PreferredSites();

            dtw = new MAPResDatasetViewer();
            dtw.ShowSigma();
        }

        private void combinedResultsAsSingleTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowCombinedResults();
        }

        private void observedFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowObservedFrequency();
        }

        private void observedFrequencyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowPercentageObservedFrequency();
        }

        private void observedCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowObservedCount();
        }

        private void expectedCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowExpectedCount();
        }

        private void expectedFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowExpectedFrequency();
        }

        private void expectedFrequencyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowPercentageExpectedFrequency();
        }

        private void dOECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowDOEC();
        }

        private void deviationParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowDeviationParameters();
        }

        private void sigmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowSigma();
        }

        private void preferredSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Select Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowPreferredSites();
        }

        private void sigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowS_PreferredSites();
        }

        private void openAllDataSetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ShowAllPreferrenceEstimationTables();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            DialogResult r;
            r = MessageBox.Show("Do you want to save the project", "MAPRes Saving Option", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                MAPresApplication.Workspace.Save();    
            }
        }

        private void MAPResWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseProject();
        }

        private void runAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AssociationRulesMiningWnd armwnd = new AssociationRulesMiningWnd();
            Save();
            armwnd.Show();
        }

        private void significantlyPreferredSitesPositiveNegativeAndBothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ViewPreferredSitesWnd vpswnd = new ViewPreferredSitesWnd();
            vpswnd.Show();
        }

        
        private void runPreferrenceExtimationAnalysisOnSelectedSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RunPreferrenceEstimation();
            Save();
        }

        private void associationRulesWithAllSupportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void aminoAcidsAndPreferredPositonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTargetsOfStudy.Text == "")
            {
                MessageBox.Show(this, "Select Modification Site", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MAPresApplication.Workspace.SubjectsHash.ContainsKey(cmbTargetsOfStudy.Text) == false)
            {
                MessageBox.Show(this, "Selected Modification Site is not a valid", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowAminoAcidsAndPreferredPositions();
        }

        private void subjectOrientedSitesDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folder = GetFolderToExport();
            if (folder == "")
                return;

            MAPresApplication.Workspace.ExportSitesTo(folder);
            MessageBox.Show("Sites Data Exported");
        }

        private string GetFolderToExport()
        {
            folderBrowserDialog.ShowDialog(this);
            return folderBrowserDialog.SelectedPath;
        }

        private void proteinDatasetAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folder = GetFolderToExport();
            if (folder == "")
                return;

            MAPresApplication.Workspace.ExportProteinsTo(folder);
            MessageBox.Show("Proteins Data Exported");
        }

        private void peptideDatasetAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folder = GetFolderToExport();
            if (folder == "")
                return;

            MAPresApplication.Workspace.ExportPeptidesTo(folder);
            MessageBox.Show("Peptides Data Exported");
        }

        private void associationRulesAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folder = GetFolderToExport();
            if (folder == "")
                return;

            if (MAPresApplication.Workspace.ExportAssociationRulesTo(folder) == false)
                MessageBox.Show("Canot Export. First perform association rules mining");
            else
                MessageBox.Show("Association Rules Exported");
        }

        private void preferrenceAnalysisResultAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folder = GetFolderToExport();
            if (folder == "")
                return;

            if (MAPresApplication.Workspace.ExportPreferrenceEstimationResultsTo(folder) == false)
                MessageBox.Show("Cannot Export. First perform preferrence estimation");
            else
                MessageBox.Show("Preferrence Estimation Results Exported");
        }

        private void fullProjectAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string folder = GetFolderToExport();
            if (folder == "")
                return;
            MAPresApplication.Workspace.ExportAll(folder);
            MessageBox.Show("Project Completed Exported");
        }

        private void fullProjectAsMSAccess2003DatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not enabled in this version");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenXMLFile();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox abtbox = new AboutBox())
            {
                abtbox.ShowDialog(this);
            }

        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProperties();
        }

        private void ShowProperties()
        {
            PropertiesWnd pwnd = new PropertiesWnd();
            pwnd.Show();
        }

        
        
        private void associationRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowAllAssociationRules();
        }

        private void tbtnViewListofModificationSitewithS_PreferredSites_Click(object sender, EventArgs e)
        {
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DataTable dtSummary = null;

            PreferrenceEstimationSummaryManagerWnd smwnd = new PreferrenceEstimationSummaryManagerWnd();
            smwnd.MdiParent = this;
            smwnd.Show();
            dtSummary = smwnd.CreateSummary();
            smwnd.Close();
            smwnd.Dispose();
            smwnd = null;

            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowDataTable(dtSummary, "Preferrence Estimation Summary");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Combined all results of all modification sites into single table
            if (MAPresApplication.Workspace.ProjectOpen == false)
            {
                MessageBox.Show(this, "Please open or create new project", "IMSB MAPRes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtCombined = null;

            PreferrenceEstimationSummaryManagerWnd smwnd = new PreferrenceEstimationSummaryManagerWnd();
            smwnd.MdiParent = this;
            smwnd.Show();
            dtCombined = smwnd.CreateCombinedPreferrenceEstimationResultSet();
            smwnd.Close();
            smwnd.Dispose();
            smwnd = null;

            MAPResDatasetViewer dtw = new MAPResDatasetViewer();
            dtw.ShowDataTable(dtCombined, "All Modification Site's Preferrence Estimation Result");

        }

        
    }
}