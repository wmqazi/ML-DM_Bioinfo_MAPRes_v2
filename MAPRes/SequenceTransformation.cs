using System;
using System.Collections.Generic;
using System.Text;

namespace MAPRes
{
    class SequenceTransformation
    {
        public string ToIMSBSequence(string sequence)
        {
            char aminoacid;
            StringBuilder imsbSequence = new StringBuilder();
            for (int aminoIndex = 0; aminoIndex < sequence.Length; aminoIndex++)
            {
                aminoacid = sequence[aminoIndex];
                imsbSequence.Append(aminoacid);
                if (aminoIndex < sequence.Length - 1)
                    imsbSequence.Append(',');
            }
            return imsbSequence.ToString();
        }
    }
}
