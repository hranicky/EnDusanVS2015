using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EnDusan
{

    public class ITextSharpA4PDFBase : PdfPageEventHelper
    {
        #region Privates
        protected const string NewLine = "\n";
        protected Document A1;
        protected BaseFont fontTimes;        
        protected PdfTemplate footerTemplate;
        protected PdfContentByte PDFCntByte;
        // font definitions 
        protected iTextSharp.text.Font fontFooter;
        protected iTextSharp.text.Font fontGeneralText;
        protected iTextSharp.text.Font fontBoldText;
        protected iTextSharp.text.Font fontCellHeader;
        protected iTextSharp.text.Font fontLargeBoldText;
       
        //New Fonts
        protected iTextSharp.text.Font fontH2;
        protected iTextSharp.text.Font fontH4;
        protected iTextSharp.text.Font fontH5;
        //New Fonts CP1250
        protected BaseFont BfontTimesCP1250;
        protected iTextSharp.text.Font fontH2CP1250;

        protected PdfWriter PDFWrt;
        #endregion

        #region Properties
        #region PDFStream
        private MemoryStream memoryStream_PDFStream = new MemoryStream();
        public MemoryStream PDFStream
        {
            get { return memoryStream_PDFStream; }
            set
            {
                if (memoryStream_PDFStream == value)
                    return;
                memoryStream_PDFStream = value;
            }
        }
        #endregion
        #endregion

        public byte[] DocumentBytes;
        #region CTOR
        public ITextSharpA4PDFBase()
        {
            A1 = new Document(PageSize.A4);
            PDFStream = new MemoryStream();
            buildFonts();

            //TODO: Change Footer Address
            /*FooterLines.Add("503-250 Ferrand Drive");
            FooterLines.Add("Toronto Ontario, M3C 3G8 Canada");
            FooterLines.Add("Tel +1 416-849-8900 x 100");*/
        }
        #endregion

        #region buildFonts
        /// <summary>
        /// defines standard fonts used in this class
        /// </summary>
        private void buildFonts()
        {
            // add more font types. These may be reused through the document creation
            fontTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
            fontFooter = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);
            fontGeneralText = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            fontBoldText = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            fontCellHeader = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            fontLargeBoldText = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 17, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            //New Fonts
            fontH2 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK); 
            fontH4 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 28, iTextSharp.text.Font.BOLD, BaseColor.BLACK); 
            fontH5 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 35, iTextSharp.text.Font.BOLD, BaseColor.BLACK); 
            //New Fonts CP1250
            BfontTimesCP1250 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            fontH2CP1250 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK); 
        }
        #endregion

        #region GenerateA4Base
        /// <summary>
        /// This creates the base A4 objects
        /// </summary>
        public void GenerateA4Base()
        {
            PDFWrt = PdfWriter.GetInstance(A1, PDFStream);
            A1.Open();
            PDFCntByte = PDFWrt.DirectContent;
            PDFWrt.PageEvent = this;
            A1.SetMargins(A1.LeftMargin, A1.RightMargin, A1.TopMargin, A1.BottomMargin);            
        }
        #endregion

        #region HeaderLogo
        /// <summary>
        /// Adds the header logo from the resource file.
        /// </summary>
        /// <returns>(IElement) Image</returns>
        public iTextSharp.text.Image HeaderLogo()
        {
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance((System.Drawing.Image)Resource.Anonymous_C, BaseColor.WHITE);
            // This scales the image to a usable size.  you can change this if your image does not look right.
            gif.ScaleAbsolute(125.0f, 50.0f);
            return gif;
        }
        #endregion

        #region DateLine 
        /// <summary>
        /// Dateline - creates a data line paragraph 
        /// </summary>
        /// <param name="LetterDate">date to be printed</param>
        /// <returns>itextsharp paragraph</returns>
        public Paragraph DateLine(string A4Date)
        {
            Paragraph parDTLine = new Paragraph(A4Date, fontGeneralText); // fontGeneralText);
            parDTLine.Alignment = 2;
            parDTLine.SpacingAfter = 15.0f;
            parDTLine.IndentationRight = 60.0f;

            return parDTLine;
        }
        /// <summary>
        /// 201701061730
        /// Dateline - creates a data line paragraph - defaults to today's date
        /// </summary>
        /// <returns>itextsharp paragraph</returns>
        public Paragraph DateLine()
        {
            Chunk chunkDTText = new Chunk("Datum zpracovani: ", fontGeneralText);
            Chunk chunkDT = new Chunk(DateTime.Now.ToString("dd.MM.yyyy - HH:mm"), fontGeneralText);
            Paragraph parDTLine = new Paragraph();
            parDTLine.Add(chunkDTText);
            parDTLine.Add(chunkDT);
            parDTLine.Alignment = 2;
            parDTLine.SpacingAfter = 15.0f;
            parDTLine.IndentationRight = 60.0f;
            return parDTLine;
        }
        #endregion

        #region TextLineH2CP1250
        /// <summary>
        /// TextLine H2 - creates a text line paragraph 
        /// </summary>
        /// <param name="TextLineH2CP1250">text to be printed</param>
        /// <returns>itextsharp paragraph</returns>
        public Paragraph TextLineH2CP1250(string Text)
        {
            Paragraph parTextLineH2 = new Paragraph(Text, fontH2CP1250);
            //parTextLineH5.Alignment = 2;
            //parTextLineH5.SpacingAfter = 15.0f;
            //parTextLineH5.IndentationRight = 60.0f;
            parTextLineH2.Alignment = Element.ALIGN_CENTER;
            return parTextLineH2;
        }
        #endregion
        #region TextLineH2
        /// <summary>
        /// TextLine H2 - creates a text line paragraph 
        /// </summary>
        /// <param name="TextLineH2">text to be printed</param>
        /// <returns>itextsharp paragraph</returns>
        public Paragraph TextLineH2(string Text)
        {
            Paragraph parTextLineH2 = new Paragraph(Text, fontH2);
            //parTextLineH5.Alignment = 2;
            //parTextLineH5.SpacingAfter = 15.0f;
            //parTextLineH5.IndentationRight = 60.0f;
            parTextLineH2.Alignment = Element.ALIGN_CENTER;
            return parTextLineH2;
        }
        #endregion



        #region TextLineH4
        /// <summary>
        /// TextLine H4 - creates a text line paragraph 
        /// </summary>
        /// <param name="TextLineH4">text to be printed</param>
        /// <returns>itextsharp paragraph</returns>
        public Paragraph TextLineH4(string Text)
        {
            Paragraph parTextLineH4 = new Paragraph(Text, fontH5);
            //parTextLineH5.Alignment = 2;
            //parTextLineH5.SpacingAfter = 15.0f;
            //parTextLineH5.IndentationRight = 60.0f;
            parTextLineH4.Alignment = Element.ALIGN_CENTER;
            return parTextLineH4;
        }
        #endregion

        #region TextLineH5
        /// <summary>
        /// TextLine H5 - creates a text line paragraph 
        /// </summary>
        /// <param name="TextLineH5">text to be printed</param>
        /// <returns>itextsharp paragraph</returns>
        public Paragraph TextLineH5(string Text)
        {
            Paragraph parTextLineH5 = new Paragraph(Text, fontH5);
            //parTextLineH5.Alignment = 2;
            //parTextLineH5.SpacingAfter = 15.0f;
            //parTextLineH5.IndentationRight = 60.0f;
            parTextLineH5.Alignment = Element.ALIGN_CENTER;
            return parTextLineH5;
        }
        #endregion

        #region REBlock
        /// <summary>
        /// Defines a Reference section for A4
        /// /// </summary>
        /// <param name="para">Paragraph containing the reference information.</param>
        /// <returns>PdfPTable object (Ielement)</returns>
        public PdfPTable REBlock(Paragraph para)
        {
            PdfPTable table = new PdfPTable(2);          
            float[] widths = new float[] { 1f, 9f };
            table.SetWidths(widths);
            table.SpacingAfter = 10.0f;

            para.Leading = 12f;
            table.HorizontalAlignment = 0;
            // RE Line 
            table.AddCell(CellDataNoBorder("RE:"));
            table.AddCell(CellDataNoBorder(para));
            return table;
        }
        #endregion

        #region CellDataNoBorder
        /// <summary>
        /// creates a PdfpCell without a border.
        /// </summary>
        /// <param name="text">text to be included in the cell</param>
        /// <returns>PdfPCell object</returns>
        public PdfPCell CellDataNoBorder(string text)
        {
            Paragraph curphrase = new Paragraph(text, fontGeneralText);
            PdfPCell x = new PdfPCell(curphrase);
            x.Border = 0;
            x.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            return x;
        }
        /// <summary>
        /// creates a PdfpCell without a border.
        /// </summary>
        /// <param name="text">ItextSharp Paragraph containing data</param>
        /// <returns>PdfPCell Object</returns>
        public PdfPCell CellDataNoBorder(Paragraph text)
        {
            PdfPCell x = new PdfPCell(text);
            x.Border = 0;
            x.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            return x;
        }
        #endregion

        #region CellData
        /// <summary>
        /// creates a PdfpCell with a border.
        /// </summary>
        /// <param name="text">text to be included in the cell</param>
        /// <returns>PdfPCell object</returns>
        public PdfPCell CellData(string text)
        {
            Paragraph curphrase = new Paragraph(text, fontGeneralText);
            PdfPCell x = new PdfPCell(curphrase);
            x.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
            return x;
        }
        #endregion

        #region CellHeader
        /// <summary>
        /// creates a PdfpCell Header Cell, bold text, light grey background.
        /// </summary>
        /// <param name="text">text to be included in the cell</param>
        /// <returns>PdfPCell object</returns>
        public PdfPCell CellHeader(string text)
        {
            Paragraph curphrase = new Paragraph(text, fontCellHeader);
            PdfPCell x = new PdfPCell(curphrase);
            x.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            return x;
        }
        #endregion


        #region WriteREBlock
        /// <summary>
        /// Writes the REBlock
        /// </summary>
        /// <param name="block">Paragraph containing RE Content </param>
        /// <returns>(IElement) PdfPTable object</returns>
        public PdfPTable WriteREBlock(Paragraph block, int iSpaceBefore)
        {
            PdfPTable table = new PdfPTable(2);
            table.SpacingBefore = iSpaceBefore;
            float[] widths = new float[] { 1f, 9f };

            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.DefaultCell.BorderWidth = 0;
            table.DefaultCell.BorderColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

            // RE Line 
            table.AddCell(CellDataNoBorder("RE:"));
            table.AddCell(CellDataNoBorder(block));

            table.SpacingAfter = 10.0f;

            return table;
        }
        #endregion


        #region Closing
        /// <summary>
        /// Creates the closing block for the letter.  Closing Properties are defaulted at construction.
        /// 
        /// </summary>
        public void Closing()
        {

            /*Paragraph p6 = new Paragraph();
            p6.SpacingAfter = 30.0f;
            p6.Add(new Phrase(ClosingFinalLine, fontGeneralText));
            l1.Add(p6);

            Paragraph p7 = new Paragraph();
            p7.SpacingAfter = 20.0f;
            p7.Add(new Phrase(ClosingSalutation, fontGeneralText));
            l1.Add(p7);

            Paragraph p8 = new Paragraph();
            p8.SpacingAfter = 20.0f;
            p8.Leading = 12;
            p8.Add(new Phrase(FromPerson + Environment.NewLine, fontGeneralText));
            p8.Add(new Phrase(FromTitle, fontGeneralText));
            l1.Add(p8);*/
        }
        #endregion
    }

}

