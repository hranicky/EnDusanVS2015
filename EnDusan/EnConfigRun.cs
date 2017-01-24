/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/12/2015
 * Time: 9:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EnDusan
{
	/// <summary>
	/// Description of EnConfig.
	/// </summary>
	public static class EnConfigRun
	{
		private static int iDGVRowCount;
		private static bool bDGVFixRow;
		private static string sExportXML;
		private static string sProjectName;
		
		public EnConfigRun()
		{
			iDGVRowCount = 10;
			bDGVFixRow = true;
			sExportXML = @"F:\";
		}
		
		public int DGVCountRow
    	{
        	get { return iDGVRowCount; }
        	set { iDGVRowCount = value; }
    	}
		
		public bool DGVFixRow
		{
        	get { return bDGVFixRow; }
        	set { bDGVFixRow = value; }			
		}
		
		public string ExportXML
		{
        	get { return sExportXML; }
        	set { sExportXML = value; }										
		}
		
		public string ProjectName
		{
        	get { return sProjectName; }
        	set { sProjectName = value; }										
		}
		
	}
}
