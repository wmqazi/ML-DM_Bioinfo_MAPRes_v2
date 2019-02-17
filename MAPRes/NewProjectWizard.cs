using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Bioinformatics.Tools;

namespace MAPRes
{
    class NewProjectWizard : IDisposable 
    {
        private string  _analysisTitle;
        private string  _analysisDescription;
        private string  _analysistName;
        private string  _subjects;
        private string  _setOfAminoAcids;

        private int     _singleSidePeptideSize;
        private int     _subjectPosition;
        private bool    _subjectPositionIsTheMemberOfPeptide;
        private bool    _isUSDNative;
        private DataTable _usd;
        private List<Subject> _lstSubjects;
        private List<string>  _errorMessages;
        private string[] subjects;
        private int numberOfSujects;
        
        //******************** Constructors, Destructors & Dispose Methods ********************
        public NewProjectWizard(string analysisTitle, string analysisDescription,
                                string analysistName, string subject,
                                string setOfAminoAcids, int singleSidePeptideSize,
                                int subjectPosition, bool subjectPositionIsTheMemberOfPeptide, bool isUSDNative, DataTable usd)
        {
            _analysisTitle = analysisTitle;
            _analysisDescription = analysisDescription;
            _analysistName = analysistName;
            _subjects = subject;
            _setOfAminoAcids = setOfAminoAcids;
            _singleSidePeptideSize = singleSidePeptideSize;
            _subjectPosition = subjectPosition;
            _subjectPositionIsTheMemberOfPeptide = subjectPositionIsTheMemberOfPeptide;
            _isUSDNative = isUSDNative;
            _usd = usd;

            _errorMessages = new List<string>();

            char[] sep = new char[1];
            sep[0] = ',';
            subjects = _subjects.Split(sep);
            numberOfSujects = subjects.Length;
            _lstSubjects = new List<Subject>();
            for (int i = 0; i < subjects.Length; i++)
            {
                _lstSubjects.Add(new Subject(subjects[i]));
                
            }
        }

        public NewProjectWizard()
        {
            _errorMessages = new List<string>();
        }

        public void Dispose()
        {

        }

        //******************** Properties ********************
        public string AnalysisTitle
        {
            set
            {
                this._analysisTitle = value;
            }
            get
            {
                return this._analysisTitle;
            }
        }
        
        public string AnalysisDescription
        {
            set
            {
                this._analysisDescription = value;
            }
            get
            {
                return this._analysisDescription;
            }
        }
        
        public string AnalysistName
        {
            set
            {
                this._analysistName = value;
            }
            get
            {
                return this._analysistName;
            }
        }
        
        public List<Subject> Subjects
        {
            set
            {
                this._lstSubjects = value;
            }
            get
            {
                return this._lstSubjects;
            }
        }
        
        public string SetOfAminoAcids
        {
            set
            {
                this._setOfAminoAcids = value;
            }
            get
            {
                return this._setOfAminoAcids;
            }
        }

        public int SingleSidePeptideSize
        {
            set
            {
                this._singleSidePeptideSize = value;
            }
            get
            {
                return this._singleSidePeptideSize;
            }
        }

        public int SubjectPosition
        {
            set
            {
                this._subjectPosition = value;
            }
            get
            {
                return this._subjectPosition;
            }
        }

        public bool SubjectPositionIsTheMemberOfPeptide
        {
            set {
                _subjectPositionIsTheMemberOfPeptide = value;
            }
            get {
                return _subjectPositionIsTheMemberOfPeptide;
            }
        }

        public DataTable UniversalSiteDataSet
        {
            set
            {
                this._usd = value;
            }
            get
            {
                return this._usd;
            }
        }
        
        public bool HasError
        {
            get
            {
                if (this._errorMessages.Count > 0)
                    return true;
                return false;
            }
        }

        public List<string> ErrorMessages
        {
            get
            {
                return this._errorMessages;
            }
        }

        //******************** Methods ********************

        //Step 1: Verify Project Profile to see that all required parameters are given and are in correct format.
        public bool VerifyProjectProfile()
        {

            if (this._errorMessages.Count > 0)
                this._errorMessages.Clear();

            if (this._analysisTitle == "")
                this._errorMessages.Add("Value required in analysis title field");

            if (this._singleSidePeptideSize <= 0)
                this._errorMessages.Add("Peptide window size is not valid. Only values greater than zero are allowed.");

            if (this._subjectPositionIsTheMemberOfPeptide == true)
            {

                if (this._subjectPosition < (-1 * _singleSidePeptideSize) || this._subjectPosition > _singleSidePeptideSize)
                    this._errorMessages.Add("Subject position is out of range.");
            }

            if (this._subjects == "")
                this._errorMessages.Add("Empty subjects set is not allowed.");

            if (this.SetOfAminoAcids == "")
                this._errorMessages.Add("Empty amino acid set is not allowed.");

            if (this._usd == null)
                this._errorMessages.Add("Universal sites data is required");
            else
            {

                if (this._usd.Columns.Contains("Sequence") == false)
                    this._errorMessages.Add("Universal sites dataset schema is inavalid. Sequence field is missing");

                if (this._usd.Columns.Contains("PID") == false)
                    this._errorMessages.Add("Universal sites dataset schema is inavalid. PID field is missing");

                if (this._usd.Columns.Contains("AminoAcid") == false)
                    this._errorMessages.Add("Universal sites dataset schema is inavalid. AminoAcid field is missing");

                if (this._usd.Columns.Contains("Position") == false)
                    this._errorMessages.Add("Universal sites dataset schema is inavalid. Position field is missing");

                if (this._usd.Columns.Contains("ModificationSite") == false)
                    this._errorMessages.Add("Universal sites dataset schema is inavalid. ModificationSite field is missing");
            }

            return this.HasError;
        }


        //Step 2: Apply Transformation Rules
        public void ApplyTransformation()
        {
            _isUSDNative = _usd.Columns.Contains("IMSB_Sequence"); //This means that if the _usd contains "IMSB_Sequence field already, then it means that the sequence is native sequence and there is no need to add "IMSB_Sequence". Therefore next condition will be false if the _usd contains the "IMSB_Sequence" field and no sequence transformation will be performed as it already is".
                
            if (_isUSDNative == false)
            { 
                //Do Transformation
                _usd.Columns.Add("IMSB_Sequence");
                string sequence;
                SequenceTransformation sequenceTransformation = new SequenceTransformation();
                
                foreach (DataRow row in _usd.Rows)
                {
                    sequence = row["Sequence"].ToString();
                    row["IMSB_Sequence"] = sequenceTransformation.ToIMSBSequence(sequence);
                }
                sequenceTransformation = null;
            }
        }

        //Step 3: Generate Subject Oritented Site Datasets
        public void GenerateSubjectOritentedSiteDatasets()
        {
            DataRow[] rows;
            List<string> pids = new List<string>();
            string pid;
            for(int subjectIndex = 0; subjectIndex < numberOfSujects; subjectIndex++)
            {
                rows = _usd.Select("[ModificationSite] = '" + subjects[subjectIndex] + "'");

                //_lstSubjects[subjectIndex].SitesDataTable = new DataTable(subjects[subjectIndex]);
                //_lstSubjects[subjectIndex].ProteinDataTable  = new DataTable(subjects[subjectIndex]);
                _lstSubjects[subjectIndex].SitesDataTable = _usd.Clone();
                _lstSubjects[subjectIndex].ProteinDataTable = _usd.Clone();

                foreach(DataRow row in rows)
                {
                    _lstSubjects[subjectIndex].SitesDataTable.ImportRow(row);
                    pid = row["PID"].ToString();
                    if (pids.Contains(pid) == false)
                    {
                        pids.Add(pid);
                        _lstSubjects[subjectIndex].ProteinDataTable.ImportRow(row);
                    }
                    
                }
                pids.Clear();
            }
        }


        //Step 4: Generate Subject Oritented Protein Datasets
        public void GenerateSubjectOritentedProteinDatasets()
        {
            int colIndex;
            DataColumn col;
            for (int subjectIndex = 0; subjectIndex < numberOfSujects; subjectIndex++)
            {
                
                for(colIndex = 0; colIndex < _lstSubjects[subjectIndex].ProteinDataTable.Columns.Count; colIndex++)
                {
                    col = _lstSubjects[subjectIndex].ProteinDataTable.Columns[colIndex];
                    if (col.ColumnName == "PID" || col.ColumnName == "Sequence" || col.ColumnName == "IMSB_Sequence")
                    { /*DoNothing. Just Ignore*/}
                    else
                    {
                        _lstSubjects[subjectIndex].ProteinDataTable.Columns.Remove(col);
                    }
                }
            }
        }

        //Step 5: Generate Subject Oritented Peptide Datasets
        public void GenerateSubjectOritentedPeptideDatasets()
        {
            PeptideGenerator peptideGenerator = new PeptideGenerator(true, this._singleSidePeptideSize);
            int subjectIndex;
            for(subjectIndex = 0; subjectIndex < numberOfSujects; subjectIndex++)
            {
                _lstSubjects[subjectIndex].PeptideDataTable = peptideGenerator.ToPeptide(_lstSubjects[subjectIndex].SitesDataTable);
                _lstSubjects[subjectIndex].PeptideDataTable.TableName = subjects[subjectIndex];
            }
        }

        public void ClearErrorStatus()
        {
            _errorMessages.Clear();
        }

    }
}
