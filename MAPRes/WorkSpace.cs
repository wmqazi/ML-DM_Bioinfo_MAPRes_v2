using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MAPRes
{
    partial class WorkSpace : IDisposable
    {
        private Project project;


        private string _fileName;
        private bool _isOpened;
        private bool _disposed = false;

        private string _analysisTitle;
        private string _analysisDescription;
        private string _analysistName;
        private string[] _setOfAminoAcids;
        private string[] _subjects;
        
        private bool _subjectPositionIsTheMemberOfPeptide;
        private int _singleSidePeptideSize;
        private int _subjectPosition;
        private string _selectedSubject;
        private bool _isDirty = false;
        private Dictionary<string, Subject>_subjectsHash; 
        

        
        private  void LoadProjectInWorkspace()
        {

//            _analysisDescription = project.AnalysisDescription;
//            _analysisTitle = project.AnalysisTitle;
//            _analysistName = project.AnalysistName;
            _subjectPosition = project.SubjectPosition;

            string sep = ",";
            _setOfAminoAcids = project.SetOfAminoAcids.Split(sep.ToCharArray());
            _subjectPositionIsTheMemberOfPeptide = project.SubjectPositionIsTheMemberOfPeptide;
            _singleSidePeptideSize = project.SingleSidePeptideSize;
            
            SubjectsHash = new Dictionary<string, Subject>(project.Subjects.Count);

            _subjects = new string[project.Subjects.Count];
            for(int i = 0; i < project.Subjects.Count; i++)
            {
                _subjects[i] = project.Subjects[i].SubjectName;
                SubjectsHash.Add(_subjects[i], project.Subjects[i]);
            }
            
            _isOpened = true;
        }

        public  bool ProjectOpen
        {
            get
            {
                return _isOpened;
            }
        }
        public Project _Project
        {
            get {
                return project;
            }
        }

        public void NewProject(Project newProject)
        {
            _fileName = newProject.FileName;
            project = newProject;
            LoadProjectInWorkspace(); 
        }

        public void Open(string fileName)
        {
            _fileName = fileName;
            project = new Project();
            project.Open(fileName);
            LoadProjectInWorkspace(); 
        }

        public void Close()
        {
            _isOpened = false;
            _fileName = "";
            _analysisTitle = "";
            _analysisDescription = "";
            _analysistName = "";
            _setOfAminoAcids = null;
            _subjects = null; ;
            _selectedSubject = null;
        }

        public void Save()
        {
            
            project.Save(_fileName);
            _isDirty = false;
        }

        public bool IsDirty
        {
            get {
                return this._isDirty;
            }
        }

        public void SaveAs(string fileName)
        {
            _fileName = fileName;
            project.Save(_fileName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                if (_isOpened == true)
                    Close();
                _disposed = true;
            }
        }

        ~WorkSpace()
        {
            Dispose(false);
        }


        public string FileName
        {
            get {
                return _fileName;
            }
        }

        public string[] SubjectNames
        {
            get
            {
                return _subjects;
            }
        }

        public DataTable GetSitesDataTable()
        {
            return SubjectsHash[SelectedSubject].SitesDataTable;                                   
        }

        public DataTable GetProteinsDataTable()
        {

            return SubjectsHash[SelectedSubject].ProteinDataTable;
        }

        public DataTable GetPeptidesDataTable()
        {

            return SubjectsHash[SelectedSubject].PeptideDataTable; 
        }

        public DataTable GetUniversalSitesDataTable()
        {

            return project.UniversalSiteDataSet;
        }

        public DataTable GetCombinedResults()
        {
            if (SubjectsHash[SelectedSubject].PreferredSitesDataTable == null)
                return null;
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.CombinedResult;
        }

        public DataTable GetPreferredSites()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.PreferredSites;
        }

        public DataTable GetS_PreferredSites()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.S_PreferredSites;
        }

        public DataTable GetObservedFrequency()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.ObserveredFrequency;
        }

        public DataTable GetPercentageObservedFrequency()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.PercentageObserveredFrequency;
        }

        public DataTable GetObservedCount()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.ObserveredCount;
        }

        public DataTable GetExpectedFrequency()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.ExpectedFrequency;
        }

        public DataTable GetExpectedCount()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.ExpectedCount;
        }


        public DataTable GetPercentageExpectedFrequency()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.PercentageExpectedFrequency;
        }

        public DataTable GetCountPerAminoAcid()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.CountPerAminoAcid;
        }

        public DataTable GetDeviationParameters()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.DeviationParameter;
        }

        public DataTable GetDOEC()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.DOEC;
        }

        public DataTable GetSigma()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.Sigma;
        }

        public DataTable GetAllAssociationRules()
        {
            
            if(AssociationRulesMiningPerformed == false)
                return null;

            if (AssociationRules == null)
                return null;

            return AssociationRules.AllAssociationRule;
        }



        public string AnalysisTitle
        {
            get
            {
                return _analysisTitle;
            }
        }
        public string AnalysisDescription
        {
            get
            {
                return _analysisDescription;
            }
        }
        public string AnalysistName
        {
            get
            {
                return _analysistName;
            }
        }

        public bool SubjectPositionIsTheMemberOfPeptide
        {
            get
            {
                return _subjectPositionIsTheMemberOfPeptide;
            }
        }

        public int SingleSidePeptideSize
        {
            get
            {
                return _singleSidePeptideSize;
            }
        }

        public int SubjectPosition
        {
            get
            {
                return _subjectPosition;
            }
        }

        public string[] SetOfAminoAcid
        {
            get {
                return _setOfAminoAcids;
            }
        }

        private void PutDataTableToVirtualStorage(DataTable table, string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, table);
            formatter = null;
            stream.Close();
            stream.Dispose();
            stream = null;
        }

        private DataTable LoadDataTableFromVirtualStorage(string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            using (DataTable t = ((DataTable)formatter.Deserialize(stream)))
            {
                formatter = null;
                stream.Close();
                stream.Dispose();
                stream = null;
                return t;
            }
        }

        public void CloseLoadedDataTableFromVirtualStorage()
        {
        
        }

        public string SelectedSubject
        {
            set {
                _selectedSubject = value;
            }
            get {
                return _selectedSubject;
            }
        }


        public PreferrenceAnalysisResultSet PreferrenceEstimationResultSet
        {
            set {
                SubjectsHash[SelectedSubject].PreferredSitesDataTable = value;
            }
            get {
                return SubjectsHash[SelectedSubject].PreferredSitesDataTable;
            }
        }
        public int FirstPosition
        {
            get {
                return -1 * SingleSidePeptideSize;
            }
        }

        public int LastPosition
        {
            get
            {
                return SingleSidePeptideSize;
            }
        }


        public bool IsPreferrenceAvaibleForAllSubjects()
        {
            
            bool allPreferrence = true;
            foreach (Subject s in SubjectsHash.Values)
            {
                if (s.PreferredSitesDataTable == null)
                    allPreferrence = false;
            }

            return allPreferrence;
        }

        public Dictionary<string, Subject> SubjectsHash
        {
                set {
                    _subjectsHash = value;
                }
            get {
                return this._subjectsHash;
                }
        }

        public AssociationRulesResult AssociationRules
        {
            set {
                project.AssociationRules = value;
            }
            get 
            {
                return project.AssociationRules;
            }
        }

        public DataTable GetAminoAcidsAndSignificantlyPreferredPositions()
        {
            return SubjectsHash[SelectedSubject].PreferredSitesDataTable.AminoAcidsAndPreferredPositions;
        }

        public void ExportSitesTo(string path)
        {
            string subjectBookMark = SelectedSubject;
            foreach (string subject in SubjectNames)
            {
                SelectedSubject = subject;
                GetSitesDataTable().WriteXml(path + "\\" + subject + "_Sites.XML");
            }

            SelectedSubject = subjectBookMark;
        }


        public void ExportProteinsTo(string path)
        {
            string subjectBookMark = SelectedSubject;
            foreach (string subject in SubjectNames)
            {
                SelectedSubject = subject;
                GetProteinsDataTable().WriteXml(path + "\\" + subject + "_Proteins.XML");
            }

            SelectedSubject = subjectBookMark;
        }

        public void ExportPeptidesTo(string path)
        {
            string subjectBookMark = SelectedSubject;
            foreach (string subject in SubjectNames)
            {
                SelectedSubject = subject;
                GetPeptidesDataTable().WriteXml(path + "\\" + subject + "_Peptides.XML");
            }

            SelectedSubject = subjectBookMark;
        }

        public bool ExportAssociationRulesTo(string path)
        {
            if (AssociationRulesMiningPerformed == false)
                return false;
            GetAllAssociationRules().WriteXml(path + "\\AssociationRules.XML");
            return true;
        }

        public void ExportAll(string path)
        {
            ExportAssociationRulesTo(path);
            ExportPeptidesTo(path);
            ExportPreferrenceEstimationResultsTo(path);
            ExportProteinsTo(path);
            ExportSitesTo(path);
            ExportPeptidesTo(path);
        }

        public bool AssociationRulesMiningPerformed
        {
            get {
                return project.AssociationAnalysisPerformed;
            }
        }

        public bool PreferrenceEstimationPerformed
        {
            get {
                return project.PreferrenceEstimationPerformed;
            }        
        
        }

        public bool ExportPreferrenceEstimationResultsTo(string path)
        {
            if(PreferrenceEstimationPerformed == false)
                return false;

            string subjectBookMark = SelectedSubject;
            foreach (string subject in SubjectNames)
            {
                SelectedSubject = subject;
                GetAminoAcidsAndSignificantlyPreferredPositions().WriteXml(path + "\\" + subject + "_AminoAcidsAndSignificantlyPreferredPositions.XML");
                GetCombinedResults().WriteXml(path + "\\" + subject + "_CombinedResults.XML");
                GetCountPerAminoAcid().WriteXml(path + "\\" + subject + "_CountPerAminoAcid.XML");
                GetDeviationParameters().WriteXml(path + "\\" + subject + "_DeviationParameters.XML");
                GetDOEC().WriteXml(path + "\\" + subject + "_DOEC.XML");
                GetExpectedCount().WriteXml(path + "\\" + subject + "_ExpectedCount.XML");
                GetExpectedFrequency().WriteXml(path + "\\" + subject + "_ExpectedFrequency.XML");
                GetObservedCount().WriteXml(path + "\\" + subject + "_ObservedCount.XML");
                GetObservedFrequency().WriteXml(path + "\\" + subject + "_ObservedFrequency.XML");
                GetPercentageExpectedFrequency().WriteXml(path + "\\" + subject + "_PercentageExpectedFrequency.XML");
                GetPercentageObservedFrequency().WriteXml(path + "\\" + subject + "_PercentageObservedFrequency.XML");
                GetPreferredSites().WriteXml(path + "\\" + subject + "_PreferredSites.XML");
                GetProteinsDataTable().WriteXml(path + "\\" + subject + "_ProteinsDataTable.XML");
                GetS_PreferredSites().WriteXml(path + "\\" + subject + "_S_PreferredSites.XML");
                GetSigma().WriteXml(path + "\\" + subject + "_Sigma.XML");
            }

            SelectedSubject = subjectBookMark;
            return true;
        }
    }
}
