namespace EnDusan
{
    partial class PDFForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPDF_1 = new System.Windows.Forms.Label();
            this.btnPDFGenerator = new System.Windows.Forms.Button();
            this.btnChapter_8 = new System.Windows.Forms.Button();
            this.btnTestPDFF = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxChosenFile = new System.Windows.Forms.TextBox();
            this.openFD_PDF = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(541, 449);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(95, 34);
            this.btnPDF.TabIndex = 0;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(653, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPDF_1
            // 
            this.lblPDF_1.AutoSize = true;
            this.lblPDF_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDF_1.Location = new System.Drawing.Point(43, 20);
            this.lblPDF_1.Name = "lblPDF_1";
            this.lblPDF_1.Size = new System.Drawing.Size(219, 24);
            this.lblPDF_1.TabIndex = 2;
            this.lblPDF_1.Text = "Pokusny text Label 01:";
            // 
            // btnPDFGenerator
            // 
            this.btnPDFGenerator.BackColor = System.Drawing.Color.Yellow;
            this.btnPDFGenerator.Location = new System.Drawing.Point(425, 449);
            this.btnPDFGenerator.Name = "btnPDFGenerator";
            this.btnPDFGenerator.Size = new System.Drawing.Size(95, 34);
            this.btnPDFGenerator.TabIndex = 3;
            this.btnPDFGenerator.Text = "PDFGenerator";
            this.btnPDFGenerator.UseVisualStyleBackColor = false;
            this.btnPDFGenerator.Click += new System.EventHandler(this.btnPDFGenerator_Click);
            // 
            // btnChapter_8
            // 
            this.btnChapter_8.BackColor = System.Drawing.Color.Yellow;
            this.btnChapter_8.Location = new System.Drawing.Point(309, 449);
            this.btnChapter_8.Name = "btnChapter_8";
            this.btnChapter_8.Size = new System.Drawing.Size(95, 34);
            this.btnChapter_8.TabIndex = 4;
            this.btnChapter_8.Text = "PDF_Chapter_8";
            this.btnChapter_8.UseVisualStyleBackColor = false;
            this.btnChapter_8.Click += new System.EventHandler(this.btnChapter_8_Click);
            // 
            // btnTestPDFF
            // 
            this.btnTestPDFF.BackColor = System.Drawing.Color.Yellow;
            this.btnTestPDFF.Location = new System.Drawing.Point(587, 58);
            this.btnTestPDFF.Name = "btnTestPDFF";
            this.btnTestPDFF.Size = new System.Drawing.Size(95, 34);
            this.btnTestPDFF.TabIndex = 5;
            this.btnTestPDFF.Text = "TestPDFFile";
            this.btnTestPDFF.UseVisualStyleBackColor = false;
            this.btnTestPDFF.Click += new System.EventHandler(this.btnTestPDFF_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxChosenFile);
            this.groupBox1.Controls.Add(this.btnTestPDFF);
            this.groupBox1.Location = new System.Drawing.Point(47, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Path PDF File:";
            // 
            // txtBoxChosenFile
            // 
            this.txtBoxChosenFile.Location = new System.Drawing.Point(96, 19);
            this.txtBoxChosenFile.Name = "txtBoxChosenFile";
            this.txtBoxChosenFile.Size = new System.Drawing.Size(586, 20);
            this.txtBoxChosenFile.TabIndex = 6;
            this.txtBoxChosenFile.DoubleClick += new System.EventHandler(this.txtBoxChosenFile_DoubleClick);
            // 
            // openFD_PDF
            // 
            this.openFD_PDF.FileName = "openFileDialog1";
            // 
            // PDFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 495);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChapter_8);
            this.Controls.Add(this.btnPDFGenerator);
            this.Controls.Add(this.lblPDF_1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPDF);
            this.Name = "PDFForm";
            this.Text = "PDFForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPDF_1;
        private System.Windows.Forms.Button btnPDFGenerator;
        private System.Windows.Forms.Button btnChapter_8;
        private System.Windows.Forms.Button btnTestPDFF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxChosenFile;
        private System.Windows.Forms.OpenFileDialog openFD_PDF;
    }
}