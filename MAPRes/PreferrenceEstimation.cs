using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace MAPRes
{

    class PreferrenceEstimationEventArgs : EventArgs
    {
        private int    _progress;
        private string _status;
        private int _stepNo;
        private string _targetOfStudy;

        public const int TotalSteps = 5;
        
        public int Progress
        {
            set { 
                _progress = value;
            }
            get {
                return _progress;
            }
        }

        public string Status
        {
            set
            {
                _status = value;
            }
            get {
                return _status;
            }
        }

        public string TargetOfStudy
        {
            set
            {
                _targetOfStudy = value;
            }
            get {
                return _targetOfStudy;
            }
        }

        public int StepNo
        {
            set
            {
                _stepNo = value;
            }
            get {
                return _stepNo;
            }
        }
    }

    class PreferrenceEstimation : IDisposable
    {
        public event WorkProgressEventHandler  PreferrenceEstimationProgress;

        private bool _isDisposed;
        private DataTable dtProteins;
        private DataTable dtPeptides;
        private int _totalPositions;

        private int currentProgress;
        private float totalProgress;
        

        private List<string> _setOfAminoAcids;

        private double[,] _ObservedFrequency;
        private double[,] _ObservedCount;
        private double[,] _DeviationParameter;
        private double[,] _DOEC;
        private double[,] _Sigma;
        private double[,] _PreferredSites;
        private double[,] _SPreferredSites;

        private double[] _ExpectedCount;
        private double[] _ExpectedFrequency;
        private double[] _CountPerAminoAcid;
        
        private int _TotalNumberOfAminoAcidsInProteinDataSet;

        private int rowIndex;
        private int positionIndex;

        private PreferrenceEstimationEventArgs peArg;
        //private string _selectedSubjectName;
        private int _firstPosition;
        private int _lastPosition;
        private bool _subjectPositionIsTheMemberOfPeptide;
        private int _subjectPosition;


        public PreferrenceEstimation(WorkSpace workspace)
        {
          //  _selectedSubjectName = workspace.SelectedSubject;

            dtPeptides = workspace.GetPeptidesDataTable();
            dtProteins = workspace.GetProteinsDataTable();
            _firstPosition = workspace.FirstPosition;
            _lastPosition = workspace.LastPosition;

            _totalPositions = workspace.SingleSidePeptideSize + workspace.SingleSidePeptideSize + 1;
            peArg = new PreferrenceEstimationEventArgs();
            peArg.TargetOfStudy = workspace.SelectedSubject;
            _setOfAminoAcids = new List<string>();
            _setOfAminoAcids.AddRange(workspace.SetOfAminoAcid);

            _subjectPositionIsTheMemberOfPeptide = workspace.SubjectPositionIsTheMemberOfPeptide;
            _subjectPosition = workspace.SubjectPosition;

            workspace = null;

            this._CountPerAminoAcid = new double[this.TotalAminoAcids];
            this._ExpectedCount = new double[this.TotalAminoAcids];
            this._ExpectedFrequency = new double[this.TotalAminoAcids];

            this._ObservedCount = new double[this.TotalAminoAcids, this._totalPositions];
            this._ObservedFrequency = new double[this.TotalAminoAcids, this._totalPositions];
            this._DeviationParameter = new double[this.TotalAminoAcids, this._totalPositions];
            this._DOEC = new double[this.TotalAminoAcids, this._totalPositions];
            this._Sigma = new double[this.TotalAminoAcids, this._totalPositions];
            this._PreferredSites = new double[this.TotalAminoAcids, this._totalPositions];
            this._SPreferredSites = new double[this.TotalAminoAcids, this._totalPositions];
        }

        ~PreferrenceEstimation()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            peArg = null;
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    this.dtProteins.Dispose();
                    this.dtPeptides.Dispose();
                    _isDisposed = true;
                }
            }
        }

        internal PreferrenceAnalysisResultSet DoEstimation()
        {
            

            ComputeObservedCount();
            ComputeObservedFrequencyAndSigma();
            ComputeCountPerAminoAcid();
            ComputeExpectedFrequencyAndExpectedCount();
            Compute_DeviationParameter_EstimatePreferredSites_DOEC_EstimateSPreferredSites();

            DataRow rowCombined;
            DataRow rowObservedCount;
            DataRow rowObservedFrequency;
            DataRow rowPercentageObservedFrequency;
            DataRow rowDeviationParameter;
            DataRow rowDOEC;
            DataRow rowSigma;
            DataRow rowPreferredSites;
            DataRow rowS_PreferredSites;
            DataRow rowExpectedCount;
            DataRow rowExpectedFrequency;
            DataRow rowPercentageExpectedFrequency;
            DataRow rowCountPerAminoAcid;
            DataRow rowAminoAcidsAndPreferredPosition;
            string listOfAminoAcidsPostivePositions = "";
            string listOfAminoAcidsNegativePositions = "";
            int numberOfPositivePositions = 0;
            int numberOfNegativePositions = 0;

            int positionInPeptide;
            Site site;
            bool addToPreferrenceList = false;


            #region Preparing Preferrence Analysis Result Set
            using (PreferrenceAnalysisResultSet prs = new PreferrenceAnalysisResultSet(_firstPosition,_lastPosition)) 
            {
                int aminoIndex, position;
                #region AminoAcidIndex Loop
                for (aminoIndex = 0; aminoIndex < TotalAminoAcids; aminoIndex++)
                {
                    #region Variable Initialization
                    listOfAminoAcidsPostivePositions = "";
                    listOfAminoAcidsNegativePositions = "";
                    numberOfPositivePositions = 0;
                    numberOfNegativePositions = 0;
                    #endregion Variable Initialization

                    #region Allocating New Rows
                    rowObservedCount = prs.ObserveredCount.NewRow();
                    rowObservedFrequency = prs.ObserveredFrequency.NewRow();
                    rowPercentageObservedFrequency = prs.PercentageObserveredFrequency.NewRow();
                    rowDeviationParameter = prs.DeviationParameter.NewRow();
                    rowDOEC = prs.DOEC.NewRow();
                    rowSigma = prs.Sigma.NewRow();
                    rowPreferredSites = prs.PreferredSites.NewRow();
                    rowS_PreferredSites = prs.S_PreferredSites.NewRow();
                    rowExpectedCount = prs.ExpectedCount.NewRow();
                    rowExpectedFrequency = prs.ExpectedFrequency.NewRow();
                    rowPercentageExpectedFrequency = prs.PercentageExpectedFrequency.NewRow();
                    rowCountPerAminoAcid = prs.CountPerAminoAcid.NewRow();
                    rowAminoAcidsAndPreferredPosition = prs.AminoAcidsAndPreferredPositions.NewRow();
                    #endregion Allocation of New Data Rows;

                    #region Assigning value AminoAcids in _setOfAminoAcids[aminoIndex] to rowXXXXXXXX["AminoAcid"]
                    rowObservedCount["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowObservedFrequency["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowPercentageObservedFrequency["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowDeviationParameter["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowDOEC["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowSigma["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowPreferredSites["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowS_PreferredSites["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowExpectedCount["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowExpectedFrequency["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowPercentageExpectedFrequency["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowCountPerAminoAcid["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    rowAminoAcidsAndPreferredPosition["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                    #endregion

                    #region Position Loop Again the AminoAcidIndex Loop
                    positionInPeptide = _firstPosition;
                    for (position = 0; position < _totalPositions; position++)
                    {
                        #region Assinging values of ObservedCount, ObservedFrequenc, etc to respective rows against amino acid and position
                        rowObservedCount["P" + positionInPeptide.ToString() ] = _ObservedCount[aminoIndex,position];
                        rowObservedFrequency["P" + positionInPeptide.ToString()] = _ObservedFrequency[aminoIndex, position];
                        rowPercentageObservedFrequency["P" + positionInPeptide.ToString()] = _ObservedFrequency[aminoIndex, position] * 100;
                        rowDeviationParameter["P" + positionInPeptide.ToString()] = _DeviationParameter[aminoIndex, position];
                        rowDOEC["P" + positionInPeptide.ToString()] = _DOEC[aminoIndex, position];
                        rowSigma["P" + positionInPeptide.ToString()] = _Sigma[aminoIndex, position];
                        rowPreferredSites["P" + positionInPeptide.ToString()] = _PreferredSites[aminoIndex, position];
                        rowS_PreferredSites["P" + positionInPeptide.ToString()] = _SPreferredSites[aminoIndex, position];
                        #endregion

                        #region DataTable Combined: Code to Add New Rows in Combined DataTable
                        rowCombined = prs.CombinedResult.NewRow();
                        rowCombined["ModificationSite"] = MAPresApplication.Workspace.SelectedSubject;
                        rowCombined["AminoAcid"] = _setOfAminoAcids[aminoIndex];
                        rowCombined["CountPerAminoAcid"] = _CountPerAminoAcid[aminoIndex];
                        rowCombined["ExpectedFrequency"] = _ExpectedFrequency[aminoIndex];
                        rowCombined["PercentageExpectedFrequency"] = _ExpectedFrequency[aminoIndex] *100; 
                        rowCombined["ExpectedCount"] = _ExpectedCount[aminoIndex];
                        rowCombined["Position"] = positionInPeptide;
                        rowCombined["S-Preferred"] = _SPreferredSites[aminoIndex, position];
                        rowCombined["Preferred"] = _PreferredSites[aminoIndex, position];
                        rowCombined["PercentageObservedFrequency"] = _ObservedFrequency[aminoIndex, position] * 100;
                        rowCombined["ObservedFrequency"] = _ObservedFrequency[aminoIndex, position];
                        rowCombined["ObservedCount"] = _ObservedCount[aminoIndex, position];
                        rowCombined["DeviationParameter"] = _DeviationParameter[aminoIndex, position];
                        rowCombined["DOEC"] = _DOEC[aminoIndex, position];
                        rowCombined["Sigma"] = _Sigma[aminoIndex, position];
                        rowCombined["Site"] = Site.ToString(_setOfAminoAcids[aminoIndex], positionInPeptide);
                        prs.CombinedResult.Rows.Add(rowCombined);
                        #endregion


                        #region Significantly Preferred Sites: In this block following DataTable are Update:- BothPositivelyAndNegativelyPreferredSites, PositivelyPreferredSites, NegativelyPreferredSites, AminoAcidsAndPositon

                        if (_SPreferredSites[aminoIndex, position] != 0)
                        {
                            if (_setOfAminoAcids[aminoIndex] != "-")
                            {
                                //About //Condition 1: 
                                    //Condition 1 will execute when position in peptide == subject position
                                    //This consition will check that wether to add s-preferred amino acid(s) at subject position in the s-preference list. If the residue at subject position is not added to s-preferrence list then this means that the corresponding entry in the modification site directly or indirectly linked to the residue at subject position. Therefore residue at subject position will be treated as target of dicovery.
                                    //Detail senaiors with examples are given below for condition variable _subjectPositionIsTheMemberOfPeptide
                                        //_subjectPositionIsTheMemberOfPeptide == true; then DONOT add to preferrence list
                                            //For example 1. if we want to analyze Phosphobase such that S/T/Y are modifiation site and same are at the member of subject positions in their respective datasets then, S/T/Y at subject position will be treated as traget of discovery such that the association rule will be writen as LHS => RHS, where RHS will be S at subject Position; similary LHS => T and LHS => Y
                                            //For example 2. if we want to analyze Phosphobase such that S-PKA,S-PKC/T-PKA/Y-ABL,Y-SRC (i.e. residue - Kinase) are modifiation sites but these Pseudo-redues are not used in the protein sequence, i.e. protein sequence is using standard single letter code and during the analysis it is assumed that these Pseudo-residue are related/represents their orignal amino acids at subject position then this means that residue at subject position will not become the member of s-preferrence list, because respective residues at subject position can not be the member of LHS of association rule. Therefore in the example association rule will be written as: LHS => RHS where RHS is the corresponding member of modification site (i.e. S-PKA) [LHS => S-PKA][LHS => Y-ABL] but S/T/Y at subject postion are not the member of LHS but are indirectly treated in their Pseudo representation and these Pseudo representors (i.e. modification site) is the member of RHS
                                        //_subjectPositionIsTheMemberOfPeptide == false; then add to preferrence list
                                            //For example 3. if we want to analyze Phosphobase such that the 3D structures are the member of modification sites, then there may the case if analyst wants to assume that there is no link between modification site (target of discovery) and residue(s) at subject position, therefore want to add residue(s) at subject position in the list of s-preferrence which will result in association rule LHS => RHS such that residue at subject position are the member of LHS and 3D Structures is the member of RHS. LHS (including residue at subject position) => RHS (3D structure).
                                if (positionInPeptide == _subjectPosition)
                                {    
                                    /*Condition 1*/    
                                    addToPreferrenceList = !_subjectPositionIsTheMemberOfPeptide;
                                    //Above statement "addToPreferrenceList = !_subjectPositionIsTheMemberOfPeptide" is an alternative to following statement
                                    /*if (_subjectPositionIsTheMemberOfPeptide) //Condition 1
                                        addToPreferrenceList == false;
                                    else
                                        addToPreferrenceList == true;
                                     */
                                }
                                else
                                {
                                    //position in peptide is not equal to subjkect position
                                    addToPreferrenceList = true;
                                }

                                if(addToPreferrenceList)
                                {
                                    site = new Site(_setOfAminoAcids[aminoIndex], positionInPeptide);
                                    prs.BothPositivelyAndNegativelyPreferredSites.Add(site);
                                    if (_SPreferredSites[aminoIndex, position] == 1)
                                    {
                                        prs.PositivelyPreferredSites.Add(site);
                                        listOfAminoAcidsPostivePositions = listOfAminoAcidsPostivePositions + positionInPeptide.ToString() + ",";
                                        numberOfPositivePositions++;
                                    }
                                    else
                                    if (_SPreferredSites[aminoIndex, position] == -1)
                                    {
                                        prs.NegativelyPreferredSites.Add(site);
                                        listOfAminoAcidsNegativePositions = listOfAminoAcidsNegativePositions + positionInPeptide.ToString() + ",";
                                        numberOfNegativePositions++;
                                    }
                                }
                            }
                        }
                        #endregion


                        positionInPeptide++;
                    }
                    #endregion End Position Loop

                    #region Assigning values to ExpectedCount, ExpectedFrquency and CountPerAminoAcid agiant aminoAcidIndex
                    rowExpectedCount["Value"] = _ExpectedCount[aminoIndex];
                    rowExpectedFrequency["Value"] = _ExpectedFrequency[aminoIndex];
                    rowPercentageExpectedFrequency["Value"] = _ExpectedFrequency[aminoIndex] * 100;
                    rowCountPerAminoAcid["Value"] = _CountPerAminoAcid[aminoIndex];
                    #endregion


                    #region AminoAcidsAndPreferredPosition:- Adding List Of Significantly Preferred Positions Againts Amino Acids
                    rowAminoAcidsAndPreferredPosition["PositivePositions"] = listOfAminoAcidsPostivePositions;
                    rowAminoAcidsAndPreferredPosition["NegativePositions"] = listOfAminoAcidsNegativePositions;
                    rowAminoAcidsAndPreferredPosition["NumberOfPositivePositions"] = numberOfPositivePositions;
                    rowAminoAcidsAndPreferredPosition["NumberOfNegativePositions"] = numberOfNegativePositions;
                    #endregion AminoAcidsAndPreferredPosition:- Adding List Of Significantly Preferred Positions Againts Amino Acids

                    #region Adding Rows to repective DataTables
                    prs.CountPerAminoAcid.Rows.Add( rowCountPerAminoAcid );
                    prs.DeviationParameter.Rows.Add( rowDeviationParameter );
                    prs.ExpectedCount.Rows.Add( rowExpectedCount);
                    prs.DOEC.Rows.Add( rowDOEC);
                    prs.ExpectedFrequency.Rows.Add( rowExpectedFrequency );
                    prs.ObserveredCount.Rows.Add(rowObservedCount);
                    prs.ObserveredFrequency.Rows.Add(rowObservedFrequency);
                    prs.PercentageExpectedFrequency.Rows.Add(rowPercentageExpectedFrequency);
                    prs.PercentageObserveredFrequency.Rows.Add(rowPercentageObservedFrequency);
                    prs.PreferredSites.Rows.Add(rowPreferredSites);
                    prs.S_PreferredSites.Rows.Add(rowS_PreferredSites);
                    prs.Sigma.Rows.Add(rowSigma);
                    prs.AminoAcidsAndPreferredPositions.Rows.Add(rowAminoAcidsAndPreferredPosition);
                    #endregion


                }
                #endregion AminoAcidIndex loop
                return prs;
            }
            #endregion Preparing Preferrence Analysis Result Set
        }

        private void ComputeCountPerAminoAcid()
        {

            UpdateProgress("Starting to compute count per amino acid.", 1, 0);
            UpdateProgress("Computing count per amino acid.");
            totalProgress = TotalAminoAcids;

            string[] ExtendedSequence;
            this._TotalNumberOfAminoAcidsInProteinDataSet = 0;
            char []sep = {','};
            int colIndex;
            int totalCols;
            
            for (rowIndex = 0; rowIndex < this.TotalProteins; rowIndex++)
            {
                ExtendedSequence = dtProteins.Rows[rowIndex]["IMSB_Sequence"].ToString().Split(sep);
                totalCols = ExtendedSequence.Length;
                _TotalNumberOfAminoAcidsInProteinDataSet = _TotalNumberOfAminoAcidsInProteinDataSet + totalCols; //ExtendedSequence.Length
                for (colIndex = 0; colIndex < totalCols; colIndex++)
                {
                    this._CountPerAminoAcid[_setOfAminoAcids.IndexOf(ExtendedSequence[colIndex])]++;
                }
                currentProgress = rowIndex + 1;
                UpdateProgress();
            }
            UpdateProgress("Computing of count per amini acid is completed", 1, 100);
        }

        private void ComputeObservedFrequencyAndSigma()
        {
            UpdateProgress("Starting to Compute observed frequency and sigma.", 1, 0);
            UpdateProgress("Computing observed frequency and sigma.");
            totalProgress = TotalAminoAcids;
            for (rowIndex = 0; rowIndex < TotalAminoAcids; rowIndex++)
            {
                for (positionIndex = 0; positionIndex < _totalPositions; positionIndex++)
                {
                    this._ObservedFrequency[rowIndex, positionIndex] = this._ObservedCount[rowIndex, positionIndex] / this.TotalPeptide;
                    this._Sigma[rowIndex, positionIndex] = Math.Sqrt(this._ObservedCount[rowIndex, positionIndex]);
                }
                currentProgress = rowIndex + 1;
                UpdateProgress();
            }

            UpdateProgress("Computing of observed frequency and sigma completed", 1, 100);
        }

        private void ComputeObservedCount()
        {
            UpdateProgress("Starting to compute observed count.", 1, 0);
            UpdateProgress("Computing observed count.");
            totalProgress = TotalPeptide;
            string aminoacid;
            for (rowIndex = 0; rowIndex < TotalPeptide; rowIndex++)
            {
                for (positionIndex = 0; positionIndex < _totalPositions; positionIndex++)
                {
                    aminoacid = dtPeptides.Rows[rowIndex][positionIndex +3].ToString();
                    this._ObservedCount[_setOfAminoAcids.IndexOf(aminoacid), positionIndex]++;
                }

                currentProgress = rowIndex + 1;
                UpdateProgress();
            }
            UpdateProgress("Completed observed count coumputation", 1, 100);
        }

        private void ComputeExpectedFrequencyAndExpectedCount()
        {
            UpdateProgress("Starting to expected frequency and expected count.", 1, 0);
            UpdateProgress("Computing expected frequency and expected count.");
            totalProgress = TotalAminoAcids;
            for (rowIndex = 0; rowIndex < TotalAminoAcids; rowIndex++)
            {
                this._ExpectedFrequency[rowIndex] = ((this._CountPerAminoAcid[rowIndex]) / (this._TotalNumberOfAminoAcidsInProteinDataSet));
                this._ExpectedCount[rowIndex] = this.TotalPeptide * this._ExpectedFrequency[rowIndex];
                currentProgress = rowIndex + 1;
                UpdateProgress();
            }
            UpdateProgress("Completed computation of expected frequency and expected count", 1, 100);
        }

        private void Compute_DeviationParameter_EstimatePreferredSites_DOEC_EstimateSPreferredSites()
        {

            UpdateProgress("Starting to Estimating Preferred Sites.", 1, 0);
            UpdateProgress("Estimating Preferred Sites.");
            totalProgress = TotalAminoAcids;

            double expectedFrequency, expectedCount;
            double dp, doec, sigma;
            int mark;
            int colIndex;
            for (rowIndex = 0; rowIndex < TotalAminoAcids; rowIndex++)
            {
                expectedFrequency = this._ExpectedFrequency[rowIndex];
                expectedCount = this._ExpectedCount[rowIndex];
                for (colIndex = 0; colIndex < _totalPositions; colIndex++)
                {
                    
                    #region Computing Deviation Parameter
                    dp = ((this._ObservedFrequency[rowIndex, colIndex] - expectedFrequency) / expectedFrequency) * 100;
                    this._DeviationParameter[rowIndex, colIndex] = dp;
                    #endregion

                    #region Estimation of Preferred Sites
                    if (double.IsNaN(dp) == true)
                        mark = 0;
                    else
                        mark = Math.Sign(dp);
                    this._PreferredSites[rowIndex, colIndex] = mark;
                    #endregion

                    #region Compute DOEC
                    doec = this._ObservedCount[rowIndex, colIndex] - expectedCount;
                    this._DOEC[rowIndex, colIndex] = doec;
                    #endregion

                    #region Estimation of Significantly Preferred Sites
                    sigma = this._Sigma[rowIndex, colIndex];
                    if (doec >= (2 * sigma))
                    {
                        this._SPreferredSites[rowIndex, colIndex] = mark;
                    }
                    #endregion

                    currentProgress = rowIndex + 1;
                    UpdateProgress();
                }
                currentProgress = rowIndex + 1;
                UpdateProgress();
            }
            UpdateProgress("Estimation of preferred sites completed.", 1, 100);
        }



        private  int TotalProteins
        {
            get {
                return dtProteins.Rows.Count;
            }
        }

        private int TotalPeptide
        {
            get {
                return dtPeptides.Rows.Count;
            }
        }

        private int TotalAminoAcids
        {
            get {
                return _setOfAminoAcids.Count;
            }
        }

        private void UpdateProgress(string status, int step, int progress)
        {
            peArg.Progress = progress;
            peArg.Status = status;
            peArg.StepNo = step;
            if(PreferrenceEstimationProgress!= null)
                PreferrenceEstimationProgress(this, peArg);
        }

        private void UpdateProgress(int progress)
        {
            peArg.Progress = progress;
            if (PreferrenceEstimationProgress != null)
                PreferrenceEstimationProgress(this, peArg);
        }

        private void UpdateProgress(string status)
        {
            peArg.Status = status;
        }

        private void UpdateProgress()
        {
            Math.Round(((currentProgress / totalProgress) * 100), 2);
            if (PreferrenceEstimationProgress != null)
                PreferrenceEstimationProgress(this, peArg);
        }

    }

}