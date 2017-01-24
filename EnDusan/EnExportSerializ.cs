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
	public class EnExportSerializHead
	{
		string sProjectName;	
		public EnExportSerializHead()
		{
			sProjectName = "Spaghetti";
			Details = new List<DGVDetail>();
		}
		public string ID { get; set; } // Textbox
		public string Initial { get; set; } // Textbox
		public List<DGVDetail> Details { get; set; } // Datagrid
	}
	
	[Serializable]
	public class DGVDetail
	{
		public DGVDetail()
		{
			Poradi = "";
			A = "";
			U1 = 0.0m;
			U2 = 0.0m;
		}
		[XmlElement("Poradi")]
		public string Poradi { get; set; }
		[XmlElement("A")]
		public string A { get; set; }
		[XmlElement("U1")]
		public decimal U1 { get; set; }
		[XmlElement("U2")]
		public decimal U2 { get; set; }
	}	
}
