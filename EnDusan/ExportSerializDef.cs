/*
 * Created by SharpDevelop.
 * User: chmelal
 * Date: 11/18/2015
 * Time: 5:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;


namespace EnDusan
{
	/// <summary>
	/// Description of EnExportSerializ.
	/// </summary>
	[Serializable]
	public class DATAExportSerializXMLDef
	{		
		public string sProjectName { get; set; }
		
		public DATAExportSerializXMLDef()
		{
			sProjectName = "";
			Details = new List<DATADGVDetail>();
		}
		/*
		public string ProjectName { get; set; 
			set { sProjectName = value;  }
		} 
		*/
		//public string Initial { get; set; } // Textbox
		public List<DATADGVDetail> Details { get; set; } // Datagrid
	}
	
	[Serializable]
	public class DATADGVDetail
	{
		[XmlElement("Poradi")]
		public int Poradi { get; set; }
		[XmlElement("A")]
		public decimal A { get; set; }
		[XmlElement("U1")]
		public decimal U1 { get; set; }
		[XmlElement("U2")]
		public decimal U2 { get; set; }
		
		public DATADGVDetail()
		{
			/*Poradi = iA;
			A = dA;*/
		}
	}
	
	
	[Serializable]
	public class EnCNFExportSerializXMLDef
	{						
		public EnCNFExportSerializXMLDef()
		{			
			DetailsEnCNF = new List<EnCNFDGVDetail>();
		}
		/*
		public string ProjectName { get; set; 
			set { sProjectName = value;  }
		} 
		*/
		//public string Initial { get; set; } // Textbox
		public List<EnCNFDGVDetail> DetailsEnCNF { get; set; } // Datagrid
	}
	
	
	[Serializable]
	//Row: NazevPolozky, FEdit, FDel, MemoName, DatType, Hodnota
	public class EnCNFDGVDetail
	{
		[XmlElement("Poradi")]
		public int Poradi { get; set; }		
		[XmlElement("NazevPolozky")]
		public string NazevPolozky { get; set; }	
		[XmlElement("FEdit")]
		public string FEdit { get; set; }		
		[XmlElement("FDel")]
		public string FDel { get; set; }		
		[XmlElement("MemoName")]
		public string MemoName { get; set; }		
		[XmlElement("DatType")]
		public string DatType { get; set; }		
		[XmlElement("Hodnota")]
		public string Hodnota { get; set; }
		
		public EnCNFDGVDetail()
		{
			//empty class definition
		}
	}
}
