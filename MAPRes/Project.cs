using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace MAPRes
{
    [Serializable]
    class Project : IDisposable 
    {
        [NonSerialized] private string _fileName;

        private string  _analysisTitle;
        private string  _analysisDescription;
        private string  _analysistName;
        private string _setOfAminoAcids;
        private bool _subjectPositionIsTheMemberOfPeptide;

        private int     _singleSidePeptideSize;
        private int     _subjectPosition;
        private bool _preferrenceEstimationPerformed;
        private bool _assocaitionRulesMiningPerformed;
        
        private DataTable _usd;

        private List<Subject> _subjects;
        private AssociationRulesResult _associationRules;


        public void Create(string fileName, string  analysisTitle,
                            string  analysisDescription,
                            string  analysistName,
                            string  setOfAminoAcids,
                            int     singleSidePeptideSize,
                            int     subjectPosition,
                            bool subjectPositionIsTheMemberOfPeptide,
                            List<Subject> subjects, DataTable usd)
        {

            _fileName = fileName;
            _analysisTitle = analysisTitle;
            _analysisDescription = analysisDescription;
            _analysistName = analysistName;
            _setOfAminoAcids = setOfAminoAcids;
            _singleSidePeptideSize = singleSidePeptideSize;
            _subjectPosition = subjectPosition;
            _subjects = subjects;
            _subjectPositionIsTheMemberOfPeptide = subjectPositionIsTheMemberOfPeptide;
            _usd = usd;
            _preferrenceEstimationPerformed = false;
            _assocaitionRulesMiningPerformed = false;
            Save(fileName);
        }

        internal bool PreferrenceEstimationPerformed
        {
            set
            {
                _preferrenceEstimationPerformed = value;
            }
            get {
                return _preferrenceEstimationPerformed;
            }
        }

        internal bool AssociationAnalysisPerformed
        {
            set {
                _assocaitionRulesMiningPerformed = value;
            }
            get {
                return _assocaitionRulesMiningPerformed;
            }
        }

        public void Open(string fileName)
        {
            _fileName = fileName;
            Stream stream = File.Open(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Project p = ((Project)formatter.Deserialize(stream));
            formatter = null;
            stream.Close();
            stream.Dispose();
            stream = null;

            this._analysisDescription = p._analysisDescription;
            this._analysisTitle = p._analysisTitle;
            this._analysistName = p._analysistName;
            this._setOfAminoAcids = p._setOfAminoAcids;
            this._singleSidePeptideSize = p._singleSidePeptideSize;
            this._subjectPosition = p._subjectPosition;
            this._subjectPositionIsTheMemberOfPeptide = p.SubjectPositionIsTheMemberOfPeptide;
            this._subjects = p._subjects;
            this._usd = p._usd;
            this._assocaitionRulesMiningPerformed = p._assocaitionRulesMiningPerformed;
            this._preferrenceEstimationPerformed = p._preferrenceEstimationPerformed;
            this._associationRules = p._associationRules;
            p.Close();
        }

        public void Save(string fileName)
        {
            
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            formatter = null;
            stream.Close();
            stream.Dispose();
            stream = null;
            
        }

        public void Close()
        {
            Dispose();
        }



        public void Dispose()
        {

        }


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
                this._subjects = value;
            }
            get
            {
                return this._subjects;
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
            set
            {
                _subjectPositionIsTheMemberOfPeptide = value;
            }
            get
            {
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

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public AssociationRulesResult AssociationRules
        {
            set
            {
                this._associationRules = value;
            }
            get
            {
                return this._associationRules;
            }
        }
        
    }
}
