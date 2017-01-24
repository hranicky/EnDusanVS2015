/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 12/1/2015
 * Time: 2:25 PM
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
	/// Description of OtevritProjektXML.
	/// </summary>
	public partial class OtevritProjektXML : Form
	{
		private bool bOPFileExists;
		
		public OtevritProjektXML()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//PrgDEBUG();
		}
		
		
		
		/*void PrgDEBUG () {
        	OPtxtBxMistoUlozeni.Text = @"C:\\TestDBG.xml";
        }*/

		void eventFrmLoad(object sender, EventArgs e)
		{
			OPtxtBxMistoUlozeni.Text = EnDusan.EnConfigRun.CNFPathEXEData;
			OPtxtBxFileName.Text = EnDusan.EnConfigRun.CNFPathEXEData;
			bOPFileExists = false;
		}
		
		void eventFileNameChanged(object sender, EventArgs e)
		{
			if( !File.Exists( OPtxtBxFileName.Text ) ) {
				bOPFileExists = false;	
			}
			else {
				bOPFileExists = true;
			}
		}
		
		void eventOPReadXML(object sender, EventArgs e)
		{
			int iDBGRead = 100;
			if ( !bOPFileExists )
				return;
			
			XmlSerializer XMLserializerReadRun = new XmlSerializer(typeof(EnDusan.DATAExportSerializXMLDef));
			EnDusan.DATAExportSerializXMLDef XMLReadRun = new EnDusan.DATAExportSerializXMLDef();					
			// Read file.
			using (TextReader textReader = new StreamReader(OPtxtBxFileName.Text) )
			{
				XMLReadRun = (EnDusan.DATAExportSerializXMLDef)XMLserializerReadRun.Deserialize(textReader);
				textReader.Close();
			}
			//Fill ProjectName
			SPtxtProcessedProject.Text = XMLReadRun.sProjectName;
			EnConfigRun.ProjectName = XMLReadRun.sProjectName;
			string sProjet = XMLReadRun.sProjectName;
			//DGV Columns Names ...
			foreach (DataGridViewColumn column in EnConfigRun.DGVRun.Columns)
			{
    			string sColumn = column.Name;
			}
			
			//Fill DGV
			int iDBGXML = 10;
			if ( iDBGXML == 1 ) {
				//EnConfigRun.DGVRun.DataSource = null;
				//EnConfigRun.DGVRun.Rows.Clear();
				//EnConfigRun.DGVRun.AutoGenerateColumns = false;
				EnConfigRun.DGVRun.DataSource = XMLReadRun.Details;				
				foreach (DataGridViewColumn column in EnConfigRun.DGVRun.Columns)
				{
	    			string sColumn = column.Name;
				}				
			}
			else {
				int iDBGDBG = 0;								
				openDGVTrans.DataSource = XMLReadRun.Details;
				int iRows = openDGVTrans.Rows.Count;
				//Manual Filling
				//DataGridViewRow rowDGVTrans = new DataGridViewRow();
				for ( int iR=0; iR<EnConfigRun.DGVRun.Rows.Count;iR++) {
					//row = (DataGridViewRow) openDGVTrans.Rows[i].Clone();
					for ( int iC=0; iC< openDGVTrans.Rows[iR].Cells.Count; iC++) {
						EnConfigRun.DGVRun.Rows[iR].Cells[iC].Value = openDGVTrans.Rows[iR].Cells[iC].Value;					
						string sCellValue = openDGVTrans.Rows[iR].Cells[iC].Value.ToString();
					}
				}
			}
			formClose();
		}
		
		void formClose() {
			this.Close();
		}
		
		void SPbtnCancelClick(object sender, EventArgs e)
		{
			formClose();
		}
	}
}
