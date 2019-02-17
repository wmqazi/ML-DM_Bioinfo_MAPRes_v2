using System;
using System.Collections;
using System.Collections.Specialized;


namespace MAPRes
{

    public class ISiteCompare : System.Collections.IComparer
    {
        private Site s1, s2;
        

        public Int32 Compare(Object a, Object b)
        {
            s1 = ((Site)(a));
            s2 = ((Site)(b));
            if (s1.Position < s2.Position)
                return -1;

            if (s1.Position > s2.Position)
                return 1;

            return 0;
        }
    }


    /// <summary>
    /// Summary description for Rule.
    /// </summary>
    public class Rule : IEquatable<Rule>
    {
        private ArrayList lst;
        private ISiteCompare siteCompare;
        private int supportAUB;
        private int supportA;
        private ArrayList forbiddenPositions;
        public int Generation;
        private string targetOfStudy;
        private float minimumSupporLevel;


        public Rule(int capacity)
        {
            siteCompare = new ISiteCompare();
            lst = new ArrayList(capacity);
            forbiddenPositions = new ArrayList();
        }

        public Rule()
        {
            lst = new ArrayList();
            siteCompare = new ISiteCompare();
            forbiddenPositions = new ArrayList();
        }



        ~Rule()
        {
            lst.Clear();
            lst = null;
            siteCompare = null;
            forbiddenPositions.Clear();
            forbiddenPositions = null;
        }

        public Rule GetCopy()
        {

            Rule r = new Rule(this.Count);
            r.lst = ((ArrayList)lst.Clone());
            r.forbiddenPositions = ((ArrayList)this.forbiddenPositions.Clone());
            return r;
        }

        public void Add(string strrule)
        {
            char[] sep = new char[2];
            sep[0] = '<';
            sep[1] = '>';

            string[] strSites = strrule.Split(sep);
            Site site;
            for (int i = 0; i < strSites.Length; i++)
            {
                if (strSites[i] != "")
                {
                    site = Site.ToSite(strSites[i]);
                    this.Add(site);
                }
            }

        }

        
        public int Add(Site site)
        {
            if (forbiddenPositions.Contains(site.Position) == true)
                return -1;

            if (Contains(site) == true)
                return -1;

            forbiddenPositions.Add(site.Position);
            return lst.Add(site);
        }

        public bool Contains(Site site)
        {
            return lst.Contains(site);
        }

        public void Clear()
        {
            lst.Clear();
        }

        public int Count
        {
            get
            {
                return lst.Count;
            }
        }

        public Site this[int siteIndex]
        {
            get
            {
                return ((Site)lst[siteIndex]);
            }
        }

        public void Sort()
        {
            lst.Sort(siteCompare);
        }

        public override string ToString()
        {

            if (this.Count == 1)
            {
                return ((Site)lst[0]).ToString();
            }

            this.Sort();
            string str = "";
            for (int i = 0; i < lst.Count; i++)
            {
                str = str + ((Site)lst[i]).ToString();
            }
            return str;
        }

        public string ToAssociationRule()
        {
            return ToString() + "=>" + targetOfStudy;
        }



        public bool Equals(Rule rule)
        {
            if (rule.Count != this.Count)
                return false;

            bool match = false;
            Site site;
            for (int i = 0; i < rule.Count; i++)
            {
                site = rule[i];
                if (this.Contains(site) == true)
                {
                    match = true;
                }
                else
                {
                    //if site is not present in "this", then this means that both rule are not equal, henece terminate the search
                    i = rule.Count + 1;
                    match = false;
                }
            }

            return match;
        }

        public int SupportCountAUB
        {
            get
            {
                return this.supportAUB;
            }
            set
            {
                this.supportAUB = value;
            }
        }

        public int SupportCountA
        {
            get
            {
                return this.supportA;
            }
            set
            {
                this.supportA = value;
            }
        }

        
        public float Confidence
        {
            get
            {
                return ((float)((float)SupportCountAUB / SupportCountA)) * 100;
            }
        }



        public string TargetOfStudy
        {
            get
            {
                return this.targetOfStudy;
            }
            set
            {
                this.targetOfStudy = value;
            }
        }

        public float MinimumSupportLevel
        {
            get
            {
                return this.minimumSupporLevel;
            }
            set
            {
                this.minimumSupporLevel = value;
            }
        }


    }
}

