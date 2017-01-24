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
	/// Description of SaveProjectXMLForm.
	/// </summary>
	public partial class SaveProjectXMLForm : Form
	{
		private DataGridView DGVProcesssed;
        private EnDusanMasterForm fRunMaster = null;
        private List<Control> lstControlsSaveToXML;

        public SaveProjectXMLForm(EnDusanMasterForm runMasterForm, List<Control> prmListControlsToSaveXML)   //EnDusanMasterForm formMaster)
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

        /* 20170104 Test Fill XML File*/
        [Serializable]
        public class TextBoxDetail // Datagrid
        {
            public TextBoxDetail()
            {
                // default values, if appropriate.
            }
            [XmlElement("Control")]
            public string Control { get; set; }
            [XmlElement("Value")]
            public string Value { get; set; }
        }

        [Serializable]
        public class DGVDetail // Datagrid
        {
            public DGVDetail()
            {
                // default values, if appropriate.
            }
            [XmlElement("Control")]
            public string Control { get; set; }
            [XmlElement("FirstName")]
            public string FirstName { get; set; }
            [XmlElement("LastName")]
            public string LastName { get; set; }
        }

        [Serializable]
        public class ImageDetail // Image
        {
            public ImageDetail()
            {
                // default values, if appropriate.
            }
            [XmlElement("Control")]
            public string Control { get; set; }
            [XmlElement("ValueImage")]
            public string ValueImage { get; set; }
        }


        [Serializable]
        public class XMLExample 
        {
            public XMLExample()
            {
                TxtBxDetails = new List<TextBoxDetail>();
                DVGDetails = new List<DGVDetail>();
                ImageDetails = new List<ImageDetail>();
            }

            public List<TextBoxDetail> TxtBxDetails { get; set; }
            public List<DGVDetail> DVGDetails { get; set; }
            public List<ImageDetail> ImageDetails { get; set; }
        }

        Bitmap getImageTest()
        {
            string imgPath = @"F:\\Alexandria\\Devel\\CS\\EnDusanVS2015\\EnDusan\\Documents\\drahotuse.jpg";
            return (Bitmap)Image.FromFile(imgPath);
        }

        private byte[] ByteArrayFromBitmap(Bitmap bitmap)
        {
            // The bitmap contents are coded with Width and Height followed by pixel colors (uint)
            byte[] b = new byte[4 * (bitmap.Height * bitmap.Width + 2)];
            int n = 0;
            // encode the width
            uint x = (uint)bitmap.Width;
            int y = (int)x;
            b[n] = (byte)(x / 0x1000000);
            x = x % (0x1000000);
            n++;
            b[n] = (byte)(x / 0x10000);
            x = x % (0x10000);
            n++;
            b[n] = (byte)(x / 0x100);
            x = x % 0x100;
            n++;
            b[n] = (byte)x;
            n++;
            // encode the height
            x = (uint)bitmap.Height;
            y = (int)x;
            b[n] = (byte)(x / 0x1000000);
            x = x % (0x1000000);
            n++;
            b[n] = (byte)(x / 0x10000);
            x = x % (0x10000);
            n++;
            b[n] = (byte)(x / 0x100);
            x = x % 0x100;
            n++;
            b[n] = (byte)x;
            n++;
            // Loop through each row
            for (int j = 0; j < bitmap.Height; j++)
            {
                // Loop through the pixel on this row
                for (int i = 0; i < bitmap.Width; i++)
                {
                    Color pixelColorDBG = bitmap.GetPixel(i, j);
                    int iColDBG0A = pixelColorDBG.A;
                    int iColDBG0R = pixelColorDBG.R;
                    int iColDBG0G = pixelColorDBG.G;
                    int iColDBG0B = pixelColorDBG.B;                    
                    int iColDBG02 = (pixelColorDBG.A << 24) | (pixelColorDBG.R << 16) | (pixelColorDBG.G << 8) | pixelColorDBG.B;
                    int xDBG = bitmap.GetPixel(i, j).ToArgb();
                    x = (uint)bitmap.GetPixel(i, j).ToArgb();
                    y = (int)x;
                    b[n] = (byte)(x / 0x1000000);
                    x = x % (0x1000000);
                    n++;
                    b[n] = (byte)(x / 0x10000);
                    x = x % (0x10000);
                    n++;
                    b[n] = (byte)(x / 0x100);
                    x = x % 0x100;
                    n++;
                    b[n] = (byte)x;
                    n++;
                }
            }
            return b;
        }

        //https://www.roelvanlisdonk.nl/2009/05/25/c-convert-a-bitmap-to-byte/
        private byte[] ConvertBitMapToByteArray(Bitmap bitmap)
        {
            byte[] result = null;
            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
            }
            return result;
        }

        void TestSave()
        {
            XmlSerializer XMLserializerSaveRun = new XmlSerializer(typeof(XMLExample));
            XMLExample XMLSaveRun = new XMLExample();
            //Fill TextBox
            TextBoxDetail runTxtBxDetail = new TextBoxDetail() { Control = "TextBox", Value = "111" };
            XMLSaveRun.TxtBxDetails.Add(runTxtBxDetail);
            
            //Fill DataGridView
            DGVDetail runDGVDetail = new DGVDetail() { Control = "DataGridView", FirstName = "FName", LastName = "LName"};
            XMLSaveRun.DVGDetails.Add(runDGVDetail);
            
            //Fiil Test Image
            Bitmap bmpImage = getImageTest();
            byte[] byteImage = ConvertBitMapToByteArray(bmpImage);
            string sImage = Convert.ToBase64String(byteImage);
            ImageDetail runImageDetail = new ImageDetail() { Control = "TestImage", ValueImage = sImage};
            XMLSaveRun.ImageDetails.Add(runImageDetail);

            using (TextWriter textWriter = new StreamWriter(@"F:\\TestSerialization.xml"))
            {
                XMLserializerSaveRun.Serialize(textWriter, XMLSaveRun);
                textWriter.Close();
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

        private void btnTestSave_Click(object sender, EventArgs e)
        {
            TestSave();
        }
    }
}