/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/11/2015
 * Time: 7:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

using System.Collections.Generic;


namespace EnDusan
{
	/// <summary>
	/// Description of EnDusanForm.
	/// </summary>
	public partial class EnDusanMasterForm : Form
	{
		//EnConfigRun EnConfigRun;
		//HeaderText-0, Name-1, Visible-2, ReadOnly-3, Width-4, Type	-5
		private string[,] dgvEnColumns = new string[,]
		{{"Stena","Stena","true","false","60","System.Int16"},
		 {"A Plocha[xx]","A","true","false","80","System.Decimal"},
		 {"Ui[xx]","Ui","true","false","80","System.Decimal"},
		 {"UN,20[xx]","UN20","true","false","80","System.Decimal"},
		 {"Di[xx]","Di","true","false","80","System.Decimal"}
        };

        private decimal[] dWorkSuma = new decimal[3];
        private string sStore = "<textBox3>";        
        public string sCtrlToSaveTag = "XMLStorable";
        public string sCtrlMasterFormTag = "MasterForm";

        private List<Control> availControlsToXMLStorable;
        string sFiltrXMLStorable = "XMLStorable";
        string sFiltrPDF = "PDF_";
        private List<Control> availControlsToProcess;
        EnDusanMasterForm parentForm;

        //err Form ThisForm = new Form();       
        //DialogResult runDialogResult = new DialogResult(this);

        public string ProjectName 
		{
			get { return txtBoxProjekt.Text.ToString(); }
		}
		
		public DataGridView ProjectDGV
		{
			get { return dgvEn; }
		}
		
		
		private void setDGViewColums (DataGridView dgvName)
		{
			string sHeaderText, sName, sVisible, sWidth;
			for (int i = 0; i <= dgvEnColumns.GetUpperBound(0); i++)
			{
				sHeaderText = dgvEnColumns[i,0];
				sName = dgvEnColumns[i,1];
				sVisible = dgvEnColumns[i,2];
				sWidth = dgvEnColumns[i,3];
				
				
				DataGridViewTextBoxColumn dgvColumn = new DataGridViewTextBoxColumn();
				dgvColumn.HeaderText = dgvEnColumns[i,0];
				dgvColumn.Name = dgvEnColumns[i,1];
				dgvColumn.Visible = Boolean.Parse(dgvEnColumns[i,2]);
				dgvColumn.ReadOnly = Boolean.Parse(dgvEnColumns[i,3]);
				dgvColumn.Width =  Int16.Parse(dgvEnColumns[i,4]);
				dgvColumn.ValueType = Type.GetType(dgvEnColumns[i,5]);
				                                   

				
				dgvName.Columns.Add(dgvColumn);
			}				
		}
		
		/*public void readXMLRunConfig()
		{
			XmlDocument XMLCnfMaster = new X, XMLCnfRun;
		}*/

		public EnDusanMasterForm()
		{
			//EnConfigRun configEnWork = new EnConfigRun();
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//configWork.xmlDGVCountRow.ToString();
		}
		
		
		
		void PrgDEBUG () {
            //Header
            textBox3.Text = "NasText3";
            //textBox4.Text = "NasText4";
			txtBoxProjekt.Text = "TestDBG";
			EnDusan.EnConfigRun.ProjectName = txtBoxProjekt.Text;
			dgvEn[1, 0].Value = 1.11;
			dgvEn[2, 0].Value = 1.22;
			dgvEn[3, 0].Value = 1.33;
            dgvEn[4, 0].Value = 1.44;
            dgvEn[2, 2].Value = 2.22;
			dgvEn[3, 3].Value = 3.33;
            //Image
            textBox5.Text = "Label of Image";
			EnConfigRun.DGVRun = (DataGridView) dgvEn;
		}
		
		void ClearDGV() {
			int iDBG478 = 478;
			
			for (int iRows=0; iRows<dgvEn.Rows.Count; iRows++ ) {				
				dgvEn[1, iRows].Value = "";
				dgvEn[2, iRows].Value = "";
				dgvEn[3, iRows].Value = "";
                dgvEn[4, iRows].Value = "";
                dgvEn.Update();
				dgvEn.Refresh();
			}
			EnConfigRun.DGVRun = (DataGridView) dgvEn;
			iDBG478 = 1000;
		}
		
		
		void TestFillDGV() {
			int iDBG478 = 478;
			decimal dStartValue = 1.11M;
			for (int iRows=0; iRows<dgvEn.Rows.Count; iRows++ ) {
				dgvEn[1, iRows].Value = dStartValue * (iRows + 1) + 10;
				dgvEn[2, iRows].Value = dStartValue * (iRows + 1) + 20;
				dgvEn[3, iRows].Value = dStartValue * (iRows + 1) + 30;
				dgvEn.Update();
				dgvEn.Refresh();

			}
			EnConfigRun.DGVRun = (DataGridView) dgvEn;
			iDBG478 = 1000;
		}

        List<Control> controlListWork = new List<Control>();

        /*    string cText, cName, sCtrlToSave;
            sCtrlToSave = "";
            Type cType;
            string cTag;
            //foreach (Control wCNTRL in listCNTRL)
            Control wCNTRL;
            for(int iList=0; iList < listCNTRL.Count; iList++)
            {
                wCNTRL = listCNTRL[iList];
                cName = wCNTRL.Name;
                if (wCNTRL.Tag != null && wCNTRL.Tag.ToString() == "XMLStorable")
                {
                    cText = wCNTRL.Text;
                    cName = wCNTRL.Name;
                    cType = wCNTRL.GetType();
                    sCtrlToSave = sCtrlToSave + " " + cName + ";";
                }
                else
                {
                    listCNTRL.Remove(wCNTRL);
                    int iDBG478 = 478;
                }
            }
            return listCNTRL;
        }*/

        /*public static List<Control> Get_ControlsOLD(Control form)
        {
            var controlList = new List<Control>();
            Control.ControlCollection ctrColl = form.Controls;
            foreach (Control childControl in ctrColl)
            {
                // Recurse child controls.
                controlList.AddRange(Get_ControlsOLD(childControl));
                controlList.Add(childControl);
                //controlListWork.Add(childControl);
            }
            return controlList;
        }*/

        void eventFrmMaster_LoadForm(object sender, EventArgs e)
		{
			//if ( configEnRun == null )
			//	configEnRun = new EnConfigRun();

			//dgvEn.   .RowCount = 10;
			//configEnWork.DGVCountRow;
			EnDusan.EnConfigRun.DGVRun = (DataGridView) dgvEn;
			setDGViewColums ( dgvEn );
			dgvEn.RowCount = EnDusan.EnConfigRun.DGVCountRow;
            //20161218
            //List<Control> availControls = GetControlsLCH(this, controlListWork);
            /*availControls = GetControlsLCH(this, controlListWork);
            string cText, cName, sCtrlToSave;
            sCtrlToSave = "";
            Type cType;
            string cTag;
            foreach (Control wCNTRL in availControls)
            {
                cName = wCNTRL.Name;
                if (wCNTRL.Tag != null && wCNTRL.Tag.ToString() == "XMLStorable")
                {
                    cText = wCNTRL.Text;
                    cName = wCNTRL.Name;
                    cType = wCNTRL.GetType();
                    sCtrlToSave = sCtrlToSave + " " + cName + ";";
                }
            }*/
            int iDBG100 = 100;
            //20161127 PrgDEBUG();			
        }
		
		void eventFrmMaster_DGVRowAdd(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dgvEn.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();	
		}
		
		void eventMnItemExit_Click(object sender, EventArgs e)
		{
			Close();
		}

        public List<Control> GetControls(Control cControlParent)
        {
            List<Control> controlList = new List<Control>();

            foreach (Control childControl in cControlParent.Controls)
            {
                // Recurse child controls.
                if (childControl.HasChildren)
                {
                    controlList.AddRange(GetControls(childControl));
                }
                if (childControl.Tag != null && childControl.Tag.ToString() == sCtrlToSaveTag)// "XMLStorable")
                {
                    controlList.Add(childControl);
                }
                if (childControl.Tag != null && childControl.Tag.ToString() == sCtrlMasterFormTag)
                {
                    int iDBG369 = 369;
                    controlList.Add(childControl);
                }
                //return controlList;
            }
            return controlList;
        }

        //XMLStorable - 
        //PDF_Projekt -
        public List<Control> GetControlsNew(Control cControlParent, string sTagFiltr)
        {
            List<Control> controlList = new List<Control>();
            StringComparison SComp = StringComparison.Ordinal;
            
            foreach (Control childControl in cControlParent.Controls)
            {
                // Recurse child controls.
                if (childControl.HasChildren)
                {
                    controlList.AddRange(GetControls(childControl));
                }
                if (childControl.Tag != null && (childControl.Tag.ToString().Contains( sTagFiltr))) // "XMLStorable")
                {
                    controlList.Add(childControl);
                }
                if (childControl.Tag != null && (childControl.Tag.ToString().Contains(sTagFiltr)))
                {
                    int iDBG369 = 369;
                    controlList.Add(childControl);
                }
                //return controlList;
            }
            return controlList;
        }
        void getFormControls(string sFiltr)
        {
            parentForm = Application.OpenForms["EnDusanMasterForm"] as EnDusanMasterForm;
            availControlsToProcess = GetControlsNew(this, sFiltr);
            int iDBG777 = 777;
        }

        void eventMnItemUlozitProjekt20170104(object sender, EventArgs e)
		{
			int iDBG = 100;
            //Test Form Controls
            Control.ControlCollection coll = this.Controls;
            string cText, cName, sStorable;
            int iGetChildIndex;
            int iITER = 0;
            //List<Control> availControls = GetControls(this);
            availControlsToXMLStorable = GetControls(this);
            /*foreach (Control c in coll)
            {
                sStorable = "";
                if (c != null)
                {
                    iITER++;
                    cText = c.Text;
                    cName = c.Name;
                    iGetChildIndex = coll.GetChildIndex(c, false);
                    if (c.Tag != null && c.Tag.ToString() == "XMLStorable")
                    {
                        sStorable = "XMLStorable";
                        iGetChildIndex = coll.GetChildIndex(c, false);
                        Control cnt = this.Controls[cName];
                        Type myType = cnt.GetType();
                    }
                }
            }
            */
            /* Control.ControlCollection coll = Controls;
            foreach (Control c in coll)
            {
                string cText, cName;
                int iGetChildIndex;
                if (c != null)
                {
                    cText = c.Text;
                    cName = c.Name;
                    iGetChildIndex = coll.GetChildIndex(c, false);
                }
            }*/
            //SaveProjectXMLForm saveProjectXMLRun = new SaveProjectXMLForm();

            //EnDusanMasterForm 
            parentForm = Application.OpenForms["EnDusanMasterForm"] as EnDusanMasterForm;
            SaveProjectXMLForm saveProjectRun = new SaveProjectXMLForm(parentForm, availControlsToXMLStorable);

            int iDBG777 = 777;
            //Control formTest = ((EnDusanMasterForm)this.ParentForm);
            
            DialogResult dlgResult = new DialogResult();
            //err saveProjectXMLRun.Parent = this;
            dlgResult = saveProjectRun.ShowDialog();
			if ( dlgResult == DialogResult.OK ) {
				int iDBG101 = 101;
			} 
			if ( dlgResult == DialogResult.Cancel ) {
				int iDBG102 = 102;
			}
		}



        void eventMnItemUlozitPrjXML(object sender, EventArgs e)
        {
            int iDBG = 100;
            //Test Form Controls
            Control.ControlCollection coll = this.Controls;
            string cText, cName, sStorable;
            int iGetChildIndex;
            int iITER = 0;
            //List<Control> availControls = GetControls(this);
            availControlsToXMLStorable = GetControls(this);
            /*foreach (Control c in coll)
            {
                sStorable = "";
                if (c != null)
                {
                    iITER++;
                    cText = c.Text;
                    cName = c.Name;
                    iGetChildIndex = coll.GetChildIndex(c, false);
                    if (c.Tag != null && c.Tag.ToString() == "XMLStorable")
                    {
                        sStorable = "XMLStorable";
                        iGetChildIndex = coll.GetChildIndex(c, false);
                        Control cnt = this.Controls[cName];
                        Type myType = cnt.GetType();
                    }
                }
            }
            */
            /* Control.ControlCollection coll = Controls;
            foreach (Control c in coll)
            {
                string cText, cName;
                int iGetChildIndex;
                if (c != null)
                {
                    cText = c.Text;
                    cName = c.Name;
                    iGetChildIndex = coll.GetChildIndex(c, false);
                }
            }*/
            //SaveProjectXMLForm saveProjectXMLRun = new SaveProjectXMLForm();

            EnDusanMasterForm parentForm = Application.OpenForms["EnDusanMasterForm"] as EnDusanMasterForm;
            SaveProjectXMLForm saveProjectXMLRun = new SaveProjectXMLForm(parentForm, availControlsToXMLStorable);

            int iDBG777 = 777;
            //Control formTest = ((EnDusanMasterForm)this.ParentForm);

            DialogResult dlgResult = new DialogResult();
            //err saveProjectXMLRun.Parent = this;
            dlgResult = saveProjectXMLRun.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                int iDBG101 = 101;
            }
            if (dlgResult == DialogResult.Cancel)
            {
                int iDBG102 = 102;
            }
        }

        /*void eventTLTxtBoxProject(object sender, EventArgs e)
		{
			EnDusan.EnConfigRun.ProjectName = txtBoxProjekt.Text;		
		}*/

        void eventFrmMaster_TxtBoxProjectChange(object sender, EventArgs e)
		{
			EnDusan.EnConfigRun.ProjectName = txtBoxProjekt.Text;					
		}
		
		void eventMnPrjExpPDF(object sender, EventArgs e)
		{
            int iDBG777 = 777;
            getFormControls(sFiltrPDF);
            PDFForm runPDFForm = new PDFForm(parentForm, availControlsToProcess);
            runPDFForm.Show();
		}
		
		void eventMnPrj_ExportRTF(object sender, EventArgs e)
		{
			int iDBG = 100;
			EnDusan.EnConfigRun.DGVRun = (DataGridView) dgvEn;
			ExportProjectRTFForm exportProjectRTFRun = new ExportProjectRTFForm();
			DialogResult dlgResult;
			dlgResult = exportProjectRTFRun.ShowDialog();
			if ( dlgResult == DialogResult.OK ) {
				int iDBG101 = 101;
			} 
			if ( dlgResult == DialogResult.Cancel ) {
				int iDBG102 = 102;
			}
		}
		
		void eventMnPrj_OtevritProjekt(object sender, EventArgs e)
		{
			int iDBG = 100;
			EnDusan.EnConfigRun.DGVRun = (DataGridView) dgvEn;
			OtevritProjektXML openProjectRun = new OtevritProjektXML();
			DialogResult dlgResult;
			dlgResult = openProjectRun.ShowDialog();
			if ( dlgResult == DialogResult.OK ) {
				int iDBG101 = 101;
			} 
			if ( dlgResult == DialogResult.Cancel ) {
				int iDBG102 = 102;
			}			
		}
		
		
		void eventClearDGV(object sender, EventArgs e)
		{
			int iDBG78 = 78;
			ClearDGV();
			EnDusan.EnConfigRun.DGVDataChanged = false;
		}

		void eventFillDGVTest(object sender, EventArgs e)
		{
			int iDBG78 = 78;
			ClearDGV();
			TestFillDGV();
			EnDusan.EnConfigRun.DGVDataChanged = true;
		}

		
		void eventMnSystem_CNF(object sender, EventArgs e)
		{
			int iDBGCNF = 100;
			EnConfigForm EnConfigFormRun = new EnConfigForm();
			DialogResult dlgResult;
			dlgResult = EnConfigFormRun.ShowDialog();
			if ( dlgResult == DialogResult.OK ) {
				int iDBG101 = 101;
			} 
			if ( dlgResult == DialogResult.Cancel ) {
				int iDBG102 = 102;
			}
		}
		
			
		
		void eventMnOAplikaci(object sender, EventArgs e)
		{
			int iDBG777 = 777;	
		}
		
		
		
		void getSumaTab()
		{
			//decimal[] dWorkSuma = new decimal[3];
			int iDBG6666 = 12;
			dWorkSuma[0] = 0.0M;
			dWorkSuma[1] = 0.0M;
			dWorkSuma[2] = 0.0M;
			
			for (int iRows=0; iRows<dgvEn.Rows.Count; iRows++ ) {
				dWorkSuma[0] = dWorkSuma[0]  + Convert.ToDecimal(dgvEn[1, iRows].Value);
				dWorkSuma[1] = dWorkSuma[1]  + Convert.ToDecimal(dgvEn[1, iRows].Value) * Convert.ToDecimal(dgvEn[2, iRows].Value) * Convert.ToDecimal(dgvEn[4, iRows].Value);
				dWorkSuma[2] = dWorkSuma[2]  + Convert.ToDecimal(dgvEn[1, iRows].Value) * Convert.ToDecimal(dgvEn[3, iRows].Value) * Convert.ToDecimal(dgvEn[4, iRows].Value);
			}
			EnDusan.EnConfigRun.SumaResult = dWorkSuma;
			/*KVtxtSA.Text = Convert.ToString(dWorkSuma[0]);
			KVtxtSAU1.Text = Convert.ToString(dWorkSuma[1]);
			KVtxtSAU2.Text = Convert.ToString(dWorkSuma[2]);*/				
		}
		
		void eventSumaTab(object sender, EventArgs e)
		{
			getSumaTab();
			decimal[] dWorkSuma = new decimal[3];
			dWorkSuma = EnDusan.EnConfigRun.SumaResult;
			KVtxtSumaA.Text = Convert.ToString(dWorkSuma[0]);
			KVtxtSumaAUiDi.Text = Convert.ToString(dWorkSuma[1]);
			KVtxtSumaAUN20Di.Text = Convert.ToString(dWorkSuma[2]);
			
		}
		
		void eventLeave(object sender, EventArgs e)
		{
			getSumaTab();
		}

        private void btnDBG_Click(object sender, EventArgs e)
        {
            PrgDEBUG();
            getSumaTab();
            KVtxtSumaAUiDi.Text = Convert.ToString(dWorkSuma[1]);
            KVtxtSumaAUiDiMaster.Text = KVtxtSumaAUiDi.Text;
            KVtxtSumaAUN20Di.Text = Convert.ToString(dWorkSuma[2]);
            KVtxtSumaAUN20DiMaster.Text = KVtxtSumaAUN20Di.Text;
        }

        private void dgvEn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int iDBG = 123;
            getSumaTab();
            KVtxtSumaAUiDi.Text = Convert.ToString(dWorkSuma[1]);
            KVtxtSumaAUiDiMaster.Text = KVtxtSumaAUiDi.Text;
            KVtxtSumaAUN20Di.Text = Convert.ToString(dWorkSuma[2]);
            KVtxtSumaAUN20DiMaster.Text = KVtxtSumaAUN20Di.Text;
        }

        private void pctBoxA_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPict = new OpenFileDialog();
            openPict.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (openPict.ShowDialog() == DialogResult.OK)
            {
                pctBoxA.Image = new Bitmap(openPict.FileName);
                pctBoxA.SizeMode = PictureBoxSizeMode.StretchImage;                
            } 
        }

        #region Menu Item Print Click Event
        private void eventMnItemPrint_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }

    public static class EnConfigRun
    {
        private static string sIAMHERE = "I am Here!";
        private static string sCNFPathEXE = "";
        private static string sCNFDirEXEConfig = @"\EnCNF\";
        private static string sCNFPathEXEConfig = "";
        private static string sCNFFileName = @"EnRunCNF.xml";
        private static string sCNFFilePath = "";
        private static string sCNFDirEXEData = @"\EnData\";
        private static string sCNFPathEXEData = "";
        private static string sXMLEnCNFMasterFileName = @"XMLEnCNFMaster.xml";
        private static string sXMLEnCNFMasterFilePath = "";
        private static decimal[] dSumaResult = new decimal[3];
        private static bool bDGVDataChanged = false;
        private static bool bXMLEnCNFMasterExists = false;
        private static bool bXMLEnCNFRunExists = false;
        private static int iDGVRowCount = 10;
        private static bool bDGVFixRow = true;
        private static string sExportXML = @"C:\";
        private static string sProjectName = "";
        private static DataGridView dgvRun = new DataGridView();
        /* from file ENDusan002.rtf, 20151217*/
        private static string sRTFBastl = @"{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\froman\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f6\froman\fprq2\fcharset0 Arial;}{\f7\fnil\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}}
{\colortbl;\red0\green0\blue0;\red128\green128\blue128;\red0\green0\blue1;}
{\stylesheet{\s0\snext0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\s1\sbasedon15\snext1\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs36\lang1033 Heading 1;}
{\s2\sbasedon15\snext2\ql\nowidctlpar\sb200\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs32\lang1033 Heading 2;}
{\s3\sbasedon15\snext3\ql\nowidctlpar\sb140\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs28\lang1033 Heading 3;}
{\s15\sbasedon0\snext16\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f5\fs28\lang1033 Heading;}
{\s16\sbasedon0\snext16\sl288\slmult1\ql\nowidctlpar\sb0\sa140\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Text Body;}
{\s17\sbasedon16\snext17\sl288\slmult1\ql\nowidctlpar\sb0\sa140\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 List;}
{\s18\sbasedon0\snext18\ql\nowidctlpar\sb120\sa120\ltrpar\cf1\i\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Caption;}
{\s19\sbasedon0\snext19\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Index;}
{\s20\sbasedon0\snext20\ql\nowidctlpar\li567\ri567\lin567\rin567\fi0\sb0\sa283\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Quotations;}
{\s21\sbasedon15\snext21\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f5\fs56\lang1033 Title;}
{\s22\sbasedon15\snext22\ql\nowidctlpar\sb60\sa120\keepn\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f5\fs36\lang1033 Subtitle;}
{\s23\sbasedon0\snext23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Table Contents;}
{\s24\sbasedon23\snext24\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Table Heading;}
}{\*\generator LibreOffice/4.4.1.2$Windows_x86 LibreOffice_project/45e2de17089c24a1fa810c8f975a7171ba4cd432}{\info{\creatim\yr2015\mo11\dy22\hr19\min43}{\revtim\yr2015\mo12\dy19\hr6\min7}{\printim\yr0\mo0\dy0\hr0\min0}}\deftab367
\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade{\*\pgdscno0}\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1033\rtlch \ltrch\fs32\lang1033
 }{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Projekt: =Project_Rep}
\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1033\rtlch \ltrch\fs32\lang1033
 }{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Datum Zpracovani: =DATE_Rep}
\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Polozka}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
A [mm]}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
U1 [mm]}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
U2 [mm]}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
1}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.1_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
2}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.2_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
3}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.3_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
4}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.4_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
5}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.5_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
6}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.6_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
7}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.7_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
8}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.8_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
9}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.9_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1499\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4446\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7501\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10127\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
10}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.10_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \trowd\trql\trleft1356\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx3848\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx6341\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\clbrdrr\brdrs\brdrw2\brdrcf3\cellx8834\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx11327\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1033\accnone\rtlch \ltrch\fs32\lang1033\loch\f6
\u8721\'3f }{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033\loch\f6
A}\cell\trowd\trql\trleft1356\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx3848\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx6341\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\clbrdrr\brdrs\brdrw2\brdrcf3\cellx8834\clbrdrt\brdrs\brdrw2\brdrcf3\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx11327\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1033\accnone\rtlch \ltrch\fs32\lang1033\loch\f6
\u8721\'3f }{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033\loch\f6
A*U1}\cell\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1033\accnone\rtlch \ltrch\fs32\lang1033\loch\f6
\u8721\'3f }{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033\loch\f6
A*U2}\cell\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033
\cell\cell\row\pard\trowd\trql\trleft1356\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx5552\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\cellx8945\clbrdrl\brdrs\brdrw2\brdrcf3\clbrdrb\brdrs\brdrw2\brdrcf3\clbrdrr\brdrs\brdrw2\brdrcf3\cellx11327\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b0\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033
= SA_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b0\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033
= SAU1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b0\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
= SAU2_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\rtlch \ltrch\loch

\par }";
        /*@"{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\froman\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\froman\fprq2\fcharset0 Arial;}{\f6\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f7\fnil\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}}
{\colortbl;\red0\green0\blue0;\red128\green128\blue128;\red0\green0\blue1;}
{\stylesheet{\s0\snext0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\s1\sbasedon15\snext1\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f6\fs36\lang1033 Heading 1;}
{\s2\sbasedon15\snext2\ql\nowidctlpar\sb200\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f6\fs32\lang1033 Heading 2;}
{\s3\sbasedon15\snext3\ql\nowidctlpar\sb140\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f6\fs28\lang1033 Heading 3;}
{\s15\sbasedon0\snext16\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs28\lang1033 Heading;}
{\s16\sbasedon0\snext16\sl288\slmult1\ql\nowidctlpar\sb0\sa140\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Text Body;}
{\s17\sbasedon16\snext17\sl288\slmult1\ql\nowidctlpar\sb0\sa140\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 List;}
{\s18\sbasedon0\snext18\ql\nowidctlpar\sb120\sa120\ltrpar\cf1\i\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Caption;}
{\s19\sbasedon0\snext19\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Index;}
{\s20\sbasedon0\snext20\ql\nowidctlpar\li567\ri567\lin567\rin567\fi0\sb0\sa283\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Quotations;}
{\s21\sbasedon15\snext21\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs56\lang1033 Title;}
{\s22\sbasedon15\snext22\ql\nowidctlpar\sb60\sa120\keepn\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs36\lang1033 Subtitle;}
{\s23\sbasedon0\snext23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Table Contents;}
{\s24\sbasedon23\snext24\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Table Heading;}
}{\*\generator LibreOffice/4.4.1.2$Windows_x86 LibreOffice_project/45e2de17089c24a1fa810c8f975a7171ba4cd432}{\info{\creatim\yr2015\mo11\dy22\hr19\min43}{\revtim\yr2015\mo12\dy17\hr13\min17}{\printim\yr0\mo0\dy0\hr0\min0}}\deftab367
\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade{\*\pgdscno0}\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1033\rtlch \ltrch\fs32\lang1033
}{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Projekt: =Project_Rep}
\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1033\rtlch \ltrch\fs32\lang1033
}{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Datum Zpracovani: =DATE_Rep}
\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Polozka}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
A [mm]}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
U1 [mm]}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
U2 [mm]}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
1}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.1_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
2}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.2_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
3}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.3_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
4}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.4_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
5}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.5_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
6}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.6_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
7}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.7_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
8}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.8_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
9}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.9_Rep}\cell\row\pard\trowd\trql\trleft156\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx1365\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4358\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7460\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx10128\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
10}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.10_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \trowd\trql\trleft1356\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx4768\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx8622\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\clbrdrr\brdrhair\brdrw1\brdrcf1\cellx11328\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1033\accnone\rtlch \ltrch\fs32\lang1033\loch\f5
\u8721\'3f }{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033\loch\f5
A*U1}\cell\trowd\trql\trleft1356\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx4768\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx8622\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\clbrdrr\brdrhair\brdrw1\brdrcf1\cellx11328\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1033\accnone\rtlch \ltrch\fs32\lang1033\loch\f5
\u8721\'3f }{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033\loch\f5
A*U1}\cell\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1033\accnone\rtlch \ltrch\fs32\lang1033\loch\f5
\u8721\'3f }{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033\loch\f5
A*U2}\cell\cell\row\pard\trowd\trql\trleft1356\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx4768\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx8622\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\clbrdrr\brdrhair\brdrw1\brdrcf1\cellx11328\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b0\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033
= SAU1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b0\kerning1\dbch\af7\langfe1081\accnone\rtlch \ltrch\loch\fs32\lang1033
= SAU1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\qc\nowidctlpar{\cf1\outl0\strike0\i0\shad0\ulnone\ulc0\b0\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
= SAU2_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\aspalpha\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\rtlch \ltrch\loch

\par }";*/
        /*@"{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\froman\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f6\froman\fprq2\fcharset0 Arial;}{\f7\fnil\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}}
{\colortbl;\red0\green0\blue0;\red128\green128\blue128;\red0\green0\blue1;}
{\stylesheet{\s0\snext0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\s1\sbasedon15\snext1\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs36\lang1033 Heading 1;}
{\s2\sbasedon15\snext2\ql\nowidctlpar\sb200\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs32\lang1033 Heading 2;}
{\s3\sbasedon15\snext3\ql\nowidctlpar\sb140\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f4\fs28\lang1033 Heading 3;}
{\s15\sbasedon0\snext16\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f5\fs28\lang1033 Heading;}
{\s16\sbasedon0\snext16\sl288\slmult1\ql\nowidctlpar\sb0\sa140\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Text Body;}
{\s17\sbasedon16\snext17\sl288\slmult1\ql\nowidctlpar\sb0\sa140\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 List;}
{\s18\sbasedon0\snext18\ql\nowidctlpar\sb120\sa120\ltrpar\cf1\i\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Caption;}
{\s19\sbasedon0\snext19\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Index;}
{\s20\sbasedon0\snext20\ql\nowidctlpar\li567\ri567\lin567\rin567\fi0\sb0\sa283\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Quotations;}
{\s21\sbasedon15\snext21\ql\nowidctlpar\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f5\fs56\lang1033 Title;}
{\s22\sbasedon15\snext22\ql\nowidctlpar\sb60\sa120\keepn\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f5\fs36\lang1033 Subtitle;}
{\s23\sbasedon0\snext23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Table Contents;}
{\s24\sbasedon23\snext24\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033 Table Heading;}
}{\*\generator LibreOffice/4.4.1.2$Windows_x86 LibreOffice_project/45e2de17089c24a1fa810c8f975a7171ba4cd432}{\info{\creatim\yr2015\mo11\dy22\hr19\min43}{\revtim\yr2015\mo12\dy17\hr8\min25}{\printim\yr0\mo0\dy0\hr0\min0}}\deftab367
\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade{\*\pgdscno0}\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs24\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Projekt: =Project_Rep}
\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Datum Zpracovani: =DATE_Rep}
\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrt\brdrs\brdrw15\brdrcf3\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
Polozka}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
A [mm]}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
U1 [mm]}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
U2 [mm]}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
1}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.1_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
2}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.2_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
3}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.3_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
4}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.4_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
5}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.5_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
6}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.6_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
7}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.7_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
8}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.8_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
9}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.9_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx2058\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf3\clbrdrb\brdrs\brdrw15\brdrcf3\clbrdrr\brdrs\brdrw15\brdrcf3\cellx9970\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
10}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=A10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U1.10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar{\cf1\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033
=U2.10_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \trowd\trql\trleft2136\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx5796\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx9343\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\clbrdrr\brdrhair\brdrw1\brdrcf1\cellx12108\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc{\outl0\strike0\i0\shad0\ulnone\ulc0\b\afs32\ab\accnone\rtlch \ltrch\fs32\loch\f6
\u8721\'3f}{\outl0\strike0\i0\shad0\ulnone\ulc0\b\afs32\ab\accnone\rtlch \ltrch\loch\fs32\loch\f6
A}\cell\trowd\trql\trleft2136\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx5796\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx9343\clbrdrt\brdrhair\brdrw1\brdrcf1\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\clbrdrr\brdrhair\brdrw1\brdrcf1\cellx12108\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc{\outl0\strike0\i0\shad0\ulnone\ulc0\b\afs32\ab\accnone\rtlch \ltrch\fs32\loch\f6
\u8721\'3f }{\outl0\strike0\i0\shad0\ulnone\ulc0\b\afs32\ab\accnone\rtlch \ltrch\loch\fs32\loch\f6
A*U1}\cell\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\intbl\qc{\outl0\strike0\i0\shad0\ulnone\ulc0\b\afs32\ab\accnone\rtlch \ltrch\fs32\loch\f6
\u8721\'3f }{\outl0\strike0\i0\shad0\ulnone\ulc0\b\afs32\ab\accnone\rtlch \ltrch\loch\fs32\loch\f6
A*U2}\cell\cell\row\pard\trowd\trql\trleft2136\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx5796\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\cellx9343\clbrdrl\brdrhair\brdrw1\brdrcf1\clbrdrb\brdrhair\brdrw1\brdrcf1\clbrdrr\brdrhair\brdrw1\brdrcf1\cellx12108\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl{\afs32\rtlch \ltrch\fs32
 }{\afs32\rtlch \ltrch\loch\fs32
= SA_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl{\afs32\rtlch \ltrch\fs32
 }{\afs32\rtlch \ltrch\loch\fs32
= SAU1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\ltrpar\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\loch\f3\fs24\lang1033\intbl{\afs32\rtlch \ltrch\fs32
 }{\afs32\rtlch \ltrch\loch\fs32
= SAU2_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\cf1\b\kerning1\dbch\af7\langfe1081\rtlch \ltrch\loch\fs32\lang1033

\par \pard\plain \s0\ql\nowidctlpar\ltrpar{\*\hyphen2\hyphlead2\hyphtrail2\hyphmax0}\cf1\kerning1\dbch\af7\langfe1081\dbch\af7\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\rtlch \ltrch\loch

\par }";*/

        /*@"{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\froman\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f6\fnil\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}}
{\colortbl;\red0\green0\blue0;\red0\green0\blue255;\red0\green255\blue255;\red0\green255\blue0;\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;\red128\green128\blue0;\red128\green128\blue128;\red192\green192\blue192;\red0\green0\blue1;}
{\stylesheet{\s0\snext0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\s1\sbasedon15\snext1\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs36\lang1033 Heading 1;}
{\s2\sbasedon15\snext2\ql\nowidctlpar\hyphpar0\sb200\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs32\lang1033 Heading 2;}
{\s3\sbasedon15\snext3\ql\nowidctlpar\hyphpar0\sb140\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs28\lang1033 Heading 3;}
{\s15\sbasedon0\snext16\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs28\lang1033 Heading;}
{\s16\sbasedon0\snext16\sl288\slmult1\ql\nowidctlpar\hyphpar0\sb0\sa140\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Text Body;}
{\s17\sbasedon16\snext17\sl288\slmult1\ql\nowidctlpar\hyphpar0\sb0\sa140\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 List;}
{\s18\sbasedon0\snext18\ql\nowidctlpar\hyphpar0\sb120\sa120\ltrpar\cf1\i\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Caption;}
{\s19\sbasedon0\snext19\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Index;}
{\s20\sbasedon0\snext20\ql\nowidctlpar\hyphpar0\li567\ri567\lin567\rin567\fi0\sb0\sa283\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Quotations;}
{\s21\sbasedon15\snext21\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs56\lang1033 Title;}
{\s22\sbasedon15\snext22\ql\nowidctlpar\hyphpar0\sb60\sa120\keepn\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs36\lang1033 Subtitle;}
{\s23\sbasedon0\snext23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Table Contents;}
{\s24\sbasedon23\snext24\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Table Heading;}
}{\*\generator LibreOffice/5.0.2.2$Windows_x86 LibreOffice_project/37b43f919e4de5eeaca9b9755ed688758a8251fe}{\info{\creatim\yr2015\mo11\dy22\hr19\min43}{\revtim\yr2015\mo11\dy25\hr22\min21}{\printim\yr0\mo0\dy0\hr0\min0}}\deftab709
\hyphauto0\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade{\*\pgdscno0}\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\rtlch \ltrch\loch

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Projekt: =Project_Rep}
\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Datum Zpracovani: =DATE_Rep}
\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Polozka}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
A [mm]}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
U1 [mm]}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
U2 [mm]}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
1}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.1_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
2}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.2_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.2_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
3}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.3_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
4}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.4_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
5}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.5_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
6}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.6_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
7}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.7_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
8}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.8_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
9}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.9_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2059\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7789\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
10}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=A10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U1.10_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
=U2.10_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\rtlch \ltrch\loch

\par }";*/
        /*{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\froman\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f6\fnil\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}}
{\colortbl;\red0\green0\blue0;\red0\green0\blue255;\red0\green255\blue255;\red0\green255\blue0;\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;\red128\green128\blue0;\red128\green128\blue128;\red192\green192\blue192;\red0\green0\blue1;}
{\stylesheet{\s0\snext0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\s1\sbasedon15\snext1\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs36\lang1033 Heading 1;}
{\s2\sbasedon15\snext2\ql\nowidctlpar\hyphpar0\sb200\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs32\lang1033 Heading 2;}
{\s3\sbasedon15\snext3\ql\nowidctlpar\hyphpar0\sb140\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs28\lang1033 Heading 3;}
{\s15\sbasedon0\snext16\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs28\lang1033 Heading;}
{\s16\sbasedon0\snext16\sl288\slmult1\ql\nowidctlpar\hyphpar0\sb0\sa140\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Text Body;}
{\s17\sbasedon16\snext17\sl288\slmult1\ql\nowidctlpar\hyphpar0\sb0\sa140\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 List;}
{\s18\sbasedon0\snext18\ql\nowidctlpar\hyphpar0\sb120\sa120\ltrpar\cf1\i\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Caption;}
{\s19\sbasedon0\snext19\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Index;}
{\s20\sbasedon0\snext20\ql\nowidctlpar\hyphpar0\li567\ri567\lin567\rin567\fi0\sb0\sa283\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Quotations;}
{\s21\sbasedon15\snext21\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs56\lang1033 Title;}
{\s22\sbasedon15\snext22\ql\nowidctlpar\hyphpar0\sb60\sa120\keepn\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs36\lang1033 Subtitle;}
{\s23\sbasedon0\snext23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Table Contents;}
{\s24\sbasedon23\snext24\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Table Heading;}
}{\*\generator LibreOffice/5.0.2.2$Windows_x86 LibreOffice_project/37b43f919e4de5eeaca9b9755ed688758a8251fe}{\info{\creatim\yr2015\mo11\dy22\hr19\min43}{\revtim\yr2015\mo11\dy25\hr20\min12}{\printim\yr0\mo0\dy0\hr0\min0}}\deftab709
\hyphauto0\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade{\*\pgdscno0}\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\rtlch \ltrch\loch

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Projekt: .Project_Rep}
\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Datum Zpracovani: .DATE_Rep}
\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Polozka}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
A [mm]}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
U1 [mm]}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
U2 [mm]}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
1}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A1_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U11_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U21_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
2}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A}{\rtlch \ltrch\loch\fs32
2}{\rtlch \ltrch\loch\fs32
_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U12_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U22_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
3}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A3_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U13_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U23_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
4}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A4_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U14_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U24_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
5}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A5_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U15_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U25_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
6}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A6_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U16_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U26_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
7}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A7_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U17_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U27_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
8}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A8_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U18_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U28_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
9}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A9_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U19_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U29_Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2061\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7788\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
10}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A1}{\rtlch \ltrch\loch\fs32
0}{\rtlch \ltrch\loch\fs32
_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U11}{\rtlch \ltrch\loch\fs32
0}{\rtlch \ltrch\loch\fs32
_Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U21}{\rtlch \ltrch\loch\fs32
0}{\rtlch \ltrch\loch\fs32
_Rep}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\rtlch \ltrch\loch

\par }"; */
        /*{\rtf1\ansi\deff3\adeflang1025
{\fonttbl{\f0\froman\fprq2\fcharset0 Times New Roman;}{\f1\froman\fprq2\fcharset2 Symbol;}{\f2\fswiss\fprq2\fcharset0 Arial;}{\f3\froman\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}{\f4\fswiss\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f5\froman\fprq2\fcharset0 Liberation Sans{\*\falt Arial};}{\f6\fnil\fprq2\fcharset0 Liberation Serif{\*\falt Times New Roman};}}
{\colortbl;\red0\green0\blue0;\red0\green0\blue255;\red0\green255\blue255;\red0\green255\blue0;\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;\red128\green128\blue0;\red128\green128\blue128;\red192\green192\blue192;\red0\green0\blue1;}
{\stylesheet{\s0\snext0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033 Normal;}
{\s1\sbasedon15\snext1\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs36\lang1033 Heading 1;}
{\s2\sbasedon15\snext2\ql\nowidctlpar\hyphpar0\sb200\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs32\lang1033 Heading 2;}
{\s3\sbasedon15\snext3\ql\nowidctlpar\hyphpar0\sb140\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f4\fs28\lang1033 Heading 3;}
{\s15\sbasedon0\snext16\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs28\lang1033 Heading;}
{\s16\sbasedon0\snext16\sl288\slmult1\ql\nowidctlpar\hyphpar0\sb0\sa140\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Text Body;}
{\s17\sbasedon16\snext17\sl288\slmult1\ql\nowidctlpar\hyphpar0\sb0\sa140\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 List;}
{\s18\sbasedon0\snext18\ql\nowidctlpar\hyphpar0\sb120\sa120\ltrpar\cf1\i\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Caption;}
{\s19\sbasedon0\snext19\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Index;}
{\s20\sbasedon0\snext20\ql\nowidctlpar\hyphpar0\li567\ri567\lin567\rin567\fi0\sb0\sa283\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Quotations;}
{\s21\sbasedon15\snext21\ql\nowidctlpar\hyphpar0\sb240\sa120\keepn\ltrpar\cf1\b\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs56\lang1033 Title;}
{\s22\sbasedon15\snext22\ql\nowidctlpar\hyphpar0\sb60\sa120\keepn\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f5\fs36\lang1033 Subtitle;}
{\s23\sbasedon0\snext23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033 Table Contents;}
}{\*\generator LibreOffice/5.0.2.2$Windows_x86 LibreOffice_project/37b43f919e4de5eeaca9b9755ed688758a8251fe}{\info{\creatim\yr2015\mo11\dy22\hr19\min43}{\revtim\yr2015\mo11\dy24\hr21\min41}{\printim\yr0\mo0\dy0\hr0\min0}}\deftab709
\hyphauto0\viewscale100
{\*\pgdsctbl
{\pgdsc0\pgdscuse451\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\pgdscnxt0 Default Style;}}
\formshade{\*\pgdscno0}\paperh15840\paperw12240\margl1134\margr1134\margt1134\margb1134\sectd\sbknone\sectunlocked1\pgndec\pgwsxn12240\pghsxn15840\marglsxn1134\margrsxn1134\margtsxn1134\margbsxn1134\ftnbj\ftnstart1\ftnrstcont\ftnnar\aenddoc\aftnrstcont\aftnstart1\aftnnrlc
{\*\ftnsep\chftnsep}\pgndec\pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\rtlch \ltrch\loch

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Projekt: .Project_Rep}
\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
D}{\b\rtlch \ltrch\loch\fs32
a}{\b\rtlch \ltrch\loch\fs32
tum Zpracovani: DATE_Rep}
\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrt\brdrs\brdrw15\brdrcf17\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
Polozka}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
A [mm]}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
U1 [mm]}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
U2 [mm]}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
1}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.A1_}{\rtlch \ltrch\loch\fs32
Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U11_}{\rtlch \ltrch\loch\fs32
Rep}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
.U21_}{\rtlch \ltrch\loch\fs32
Rep}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
2}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_2}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_2}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_2}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
3}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_3}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_3}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_3}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
4}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_4}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_4}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_4}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
5}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_5}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_5}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_5}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
6}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_6}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_6}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_6}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
7}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_7}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_7}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_7}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
8}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_8}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_8}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_8}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
9}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_9}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_9}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_9}\cell\row\pard\trowd\trql\trleft0\ltrrow\trpaddft3\trpaddt0\trpaddfl3\trpaddl0\trpaddfb3\trpaddb0\trpaddfr3\trpaddr0\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx2062\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx4995\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\cellx7787\clbrdrl\brdrs\brdrw15\brdrcf17\clbrdrb\brdrs\brdrw15\brdrcf17\clbrdrr\brdrs\brdrw15\brdrcf17\cellx9970\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\b\rtlch \ltrch\loch\fs32
10}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
A_10}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U1_10}\cell\pard\plain \s23\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\loch\f3\fs24\lang1033\intbl\ql\nowidctlpar\hyphpar0\ltrpar{\rtlch \ltrch\loch\fs32
U2_10}\cell\row\pard\pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\b\rtlch \ltrch\loch\fs32

\par \pard\plain \s0\ql\nowidctlpar\hyphpar0\ltrpar\cf1\kerning1\dbch\af6\langfe1081\dbch\af6\afs24\alang1081\loch\f3\fs24\lang1033\ql\nowidctlpar\hyphpar0\ltrpar\rtlch \ltrch\loch

\par }";*/

        /*iDGVRowCount = 10;
		bDGVFixRow = true;
		sExportXML = @"F:\"; */

        /*public EnConfigRun()
		{
			iDGVRowCount = 10;
			bDGVFixRow = true;
			sExportXML = @"F:\";
		}
		*/

        public static string IAmHere
        {
            get { return sIAMHERE; }
        }

        public static string CNFPathEXE
        {
            get { return sCNFPathEXE; }
            set
            {
                sCNFPathEXE = value;
                sCNFPathEXEConfig = sCNFPathEXE + sCNFDirEXEConfig;
                sCNFPathEXEData = sCNFPathEXE + sCNFDirEXEData;
                sXMLEnCNFMasterFilePath = sCNFPathEXEConfig + sXMLEnCNFMasterFileName;
                sCNFFilePath = sCNFPathEXEConfig + sCNFFileName;
            }
        }

        public static string CNFDirEXEConfig
        {
            get { return sCNFDirEXEConfig; }
            set { sCNFDirEXEConfig = value; }
        }

        public static string EnCNFFile
        {
            get { return sCNFFileName; }
            set { sCNFFileName = value; }
        }

        public static string XMLEnCNFMasterFilePath
        {
            get { return sXMLEnCNFMasterFilePath; }
            set { sXMLEnCNFMasterFilePath = value; }
        }

        public static string CNFDirEXEData
        {
            get { return sCNFDirEXEData; }
            set { sCNFDirEXEData = value; }
        }

        public static string CNFFilePath
        {
            get { return sCNFFilePath; }
            set { sCNFFilePath = value; }
        }

        public static string XMLEnCNFMasterFileName
        {
            get { return sXMLEnCNFMasterFileName; }
            set { sXMLEnCNFMasterFileName = value; }
        }

        public static string CNFPathEXEConfig
        {
            get { return sCNFPathEXEConfig; }
            set { sCNFPathEXEConfig = value; }
        }

        public static string CNFPathEXEData
        {
            get { return sCNFPathEXEData; }
            set { sCNFPathEXEData = value; }
        }

        public static bool XMLEnCNFMasterExists
        {
            get { return bXMLEnCNFMasterExists; }
            set { bXMLEnCNFMasterExists = value; }
        }

        public static bool XMLEnCNFRunExists
        {
            get { return bXMLEnCNFRunExists; }
            set { bXMLEnCNFRunExists = value; }
        }

        public static int DGVCountRow
        {
            get { return iDGVRowCount; }
            set { iDGVRowCount = value; }
        }

        public static bool DGVDataChanged
        {
            get { return bDGVDataChanged; }
            set { bDGVDataChanged = value; }
        }

        public static bool DGVFixRow
        {
            get { return bDGVFixRow; }
            set { bDGVFixRow = value; }
        }

        public static string ExportXML
        {
            get { return sExportXML; }
            set { sExportXML = value; }
        }

        public static string ProjectName
        {
            get { return sProjectName; }
            set { sProjectName = value; }
        }

        public static DataGridView DGVRun
        {
            get { return dgvRun; }
            set { dgvRun = value; }
        }

        public static decimal[] SumaResult
        {
            get { return dSumaResult; }
            set { dSumaResult = value; }
        }
        public static string RTFBastl
        {
            get { return sRTFBastl; }
            set { sRTFBastl = value; }
        }

        public static void readXMLRunConfig()
        {
            XmlDocument XMLCnfMaster = new XmlDocument();
            XmlDocument XMLCnfRun = new XmlDocument();
            XmlNodeList XMLEnMasterElementTop, XMLEnMasterList, XMLEnRunElementTop, XMLEnRunList;

            string sXMLRunElementValue;
            string sNazevPolozky, sHodnotaMaster, sHodnotaRun;

            XMLCnfMaster.Load(sXMLEnCNFMasterFilePath);
            XMLEnMasterElementTop = XMLCnfMaster.SelectNodes("EnCNFMaster");
            if (XMLEnMasterElementTop.Count == 1)
            {
                XMLEnMasterList = XMLCnfMaster.SelectNodes("EnCNFMaster/Polozka");
                if (XMLEnMasterList.Count > 0)
                {
                    int iDBGMasterOK = 10;
                }
            }
            //Processing Running CNF and update running environment			
            XMLCnfRun.Load(sCNFFilePath);
            XMLEnRunElementTop = XMLCnfRun.SelectNodes("EnCNFRun");
            if (XMLEnRunElementTop.Count == 1)
            {
                XMLEnRunList = XMLCnfRun.SelectNodes("EnCNFRun/Polozka");
                if (XMLEnRunList.Count > 0)
                {
                    int iDBGRunOK = 10;
                    foreach (XmlElement XMLRunElement in XMLEnRunList)
                    {
                        sXMLRunElementValue = XMLRunElement.InnerText;
                        XmlAttributeCollection XMLRunElementAttrColl = XMLRunElement.Attributes;
                        sNazevPolozky = XMLRunElementAttrColl["NazevPolozky"].Value;
                        sHodnotaRun = XMLRunElementAttrColl["Hodnota"].Value;
                        //Master
                        XMLEnMasterList = XMLCnfMaster.SelectNodes("EnCNFMaster/Polozka[@NazevPolozky='" + sNazevPolozky + "']");
                        //XMLEnMasterList = XMLEnMasterElementTop.SelectNodes("//Polozka[@NazevPolozky=sNazevPolozky");
                        int iDBGCount = XMLEnMasterList.Count;
                        if (XMLEnMasterList.Count == 1)
                        {
                            XmlElement XMLMasterElement = (XmlElement)XMLEnMasterList.Item(0);
                            XmlAttributeCollection XMLMasterElementAttrColl = XMLMasterElement.Attributes;
                            sHodnotaMaster = XMLMasterElementAttrColl[5].Value;
                            switch (sHodnotaMaster)
                            {
                                case "fPathEnDATA":
                                    sCNFPathEXEData = sHodnotaRun;
                                    if (!Directory.Exists(sHodnotaRun))
                                    {
                                        Directory.CreateDirectory(sHodnotaRun);
                                    }
                                    break;
                                case "fPathEnCNF":
                                    sCNFDirEXEConfig = sHodnotaRun;
                                    break;
                                case "fCountRows":
                                    iDGVRowCount = Convert.ToInt16(sHodnotaRun);
                                    break;
                            }
                        }
                    }
                }
            }
        }

    } //EndOfClass
}
