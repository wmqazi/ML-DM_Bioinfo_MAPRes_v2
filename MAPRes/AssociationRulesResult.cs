using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MAPRes
{
    [Serializable]
    class AssociationRulesResult : IDisposable 
    {
        private DataTable _dtAssociationRules;
        private List<float> _supportLevels;
        private bool isDisposed = false;

        public AssociationRulesResult()
        {
            InitAssociationRulesTable();
        }

        ~AssociationRulesResult()
        {
            Dispose(false);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _dtAssociationRules.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void InitAssociationRulesTable()
        {
            if (_dtAssociationRules == null)
            {
                _dtAssociationRules = new DataTable("AssociationRules");
                _dtAssociationRules.Columns.Add("AssociationRule", System.Type.GetType("System.String"));
                _dtAssociationRules.Columns.Add("LHS", System.Type.GetType("System.String"));
                _dtAssociationRules.Columns.Add("RHS", System.Type.GetType("System.String"));
                _dtAssociationRules.Columns.Add("NumberOfSitesInAssociationRule", System.Type.GetType("System.Int32"));
                _dtAssociationRules.Columns.Add("SupportLHS_U_RHS", System.Type.GetType("System.Int32"));
                _dtAssociationRules.Columns.Add("SupportLHS", System.Type.GetType("System.Int32"));
                _dtAssociationRules.Columns.Add("Confidence", System.Type.GetType("System.Single"));
                _dtAssociationRules.Columns.Add("MinimumSupportLevel", System.Type.GetType("System.Single"));
                _supportLevels = new List<float>();
            }
        }

        public void AddRule(Rule _rule)
        {
            DataRow newRow;
            newRow = _dtAssociationRules.NewRow();
                newRow["AssociationRule"] = _rule.ToAssociationRule();
                newRow["LHS"] = _rule.ToString();
                newRow["RHS"] = _rule.TargetOfStudy;
                newRow["NumberOfSitesInAssociationRule"] = _rule.Count;
                newRow["SupportLHS_U_RHS"] = _rule.SupportCountAUB;
                newRow["SupportLHS"] = _rule.SupportCountA;
                newRow["Confidence"] = _rule.Confidence;
                newRow["MinimumSupportLevel"] = _rule.MinimumSupportLevel;
            _dtAssociationRules.Rows.Add(newRow);
        }

        public List<float> SupportLevels
        {
            get {
                return _supportLevels;
            }
        }

        public DataTable AllAssociationRule
        {
            get {
                return _dtAssociationRules;
            }
        }

        public DataTable GetAssociationRules(float support)
        {
            //Code not implemented
            return null;
        }



    }
}
