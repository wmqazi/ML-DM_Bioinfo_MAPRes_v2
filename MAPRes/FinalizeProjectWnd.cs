using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAPRes
{
    public partial class FinalizeProjectWnd : Form
    {
        private NewProjectWizard _npw;
        private string _filename;
        private bool _cancelByUser = false;
        
        public FinalizeProjectWnd(string filename, string analysisTitle, string analysisDescription,
                                    string analysistName, string subjects,
                                    string setOfAminoAcids, int singleSidePeptideSize,
                                    int subjectPosition, bool isUSDNative,bool subjectPositionIsTheMemberOfPeptide, DataTable usd)
        {
            _npw = new NewProjectWizard(analysisTitle, analysisDescription,
                                        analysistName, subjects,
                                        setOfAminoAcids, singleSidePeptideSize,
                                        subjectPosition, subjectPositionIsTheMemberOfPeptide,isUSDNative, usd);
            
            InitializeComponent();
            _filename = filename;
            
        }

        public bool CancledByUser
        {
            get {
                return _cancelByUser;
            }
        }
        
        public bool CreateProject()
        {
            //Step 1: Verify Project Profile to see that all required parameters are given and are in correct format.
            VerifyProjectProfile();
            if (_npw.HasError == true)
            {
                return false;
            }

            //Step 2: Apply Transformation Rules
            ApplyTransformation();
            if (_npw.HasError == true)
            {
                return false;
            }

            //Step 3: Generate Subject Oritented Site Datasets
            GenerateSubjectOritentedSiteDatasets();
            if (_npw.HasError == true)
            {
                return false;
            }

            //Step 4: Generate Subject Oritented Protein Datasets
            GenerateSubjectOritentedProteinDatasets();
            if (_npw.HasError == true)
            {
                return false;
            }

            //Step 5: Generate Subject Oritented Peptide Datasets
            GenerateSubjectOritentedPeptideDatasets();
            if (_npw.HasError == true)
            {
                return false;
            }
            
            //Step 6: Write Project Configuration (Save Project)
            SaveProject();
            if (_npw.HasError == true)
            {
                return false;
            }

            return !_npw.HasError; //if errors = true then return false becuase project was not created due to errors
        
        }

        //Step 1: Verify Project Profile to see that all required parameters are given and are in correct format.
        private void VerifyProjectProfile()
        {
            imglblVerifyingProjectProfile.Visible = true;
            Application.DoEvents();
            _npw.VerifyProjectProfile();
            imglblVerifyingProjectProfile.ImageIndex = 0;
            Application.DoEvents();
        }

        //Step 2: Apply Transformation Rules
        private void ApplyTransformation()
        {
            this.imglblApplyTransformationRule.Visible = true;
            Application.DoEvents();
            _npw.ApplyTransformation();
            this.imglblApplyTransformationRule.ImageIndex = 0;
            Application.DoEvents();
        }

        //Step 3: Generate Subject Oritented Site Datasets
        private void GenerateSubjectOritentedSiteDatasets()
        {
            this.imglblGeneratingSubjectOrientedSitesDatasets.Visible = true;
            Application.DoEvents();
            _npw.GenerateSubjectOritentedSiteDatasets();
            this.imglblGeneratingSubjectOrientedSitesDatasets.ImageIndex = 0;
            Application.DoEvents();
        }
    

        //Step 4: Generate Subject Oritented Protein Datasets
        private void GenerateSubjectOritentedProteinDatasets()
        {
            this.imglblGeneratingSubjectOrientedProteinDatasets.Visible = true;
            Application.DoEvents();
            _npw.GenerateSubjectOritentedProteinDatasets();
            this.imglblGeneratingSubjectOrientedProteinDatasets.ImageIndex = 0;
            Application.DoEvents();
        }

        //Step 5: Generate Subject Oritented Peptide Datasets
        private void GenerateSubjectOritentedPeptideDatasets()
        {
            this.imglblGenerateSubjectOrientedPeptideDatasets.Visible = true;
            Application.DoEvents();
            _npw.GenerateSubjectOritentedPeptideDatasets();
            this.imglblGenerateSubjectOrientedPeptideDatasets.ImageIndex = 0;
            Application.DoEvents();
        }

        //Step 6: Write Project Configuration (Save Project)
        private void SaveProject()
        {
            this.imglblWritingProjectConfiguration.Visible = true;
            Application.DoEvents();
            Project project = new Project();
            project.Create(_filename,_npw.AnalysisTitle, _npw.AnalysisDescription, _npw.AnalysistName, _npw.SetOfAminoAcids, _npw.SingleSidePeptideSize, _npw.SubjectPosition,_npw.SubjectPositionIsTheMemberOfPeptide, _npw.Subjects, _npw.UniversalSiteDataSet);
            MAPresApplication.Workspace.NewProject(project);
            project = null;
            this.imglblWritingProjectConfiguration.ImageIndex = 0;
            Application.DoEvents();
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you certain you want to exit IMSB MAPRes Project Creation Wizard?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this._cancelByUser = true;
                CloseWindow();
            }
        }

        private void CloseWindow()
        {
            this.Close();
        }

        public void ShowErrors()
        {
            string totalErrors = _npw.ErrorMessages.Count.ToString();
            string error_message;
            for(int i = 1; i <= _npw.ErrorMessages.Count; i++)
            {
                error_message = "[" + i.ToString() + "/" + totalErrors + "]" + _npw.ErrorMessages[i-1];
                MessageBox.Show(error_message);
            }
            _npw.ClearErrorStatus();

        }
    }
}