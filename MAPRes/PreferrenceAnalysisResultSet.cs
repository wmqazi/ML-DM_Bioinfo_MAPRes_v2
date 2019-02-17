using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MAPRes
{
    [Serializable]
    class PreferrenceAnalysisResultSet : IDisposable
    {
        private DataTable dtCombinedResultTable;

        private DataTable dtObserveredFrequencyTable;
        private DataTable dtObserveredCountTable;
        private DataTable dtPercentageObserveredFrequencyTable;
        private DataTable dtPercentageExpectedFrequencyTable;
        private DataTable dtExpectedFrequencyTable;
        private DataTable dtDOECTable;
        private DataTable dtDeveiationParameterTable;
        private DataTable dtSigmaTable;
        private DataTable dtPreferredSitesTable;
        private DataTable dtS_PreferredSitesTable;
        private DataTable dtExpectedCountTable;
        private DataTable dtCountPerAminoAcidTable;
        private DataTable dtAminoAcidsAndPreferredPositions;
        

        private List<Site> positivelyPreferredSites;
        private List<Site> negativelyPreferredSites;
        private List<Site> bothPositiveAndNegativePreferredSites;


        //private long _totalNumberOfAminoAcidsInProteinDataSet;

        [NonSerialized]
        private bool isDisposed = false;
        [NonSerialized]
        private int _firstPosition;
        [NonSerialized]
        private int _lastPosition;

        public PreferrenceAnalysisResultSet(int firstPosition, int lastPosition)
        {
            _firstPosition = firstPosition;
            _lastPosition = lastPosition;
            
            dtCombinedResultTable = new DataTable("CombinedResults");
            dtCombinedResultTable.Columns.Add("ModificationSite");
            dtCombinedResultTable.Columns.Add("AminoAcid");
            dtCombinedResultTable.Columns.Add("CountPerAminoAcid");
            dtCombinedResultTable.Columns.Add("ExpectedFrequency");
            dtCombinedResultTable.Columns.Add("PercentageExpectedFrequency");
            dtCombinedResultTable.Columns.Add("ExpectedCount");
            dtCombinedResultTable.Columns.Add("Position");
            dtCombinedResultTable.Columns.Add("Site");
            dtCombinedResultTable.Columns.Add("S-Preferred");
            dtCombinedResultTable.Columns.Add("Preferred");
            dtCombinedResultTable.Columns.Add("PercentageObservedFrequency");
            dtCombinedResultTable.Columns.Add("ObservedFrequency");
            dtCombinedResultTable.Columns.Add("ObservedCount");
            dtCombinedResultTable.Columns.Add("DeviationParameter");
            dtCombinedResultTable.Columns.Add("DOEC");
            dtCombinedResultTable.Columns.Add("Sigma");

            dtObserveredCountTable = new DataTable("ObservedCount");
            dtObserveredFrequencyTable = new DataTable("ObservedFrequency");
            dtDeveiationParameterTable = new DataTable("DeviationParameter");
            dtDOECTable = new DataTable("DOEC");
            dtSigmaTable = new DataTable("Sigma");
            dtPreferredSitesTable = new DataTable("PreferredSites");
            dtS_PreferredSitesTable = new DataTable("SPreferredSites");
            dtPercentageObserveredFrequencyTable = new DataTable("PercentageObservedFrequency");
            dtPercentageExpectedFrequencyTable = new DataTable("PercentageExpectedFrequency");
            dtExpectedFrequencyTable = new DataTable("ExpectedFrequency");
            dtCountPerAminoAcidTable = new DataTable("CountPerAminoAcidInProteinDataSet");
            dtExpectedCountTable = new DataTable("ExpectedCount");

            dtObserveredCountTable.Columns.Add("AminoAcid");
            dtObserveredFrequencyTable.Columns.Add("AminoAcid");
            dtDeveiationParameterTable.Columns.Add("AminoAcid");
            dtDOECTable.Columns.Add("AminoAcid");
            dtSigmaTable.Columns.Add("AminoAcid");
            dtPreferredSitesTable.Columns.Add("AminoAcid");
            dtS_PreferredSitesTable.Columns.Add("AminoAcid");
            dtPercentageObserveredFrequencyTable.Columns.Add("AminoAcid");
            dtPercentageExpectedFrequencyTable.Columns.Add("AminoAcid");
            dtExpectedFrequencyTable.Columns.Add("AminoAcid");
            dtCountPerAminoAcidTable.Columns.Add("AminoAcid");
            dtExpectedCountTable.Columns.Add("AminoAcid");

            dtPercentageExpectedFrequencyTable.Columns.Add("Value");
            dtExpectedFrequencyTable.Columns.Add("Value");
            dtCountPerAminoAcidTable.Columns.Add("Value");
            dtExpectedCountTable.Columns.Add("Value");
            
            for (int position = _firstPosition; position <= _lastPosition; position++)
            {
                dtDeveiationParameterTable.Columns.Add("P" + position.ToString());
                dtDOECTable.Columns.Add("P" + position.ToString());
                dtObserveredCountTable.Columns.Add("P" + position.ToString());
                dtObserveredFrequencyTable.Columns.Add("P" + position.ToString());
                dtPercentageExpectedFrequencyTable.Columns.Add("P" + position.ToString());
                dtPercentageObserveredFrequencyTable.Columns.Add("P" + position.ToString());
                dtPreferredSitesTable.Columns.Add("P" + position.ToString());
                dtS_PreferredSitesTable.Columns.Add("P" + position.ToString());
                dtSigmaTable.Columns.Add("P" + position.ToString());
            }

            positivelyPreferredSites = new List<Site>();
            negativelyPreferredSites  = new List<Site>();
            bothPositiveAndNegativePreferredSites = new List<Site>();

            #region Memory Allocation Block for:-> dtAminoAcidsAndPreferredPositions DataTable
            dtAminoAcidsAndPreferredPositions = new DataTable("AminoAcidsAndNegativelyPreferredPositions");
            dtAminoAcidsAndPreferredPositions.Columns.Add("AminoAcid");
            dtAminoAcidsAndPreferredPositions.Columns.Add("NumberOfPositivePositions", System.Type.GetType("System.Int32"));
            dtAminoAcidsAndPreferredPositions.Columns.Add("PositivePositions");
            dtAminoAcidsAndPreferredPositions.Columns.Add("NumberOfNegativePositions", System.Type.GetType("System.Int32"));
            dtAminoAcidsAndPreferredPositions.Columns.Add("NegativePositions");
            #endregion
        }



        ~PreferrenceAnalysisResultSet()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (isDisposed == false)
            {
                if (disposing)
                {
                    dtCombinedResultTable.Dispose();
                    dtObserveredFrequencyTable.Dispose();
                    dtPercentageObserveredFrequencyTable.Dispose();
                    dtPercentageExpectedFrequencyTable.Dispose();
                    dtExpectedFrequencyTable.Dispose();
                    dtDOECTable.Dispose();
                    dtDeveiationParameterTable.Dispose();
                    dtSigmaTable.Dispose();
                    dtPreferredSitesTable.Dispose();
                    dtS_PreferredSitesTable.Dispose();
                    dtExpectedCountTable.Dispose();
                    dtExpectedFrequencyTable.Dispose();
                    dtCountPerAminoAcidTable.Dispose();
                    dtAminoAcidsAndPreferredPositions.Dispose();
                    
                }
            }
        }

        public DataTable CombinedResult
        {
            get {
                return dtCombinedResultTable;
            }
        }

        public DataTable AminoAcidsAndPreferredPositions
        {
            get {
                return dtAminoAcidsAndPreferredPositions;
            }
        }

      
        public DataTable ObserveredFrequency
        {
            get
            {
                return dtObserveredFrequencyTable;
            }
        }

        public DataTable ObserveredCount
        {
            get
            {
                return dtObserveredCountTable;
            }
        }

        public DataTable PercentageObserveredFrequency
        {
            get
            {
                return dtPercentageObserveredFrequencyTable;
            }
        }

        public DataTable PercentageExpectedFrequency
        {
            get
            {
                return dtPercentageExpectedFrequencyTable;
            }
        }

        public DataTable ExpectedFrequency
        {
            get
            {
                return dtExpectedFrequencyTable;
            }
        }

        public DataTable DOEC
        {
            get
            {
                return dtDOECTable;
            }
        }

        public DataTable DeviationParameter
        {
            get
            {
                return dtDeveiationParameterTable;
            }
        }

        public DataTable Sigma
        {
            get
            {
                return dtSigmaTable;
            }
        }

        public DataTable PreferredSites
        {
            get
            {
                return dtPreferredSitesTable;
            }
        }

        public DataTable S_PreferredSites
        {
            get
            {
                return dtS_PreferredSitesTable;
            }
        }

        public DataTable ExpectedCount
        {
            get {
                return dtExpectedCountTable;
            }
        }

        public DataTable CountPerAminoAcid
        {
            get
            {
                return dtCountPerAminoAcidTable;
            }
        }

        public List<Site> PositivelyPreferredSites
        {
            get {
                return this.positivelyPreferredSites;
            }
        }

        public List<Site> NegativelyPreferredSites
        {
            get
            {
                return this.negativelyPreferredSites;
            }
        }

        public List<Site> BothPositivelyAndNegativelyPreferredSites
        {
            get
            {
                return this.bothPositiveAndNegativePreferredSites;
            }
        }


        public bool IsPreferred(Site site, TypeOfPreferrence typeOfPreferrence)
        { 
            if( typeOfPreferrence == TypeOfPreferrence.Both_PositiveAndNegativePreferrence)
            {
                return bothPositiveAndNegativePreferredSites.Contains(site);
            }
            else if( typeOfPreferrence == TypeOfPreferrence.NegativePreferrence )
            {
                return negativelyPreferredSites.Contains(site);
            }
            else if (typeOfPreferrence == TypeOfPreferrence.PositivePreferrence)
            {
                return positivelyPreferredSites.Contains(site);
            }
            return false;
        }
    }
}
