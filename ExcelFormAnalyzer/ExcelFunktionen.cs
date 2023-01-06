using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ExcelFormAnalyzer
{
    public class ExcelFunktionen
    {
        public String RohText;
        public ExcelFunktionen()
        {
        }
        public String FindeFunktion(Int32 iBracketPos)
        {
            Int32 ptr;
            ptr = iBracketPos - 1;
            while ( (Char.IsLetterOrDigit(RohText[ptr]) || RohText[ptr]=='.') && ptr >= 0)
                ptr--;
            ptr++;
            return RohText.Substring(ptr, iBracketPos - ptr);
        }
    }
}
