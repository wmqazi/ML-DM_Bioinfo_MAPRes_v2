using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Bioinformatics.Tools
{
    class PeptideGenerator
    {
        private bool _useIMSBSequence;
        private int _sizeOfOneSide;
        private string _peptideSequence;
        private readonly char[] sep = { ',' };
        private int start, end;
        private int _sizeOfPeptides;
        private const string dash = "-";
        private const string comma = ",";
        private string amino;
        private DataRow newRow = null;

        public PeptideGenerator(bool useIMSBSequence, int sizeOfOneSide)
        {
            _sizeOfOneSide = sizeOfOneSide;
            _sizeOfPeptides = sizeOfOneSide + sizeOfOneSide + 1;
            _useIMSBSequence = useIMSBSequence;
        }

        public bool UsingIMSBSequence
        {
            set {
                _useIMSBSequence = value;
            }
            get { 
                return _useIMSBSequence;
            }
        }

        public int SizeOfOneSide
        {
            set
            {
                _sizeOfOneSide = value;
            }
            get
            {
                return _sizeOfOneSide;
            }
        }

        public string ToPeptide(string sequence, int position)
        {
            if (_useIMSBSequence == true)
            {
                GeneratePeptideFromIMSBSequence(sequence, position);
            }
            else
            {
                GeneratePeptideFromStandardSequence(sequence, position);
            }

            return this._peptideSequence;
        }

        public DataTable ToPeptide(DataTable dtSites)
        {
            using (DataTable dtPeptide = new DataTable("Peptide"))
            {
                CreatePeptideStructureIn(dtPeptide);
                
                int position;
                foreach (DataRow row in dtSites.Rows)
                {
                    newRow = dtPeptide.NewRow();
                    position = int.Parse(row["Position"].ToString());
                    newRow["Position"] = row["Position"];
                    newRow["PID"] = row["PID"];
                    if(_useIMSBSequence == true)
                        newRow["PeptideSequence"] = ToPeptide(row["IMSB_Sequence"].ToString(), position);
                    else
                        newRow["PeptideSequence"] = ToPeptide(row["Sequence"].ToString(), position);
                    dtPeptide.Rows.Add(newRow);
                }
                return dtPeptide;
            }//end using
        }

        private void CreatePeptideStructureIn(DataTable dtPeptide)
        {
            dtPeptide.Columns.Add("PID");
            dtPeptide.Columns.Add("Position");
            dtPeptide.Columns.Add("PeptideSequence");

            int i;
            for (i = (-1 * this._sizeOfOneSide); i <= this._sizeOfOneSide; i++)
            {
                dtPeptide.Columns.Add("P" + i.ToString());
            }
        }

        private void GeneratePeptide(string[] sequenceArray, int position)
        {
            position--; //Convert position number to index. Here after variable position will refer to the index in sequence
            start = position - this._sizeOfOneSide;
            end = position + this._sizeOfOneSide;
            _peptideSequence = "";
            int indexInPeptide = -1 * this._sizeOfOneSide;

            for (int indexInSequence = start; indexInSequence <= end; indexInSequence++)
            {
                // transverse in sequence to get peptide
                if (indexInSequence < 0)
                    amino = dash;
                else if (indexInSequence >= sequenceArray.Length)
                    amino = dash;
                else
                    amino = sequenceArray[indexInSequence];

                _peptideSequence = _peptideSequence + amino;

                if (indexInSequence < end && _useIMSBSequence == true)
                    _peptideSequence = _peptideSequence + ",";


                if (newRow != null)
                {
                    newRow["P" + indexInPeptide.ToString()] = amino;
                    indexInPeptide++;
                }
            }
        }

        private void GeneratePeptideFromIMSBSequence(string sequence, int position)
        {
            string[] sequenceArray;
            sequenceArray = sequence.Split(sep);
            GeneratePeptide(sequenceArray, position);
        }

        private void GeneratePeptideFromStandardSequence(string sequence, int position)
        {
            string []sequenceArray;
            sequenceArray = new string[sequence.Length];
            
            for(int index = 0; index < sequence.Length; index++)
            {
                sequenceArray[index] = sequence[index].ToString();
            }

            GeneratePeptide(sequenceArray, position);
        }

    }

}
