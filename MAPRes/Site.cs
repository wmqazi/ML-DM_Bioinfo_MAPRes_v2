using System;

namespace MAPRes
{
    /// <summary>
    /// Summary description for RuleNode.
    /// </summary>
    
    [Serializable]
    public struct Site
    {
        public int Position;
        public string Residue;
        

        public Site(string resiude, int position)
        {
            Residue = resiude;
            Position = position;
        }

        public static Site ToSite(string strSite)
        {
            Site site;
            char[] sep = new char[1];
            sep[0] = ',';
            string[] ss = strSite.Split(sep);
            site = new Site();
            site.Residue = ss[0];
            site.Position = int.Parse(ss[1]);
            return site;
        }

        public override string ToString()
        {
            return "<" + Residue + "," + Position.ToString() + ">";
        }

        public static string ToString(string residue, int position )
        {
            return "<" + residue + "," + position.ToString() + ">";
        }

        
    }
}
