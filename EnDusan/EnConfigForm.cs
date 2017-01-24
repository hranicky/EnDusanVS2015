/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/17/2015
 * Time: 4:09 PM
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

//sing System.Threading;
//using System.Threading.Tasks; 

namespace EnDusan
{
	/// <summary>
	/// Description of ConfigForm.
	/// </summary>
	public partial class EnConfigForm : Form
	{
		//EnConfigRun EnConfigRun;
		//Column: HeaderText-0, Name-1, Visible-2, ReadOnly-3, Width-4, Type-5
		private string[,] dgvEnConfigColumns = new string[,]
		{{"PoradiCnf","PoradiCnf","true","true","30","System.Int16"},
		 {"NazevPolozky","NazevPolozky","true","false","110","String"},		
		 {"FEdit","FEdit","false","true","20","System.Boolean"},
		 {"FDelRow","FDelRow","false","true","20","System.Boolean"},	
 		 {"MemoName","MemoName","false","true","20","System.Boolean"},
 		 {"DatTyp","DatType","true","false","60","String"}, 		 
		 {"Hodnota","Hodnota","true","false","150","String"}		 
		};
		private int iCountRows = 1;
		private int iStateEnConfig;
		
		//Row: PoradiCnf-0, NazevPolozky-1, FEdit-2, FDel-3, MemoName-4, DatType-5, Hodnota-6
		private string[,] dgvEnConfigReqRows = new string[,]
		{{"DateEditEditace","false","false","sDateTimeEdit","DateTime","fDTNow"},
		 {"PocetDatRadku","false","false","iCountRow","Int","fCountRows"},			
		 {"PathEnDATA","false","false","sPath.EnDATA","String","fPathEnDATA"},			
		 {"PathEnCNF","false","false","sPath.EnCNF","String","fPathEnCNF"}			
		};
		
		private XmlDocument XMLEnCNFMaster = new XmlDocument();
		
		
		string sXMLElementMaster = "<Polozka NazevPolozky=\"_0_\" FEdit=\"_1_\" FDelRow=\"_2_\" MemoName=\"_3_\" DatTyp=\"_4_\" Hodnota=\"_5_\">_i_</Polozka>";
		string sXMLElementRun = "<Polozka NazevPolozky=\"_0_\" Hodnota=\"_5_\">_i_</Polozka>";
		
		
		private string sExePath;
		
		public EnConfigForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//sExePath = Application.ExecutablePath;
			setXMLEnCNFMaster();
		}
		
		private StringBuilder sbXMLEnCNFMaster;
		
		//private XmlDocument setXMLEnCNFMaster() {
		private void setXMLEnCNFMaster() {
			string sDBGFile = EnDusan.EnConfigRun.XMLEnCNFMasterFilePath;
			if( File.Exists(EnDusan.EnConfigRun.XMLEnCNFMasterFilePath) ) {
				//XMLEnCNFMaster = new XmlDocument();
				XMLEnCNFMaster.Load(EnDusan.EnConfigRun.XMLEnCNFMasterFilePath);
				//return XMLEnCNFMaster;
			}
			int iZ = dgvEnConfigReqRows.GetUpperBound(0);		
			sbXMLEnCNFMaster = new StringBuilder();
			sbXMLEnCNFMaster.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			sbXMLEnCNFMaster.AppendLine("<EnCNFMaster>");
			string sXMLElementPolozka;
			//string sTest = "prvni=_0_druhy_1_";
			//Processing						
			for (int i = 0; i <= iZ; i++)
			{
				//sTest = sTest.Replace("_0_", "PRDEL");
				sXMLElementPolozka = sXMLElementMaster;
				string sDBG456 = dgvEnConfigReqRows[i,0];
				sXMLElementPolozka = sXMLElementPolozka.Replace("_0_",dgvEnConfigReqRows[i,0]);
				sXMLElementPolozka = sXMLElementPolozka.Replace("_1_",dgvEnConfigReqRows[i,1]);
				sXMLElementPolozka = sXMLElementPolozka.Replace("_2_",dgvEnConfigReqRows[i,2]);
				sXMLElementPolozka = sXMLElementPolozka.Replace("_3_",dgvEnConfigReqRows[i,3]);
				sXMLElementPolozka = sXMLElementPolozka.Replace("_4_",dgvEnConfigReqRows[i,4]);
				sXMLElementPolozka = sXMLElementPolozka.Replace("_5_",dgvEnConfigReqRows[i,5]);
				sXMLElementPolozka = sXMLElementPolozka.Replace("_i_", Convert.ToString(i));
				//Add child node
				sbXMLEnCNFMaster.AppendLine(sXMLElementPolozka);
			}
			sbXMLEnCNFMaster.AppendLine("</EnCNFMaster>");
			XmlDocument XMLDocumentEnCNFMaster = new XmlDocument();
			XMLDocumentEnCNFMaster.LoadXml(sbXMLEnCNFMaster.ToString());
			//Save Master
			XMLDocumentEnCNFMaster.Save(EnDusan.EnConfigRun.XMLEnCNFMasterFilePath);
			EnDusan.EnConfigRun.XMLEnCNFMasterExists = true;
			//return XMLDocumentEnCNFMaster;
			XMLEnCNFMaster = (XmlDocument) XMLDocumentEnCNFMaster;
		}
		
		
		public EnConfigForm(int iStateEnConfigArg)
		{
			iStateEnConfig = iStateEnConfigArg;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//sExePath = Application.ExecutablePath;
			//sExePath = @"F:\Alexandria\Devel\CS\EnDusan\EnDusan\";
			if (iStateEnConfig > 0 ) {
				EnCnfTxtBoxPopis.Text = @"!!! Konfiguracni soubor nenalezen !!!";
				EnCnfTxtBoxPopis.BackColor = Color.Yellow;
				EnCnfTxtBoxPopis.ForeColor = Color.Red;
			}
			//generate XMLEnCNFMaster
			//XMLEnCNFMaster = setXMLEnCNFMaster();
			//XMLEnCNFMaster.Save("F:\\XMLEnCNFMaster.xml");
			setXMLEnCNFMaster();
		}
		
		
		private void setDGViewColumsCNF (DataGridView dgvName)
		{
			//NazevPolozky, fEdit, fDel, DatType, Hodnota, MemoName
			string sHeaderText, sName, sVisible, sWidth;
			int iXDGV, iYDGV, iXDGVUsed;
			iXDGVUsed = 0;
			iXDGV = dgvName.Size.Width;
			int iZ = dgvEnConfigColumns.GetUpperBound(0);
			int iDBG = dgvName.Columns.Count;
			for (int i = 0; i <= iZ; i++)
			{
				sHeaderText = dgvEnConfigColumns[i,0];
				sName = dgvEnConfigColumns[i,1];
				sVisible = dgvEnConfigColumns[i,2];
				sWidth = dgvEnConfigColumns[i,4];				
				
				DataGridViewTextBoxColumn dgvColumn = new DataGridViewTextBoxColumn();
				dgvColumn.HeaderText = dgvEnConfigColumns[i,0];
				//dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvColumn.Name = dgvEnConfigColumns[i,1];
				dgvColumn.Visible = Boolean.Parse(dgvEnConfigColumns[i,2]);
				dgvColumn.ReadOnly = Boolean.Parse(dgvEnConfigColumns[i,3]);
				if ( i == iZ ){
					//dgvColumn.Width =  iXDGV - iXDGVUsed;	
					dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
					iXDGVUsed += dgvName.Width;
				}
				else {
					dgvColumn.Width =  Int16.Parse(dgvEnConfigColumns[i,4]);
					iXDGVUsed += Int16.Parse(dgvEnConfigColumns[i,4]);
				}
				dgvColumn.ValueType = Type.GetType(dgvEnConfigColumns[i,5]);
				                                   
				dgvName.Columns.Add(dgvColumn);
			}				
		}
		
		private void setDefinedRows (DataGridView dgvName) {
			//Row: NazevPolozky, FEdit, FDel, MemoName, DatType, Hodnota
			string sNazevPolozky, sFEdit, sFDelete, sMemoName, sDatType, sHodnota;
			int iZ = dgvEnConfigReqRows.GetUpperBound(0);
			int iDBG = dgvName.Rows.Count;
			if (dgvName.Rows.Count > 0 ) {
				dgvName.Rows.Clear();
			}
			
			int iDBGCount;
			for (int i = 0; i <= iZ; i++)
			{
				sNazevPolozky = dgvEnConfigReqRows[i,0];
				sFEdit = dgvEnConfigReqRows[i,1];
				sFDelete = dgvEnConfigReqRows[i,2];
				sMemoName = dgvEnConfigReqRows[i,3];
				sDatType = dgvEnConfigReqRows[i,4];
				sHodnota = dgvEnConfigReqRows[i,5];
				
				switch ( sHodnota )
				{
	    			case "fDTNow":
						sHodnota = System.DateTime.Now.ToString("yyyy.MM.dd");
						break;
					case "fPathDATA":
						sHodnota = @"F:\";
						break;
					case "fPathEnCNF":
						sHodnota = @"F:\";
						break;
				}
				
				DataGridViewRow rowEnConfig = (DataGridViewRow)dgvName.Rows[0].Clone();
				//Row: NazevPolozky, FEdit, FDel, MemoName, DatType, Hodnota	
				rowEnConfig.Cells[1].Value = sNazevPolozky;
				rowEnConfig.Cells[2].Value = Convert.ToBoolean(sFEdit);
				rowEnConfig.Cells[3].Value = Convert.ToBoolean(sFDelete);
				rowEnConfig.Cells[4].Value = sMemoName;
				rowEnConfig.Cells[5].Value = sDatType;				
				rowEnConfig.Cells[6].Value = sHodnota;
				dgvName.Rows.Add(rowEnConfig);
				iDBGCount = dgvName.Rows.Count;
			}				

		}
		
		private void setDefinedRowsB (DataGridView dgvName, XmlDocument XMLCnfMaster) {
			//Row: NazevPolozky, FEdit, FDel, MemoName, DatType, Hodnota
			string sNazevPolozky, sFEdit, sFDelete, sMemoName, sDatType, sHodnota;
			string sXMLAttrName_DBG;
			int iZ = dgvEnConfigReqRows.GetUpperBound(0);
			int iDBG = dgvName.Rows.Count;
			if (dgvName.Rows.Count > 0 ) {
				dgvName.Rows.Clear();
			}
			
			int iDBGCount;
			//XmlElement XMLElement;
			XmlNodeList XMLEnElementTop, XMLElementItems;
		    string sXMLItemAttrName, sXMLItemAttrValue;
		    //XmlAttributeCollection XMLElementAttrColl;
		    XmlAttribute XMLAtt;
		    string sXMLElementValue;
		    string sXMLElementName_DBG;
			XMLEnElementTop = XMLCnfMaster.SelectNodes("EnCNFMaster");
			if (XMLEnElementTop.Count == 1 ) {
				XMLElementItems = XMLCnfMaster.SelectNodes("EnCNFMaster/Polozka");
				if (XMLElementItems.Count > 0 )  {
					foreach (XmlElement XMLElement in XMLElementItems) {
						sXMLElementValue = XMLElement.InnerText;
						XmlAttributeCollection XMLElementAttrColl = XMLElement.Attributes;												
								sXMLAttrName_DBG = XMLElementAttrColl[0].Value;
							sNazevPolozky = XMLElementAttrColl[0].Value;
								sXMLAttrName_DBG = XMLElementAttrColl[1].Value;
							sFEdit = XMLElementAttrColl[1].Value;
								sXMLAttrName_DBG = XMLElementAttrColl[2].Value;
							sFDelete = XMLElementAttrColl[2].Value;
								sXMLAttrName_DBG = XMLElementAttrColl[3].Value;
							sMemoName = XMLElementAttrColl[3].Value;
								sXMLAttrName_DBG = XMLElementAttrColl[4].Value;
							sDatType = XMLElementAttrColl[4].Value;
								sXMLAttrName_DBG = XMLElementAttrColl[5].Value;
							sHodnota = XMLElementAttrColl[5].Value;
							
							switch ( sHodnota )
							{
				    			case "fDTNow":
									sHodnota = System.DateTime.Now.ToString("yyyy.MM.dd");
									break;
								case "fPathEnDATA":
									sHodnota = EnDusan.EnConfigRun.CNFPathEXEData;
									if( !Directory.Exists(sHodnota) ) {
						    			Directory.CreateDirectory(sHodnota);
									}
									break;
								case "fPathEnCNF":
									sHodnota = EnDusan.EnConfigRun.CNFPathEXEConfig;
									if( !Directory.Exists(sHodnota) ) {
						    			Directory.CreateDirectory(sHodnota);
									}									
									break;
								case "fCountRows":
									sHodnota = Convert.ToString(EnDusan.EnConfigRun.DGVCountRow);
									break;
							}
							
							DataGridViewRow rowEnConfig = (DataGridViewRow)dgvName.Rows[0].Clone();
								//Row: NazevPolozky, FEdit, FDel, MemoName, DatType, Hodnota	
								rowEnConfig.Cells[1].Value = sNazevPolozky;
								rowEnConfig.Cells[2].Value = Convert.ToBoolean(sFEdit);
								rowEnConfig.Cells[3].Value = Convert.ToBoolean(sFDelete);
								rowEnConfig.Cells[4].Value = sMemoName;
								rowEnConfig.Cells[5].Value = sDatType;				
								rowEnConfig.Cells[6].Value = sHodnota;
								dgvName.Rows.Add(rowEnConfig);
								dgvName.Update();
								dgvName.Refresh();
								string sDBGCell = rowEnConfig.Cells[1].Value.ToString();
								sDBGCell = rowEnConfig.Cells[2].Value.ToString();
								sDBGCell = rowEnConfig.Cells[3].Value.ToString();
								sDBGCell = rowEnConfig.Cells[4].Value.ToString();
								sDBGCell = rowEnConfig.Cells[5].Value.ToString();
								sDBGCell = rowEnConfig.Cells[6].Value.ToString();
								iDBGCount = dgvName.Rows.Count;

						/*for ( int iAttr=0; iAttr < XMLElementAttrColl.Count; iAttr++) {	
							XMLAtt = XMLElementAttrColl[iAttr];
							sXMLItemAttrName = XMLAtt.Name;
							sXMLItemAttrValue = XMLAtt.Value;
						}*/							
					}
				}					
			}
			int iDBG1234 = 100;
		}
		
		public static void readXMLRunConfigIntoDGV( DataGridView dgwWork)
		{
			//XmlDocument XMLCnfMaster = new XmlDocument();
			XmlDocument XMLCnfRun = new XmlDocument();
			XmlNodeList XMLEnMasterElementTop, XMLEnMasterList, XMLEnRunElementTop, XMLEnRunList;
			
			string sXMLRunElementValue;
			string sNazevPolozkyRunCNFXML, sHodnotaMaster, sHodnotaRunCNFXML; 
			
			/*XMLCnfMaster.Load(sXMLEnCNFMasterFilePath);
			XMLEnMasterElementTop = XMLCnfMaster.SelectNodes("EnCNFMaster");
			if (XMLEnMasterElementTop.Count == 1 ) {
				XMLEnMasterList = XMLCnfMaster.SelectNodes("EnCNFMaster/Polozka");
				if (XMLEnMasterList.Count > 0 )  {
					int iDBGMasterOK = 10;
				}
			}*/
			
			XMLCnfRun.Load( EnDusan.EnConfigRun.CNFFilePath);
			XMLEnRunElementTop = XMLCnfRun.SelectNodes("EnCNFRun");
			if (XMLEnRunElementTop.Count == 1 ) {
				XMLEnRunList = XMLCnfRun.SelectNodes("EnCNFRun/Polozka");
				if (XMLEnRunList.Count > 0 )  {
					int iDBGRunOK = 10;
					foreach (XmlElement XMLRunElement in XMLEnRunList) {
						sXMLRunElementValue = XMLRunElement.InnerText;
						XmlAttributeCollection XMLRunElementAttrColl = XMLRunElement.Attributes;																			
							sNazevPolozkyRunCNFXML = XMLRunElementAttrColl["NazevPolozky"].Value;
							sHodnotaRunCNFXML = XMLRunElementAttrColl["Hodnota"].Value;
							//sHodnotaRunCNFXML = "testKUK";
						for (int iRows=0; iRows<dgwWork.Rows.Count; iRows++ ) {
								if ( dgwWork["NazevPolozky", iRows].Value.ToString() == sNazevPolozkyRunCNFXML ) {
									dgwWork["Hodnota", iRows].Value = sHodnotaRunCNFXML;
									dgwWork.Update();
									dgwWork.Refresh();									
									break;									
								}
						}	
						/*
						//Master
						XMLEnMasterList = XMLCnfMaster.SelectNodes("EnCNFMaster/Polozka[@NazevPolozky='" + sNazevPolozky +"']");
						//XMLEnMasterList = XMLEnMasterElementTop.SelectNodes("//Polozka[@NazevPolozky=sNazevPolozky");
						int iDBGCount = XMLEnMasterList.Count;
						if ( XMLEnMasterList.Count == 1 ) {
							XmlElement XMLMasterElement = (XmlElement) XMLEnMasterList.Item(0);
							XmlAttributeCollection XMLMasterElementAttrColl = XMLMasterElement.Attributes;												
							sHodnotaMaster = XMLMasterElementAttrColl[5].Value;					
							switch ( sHodnotaMaster )
							{
								case "fPathEnDATA":
									sCNFPathEXEData = sHodnotaRun;
									if( !Directory.Exists(sHodnotaRun) ) {
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
						*/
					}
				}
			}
		}		
			
		
		void eventReadRunCNF(object sender, EventArgs e)
		{
			readXMLRunConfigIntoDGV( EnCnfDGVConfig );
		}
		
		void eventRowAdd(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			EnCnfDGVConfig.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();	
		}
		
		void eventLoadForm(object sender, EventArgs e)
		{
			int iDBG89 = 89;
			//if ( configEnRun == null )
			//	configEnRun = new EnConfigRun();

			//dgvEn.   .RowCount = 10;
			//configEnWork.DGVCountRow;
			//EnDusan.EnConfigRun.DGVRun = (DataGridView) dgvEn;
			setDGViewColumsCNF ( EnCnfDGVConfig );
			//dgvEn.RowCount = EnDusan.EnConfigRun.DGVCountRow;
			/*if ( iStateEnConfig != 0 ) {
				setDefinedRows( EnCnfDGVConfig );
			}*/
			//PrgDEBUG();
			//fill DGV from XMLEnCNFMaster
			//generate XMLEnCNFMaster			
			setDefinedRowsB( EnCnfDGVConfig,  XMLEnCNFMaster);
			
		}
		
		void eventFormShown(object sender, EventArgs e)
		{
			/*if ( iStateEnConfig > 0 ) {
				setDefinedRowsB( EnCnfDGVConfig );
			}*/
			int iDBG777 = 123;
		}
		
		
		void saveEnCNFXML_001(string sPathEnCNF )
		{
			//Indicator:
			char chDone = (char)0x266A;
			EnCNFtxtBxSaveXML.Visible = true;
			EnCNFtxtBxSaveXML.Text = " Save XML: ";
			
			//test directory System
  			if (!Directory.Exists( sPathEnCNF ))
    			Directory.CreateDirectory( sPathEnCNF );
  			string sEnCNFFile = sPathEnCNF + @"\" + @"EnCNF.xml";
			//create date of XML Save
			XmlSerializer EnCNFXMLSerializerSaveRun = new XmlSerializer(typeof(EnDusan.EnCNFExportSerializXMLDef));
			EnDusan.EnCNFExportSerializXMLDef EnCNFXMLSaveRun = new EnDusan.EnCNFExportSerializXMLDef();
			//Row: PoradiCnf-0, NazevPolozky-1, FEdit-2, FDel-3, MemoName-4, DatType-5, Hodnota-6
			int iPoradiCnf;
			string sNazevPolozky, sFEdit, sFDel, sMemoName, sDatType, sHodnota;
			string sDGVColumnsName = "";
			for (int iC=0; iC<EnCnfDGVConfig.Columns.Count; iC++) {
				sDGVColumnsName = sDGVColumnsName + EnCnfDGVConfig.Columns[iC].Name + ", ";
			}
			
			foreach ( DataGridViewRow DGVRow in EnCnfDGVConfig.Rows ) {
				iPoradiCnf = Convert.ToInt16( DGVRow.Cells["PoradiCnf"].Value );
				sNazevPolozky =  Convert.ToString( DGVRow.Cells["NazevPolozky"].Value );
				sFEdit = Convert.ToString( DGVRow.Cells["FEdit"].Value );
				sFDel = Convert.ToString( DGVRow.Cells["FDelRow"].Value );
				sMemoName = Convert.ToString( DGVRow.Cells["MemoName"].Value );
				sDatType = Convert.ToString( DGVRow.Cells["DatType"].Value );
				sHodnota = Convert.ToString( DGVRow.Cells["Hodnota"].Value );
				EnCNFXMLSaveRun.DetailsEnCNF.Add( new EnCNFDGVDetail() { Poradi = iPoradiCnf, NazevPolozky = sNazevPolozky, FEdit = sFEdit, FDel = sFDel, MemoName = sMemoName, DatType =sDatType});
				EnCNFtxtBxSaveXML.Text += chDone;		
			}
			//Save XML file
			// Write file.
			if( File.Exists(sEnCNFFile) ) {
    			File.Delete(sEnCNFFile);
			}
			
			TextWriter XMLWriter = new StreamWriter( sEnCNFFile ); 
			EnCNFXMLSerializerSaveRun.Serialize( XMLWriter, EnCNFXMLSaveRun);
			XMLWriter.Close();			
			//XMLSaveRun.Details.Add
			//DialogResult = DialogResult.OK;
			//Close();
		}
		

		void saveEnCNFXML_002(string sPathEnCNF )
		{
			//New XML Solution(_002):
			//<?xml version="1.0" encoding="utf‐8"?>
			//<EnCNF>
			//<Polozka NazevPolozky="" Value="">...<Poradi/>
			string sEnCNFMaster;
			string sEnCNFRunElementTop = "EnCNFRun";
			string sEnCNFMasterElementPolozka= "Polozka";
			string sDTNow = System.DateTime.Now.ToString("_yyyyMMddHHmmss");
			
			//Indicator:
			char chDone = (char)0x266A;
			EnCNFtxtBxSaveXML.Visible = true;
			EnCNFtxtBxSaveXML.Text = " Save XML: ";
			
			//test directory System
			string sDBG456 = Path.GetDirectoryName(sPathEnCNF);
			if (!Directory.Exists( Path.GetDirectoryName(sPathEnCNF) ))
    			Directory.CreateDirectory( Path.GetDirectoryName(sPathEnCNF) );
  			
  			if( File.Exists(sPathEnCNF) ) {
    			//File.Delete(sEnCNFFile);
    			File.Move(sPathEnCNF, (sPathEnCNF + sDTNow));
			}
  			
  			XmlWriter EnCNFXMLWriterRun = XmlWriter.Create(sPathEnCNF);
  			EnCNFXMLWriterRun.WriteStartDocument();
  				EnCNFXMLWriterRun.WriteStartElement(sEnCNFRunElementTop);  				  				
				//Row: PoradiCnf-0, NazevPolozky-1, FEdit-2, FDel-3, MemoName-4, DatType-5, Hodnota-6
				int iPoradiCnf;
				string sNazevPolozky, sFEdit, sFDel, sMemoName, sDatType, sHodnota;
				/*string sDBG_DGVColumnsName = "";
				for (int iC=0; iC<EnCnfDGVConfig.Columns.Count; iC++) {
					sDBG_DGVColumnsName = sDBG_DGVColumnsName + EnCnfDGVConfig.Columns[iC].Name + ", ";
				}*/
				sNazevPolozky = String.Empty;
				foreach ( DataGridViewRow DGVRow in EnCnfDGVConfig.Rows ) {
					sNazevPolozky = Convert.ToString( DGVRow.Cells["NazevPolozky"].Value);
					if ( sNazevPolozky != String.Empty ) {					                                 
						EnCNFXMLWriterRun.WriteStartElement(sEnCNFMasterElementPolozka);
						EnCNFXMLWriterRun.WriteAttributeString("NazevPolozky", sNazevPolozky);
						EnCNFXMLWriterRun.WriteAttributeString("Hodnota", Convert.ToString( DGVRow.Cells["Hodnota"].Value));
						EnCNFXMLWriterRun.WriteString(Convert.ToString(DGVRow.Cells["PoradiCnf"].Value ));
						EnCNFXMLWriterRun.WriteEndElement();
						sNazevPolozky = String.Empty;
					}
					else {
						continue;
					}
					/*iPoradiCnf = Convert.ToInt16( DGVRow.Cells["PoradiCnf"].Value );
					sNazevPolozky =  Convert.ToString( DGVRow.Cells["NazevPolozky"].Value );
					sFEdit = Convert.ToString( DGVRow.Cells["FEdit"].Value );
					sFDel = Convert.ToString( DGVRow.Cells["FDelRow"].Value );
					sMemoName = Convert.ToString( DGVRow.Cells["MemoName"].Value );
					sDatType = Convert.ToString( DGVRow.Cells["DatType"].Value );
					sHodnota = Convert.ToString( DGVRow.Cells["Hodnota"].Value );
					EnCNFXMLSaveRun.DetailsEnCNF.Add( new EnCNFDGVDetail() { Poradi = iPoradiCnf, NazevPolozky = sNazevPolozky, FEdit = sFEdit, FDel = sFDel, MemoName = sMemoName, DatType =sDatType});
					EnCNFtxtBxSaveXML.Text += chDone;*/		
				}
				EnCNFXMLWriterRun.WriteEndDocument();
				EnCNFXMLWriterRun.Close();
				EnDusan.EnConfigRun.XMLEnCNFRunExists = true;
		}
		
		
		void getEnCNFXML_002(string sEnCNFFile ) {			
  			if( ! File.Exists(sEnCNFFile) ) {
    			int iDBG001 = 100;
			}
			StringBuilder sbXMLMasterTest = new StringBuilder();
			string sXMLMemo;
			sXMLMemo = File.ReadAllText(sEnCNFFile);
			XmlDocument XMLEnMaster = new XmlDocument();
			XMLEnMaster.LoadXml(sXMLMemo);
			
		}
		
		
		void eventBtnOKClick(object sender, EventArgs e)
		{
			if (iStateEnConfig > 0 ) {
				//save EnCNF
				//saveEnCNFXML_001(@"F:\SystemDusan");
				string sXMLConfigRun = EnDusan.EnConfigRun.CNFFilePath;
				saveEnCNFXML_002(sXMLConfigRun);	
				if ( EnDusan.EnConfigRun.XMLEnCNFRunExists ) {
					Close();
				}
				//getEnCNFXML_002(sXMLConfigRun);
				
			}
		}
		
		void eventBtnCancelClick(object sender, EventArgs e) {
			Close();
		}			
	}
}
