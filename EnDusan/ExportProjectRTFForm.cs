/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/22/2015
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

namespace EnDusan
{
	/// <summary>
	/// Description of ExportProjectRTFForm.
	/// </summary>
	public partial class ExportProjectRTFForm : Form
	{
		private DataGridView DGVProcesssed;
		private bool bFillOK = false;
		
        public ExportProjectRTFForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        /*void PrgDEBUG () {
        	SPtxtBxMistoUlozeni.Text = EnDusan.EnConfigRun.CNFPathEXEData;
			SPtxtBxFileName.Text = SPtxtBxMistoUlozeni.Text + SPtxtBxProjectName.Text; 
        	SPtxtBxFileName.Text = SPtxtBxMistoUlozeni.Text + SPtxtProcessedProject.Text + ".rtf";	
        }*/
        
        void setSPBtnOKColor() {
        	if ( !bFillOK ) {
				SPbtnOK.ForeColor = Color.Red;
			}
			else
				SPbtnOK.ForeColor = Color.Green;
        }
			
        void eventExpPrjRTFLoadForm(object sender, EventArgs e)
		{
			SPtxtProcessedProject.Text = EnDusan.EnConfigRun.ProjectName; 
			SPtxtBxMistoUlozeni.Text = EnDusan.EnConfigRun.CNFPathEXEData;
			SPtxtBxFileName.Text = 	SPtxtBxMistoUlozeni.Text + 	SPtxtProcessedProject.Text + ".rtf";	
			//rtBoxExport.Rtf = EnDusan.EnConfigRun.RTFBastl;
			//PrgDEBUG();
			setSPBtnOKColor();
		}

		void eventExpPrjRTFOK(object sender, EventArgs e)
		{
			int iDBG = 100;
			DialogResult = DialogResult.OK;
			Close();
		}

		
		void eventExpPrjRTFCancel(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		
		void eventTxtBxPathChanged(object sender, EventArgs e)
		{
			SPtxtBxFileName.Text = SPtxtBxMistoUlozeni.Text + SPtxtProcessedProject.Text + ".rtf";
		}
		
		void eventTxBxFileNameLeave(object sender, EventArgs e)
		{
			int iDBG = 25;	
		}
		
			
		void eventbtnFill_OLD(object sender, EventArgs e)
		{
			string sSearchWord;
			char chFromLine;
			char[] chWord = new char[] {'R','e','p'};
			char[] chSpace = new char[1];
			chSpace[0] = ' ';
			int iCharFound;
			string sWord = "_Rep";
			int iWordFound;
			DGVProcesssed = EnConfigRun.DGVRun;
			String sRTFLine = String.Empty;
			int iLines, iChDBG, iChFound;
			iChDBG = rtBoxExport.Text.Length;
			for (int iCh = 0; iCh < rtBoxExport.Text.Length; iCh++)
			{
    			//find first "SPACE" from index
    			iCharFound = rtBoxExport.Find(chSpace, iCh);
    			int iDBGA;
    			if (iCharFound > 0 ) {
    				iWordFound = rtBoxExport.Find(chWord, iCharFound); 
    				if (iWordFound > 0 ) {
    					iDBGA = iWordFound - 3;
    					rtBoxExport.SelectionStart = 5;//iWordFound - 3;
						rtBoxExport.SelectionLength = 9;  //3;
						rtBoxExport.Cut();
						//rtBoxExport.Text = rtBoxExport.Text.Insert(iWordFound - 3, EnDusan.EnConfigRun.ProjectName);
    				}
   				}
    			break;
    		}
			int iDBGFlush = 999;
			// Save the contents of the RichTextBox into the file.
      		//rtBoxExport.SaveFile(SPtxtBxMistoUlozeni.Text, RichTextBoxStreamType.PlainText);			
      		/*if (!File.Exists(SPtxtBxFileName.Text))
            {
            	//File.Create(SPtxtBxFileName.Text);
                rtBoxExport.SaveFile(SPtxtBxFileName.Text, RichTextBoxStreamType.RichText);
            }*/
		}

		
		void eventbtnFill(object sender, EventArgs e)
		{
			int iDBGFill = 56;
			bFillOK = Fill();
			setSPBtnOKColor();
		}
		
		private bool Fill()
		{
			int iDBGFill = 23;		
			char[] charsToTrim = { ' ', '\t' };
			string sSearchWord;
			char chFromLine;
			string sWord, sWordProcWhole, sWordProcKey;
			char chWordPrefix = '=';
			string sRTFWork;  // = EnDusan.EnConfigRun.RTFBastl;
			string sRTFWorkFix = "";
			string sSubWordStart;
			int iWordStart;			
			string sSubWordEnd;
			int iWordEnd;			
			int iCharFound;
			string sWordSuffix = "_Rep";			
			int iWordSuffix;
			string sWordPrefix = "=";			
			int iWordPreffix;
			int iFixL;
			DGVProcesssed = EnConfigRun.DGVRun;
			int iLines, iChDBG, iChFound;
			string sNewWord;
			int iDBGSteps;
			decimal[] dSumas = EnDusan.EnConfigRun.SumaResult;
			//rtBoxExport.Rtf = EnDusan.EnConfigRun.RTFBastl;
			
			sRTFWork = EnDusan.EnConfigRun.RTFBastl; //rtBoxExport.Rtf; 			
			iChDBG = sRTFWork.Length;
			iWordStart = 0;
			iWordSuffix = -10;
			char chDBGStep;
			int iDBGFind = 0;
			int iStringL = sRTFWork.Length;
			int iStringStartL, iStringEndL, iStringWWholeL;
			//string sDEBUG = @"12345=Project_Replace123456ni: =DATE_Rep}12345=A1_Rep}\cel4567=U1.1_Rep}\cell1234=U2.1_Rep}\cell5678";
			//sRTFWork = sDEBUG;
			int iCells = 0;
			//sRTFWork = rtBoxExport.Text; 
			for ( int iCh = 0; iCh < sRTFWork.Length; iCh++)
			{
    			//Find Suffix
    			iWordStart = iCh;
    			iWordSuffix = sRTFWork.IndexOf(sWordSuffix, iWordStart);
    			if ( iWordSuffix == -1 ) {
    				//NENALEZENO iDBGFind = 1000;
					break;    				
    			}
    				
				//find first "SPACE" from index
				iWordPreffix = 0;
				for (int iChPrefix = iWordSuffix-1; iChPrefix > iWordStart; iChPrefix--) {
					chDBGStep = sRTFWork[iChPrefix];
					if ( sRTFWork[iChPrefix] == chWordPrefix ) {
						iWordPreffix = iChPrefix++;
						break;
					}
				}
				sWordProcWhole = sRTFWork.Substring(iWordPreffix, iWordSuffix - iWordPreffix +  sWordSuffix.Length);
				iStringWWholeL = sWordProcWhole.Length;
				//sWordProcWhole = sRTFWork.Substring(iWordPreffix, iWordSuffix - iWordPreffix - sWordSuffix.Length);
				sWordProcKey = sRTFWork.Substring(iWordPreffix+1, iWordSuffix - iWordPreffix-1);
				sSubWordStart = sRTFWork.Substring(0, iWordPreffix);
				//sSubWordEnd = sRTFWork.Substring(iWordSuffix - iWordPreffix +  sWordSuffix.Length +1);
				sSubWordEnd = sRTFWork.Substring(iWordSuffix +  sWordSuffix.Length);
				iStringStartL = sSubWordStart.Length;
				iStringEndL = sSubWordEnd.Length;
				int iIndexOfString;
				int iRowDGV, iColumnDGV;
				sWordProcKey = sWordProcKey.Trim(charsToTrim);
				switch (sWordProcKey)
				{
				 	case "Project":
						sNewWord = SPtxtProcessedProject.Text;
						sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;				        				        
						break;
					case "DATE":
				        sNewWord = DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss");
				        sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;				       
				        break;
					case "SA":
				        sNewWord = Convert.ToString( dSumas[0] );
				        sRTFWorkFix = sSubWordStart + sNewWord + sSubWordEnd;				        
				        break;
					case "SAU1":
				        sNewWord = Convert.ToString( dSumas[1] );
				        sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;				        
				        break;
					case "SAU2":
				        sNewWord = Convert.ToString( dSumas[2] );
				        sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;				        
				        break;				        
					default:
				        //Test columns				        
				        iIndexOfString = sWordProcKey.IndexOf("A");
				        if (iIndexOfString == 0 ) {
				        	//string sNumberRow = Convert.ToString(sWordProcKey[iIndexOfString+1]);
				        	string sNumberRow = sWordProcKey.Substring(iIndexOfString+1);
				        	iRowDGV  = Convert.ToInt16(sNumberRow) - 1;
				        	iColumnDGV = 1;
				        	string sA = "";
							DataGridViewRow DGVR = DGVProcesssed.Rows[iRowDGV];
							//int iColumn = 1;
							if ( DGVProcesssed[iColumnDGV,iRowDGV].Value == null )
								sA = " ";
							else
								sA = DGVProcesssed[iColumnDGV,iRowDGV].Value.ToString();
							//.Value.ToString;
				        	sNewWord = sA;
				        	sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;
				        	iCells++;
				        	break;
				        }
				        iIndexOfString = sWordProcKey.IndexOf("U1.");
				        if (iIndexOfString == 0 ) {				        
				        	//string sNumberRow = Convert.ToString(sWordProcKey[iIndexOfString+3]);
				        	string sNumberRow = sWordProcKey.Substring(iIndexOfString+3);
				        	iRowDGV = Convert.ToInt16(sNumberRow) - 1;
				        	string sA = "";
				        	iColumnDGV = 2;
							DataGridViewRow DGVR = DGVProcesssed.Rows[iRowDGV];
							if ( DGVProcesssed[iColumnDGV,iRowDGV].Value == null )
								sA = " ";
							else
								sA = DGVProcesssed[iColumnDGV,iRowDGV].Value.ToString();
							//.Value.ToString;
				        	sNewWord = sA;
				        	sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;
				        	iCells++;
				        	break;
				        }
				        iIndexOfString = sWordProcKey.IndexOf("U2.");
				        if (iIndexOfString == 0 ) {				        
				        	//string sNumberRow = Convert.ToString(sWordProcKey[iIndexOfString+3]);
				        	string sNumberRow = sWordProcKey.Substring(iIndexOfString+3);
				        	iRowDGV = Convert.ToInt16(sNumberRow) - 1;
				        	string sA = "";
				        	iColumnDGV = 3;
							DataGridViewRow DGVR = DGVProcesssed.Rows[iRowDGV];
							if ( DGVProcesssed[iColumnDGV,iRowDGV].Value == null )
								sA = " ";
							else
								sA = DGVProcesssed[iColumnDGV,iRowDGV].Value.ToString();
							//.Value.ToString;
				        	sNewWord = sA;
				        	sRTFWorkFix = sSubWordStart+sNewWord+ sSubWordEnd;
				        	iCells++;
				        	break;
				        }				        				        
				        break;
				} 
				iFixL = sRTFWorkFix.Length;
				rtBoxExport.Clear();
				rtBoxExport.Rtf = sRTFWorkFix;
				sRTFWork = sRTFWorkFix;
				//rtBoxExport.Update();
				//break;
				iCh = iWordSuffix +  sWordSuffix.Length;
				//string sDBGTT = "";
				//sDBGTT = sRTFWork.Substring(iCh,iCh+50);
				//if (iCells == 5 )
				//	break;
				if ( iCells%3 == 0 )
					iDBGSteps = 12;
    		}
			int iDBGFlush = 999;
			// Save the contents of the RichTextBox into the file.
      		//rtBoxExport.SaveFile(SPtxtBxMistoUlozeni.Text, RichTextBoxStreamType.PlainText);			
      		/*if (!File.Exists(SPtxtBxFileName.Text))
            {
            	//File.Create(SPtxtBxFileName.Text);
                rtBoxExport.SaveFile(SPtxtBxFileName.Text, RichTextBoxStreamType.RichText);
            }*/
      		return true;
		}
		
		
		
		
		void eventExpProjRTF(object sender, EventArgs e)
		{
			//rtBoxExport.SaveFile(SPtxtBxMistoUlozeni.Text, RichTextBoxStreamType.PlainText);
			if ( bFillOK ) {
				if (!File.Exists(SPtxtBxFileName.Text))
            	{
                	rtBoxExport.SaveFile(SPtxtBxFileName.Text, RichTextBoxStreamType.RichText);
            	}
				bFillOK = false;
				setSPBtnOKColor();
				Close();
			}
		}
	}
}

