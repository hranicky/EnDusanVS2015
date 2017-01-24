using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace EnDusan
{
        
    /*http://www.developerfusion.com/code/5682/create-pdf-files-on-fly-in-c/ */
    public partial class PDFForm : Form
    {
        string sPDFFile; // = @"F:\\enDusanTestPDF.pdf";
        string sEnPdfTemplatePath = @"F:\Alexandria\Devel\CS\EnDusanVS2015\EnDusan\Data\PDF\Template\";
        string sEnPdfTemplateFile = @"ENTemplate_P03";
        string sFileExt = ".pdf";
        string sEnPdfOutPath = @"F:\Alexandria\Devel\CS\EnDusanVS2015\EnDusan\Data\PDF\Out\";
        string sEnPdfOutFile = @"EN_DT_P03";
        string sEnPdfOutWriteFile = @"EN_DT_P03";
        string sTask = "";
        string sDTNow, sFilePDFRead, sFilePDFWrite;

        private EnDusanMasterForm fRunMaster = null;
        private List<Control> lstControlsPDF;

        public PDFForm(EnDusanMasterForm prmRunMasterForm, List<Control> prmListControls)
        {
            fRunMaster = prmRunMasterForm;
            lstControlsPDF = prmListControls;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            string[,] sValues = new string[10, 10];
            int iDataGridViewColumns, iDataGridViewRows;
            for (int iControl = 0; iControl < lstControlsPDF.Count; iControl++)
            {
                ctrlWControl = lstControlsPDF[iControl];

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
                    for (int iColumnDGV = 0; iColumnDGV < ((DataGridView)ctrlWControl).Columns.Count; iColumnDGV++)
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

        void PDFDemoTest001()
        {
            sPDFFile = @"F:\\enDusanTestPDF.pdf";
            string sException = "";
            // step 1: creation of a document-object
            Document myDocument = new Document(PageSize.A4.Rotate());

            try
            {
                // step 2:
                // Now create a writer that listens to this doucment and writes the document to desired Stream.
                PdfWriter.GetInstance(myDocument, new FileStream(sPDFFile, FileMode.Create));

                // step 3:  Open the document now using
                myDocument.Open();

                // step 4: Now add some contents to the document
                myDocument.Add(new Paragraph("First Test PDF file using iText Library"));

            }
            catch (DocumentException de)
            {
                sException = "DocumentException";
            }
            catch (IOException ioe)
            {
                sException = "IOException";
            }

            // step 5: Close the documnet
            myDocument.Close();
        }

        void runPDFA4NewDocument()
        {
            sTask = "DateTime_Format";
            sTask = "TextHeader_H5"; /* 20170108: public Paragraph TextLineH5(string Text)" */
            sTask = "TextHeader_H4";
            sTask = "TextHeader_H2";
            sTask = "TextHeader_H2CP1205";
            sTask = "New subHeader under H2CP1205";
            sTask = "Table_01";
            sTask = "Image_01";
            sTask = "FormField_1";

            sDTNow = DateTime.Now.ToString("yyyyMMddHHmm.");
            sFilePDFRead = sEnPdfTemplatePath + sEnPdfTemplateFile + sFileExt;
            sEnPdfOutWriteFile = sEnPdfOutWriteFile.Replace("DT", sDTNow);
            sEnPdfOutWriteFile = sEnPdfOutPath + sEnPdfOutWriteFile + sTask + sFileExt;
                        
            A1Dusan runDocument = new A1Dusan(sEnPdfOutWriteFile);
            runDocument.GenerateA4();
            FileStream fs = new FileStream(sEnPdfOutWriteFile, FileMode.Create);
            fs.Write(runDocument.DocumentBytes, 0, runDocument.DocumentBytes.Length);
            fs.Close();
            this.Close();
        }

        void runPDFA4NewDocumentEditable()
        {
            sTask = "DateTime_Format";
            sTask = "TextHeader_H5"; /* 20170108: public Paragraph TextLineH5(string Text)" */
            sTask = "TextHeader_H4";
            sTask = "TextHeader_H2";
            sTask = "TextHeader_H2CP1205";
            sTask = "New subHeader under H2CP1205";
            sTask = "Table_01";
            sTask = "Image_01";
            sTask = "FormField_1";

            sDTNow = DateTime.Now.ToString("yyyyMMddHHmm.");
            sFilePDFRead = sEnPdfTemplatePath + sEnPdfTemplateFile + sFileExt;
            sEnPdfOutWriteFile = sEnPdfOutWriteFile.Replace("DT", sDTNow);
            sEnPdfOutWriteFile = sEnPdfOutPath + sEnPdfOutWriteFile + sTask + sFileExt;

            A1Dusan runDocument = new A1Dusan();            
            runDocument.GenerateA4();
            //PdfWriter.GetInstance(runDocument, )
            FileStream fs = new FileStream(sEnPdfOutWriteFile, FileMode.Create);
            fs.Write(runDocument.DocumentBytes, 0, runDocument.DocumentBytes.Length);
            fs.Close();
            this.Close();
        }


        void runPDFA4Updated()
        {
            string sDTNow, sFilePDFRead, sFilePDFWrite;
            string sTask = "Updated_001";
            //sTask = "FormField_1";
            testPrmControls();

            sDTNow = DateTime.Now.ToString("yyyyMMddHHmm.");
            sFilePDFRead = sEnPdfTemplatePath + sEnPdfTemplateFile + sFileExt;
            sEnPdfOutFile = sEnPdfOutFile.Replace("DT", sDTNow);
            sFilePDFWrite = sEnPdfOutPath + sEnPdfOutFile + sTask + sFileExt;

            PdfReader.unethicalreading = true;
            PdfReader inputPDFFile = new PdfReader(sFilePDFRead);
            FileStream outputPDFStream = new FileStream(sFilePDFWrite, FileMode.Create, FileAccess.Write);
            PdfStamper pdfStamper = new PdfStamper(inputPDFFile, outputPDFStream);

            // Display form field names found in document
            string sFields = "";
            string sLineK = "";
            string sLineV = "";
            int iDBG = 0;
            foreach (var field in pdfStamper.AcroFields.Fields )
            {
                sLineK = string.Format("[{0}]", field.Key);                
                //Console.WriteLine(line);
                sFields = sFields + sLineK;
                sLineV = string.Format("[{0}]", field.Value);
                //Console.WriteLine(line);
                //sFields = sFields + sLine;
                iDBG++;
            }
            iDBG++;
            //testUpdate
            //"[List][Projekt][AI_01][Stena_01][UI_01][UN20_01][DI_01]"            
            //FillUp
            pdfStamper.AcroFields.SetField("List", "1");
            pdfStamper.AcroFields.SetField("Projekt", "Test EnDusan Projekt");
            pdfStamper.AcroFields.SetField("Stena_01", "Test Stena");
            pdfStamper.AcroFields.SetField("AI_01", "111.00");
            pdfStamper.AcroFields.SetField("UI_01", "111.22");
            pdfStamper.AcroFields.SetField("UN20_01", "111.33");
            pdfStamper.AcroFields.SetField("DI_01", "111.44");
            // close writers and clean up
            inputPDFFile.Close();
            pdfStamper.Close();
            outputPDFStream.Close();
            int iDBG6667 = 7;
        }

        void runPDFA4UpdatedNEW()
        {
            //string sDTNow, sFilePDFRead, sFilePDFWrite;
            sTask = "Updated_001";
            //sTask = "FormField_1";
            testPrmControls();

            sDTNow = DateTime.Now.ToString("yyyyMMddHHmm.");
            sFilePDFRead = sEnPdfTemplatePath + sEnPdfTemplateFile + sFileExt;
            sEnPdfOutFile = sEnPdfOutFile.Replace("DT", sDTNow);
            sFilePDFWrite = sEnPdfOutPath + sEnPdfOutFile + sTask + sFileExt;

            PdfReader.unethicalreading = true;
            PdfReader inputPDFFile = new PdfReader(sFilePDFRead);
            FileStream outputPDFStream = new FileStream(sFilePDFWrite, FileMode.Create, FileAccess.Write);
            PdfStamper pdfStamper = new PdfStamper(inputPDFFile, outputPDFStream);

            // Display form field names found in document
            string sFieldsToPDF = "";
            string sLineK = "";
            string sLineV = "";
            int iDBG = 0;
            foreach (var field in pdfStamper.AcroFields.Fields)
            {
                //sLineK = string.Format("[{0}]", field.Key);
                //Console.WriteLine(line);
                sFieldsToPDF = sFieldsToPDF + field.Key + ";";  // + sLineK;
                //sLineV = string.Format("[{0}]", field.Value);
                //Console.WriteLine(line);
                //sFields = sFields + sLine;
                iDBG++;
            }
            iDBG++;
            //testUpdate
            //"[List][Projekt][AI_01][Stena_01][UI_01][UN20_01][DI_01]"            
            //FillUp
            //Processing PrmListOfControls
            Control.ControlCollection coll = Controls;
            string sControlsText = "";
            string sControlsName = "";
            int iDBG456 = 0;
            foreach (Control c in lstControlsPDF) //coll)
            {
                string sText, sName;
                int iGetChildIndex;
                if (c != null)
                {
                    sText = c.Text;
                    sName = c.Name;
                    sControlsText = sControlsText + sText + ";";
                    sControlsName = sControlsName + sName + ";";
                    if (c.GetType() == typeof(TextBox) ) {
                        //TextBox
                        iDBG456 = 100;
                        int iStartWord = sName.IndexOf("__") + "__".Length;
                        string sWord = sName.Substring(iStartWord);  // + ";";
                        if (sFieldsToPDF.IndexOf(sWord + ";") != -1)
                        {
                            pdfStamper.AcroFields.SetField(sWord, sText);
                        }
                    }
                    iGetChildIndex = coll.GetChildIndex(c, false);
                    //break;
                }
                //cycle All PDF Controls
                //sPDFSeparator = "__";
                break;
            }
            int iDBG123 = 123; 

            /*pdfStamper.AcroFields.SetField("List", "1");
            pdfStamper.AcroFields.SetField("Projekt", "Test EnDusan Projekt");
            pdfStamper.AcroFields.SetField("Stena_01", "Test Stena");
            pdfStamper.AcroFields.SetField("AI_01", "111.00");
            pdfStamper.AcroFields.SetField("UI_01", "111.22");
            pdfStamper.AcroFields.SetField("UN20_01", "111.33");
            pdfStamper.AcroFields.SetField("DI_01", "111.44");
            // close writers and clean up */
            inputPDFFile.Close();
            pdfStamper.Close();
            outputPDFStream.Close();
            int iDBG6667 = 7;
        }


        void runPDFA4Edit_001()
        {
            sTask = "runPDFA4Edit_001.FormField_1";

            sDTNow = DateTime.Now.ToString("yyyyMMddHHmm.");
            sFilePDFRead = sEnPdfTemplatePath + sEnPdfTemplateFile + sFileExt;
            sEnPdfOutWriteFile = sEnPdfOutWriteFile.Replace("DT", sDTNow);
            sEnPdfOutWriteFile = sEnPdfOutPath + sEnPdfOutWriteFile + sTask + sFileExt;
            FileStream fs = new FileStream(sEnPdfOutWriteFile, FileMode.Create);
            Subscribe runPDFSubscribe = new Subscribe();
            byte[] myPDF = runPDFSubscribe.CreatePDF(); 
            fs.Write(myPDF, 0, myPDF.Length);
            fs.Close();
        }


        private void btnChapter_8_Click(object sender, EventArgs e)
        {
            runPDFA4Edit_001();
        }

        private void btnTestPDFF_Click(object sender, EventArgs e)
        {

        }

 
        void testPDFAcroFields(string iPDFFile)
        {
            string sFlow = "Y";
            sDTNow = DateTime.Now.ToString("yyyyMMddHHmm.");
            PdfReader.unethicalreading = true;
            PdfReader inputPDFFile = new PdfReader(iPDFFile);
            string sNewFileReplace = "_Test_" + sDTNow + ".pdf"; 
            string oPDFFile = iPDFFile.Replace(".pdf", sNewFileReplace);
            FileStream outputPDFStream = new FileStream(oPDFFile, FileMode.Create, FileAccess.Write );
            PdfStamper pdfStamper = new PdfStamper(inputPDFFile, outputPDFStream);

            // Display form field names found in document
            string sFieldKey = "";
            List<string> lsFieldsKey = new List<string>();
            string sFieldValue = "";
            List<string> lsFieldsValue = new List<string>();
            string sFieldADDR = "";
            int iDBG = 0;
            foreach (var field in pdfStamper.AcroFields.Fields)
            {
                sFieldKey = string.Format("{0}", field.Key);
                //Console.WriteLine(line);
                lsFieldsKey.Add(sFieldKey);
                //  .A + sLineK + " ";
                sFieldValue = string.Format("{0}", field.Value);
                lsFieldsValue.Add(sFieldValue);
                //Console.WriteLine(line);
                //sFields = sFields + sLine;
                iDBG++;
            }
            iDBG++;
            if ( sFlow == "Y" )
            {
                foreach (string sFieldProc in lsFieldsKey)
                {
                    //sFieldADDR = field1.ToString();
                    pdfStamper.AcroFields.SetField( sFieldProc, sFieldProc);
                }                
                pdfStamper.Close();
                outputPDFStream.Close();
                inputPDFFile.Close();
            }
            iDBG++;
        }

        private void txtBoxChosenFile_DoubleClick(object sender, EventArgs e)
        {
            int iDBG = 100;
            string sPDFFile = "";
            openFD_PDF.Title = "Soubor PDF . . .";
            openFD_PDF.InitialDirectory = @"f:\Alexandria\Devel\CS\EnDusanVS2015\EnDusan\Data\";
            openFD_PDF.Filter = "PDF|*.pdf";

            if (openFD_PDF.ShowDialog() == DialogResult.Cancel)
            {
                txtBoxChosenFile.Text = " ... soubor nebyl vybran.";
                btnTestPDFF.Hide();
            }
            else
            {
               
                sPDFFile = openFD_PDF.FileName;
                if (File.Exists(sPDFFile))
                {
                    txtBoxChosenFile.Text = openFD_PDF.FileName.ToString();
                    testPDFAcroFields(txtBoxChosenFile.Text);
                }
                else
                {
                    txtBoxChosenFile.Text = " ... soubor neexistuje.";
                    btnTestPDFF.Hide();
                }
            }
            iDBG = 101;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            //PDFDemoTest001();
            //runPDFA4Updated();
            runPDFA4UpdatedNEW();
        }

        private void btnPDFGenerator_Click(object sender, EventArgs e)
        {
            runPDFA4NewDocument();
        }
    }

    public class A1Dusan : ITextSharpA4PDFBase
    {
        private string sPDFFileRun;
        public A1Dusan( string sPDFFile)
        {
            sPDFFileRun = sPDFFile;
        }

        public A1Dusan()
        {
            ;
        }


        public void GenerateA4()
        {
            int iDBG = 0;
            // Create iTextSharp Objects
            GenerateA4Base();
            
            A1.Add(HeaderLogo());

            A1.Add(DateLine());
            //A1.Add(TextLineH5("PRUKAZ ENERGETICKE NAROCNOSTI BUDOV"));
            //A1.Add(TextLineH4("PRUKAZ ENERGETICKE NAROCNOSTI BUDOV"));
            A1.Add(TextLineH2CP1250("PR\u016F\u016EKAZ ENERGETICKé NáROčNOSTI BUDOV"));
            string sProjekt = "PROJEKT: ";
            sProjekt = sProjekt + "Test Projekt";
            A1.Add(TextLineH2CP1250( sProjekt));

            if (iDBG > 0)
            {
                #region Table
                //Table START
                PdfPTable table = new PdfPTable(5);
                table.SpacingBefore = 10;
                table.SpacingAfter = 10;
                //table HEADER
                table.AddCell(CellHeader("Stena"));
                table.AddCell(CellHeader("A Plocha"));
                table.AddCell(CellHeader("Ui"));
                table.AddCell(CellHeader("UN,20"));
                table.AddCell(CellHeader("Di"));
                //table Test DATA
                table.AddCell(CellData("1"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("2"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("3"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("4"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("5"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("6"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("7"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("8"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("9"));
                table.AddCell(CellData("1.1"));
                table.AddCell(CellData("1.2"));
                table.AddCell(CellData("1.3"));
                table.AddCell(CellData("1.4"));
                table.AddCell(CellData("10"));
                //Table END
                A1.Add(table);
                #endregion
            }
            if (iDBG > 0)
            {
                #region IMAGE
                //Image  START          
                iTextSharp.text.Image reportImageTest = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Resource.RosettaStone, BaseColor.WHITE);
                reportImageTest.ScaleToFit(250f, 250f);
                reportImageTest.Border = iTextSharp.text.Rectangle.BOX;
                reportImageTest.BorderColor = iTextSharp.text.BaseColor.MAGENTA;
                reportImageTest.BorderWidth = 10f;
                A1.Add(reportImageTest);
                //Image End
                #endregion
            }
            #region TextField
            //
            #endregion

            Closing();
            A1.Close();
            //Editable Field
            /*PdfReader pdfReader = new PdfReader(sPDFFileRun);
            AcroFields pdfFields = pdfReader.AcroFields;
            pdfFields.SetField("FormField_1", "1");
            pdfReader.Close();*/
            DocumentBytes = PDFStream.GetBuffer();
        }
    }


    public class ChildFieldEvent : IPdfPCellEvent
    {
        //web source: https://github.com/kusl/itextsharp/blob/master/book/iTextExamplesWeb/iTextExamplesWeb/iTextInAction2Ed/Chapter08/ChildFieldEvent.cs
        protected PdfFormField parent;
        protected PdfFormField kid;
        protected float padding;
        
        public ChildFieldEvent( PdfFormField parent, PdfFormField kid, float padding)
        {
            this.parent = parent;
            this.kid = kid;
            this.padding = padding;
        }
        public void CellLayout(PdfPCell cell, iTextSharp.text.Rectangle rect, PdfContentByte[] cb)
        {
            parent.AddKid(kid);
            kid.SetWidget(
              new iTextSharp.text.Rectangle(rect.GetLeft(padding), rect.GetBottom(padding),
              rect.GetRight(padding), rect.GetTop(padding)),
              PdfAnnotation.HIGHLIGHT_INVERT
            );
        }
    }

    public class Subscribe : PdfWriter
    {
        public void Write(Stream writeStream)
        {
            Subscribe testSubscribe = new Subscribe();
            byte[] writePDF = testSubscribe.CreatePDF();

        }

        public byte[] CreatePDF()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();                
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    document.Open();
                    PdfFormField personal = PdfFormField.CreateEmpty(writer);
                    personal.FieldName = "personal";
                    PdfPTable table = new PdfPTable(3);
                    PdfPCell cell;

                    table.AddCell("Your name:");
                    cell = new PdfPCell();
                    cell.Colspan = 2;
                    TextField field = new TextField(writer, new iTextSharp.text.Rectangle(0, 0), "name");
                    field.FontSize = 12;
                    cell.CellEvent = new  ChildFieldEvent( personal, field.GetTextField(), 1);
                    table.AddCell(cell);
                    table.AddCell("Login:");
                    cell = new PdfPCell();
                    field = new TextField(writer, new iTextSharp.text.Rectangle(0, 0), "loginname");
                    field.FontSize = 12;
                    cell.CellEvent = new ChildFieldEvent( personal, field.GetTextField(), 1);
                    table.AddCell(cell);
                    cell = new PdfPCell();
                    field = new TextField(writer, new iTextSharp.text.Rectangle(0, 0), "password");
                    field.Options = TextField.PASSWORD;
                    field.FontSize = 12;
                    cell.CellEvent = new ChildFieldEvent(personal, field.GetTextField(), 1);
                    table.AddCell(cell);
                    table.AddCell("Your motivation:");
                    cell = new PdfPCell();
                    cell.Colspan = 2;
                    cell.FixedHeight = 60;
                    field = new TextField(writer, new iTextSharp.text.Rectangle(0, 0), "reason");
                    field.Options = TextField.MULTILINE;
                    field.FontSize = 12;
                    cell.CellEvent = new ChildFieldEvent( personal, field.GetTextField(), 1);
                    table.AddCell(cell);
                    document.Add(table);
                    writer.AddAnnotation(personal);
                    //writer.Close();
                    document.Close();               
                return ms.ToArray();
            }
        }
    }
}