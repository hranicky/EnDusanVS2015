/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/22/2015
 * Time: 8:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace EnDusan
{
	/// <summary>
	/// Description of SaveProjectForm.
	/// </summary>
	public partial class SaveProjectForm : Form
	{
		private DataGridView DGVProcesssed;
        private EnDusanMasterForm fRunMaster = null;
        private List<Control> lstControlsSaveToXML;

        public SaveProjectForm(EnDusanMasterForm runMasterForm, List<Control> prmListControlsToSaveXML)   //EnDusanMasterForm formMaster)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            int iDBG456 = 456;            
            fRunMaster = runMasterForm;
            lstControlsSaveToXML = prmListControlsToSaveXML;

        }

		
		void eventSPLoadForm(object sender, EventArgs e)
		{
			SPtxtBxProjectName.Text = EnDusan.EnConfigRun.ProjectName; 
			SPtxtBxMistoUlozeni.Text = EnDusan.EnConfigRun.CNFPathEXEData;
			SPtxtBxFileName.Text = SPtxtBxMistoUlozeni.Text + SPtxtBxProjectName.Text + ".xml"; 
		}


        void testPrmControls()
        {
            Control ctrlWControl;
            //TextBox
            string sTextBox;
            string sTextBoxName;
            //DataGridView
            DataGridView wDGView;
            string sDataGridViewName, sColumnHeaderText;
            string[] sHeaderText = new string[10];
            string[,] sValues = new string[10,10];
            int iDataGridViewColumns, iDataGridViewRows;
            for (int iControl = 0; iControl < lstControlsSaveToXML.Count; iControl++)
            {
                ctrlWControl = lstControlsSaveToXML[iControl];
                
                if (ctrlWControl.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    sTextBox = ctrlWControl.Text.ToString();
                    sTextBoxName = ctrlWControl.Name.ToString();                         
                }
                if (ctrlWControl.GetType() == typeof(System.Windows.Forms.DataGridView))
                {                    
                    sDataGridViewName = ctrlWControl.Name.ToString();
                    //for (int iDGWRow = )
                    iDataGridViewColumns = ((DataGridView)ctrlWControl).Columns.Count;
                    for (int iColumnDGV = 0; iColumnDGV < ((DataGridView)ctrlWControl).Columns.Count; iColumnDGV++ )
                    {
                        sColumnHeaderText = ((DataGridView)ctrlWControl).Columns[iColumnDGV].HeaderText.ToString();
                        sHeaderText[iColumnDGV] = sColumnHeaderText;
                    }

                    iDataGridViewRows = ((DataGridView)ctrlWControl).Rows.Count;
                    for (int iRowDGV = 0; iRowDGV < ((DataGridView)ctrlWControl).Rows.Count; iRowDGV++)
                    {
                        for (int iColumnDGV = 0; iColumnDGV < ((DataGridView)ctrlWControl).Columns.Count; iColumnDGV++)
                        {
                            if (((DataGridView)ctrlWControl).Rows[iRowDGV].Cells[iColumnDGV].Value != null)
                            {
                                sValues[iRowDGV, iColumnDGV] = ((DataGridView)ctrlWControl).Rows[iRowDGV].Cells[iColumnDGV].Value.ToString();
                            }
                            else
                            {
                                sValues[iRowDGV, iColumnDGV] = "0";
                            }
                        }
                    }
                    int iDBG112 = 112;
                }
            }
            int iDBG222 = 222;

        }

        void eventSPbtnOK(object sender, EventArgs e)
        {
            Control.ControlCollection coll = Controls;

            testPrmControls();

            foreach (Control c in lstControlsSaveToXML) //coll)
            {
                string cText, cName;
                int iGetChildIndex;
                if (c != null)
                {
                    cText = c.Text;
                    cName = c.Name;
                    iGetChildIndex = coll.GetChildIndex(c, false);                    
                }
            }
        }

        void eventSPbtnOK_01(object sender, EventArgs e)
		{
			//create date of XML Save
			XmlSerializer XMLserializerSaveRun = new XmlSerializer(typeof(EnDusan.DATAExportSerializXMLDef));
			EnDusan.DATAExportSerializXMLDef XMLSaveRun = new EnDusan.DATAExportSerializXMLDef();
			//XMLSaveRun.ProjectName = SPtxtBxProjectName.Text.ToString();
			XMLSaveRun.sProjectName = SPtxtBxProjectName.Text.ToString();
			DGVProcesssed = EnDusan.EnConfigRun.DGVRun;
			int iPoradi;
			decimal dA, dU1, dU2;
			foreach ( DataGridViewRow DGVRow in DGVProcesssed.Rows ) {
				iPoradi = Convert.ToUInt16( DGVRow.Cells["Poradi"].Value );
				dA = Convert.ToDecimal( DGVRow.Cells["A"].Value );
				dU1 = Convert.ToDecimal( DGVRow.Cells["U1"].Value );
				dU2 = Convert.ToDecimal( DGVRow.Cells["U2"].Value );
				//_example.Details.Add(new Detail() { FirstName = "John", LastName = "Doe" });
				XMLSaveRun.Details.Add( new DATADGVDetail() { Poradi = iPoradi, A = dA, U1 = dU1, U2 = dU2 });
			}
			//Save XML file
			// Write file.
			string sDBG = SPtxtBxFileName.ToString();
			sDBG = SPtxtBxFileName.Text;
			TextWriter XMLWriter = new StreamWriter( SPtxtBxFileName.Text ); 
			XMLserializerSaveRun.Serialize( XMLWriter, XMLSaveRun);
			XMLWriter.Close();			
			//XMLSaveRun.Details.Add
			DialogResult = DialogResult.OK;
			Close();
		}
		
		void eventSPbtnCancel(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		void eventTxtBxPathChanged(object sender, EventArgs e)
		{
			SPtxtBxFileName.Text = SPtxtBxMistoUlozeni.Text + SPtxtBxProjectName.Text + ".xml";
		}
		
		void eventTxBxFileNameLeave(object sender, EventArgs e)
		{
			int iDBG = 25;	
		}

	}
}