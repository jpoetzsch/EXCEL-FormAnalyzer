using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFormAnalyzer
{
    public class BracketPair
    {
        public String FunctionName;
        public Int32 iStartFunktionNameRaw;
        public Int32 iStartFunktionNameConv;
        public Int32 iStartRaw, iEndRaw;
        public Int32 iStartConv, iEndConv;
        public Int32 iStartConvLine, iEndConvLine;
        public Int32 iStartConvColumn, iEndConvColumn;
        public Int32 iLevel, iPairNo;


    }
}
