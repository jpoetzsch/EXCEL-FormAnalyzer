using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace ExcelFormAnalyzer
{
    public partial class frmMain : Form
    {
        //private ArrayList Klammer;
        //private ArrayList Funktion;
        private ExcelFunktionen[] ExFunk;
        private BracketPair[] Brackets;
        private ExcelFunktionen EFunc = new ExcelFunktionen();

        private String strVersion = "v1.2";
        private String strRohtext;
        private String strConvertText;
        private Int32 iRohtextLaenge;
        private Int32 iEbene;
        private int iIdxRaw, iIdxConv;
        private Int32 iBPCount; // Bracket-Pair-Counter
        private Int32 iBracketLevel;
        private Int32 iBracketPairNo;
        private Int32[] iStack; // Stack für Klammerebenen
        private Int32 SP; // StackPointer
        private String strTabulator;

        public frmMain()
        {
            try
            {
                InitializeComponent();
                this.Text = "EXCEL-Formel-Analyzer, "+ strVersion +" 2021 J.Pötzsch";
                cboAnzLeerzeichen.SelectedIndex = 2;
                rbTabulator.Checked = true;
            }
            catch (Exception ex)
            {
                String ErrTxt1, ErrTxt2, ErrTxt3;
                ErrTxt1 = "Hoppla, da ist ein Fehler in der Funktion \"frmMain()\" aufgetreten.\n" +
                    "Der Software-Ersteller kann sicher etwas mit dieser Information anfangen.\n\n";
                ErrTxt2 = "frmMain():\n" + ex.Message + "\n" + ex.Source.ToString();
                ErrTxt3 = "\n\nMöchen Sie eine Kopie des Fehlertextes in die Zwischenablage kopieren?";
                if( MessageBox.Show( ErrTxt1 + ErrTxt2 + ErrTxt3, "EXCEL-Formel-Analyzer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Clipboard.SetText(ErrTxt2);
                Environment.Exit(0);   
            }
        }
        //-------------------------
        private void Tabs( ref String str, Int32 iEbene)
        {
            Int32 iTabs;
            for (iTabs = 0; iTabs < iEbene; iTabs++)
            {
                str += strTabulator;
            }
        }
        private void StripCrLf(ref String str)
        {
            str = str.Replace("\r\n", "");
            str = str.Replace("\n", "");
        }
        private void StripTabs(ref String str)
        {
            str= str.Replace("\t", "");
        }
        private void StripBlanks(ref String str)
        {
            Int32 iIdxSrc;
            Boolean bInString;
            String strTemp;

            bInString = false;
            strTemp = str;
            str = "";
            for( iIdxSrc=0; iIdxSrc<strTemp.Length; iIdxSrc++)
            {
                if( strTemp[iIdxSrc]== '"')
                {
                    if (bInString)
                        bInString = false;
                    else
                        bInString = true;
                    str += strTemp[iIdxSrc];
                    continue;
                }
                if ( strTemp[iIdxSrc] == ' ')
                {
                    if (bInString)
                    {
                        str += strTemp[iIdxSrc];
                        continue;
                    }
                    else
                        continue;
                }
                str += strTemp[iIdxSrc];
            }
        }
        // --- Button-Handler ---------------
        private void ButZwischenablageEinfuegen_Click(object sender, EventArgs e)
        {
            rtfRaw.Clear();
            rtfRaw.Text = Clipboard.GetText();
            rtfConv.Clear();
            dgvFunktionen.Rows.Clear();
        }
        private void ButConvert_Click(object sender, EventArgs e)
        {
            Convert();
        }
        private void Convert()
        {
            try
            {
                strRohtext = rtfRaw.Text;
                if (strRohtext.Length == 0) return;
                iEbene = 0;
                iBPCount = CountBracketPairs(strRohtext);
                if (iBPCount == 0)
                    return;
                Brackets = new BracketPair[iBPCount];
                iStack = new Int32[iBPCount];
                for (iIdxRaw = 0; iIdxRaw < iBPCount; iIdxRaw++)
                    Brackets[iIdxRaw] = new BracketPair();
                this.StripCrLf(ref strRohtext);
                this.StripTabs(ref strRohtext);
                this.StripBlanks(ref strRohtext);
                iRohtextLaenge = strRohtext.Length;
                rtfRaw.Text = strRohtext;
                strConvertText = "";
                EFunc.RohText = strRohtext;
                for (iIdxRaw = 0, iIdxConv = 0, iBracketPairNo = -1, SP = 0; iIdxRaw < iRohtextLaenge; iIdxRaw++)
                {
                    // Durchlaufe Raw-Text zeichenweise, suche dabei nach '(', ')' und ';'
                    if (strRohtext[iIdxRaw] == '(')
                    {   // öffnende Klammer erkannt
                        iBracketLevel++;
                        iBracketPairNo++;
                        Brackets[iBracketPairNo].iStartRaw = iIdxRaw;
                        Brackets[iBracketPairNo].iStartConv = iIdxConv;
                        //Brackets[iBracketPairNo].iLevel = iBracketLevel;
                        Brackets[iBracketPairNo].iPairNo = iBracketPairNo;
                        Brackets[iBracketPairNo].FunctionName = EFunc.FindeFunktion(iIdxRaw);
                        Brackets[iBracketPairNo].iStartFunktionNameRaw = iIdxRaw - Brackets[iBracketPairNo].FunctionName.Length;
                        Brackets[iBracketPairNo].iStartFunktionNameConv = iIdxConv - Brackets[iBracketPairNo].FunctionName.Length;
                        Brackets[iBracketPairNo].iLevel = iEbene;
                        iStack[SP++] = iBracketPairNo;
                        strConvertText += "(";
                        strConvertText += "\n";
                        Tabs(ref strConvertText, ++iEbene);
                        iIdxConv = strConvertText.Length;
                        continue;
                    }
                    if (strRohtext[iIdxRaw] == ')')
                    {
                        SP--;
                        Brackets[iStack[SP]].iEndRaw = iIdxRaw;
                        //Brackets[iStack[SP]].iLevel = iBracketLevel;
                        //Brackets[iStack[SP]].iPairNo = iBracketPairNo;
                        //iBracketLevel--;
                        //-------
                        strConvertText += "\n";
                        Tabs(ref strConvertText, --iEbene);
                        strConvertText += ')';
                        iIdxConv = strConvertText.Length;
                        Brackets[iStack[SP]].iEndConv = iIdxConv - 1;
                        continue;
                    }
                    if (strRohtext[iIdxRaw] == ';')
                    {
                        strConvertText += ';';
                        strConvertText += "\n";
                        Tabs(ref strConvertText, iEbene);
                        iIdxConv = strConvertText.Length;
                        continue;
                    }
                    strConvertText += strRohtext[iIdxRaw];
                    iIdxConv = strConvertText.Length;
                }
                Brackets[iStack[SP]].iEndConv = iIdxConv;
                rtfConv.Text = strConvertText;
                dgvFunktionen.Rows.Clear();
                for (int i = 0; i < iBPCount; i++)
                {
                    dgvFunktionen.Rows.Add(Brackets[i].FunctionName);
                    dgvFunktionen.Rows[i].Cells[1].Value = Brackets[i].iLevel;
                    //dgvFunktionen.Rows[i].Cells[2].Value = Brackets[i].iStartRaw;
                    //dgvFunktionen.Rows[i].Cells[3].Value = Brackets[i].iEndRaw;
                    //dgvFunktionen.Rows[i].Cells[4].Value = Brackets[i].iStartConv;
                    //dgvFunktionen.Rows[i].Cells[5].Value = Brackets[i].iEndConv;
                }
            }
            catch (Exception Ex)
            {
                String ErrTxt1, ErrTxt2, ErrTxt3;
                ErrTxt1 = "Hoppla, da ist ein Fehler in der Funktion \"Convert()\" aufgetreten.\n" +
                    "Der Software-Ersteller kann sicher etwas mit dieser Information anfangen.\n\n";
                ErrTxt2 = "EXCELFormAnalyzer, Version " + strVersion + "\nConvert():\n"
                + "\nMessage: " + Ex.Message +
                "\nSource: " + Ex.Source.ToString() +
                "\nTargetSite: " + Ex.TargetSite + "\nToString:" + Ex.ToString();
                ErrTxt3 = "\n\nMöchen Sie eine Kopie des Fehlertextes in die Zwischenablage kopieren?";
                if (MessageBox.Show(ErrTxt1 + ErrTxt2 + ErrTxt3, "EXCEL-Formel-Analyzer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Clipboard.SetText(ErrTxt2);
                Environment.Exit(0);
            }
        }
        private void ButFormatierungenEntfernen_Click(object sender, EventArgs e)
        {
            String temp = rtfRaw.Text;
            this.StripCrLf(ref temp);
            this.StripTabs(ref temp);
            this.StripBlanks(ref temp);
            rtfRaw.Clear();
            rtfRaw.Text = temp;
        }
        private void ButCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtfConv.Text);
        }
        //--- Events ------------------------
        private void rtfRaw_MouseClick(object sender, MouseEventArgs e)
        {
            Int32 iIdx;
            Int32 pos = rtfRaw.SelectionStart;
            iIdx = GetBracketPairNoFromPosRaw(pos);
            if (iIdx != -1)
            {
                SelectFunctionRaw(iIdx);
                SelectFunctionConv(iIdx);
                dgvFunktionen.CurrentCell = this.dgvFunktionen[0, iIdx];
            }
        }
        private void rtfConv_MouseClick(object sender, MouseEventArgs e)
        {
            Int32 iIdx;
            Int32 pos = rtfConv.SelectionStart;
            rtfRaw.Select(0, rtfRaw.TextLength);
            rtfRaw.SelectionColor = Color.Black;
            rtfConv.Select(0, rtfConv.TextLength);
            rtfConv.SelectionColor = Color.Black;
            iIdx = GetBracketPairNoFromPosConv(pos);
            if (iIdx != -1)
            {
                SelectFunctionRaw(iIdx);
                SelectFunctionConv(iIdx);
                dgvFunktionen.CurrentCell = this.dgvFunktionen[0, iIdx];
            }
            else
            {
                rtfRaw.Select(0, 0);
                rtfConv.Select(pos, 0);
            }
        }
        private void dgvFunktionen_MouseClick(object sender, MouseEventArgs e)
        {
            Int32 idx = dgvFunktionen.CurrentCell.RowIndex;
            SelectFunctionRaw(idx);
            SelectFunctionConv(idx);
        }
        // --- Hilfsfunktionen
        private Int32 CountBracketPairs(String txt)
        {
            Int32 i,count_open,count_close,len, diff;
            len = txt.Length;
            String ErrTxt;
            for (i = 0, count_open = 0, count_close = 0; i < len; i++)
            {
                if (txt[i] == '(')
                    count_open++;
                if (txt[i] == ')')
                    count_close++;
            }
            diff = count_open - count_close;
            if (diff > 0)
            {   // Mehr öffnende als schließende Klammern
                ErrTxt = "Diese Formel kann nicht ausgewertet werden, es ";
                if (diff == 1) ErrTxt += "fehlt eine schließende Klammer";
                else ErrTxt += "fehlen " + (diff).ToString() + " schließende Klammern!";
                MessageBox.Show(ErrTxt);
                return 0;
            }
            if( diff<0 )
            {   // Mehr schließende als öfnnende Klammern
                ErrTxt = "Diese Formel kann nicht ausgewertet werden, es ";
                if (diff == -1) ErrTxt += "fehlt eine öffnende Klammer";
                else ErrTxt += "fehlen " + (diff * -1).ToString() + " öffnende Klammern!";
                MessageBox.Show(ErrTxt);
                return 0;
            }
            if( count_open == 0)
            {
                ErrTxt = "Diese Formel kann nicht ausgewertet werden, sie enthält keine Klammerebenen!";
                MessageBox.Show(ErrTxt);
                return 0;
            }
            return count_open;
        }
        private Int32 GetBracketPairNoFromPosRaw(Int32 iPos)
        {
            Int32 idx;
            for (idx = 0; idx < iBPCount; idx++)
                // Suche im Array der "BraketPair"-Objekte "Brackets" nach der Funktion in die der Mausklick (iPos) passt
                if (iPos >= Brackets[idx].iStartFunktionNameRaw && iPos <= Brackets[idx].iStartRaw)
                    return idx;
            return -1;
        }
        private Int32 GetBracketPairNoFromPosConv(Int32 iPos)
        {
            Int32 idx;
            for (idx = 0; idx < iBPCount; idx++)
                if (iPos >= Brackets[idx].iStartFunktionNameConv && iPos <= Brackets[idx].iStartConv)
                    return idx;
            return -1;
        }
        private void ResetRtfRaw()
        {
            rtfRaw.Select(0, rtfRaw.TextLength);
            rtfRaw.SelectionColor = Color.Black;
        }
        private void ResetRtfConv()
        {
            rtfConv.Select(0, rtfConv.TextLength);
            rtfConv.SelectionColor = Color.Black;
        }
        private void SelectFunctionRaw(Int32 iIdx)
        {
            ResetRtfRaw();
            Int32 start = Brackets[iIdx].iStartFunktionNameRaw; // vom Beginn des Funktionsnamens...
            Int32 ende = Brackets[iIdx].iStartRaw; // bis zur öffnenden Klammer
            rtfRaw.Select(
                    Brackets[iIdx].iStartRaw + 1,
                    (Brackets[iIdx].iEndRaw - Brackets[iIdx].iStartRaw)); // Klammerinhalt...
            rtfRaw.SelectionColor = Color.Blue; // grün färben
            rtfRaw.Select(start, (ende - start) + 1); // Funktionsnamen...
            rtfRaw.SelectionColor = Color.Red; // rot färben
            rtfRaw.Select(Brackets[iIdx].iEndRaw, 1); // abschließende Klammer
            rtfRaw.SelectionColor = Color.Red; // rot färben
            rtfRaw.Select(0, 0);
        }
        private void SelectFunctionConv(Int32 iIdx)
        {
            ResetRtfConv();
            Int32 start = Brackets[iIdx].iStartFunktionNameConv;
            Int32 ende = Brackets[iIdx].iStartConv;
            rtfConv.Select(
                Brackets[iIdx].iStartConv + 1,
                (Brackets[iIdx].iEndConv - Brackets[iIdx].iStartConv));
            rtfConv.SelectionColor = Color.Blue;
            rtfConv.Select(start, (ende - start) + 1);
            rtfConv.SelectionColor = Color.Red;
            rtfConv.Select(Brackets[iIdx].iEndConv, 1);
            rtfConv.SelectionColor = Color.Red;
            rtfConv.Select(Brackets[iIdx].iStartConv, 0);
            rtfConv.Focus();
        }
        // --- Tabulator-Einstellungen ---
        private void rbTabulator_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTabulator.Checked)
            {
                strTabulator = "\t";
                rbLeerzeichen.Checked = false;
                Convert();
            }
            else
                rbLeerzeichen.Checked = true;
        }
        private void rbLeerzeichen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLeerzeichen.Checked)
            {
                Int32 anz = System.Convert.ToInt32(cboAnzLeerzeichen.Text);
                strTabulator = "";
                for (int i = 0; i < anz; i++)
                    strTabulator += " ";
                rbTabulator.Checked = false;
                Convert();
            }
            else
                rbTabulator.Checked = true;
        }
        private void cboAnzLeerzeichen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 anz = System.Convert.ToInt32(cboAnzLeerzeichen.SelectedItem);
            strTabulator = "";
            for (int i = 0; i < anz; i++)
                strTabulator += " ";
            rbLeerzeichen.Checked = true;
            Convert();
        }
    }
}
