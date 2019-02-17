using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace MAPRes
{
    [Serializable]
    class Subject : IDisposable 
    {
        private string _subjectName;
        private DataTable _dtSites;
        private DataTable _dtProtein;
        private DataTable _dtPeptide;
        private PreferrenceAnalysisResultSet _preferrenceResult;
        

        public Subject(string subjectName)
        {
            _subjectName = subjectName;

        }

        public string SubjectName
        {
            set
            {
                _subjectName = value;
            }
            get {
                return _subjectName;
            }
        }

        public DataTable SitesDataTable
        {
            set {
                _dtSites = value;
            }
            get {
                return _dtSites;
            }
        }

        public DataTable ProteinDataTable
        {
            set {
                _dtProtein = value;
            }
            get {
                return _dtProtein;
            }
        }

        public DataTable PeptideDataTable
        {
            set {
                _dtPeptide = value;
            }
            get {
                return _dtPeptide;
            }
        }

        public PreferrenceAnalysisResultSet PreferredAnalysis
        {
            set
            {
                this._preferrenceResult = value;
            }
            get
            {
                return this._preferrenceResult;
            }
        }

        public PreferrenceAnalysisResultSet PreferredSitesDataTable
        {
            set
            {
                this._preferrenceResult = value;
            }
            get {
                return _preferrenceResult;
            }
        
        
        }

        
        
        public void Dispose()
        {
        
        }

        public int GetSupportLHS_U_RHS(Rule rule)
        {
            //Sup(AUB)
            //Where RHS is current subject(target of study/this)
            string criteria = MakeSearchCriteria(rule);
            DataRow []rows = this._dtPeptide.Select(criteria);
            
            if (rows == null)
                return 0;

            int support = rows.Length;
            rows = null;
            return support;
        }

        public string MakeSearchCriteria(Rule rule)
        {
            string criteria = "";
            Site site;
            for (int i = 0; i < rule.Count; i++)
            {
                site = rule[i];
                if (i == (rule.Count - 1))
                    criteria = criteria + "[P" + site.Position.ToString() + "] = '" + site.Residue + "'";
                else
                    criteria = criteria + "[P" + site.Position.ToString() + "] = '" + site.Residue + "' And ";
            }
            return criteria;        
        }


        public bool IsPreferred(Rule rule, TypeOfPreferrence typeOfPreferrence)
        {
            int ctr = 0;
            Site site;
            
            for (int index = 0; index < rule.Count; index++)
            {
                site = rule[index];
                if (_preferrenceResult.IsPreferred(site,typeOfPreferrence) == true)
                    ctr++;
                else
                {
                    index = rule.Count + 1;
                    ctr = 0;
                }
            }

            if (ctr == rule.Count)
                return true;

            return false;
        }
    }
}
