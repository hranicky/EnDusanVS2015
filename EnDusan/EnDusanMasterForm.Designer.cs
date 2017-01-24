/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/11/2015
 * Time: 7:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EnDusan
{
	partial class EnDusanMasterForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novyProjektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemUlozitXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItem_OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnItemPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kOnfiguraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCtrlProjekt = new System.Windows.Forms.TabControl();
            this.tabProjekt = new System.Windows.Forms.TabPage();
            this.KVtxtSumaAUiDiMaster = new System.Windows.Forms.TextBox();
            this.KVtxtSumaAUN20DiMaster = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDBG = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvEn = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.KVtxtSumaAUN20Di = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KVtxtSumaAUiDi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KVtxtSumaA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxProjekt = new System.Windows.Forms.TextBox();
            this.lblProjetk = new System.Windows.Forms.Label();
            this.grpBoxHead = new System.Windows.Forms.GroupBox();
            this.pctBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpBoxFoto = new System.Windows.Forms.GroupBox();
            this.lblPopiskaFoto = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pctBoxA = new System.Windows.Forms.PictureBox();
            this.txtBox__List = new System.Windows.Forms.TextBox();
            this.mnMain.SuspendLayout();
            this.tabCtrlProjekt.SuspendLayout();
            this.tabProjekt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEn)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.grpBoxHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogo)).BeginInit();
            this.grpBoxFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxA)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(695, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnMain
            // 
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.systemToolStripMenuItem1,
            this.toolStripMenuItem3});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(695, 24);
            this.mnMain.TabIndex = 2;
            this.mnMain.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novyProjektToolStripMenuItem,
            this.mnItemUlozitXML,
            this.mnItem_OpenProject,
            this.mnItemExportPDF,
            this.toolStripSeparator1,
            this.mnItemPrintPreview,
            this.mnItemPrint,
            this.toolStripSeparator2,
            this.mnItemExit});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.systemToolStripMenuItem.Text = "Projekt";
            this.systemToolStripMenuItem.Click += new System.EventHandler(this.eventLeave);
            // 
            // novyProjektToolStripMenuItem
            // 
            this.novyProjektToolStripMenuItem.Name = "novyProjektToolStripMenuItem";
            this.novyProjektToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.novyProjektToolStripMenuItem.Text = "Novy Projekt";
            // 
            // mnItemUlozitXML
            // 
            this.mnItemUlozitXML.Name = "mnItemUlozitXML";
            this.mnItemUlozitXML.Size = new System.Drawing.Size(147, 22);
            this.mnItemUlozitXML.Text = "UlozitXML";
            this.mnItemUlozitXML.Click += new System.EventHandler(this.eventMnItemUlozitPrjXML);
            // 
            // mnItem_OpenProject
            // 
            this.mnItem_OpenProject.Name = "mnItem_OpenProject";
            this.mnItem_OpenProject.Size = new System.Drawing.Size(147, 22);
            this.mnItem_OpenProject.Text = "OtevritProjekt";
            this.mnItem_OpenProject.Click += new System.EventHandler(this.eventMnPrj_OtevritProjekt);
            // 
            // mnItemExportPDF
            // 
            this.mnItemExportPDF.Name = "mnItemExportPDF";
            this.mnItemExportPDF.Size = new System.Drawing.Size(147, 22);
            this.mnItemExportPDF.Text = "Export-PDF";
            this.mnItemExportPDF.Click += new System.EventHandler(this.eventMnPrjExpPDF);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // mnItemPrintPreview
            // 
            this.mnItemPrintPreview.Name = "mnItemPrintPreview";
            this.mnItemPrintPreview.Size = new System.Drawing.Size(147, 22);
            this.mnItemPrintPreview.Text = "PrintPreview";
            // 
            // mnItemPrint
            // 
            this.mnItemPrint.Name = "mnItemPrint";
            this.mnItemPrint.Size = new System.Drawing.Size(147, 22);
            this.mnItemPrint.Text = "Print";
            this.mnItemPrint.Click += new System.EventHandler(this.eventMnItemPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // mnItemExit
            // 
            this.mnItemExit.Name = "mnItemExit";
            this.mnItemExit.Size = new System.Drawing.Size(147, 22);
            this.mnItemExit.Text = "Exit";
            this.mnItemExit.Click += new System.EventHandler(this.eventMnItemExit_Click);
            // 
            // systemToolStripMenuItem1
            // 
            this.systemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kOnfiguraceToolStripMenuItem});
            this.systemToolStripMenuItem1.Name = "systemToolStripMenuItem1";
            this.systemToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem1.Text = "System";
            // 
            // kOnfiguraceToolStripMenuItem
            // 
            this.kOnfiguraceToolStripMenuItem.Name = "kOnfiguraceToolStripMenuItem";
            this.kOnfiguraceToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.kOnfiguraceToolStripMenuItem.Text = "Konfigurace";
            this.kOnfiguraceToolStripMenuItem.Click += new System.EventHandler(this.eventMnSystem_CNF);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oAplikaciToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItem3.Text = "Napoveda";
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.oAplikaciToolStripMenuItem.Text = "O Aplikaci";
            this.oAplikaciToolStripMenuItem.Click += new System.EventHandler(this.eventMnOAplikaci);
            // 
            // tabCtrlProjekt
            // 
            this.tabCtrlProjekt.Controls.Add(this.tabProjekt);
            this.tabCtrlProjekt.Controls.Add(this.tabPage2);
            this.tabCtrlProjekt.Location = new System.Drawing.Point(12, 145);
            this.tabCtrlProjekt.Name = "tabCtrlProjekt";
            this.tabCtrlProjekt.SelectedIndex = 0;
            this.tabCtrlProjekt.Size = new System.Drawing.Size(545, 375);
            this.tabCtrlProjekt.TabIndex = 3;
            // 
            // tabProjekt
            // 
            this.tabProjekt.Controls.Add(this.KVtxtSumaAUiDiMaster);
            this.tabProjekt.Controls.Add(this.KVtxtSumaAUN20DiMaster);
            this.tabProjekt.Controls.Add(this.label4);
            this.tabProjekt.Controls.Add(this.label5);
            this.tabProjekt.Controls.Add(this.btnDBG);
            this.tabProjekt.Controls.Add(this.btnFill);
            this.tabProjekt.Controls.Add(this.btnClear);
            this.tabProjekt.Controls.Add(this.dgvEn);
            this.tabProjekt.Location = new System.Drawing.Point(4, 22);
            this.tabProjekt.Name = "tabProjekt";
            this.tabProjekt.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjekt.Size = new System.Drawing.Size(537, 349);
            this.tabProjekt.TabIndex = 0;
            this.tabProjekt.Text = "Projekt";
            this.tabProjekt.UseVisualStyleBackColor = true;
            this.tabProjekt.Leave += new System.EventHandler(this.eventLeave);
            // 
            // KVtxtSumaAUiDiMaster
            // 
            this.KVtxtSumaAUiDiMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KVtxtSumaAUiDiMaster.Location = new System.Drawing.Point(124, 7);
            this.KVtxtSumaAUiDiMaster.Name = "KVtxtSumaAUiDiMaster";
            this.KVtxtSumaAUiDiMaster.ReadOnly = true;
            this.KVtxtSumaAUiDiMaster.Size = new System.Drawing.Size(127, 26);
            this.KVtxtSumaAUiDiMaster.TabIndex = 10;
            // 
            // KVtxtSumaAUN20DiMaster
            // 
            this.KVtxtSumaAUN20DiMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KVtxtSumaAUN20DiMaster.Location = new System.Drawing.Point(384, 7);
            this.KVtxtSumaAUN20DiMaster.Name = "KVtxtSumaAUN20DiMaster";
            this.KVtxtSumaAUN20DiMaster.ReadOnly = true;
            this.KVtxtSumaAUN20DiMaster.Size = new System.Drawing.Size(127, 26);
            this.KVtxtSumaAUN20DiMaster.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(258, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "∑A*UN,20*Di:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "∑A*Ui*Di:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDBG
            // 
            this.btnDBG.Location = new System.Drawing.Point(287, 313);
            this.btnDBG.Name = "btnDBG";
            this.btnDBG.Size = new System.Drawing.Size(75, 23);
            this.btnDBG.TabIndex = 5;
            this.btnDBG.Text = "DBG";
            this.btnDBG.UseVisualStyleBackColor = true;
            this.btnDBG.Click += new System.EventHandler(this.btnDBG_Click);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(449, 313);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 4;
            this.btnFill.Text = "TestFill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.eventFillDGVTest);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(368, 313);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.eventClearDGV);
            // 
            // dgvEn
            // 
            this.dgvEn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEn.Location = new System.Drawing.Point(8, 38);
            this.dgvEn.Name = "dgvEn";
            this.dgvEn.Size = new System.Drawing.Size(516, 269);
            this.dgvEn.TabIndex = 0;
            this.dgvEn.Tag = "XMLStorable";
            this.dgvEn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEn_CellValueChanged);
            this.dgvEn.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.eventFrmMaster_DGVRowAdd);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.KVtxtSumaAUN20Di);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.KVtxtSumaAUiDi);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.KVtxtSumaA);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(537, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kumulace Vysledku";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.eventSumaTab);
            // 
            // KVtxtSumaAUN20Di
            // 
            this.KVtxtSumaAUN20Di.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KVtxtSumaAUN20Di.Location = new System.Drawing.Point(117, 112);
            this.KVtxtSumaAUN20Di.Name = "KVtxtSumaAUN20Di";
            this.KVtxtSumaAUN20Di.ReadOnly = true;
            this.KVtxtSumaAUN20Di.Size = new System.Drawing.Size(127, 26);
            this.KVtxtSumaAUN20Di.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "∑A*UN,20*Di:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KVtxtSumaAUiDi
            // 
            this.KVtxtSumaAUiDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KVtxtSumaAUiDi.Location = new System.Drawing.Point(117, 69);
            this.KVtxtSumaAUiDi.Name = "KVtxtSumaAUiDi";
            this.KVtxtSumaAUiDi.ReadOnly = true;
            this.KVtxtSumaAUiDi.Size = new System.Drawing.Size(127, 26);
            this.KVtxtSumaAUiDi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "∑A*Ui*Di:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KVtxtSumaA
            // 
            this.KVtxtSumaA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KVtxtSumaA.Location = new System.Drawing.Point(117, 27);
            this.KVtxtSumaA.Name = "KVtxtSumaA";
            this.KVtxtSumaA.ReadOnly = true;
            this.KVtxtSumaA.Size = new System.Drawing.Size(127, 26);
            this.KVtxtSumaA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "∑A:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxProjekt
            // 
            this.txtBoxProjekt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBoxProjekt.Location = new System.Drawing.Point(191, 21);
            this.txtBoxProjekt.Name = "txtBoxProjekt";
            this.txtBoxProjekt.Size = new System.Drawing.Size(182, 26);
            this.txtBoxProjekt.TabIndex = 2;
            this.txtBoxProjekt.Tag = "XMLStorable;PDF_Projekt";
            this.txtBoxProjekt.Leave += new System.EventHandler(this.eventFrmMaster_TxtBoxProjectChange);
            // 
            // lblProjetk
            // 
            this.lblProjetk.Location = new System.Drawing.Point(122, 24);
            this.lblProjetk.Name = "lblProjetk";
            this.lblProjetk.Size = new System.Drawing.Size(77, 23);
            this.lblProjetk.TabIndex = 1;
            this.lblProjetk.Text = "Projekt: ";
            // 
            // grpBoxHead
            // 
            this.grpBoxHead.Controls.Add(this.pctBoxLogo);
            this.grpBoxHead.Controls.Add(this.textBox3);
            this.grpBoxHead.Controls.Add(this.label6);
            this.grpBoxHead.Controls.Add(this.txtBoxProjekt);
            this.grpBoxHead.Controls.Add(this.lblProjetk);
            this.grpBoxHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxHead.Location = new System.Drawing.Point(14, 42);
            this.grpBoxHead.Name = "grpBoxHead";
            this.grpBoxHead.Size = new System.Drawing.Size(640, 97);
            this.grpBoxHead.TabIndex = 4;
            this.grpBoxHead.TabStop = false;
            this.grpBoxHead.Text = "ZADANI: IDENTIFIKACNI  UDAJE";
            // 
            // pctBoxLogo
            // 
            this.pctBoxLogo.Image = global::EnDusan.Resource.Anonymous_C;
            this.pctBoxLogo.InitialImage = global::EnDusan.Resource.Anonymous_C;
            this.pctBoxLogo.Location = new System.Drawing.Point(15, 24);
            this.pctBoxLogo.Name = "pctBoxLogo";
            this.pctBoxLogo.Size = new System.Drawing.Size(97, 64);
            this.pctBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxLogo.TabIndex = 4;
            this.pctBoxLogo.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox3.Location = new System.Drawing.Point(191, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "XMLStorable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ulice:";
            // 
            // grpBoxFoto
            // 
            this.grpBoxFoto.Controls.Add(this.lblPopiskaFoto);
            this.grpBoxFoto.Controls.Add(this.textBox5);
            this.grpBoxFoto.Controls.Add(this.pctBoxA);
            this.grpBoxFoto.Location = new System.Drawing.Point(23, 524);
            this.grpBoxFoto.Name = "grpBoxFoto";
            this.grpBoxFoto.Size = new System.Drawing.Size(534, 201);
            this.grpBoxFoto.TabIndex = 5;
            this.grpBoxFoto.TabStop = false;
            this.grpBoxFoto.Text = "Dokumentacni Obrazek: ";
            // 
            // lblPopiskaFoto
            // 
            this.lblPopiskaFoto.AutoSize = true;
            this.lblPopiskaFoto.Location = new System.Drawing.Point(255, 20);
            this.lblPopiskaFoto.Name = "lblPopiskaFoto";
            this.lblPopiskaFoto.Size = new System.Drawing.Size(94, 13);
            this.lblPopiskaFoto.TabIndex = 2;
            this.lblPopiskaFoto.Text = "Popiska Obrazek: ";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(258, 50);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(262, 107);
            this.textBox5.TabIndex = 1;
            this.textBox5.Tag = "XMLStorable";
            // 
            // pctBoxA
            // 
            this.pctBoxA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctBoxA.Location = new System.Drawing.Point(19, 19);
            this.pctBoxA.Name = "pctBoxA";
            this.pctBoxA.Size = new System.Drawing.Size(214, 176);
            this.pctBoxA.TabIndex = 0;
            this.pctBoxA.TabStop = false;
            this.pctBoxA.Tag = "XMLStorable";
            this.pctBoxA.Click += new System.EventHandler(this.pctBoxA_Click);
            // 
            // txtBox__List
            // 
            this.txtBox__List.Enabled = false;
            this.txtBox__List.Location = new System.Drawing.Point(619, 27);
            this.txtBox__List.Name = "txtBox__List";
            this.txtBox__List.ReadOnly = true;
            this.txtBox__List.Size = new System.Drawing.Size(35, 20);
            this.txtBox__List.TabIndex = 5;
            this.txtBox__List.Tag = "PDF_List;";
            this.txtBox__List.Text = "3";
            this.txtBox__List.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnDusanMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 761);
            this.Controls.Add(this.txtBox__List);
            this.Controls.Add(this.grpBoxFoto);
            this.Controls.Add(this.grpBoxHead);
            this.Controls.Add(this.tabCtrlProjekt);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnMain);
            this.MainMenuStrip = this.mnMain;
            this.Name = "EnDusanMasterForm";
            this.Tag = "MasterForm";
            this.Text = "EnDusanMaster";
            this.Load += new System.EventHandler(this.eventFrmMaster_LoadForm);
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.tabCtrlProjekt.ResumeLayout(false);
            this.tabProjekt.ResumeLayout(false);
            this.tabProjekt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grpBoxHead.ResumeLayout(false);
            this.grpBoxHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogo)).EndInit();
            this.grpBoxFoto.ResumeLayout(false);
            this.grpBoxFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox KVtxtSumaA;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox KVtxtSumaAUiDi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox KVtxtSumaAUN20Di;
		private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnFill;
		private System.Windows.Forms.ToolStripMenuItem kOnfiguraceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnItem_OpenProject;
		private System.Windows.Forms.ToolStripMenuItem mnItemExportPDF;
		private System.Windows.Forms.ToolStripMenuItem mnItemExit;
		private System.Windows.Forms.ToolStripMenuItem mnItemUlozitXML;
		private System.Windows.Forms.ToolStripMenuItem novyProjektToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
		private System.Windows.Forms.Label lblProjetk;
		private System.Windows.Forms.TextBox txtBoxProjekt;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView dgvEn;
		private System.Windows.Forms.TabPage tabProjekt;
		private System.Windows.Forms.TabControl tabCtrlProjekt;
		private System.Windows.Forms.MenuStrip mnMain;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnDBG;
        private System.Windows.Forms.TextBox KVtxtSumaAUN20DiMaster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBoxHead;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpBoxFoto;
        private System.Windows.Forms.PictureBox pctBoxA;
        private System.Windows.Forms.Label lblPopiskaFoto;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnItemPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox KVtxtSumaAUiDiMaster;
        private System.Windows.Forms.ToolStripMenuItem mnItemPrint;
        private System.Windows.Forms.PictureBox pctBoxLogo;
        private System.Windows.Forms.TextBox txtBox__List;
    }
}
