using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MAPRes
{
    class AssociationRulesMiningProgressArg : EventArgs
    {
        public int GenerationNo;
        public float Progress;
        public string status;
        public string TargetOfStudy;
    }

 
    class AssociationRulesMining : IDisposable 
    {
    
        public event WorkProgressEventHandler AssociationRulesMiningProgress;

        private bool isDisposed = false;

        private TypeOfPreferrence _typeOfPreferrence;
        private float _minSupportLevel;
        private float _minSupportLevelPercentage;
        private bool _useVariantSupport;

        private int _generation;
        private WorkSpace _workspace;
        private List<Site> _lstOfPreferredSites;
        private List<Rule> _oldCAR;
        private List<Rule> _newCAR;
        private Rule _rule;
        private Site _site;
        private AssociationRulesMiningProgressArg armArg;
        

        public AssociationRulesMining(WorkSpace workspace, TypeOfPreferrence typeOfPreferrence, float minSupportLevel, bool useVariantSupport)
        {
            _workspace = workspace;
            _typeOfPreferrence = typeOfPreferrence;
            _minSupportLevelPercentage = minSupportLevel;
            minSupportLevel = minSupportLevel / 100;
            _minSupportLevel = minSupportLevel * _workspace.SubjectsHash[_workspace.SelectedSubject].PeptideDataTable.Rows.Count;
            _useVariantSupport = useVariantSupport;
            
            armArg = new AssociationRulesMiningProgressArg();

            if (typeOfPreferrence == TypeOfPreferrence.Both_PositiveAndNegativePreferrence)
                _lstOfPreferredSites = _workspace.PreferrenceEstimationResultSet.BothPositivelyAndNegativelyPreferredSites;
            else
                if (typeOfPreferrence == TypeOfPreferrence.PositivePreferrence)
                    _lstOfPreferredSites = _workspace.PreferrenceEstimationResultSet.PositivelyPreferredSites;
                else
                    if (typeOfPreferrence == TypeOfPreferrence.NegativePreferrence)
                        _lstOfPreferredSites = _workspace.PreferrenceEstimationResultSet.NegativelyPreferredSites;
        }
        
        ~AssociationRulesMining()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isdisposing)
        {
            if (!isDisposed)
            {
                if (isdisposing)
                {
                    _workspace = null;
                }
            }

        }

        public void RunAssociationRulesMining()
        {
            if (_workspace.IsPreferrenceAvaibleForAllSubjects() == false)
                return;

            armArg.TargetOfStudy = _workspace.SelectedSubject;
            UpdateProgress("Mining Association Rules");
            if (_workspace.AssociationRules == null)
                _workspace.AssociationRules = new AssociationRulesResult();

            _generation = 1;
            do
            {
                if (_generation == 1)
                    FirstGenerationCAR();
                else 
                    NextGenerationCAR();

                _generation++;
                UpdateProgress(0); //Reset progress for next generation

            }while(_newCAR.Count  != 0 );

            UpdateProgress("Updating Association Rules Dataset");
            if(_oldCAR != null)
            {
                for (int i = 0; i < _oldCAR.Count; i++)
                {
                    _rule = _oldCAR[i];
                    _rule.SupportCountA = GetSupport(_rule);
                    _rule.TargetOfStudy = _workspace.SelectedSubject;
                    _rule.MinimumSupportLevel = _minSupportLevelPercentage;
                    _workspace.AssociationRules.AddRule(_rule);
                    UpdateProgress(i, _oldCAR.Count);
                }
            }
        }

        private void FirstGenerationCAR()
        {
            if (_newCAR != null)
                _newCAR = null;
            
            _newCAR = new List<Rule>();

            for (int lprsIndex = 0; lprsIndex < this._lstOfPreferredSites.Count; lprsIndex++)
            {
                _rule = new Rule(1);
                _site = _lstOfPreferredSites[lprsIndex];
                if (_site.Residue != "-")
                {

                    if (_rule.Add(_site) >= 0)
                    {
                        _rule.SupportCountAUB = _workspace.SubjectsHash[_workspace.SelectedSubject].GetSupportLHS_U_RHS(_rule);
                        if (_rule.SupportCountAUB >= this._minSupportLevel)
                        {
                            _rule.Generation = this._generation;
                            if(_newCAR.Contains(_rule) == false)
                                _newCAR.Add(_rule);
                        }
                    }

                    UpdateProgress(lprsIndex, _lstOfPreferredSites.Count);
                    _rule = null;
                }
            }
        }

        private void NextGenerationCAR()
        {
            _oldCAR = _newCAR;
            _newCAR = null;
            _newCAR = new List<Rule>();
            
            int ruleIndex;
            for (int lprsIndex = 0; lprsIndex < _lstOfPreferredSites.Count ; lprsIndex++)
            {
                _site = _lstOfPreferredSites[lprsIndex];
                if (_site.Residue != "-")
                {
                    for (ruleIndex = 0; ruleIndex < _oldCAR.Count; ruleIndex++)
                    {
                        _rule = _oldCAR[ruleIndex].GetCopy();
                        if (_rule.Add(_site) >= 0)
                        {
                            _rule.SupportCountAUB = _workspace.SubjectsHash[_workspace.SelectedSubject].GetSupportLHS_U_RHS(_rule);
                            if (_rule.SupportCountAUB >= this._minSupportLevel)
                            {
                                _rule.Generation = this._generation;
                                if (_newCAR.Contains(_rule) == false)
                                    _newCAR.Add(_rule);
                            }

                        }
                        UpdateProgress(lprsIndex, _oldCAR.Count);
                        _rule = null;
                    }
                }
            }
        }


        public int GetSupport(Rule rule)
        {
            /// <summary>
            /// Computes support for the rule by counting the number of peptides in all subjects, having the rule such that the sites are also preferred in subjects.
            /// </summary>
            //Sup(A)
            int count = 0;
            foreach (Subject subject in _workspace.SubjectsHash.Values)
            {
                if (subject == _workspace.SubjectsHash[_workspace.SelectedSubject])
                    count = count + rule.SupportCountAUB;
                else
                {
                    if (subject.IsPreferred(rule, this._typeOfPreferrence) == true)
                    {
                        count = count + subject.GetSupportLHS_U_RHS(rule);
                    }
                }
            }
            return count;
        }


        public void UpdateProgress(float progress)
        {
            armArg.GenerationNo = this._generation;
            if (progress > 100)
                progress = 100;
            armArg.Progress = progress;
            AssociationRulesMiningProgress(this, armArg);
        }
        public void UpdateProgress(string status)
        {
            armArg.status = status;
        }

        public void UpdateProgress(int index, float counts)
        {
            UpdateProgress(((index / counts) * 100));
        }
        
    }
}
