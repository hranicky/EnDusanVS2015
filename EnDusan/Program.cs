/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/11/2015
 * Time: 7:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

using System.IO;

namespace EnDusan
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// to get the location the assembly is executing from
			//(not necessarily where the it normally resides on disk)
			// in the case of the using shadow copies, for instance in NUnit tests, 
			// this will be in a temp directory.			
			string sPathEXE = (new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)).Directory.ToString();
			string sDBGStart = EnDusan.EnConfigRun.IAmHere;
			EnDusan.EnConfigRun.CNFPathEXE = sPathEXE;
			string sDirEXEConfig = EnDusan.EnConfigRun.CNFPathEXEConfig; //@"\EnCNF";
			//string sDirEXEDate = @"\Data";
			//FixDirectory:
			//"F:\Alexandria\Devel\CS\EnDusan\EnDusan\bin\Debug\EnDusan.exe"
			//string sEnCNFPath = @"F:\Alexandria\Devel\CS\EnDusan\System\";
			//string sEnDataPath = @"F:\Alexandria\Devel\CS\EnDusan\Data\";
			string sEnCNFPath = EnDusan.EnConfigRun.CNFPathEXEConfig;
			//string sEnDataPath = sPathEXE + sDirEXEDate;
			//EnCNF
			//string sEnCNFFileName = EnDusan.EnConfigRun.CNFFilePath //@"EnSysCNF.xml";
			string sEnCNFFile = EnDusan.EnConfigRun.CNFFilePath;
			//Test Path.Directory
			while ( true ) {
				if( !Directory.Exists(sEnCNFPath) )
				{
	    			Directory.CreateDirectory(sEnCNFPath);
	    			int iDBGPath = 222;
					//Create EnCNF
					Application.Run(new EnConfigForm(1));
				}
				else {
					if( !File.Exists(sEnCNFFile) ) {				
						int iDBGFile = 222;
						//Create EnCNF
						Application.Run(new EnConfigForm(2));
					}				
					else {
						break;
					}
				}
			}
			int iDBGFP = 555;
			//Read EnCNF from XML
			EnDusan.EnConfigRun.readXMLRunConfig();
			Application.Run(new EnDusanMasterForm());
		}
		
	}
}
