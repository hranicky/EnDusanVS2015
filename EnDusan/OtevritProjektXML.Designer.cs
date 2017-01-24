/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 12/1/2015
 * Time: 2:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EnDusan
{
	partial class OtevritProjektXML
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
			this.SPbtnPath = new System.Windows.Forms.Button();
			this.OPtxtBxFileName = new System.Windows.Forms.TextBox();
			this.OPtxtBxMistoUlozeni = new System.Windows.Forms.TextBox();
			this.SPtxtProcessedProject = new System.Windows.Forms.TextBox();
			this.SPlblPath = new System.Windows.Forms.Label();
			this.SvPrjlblProject = new System.Windows.Forms.Label();
			this.OPbtnFill = new System.Windows.Forms.Button();
			this.SPbtnCancel = new System.Windows.Forms.Button();
			this.openDGVTrans = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.openDGVTrans)).BeginInit();
			this.SuspendLayout();
			// 
			// SPbtnPath
			// 
			this.SPbtnPath.Location = new System.Drawing.Point(425, 33);
			this.SPbtnPath.Name = "SPbtnPath";
			this.SPbtnPath.Size = new System.Drawing.Size(30, 23);
			this.SPbtnPath.TabIndex = 21;
			this.SPbtnPath.Text = " ... ";
			this.SPbtnPath.UseVisualStyleBackColor = true;
			// 
			// OPtxtBxFileName
			// 
			this.OPtxtBxFileName.Location = new System.Drawing.Point(78, 65);
			this.OPtxtBxFileName.Name = "OPtxtBxFileName";
			this.OPtxtBxFileName.Size = new System.Drawing.Size(330, 20);
			this.OPtxtBxFileName.TabIndex = 20;
			this.OPtxtBxFileName.TextChanged += new System.EventHandler(this.eventFileNameChanged);
			// 
			// OPtxtBxMistoUlozeni
			// 
			this.OPtxtBxMistoUlozeni.Location = new System.Drawing.Point(78, 37);
			this.OPtxtBxMistoUlozeni.Name = "OPtxtBxMistoUlozeni";
			this.OPtxtBxMistoUlozeni.Size = new System.Drawing.Size(330, 20);
			this.OPtxtBxMistoUlozeni.TabIndex = 19;
			// 
			// SPtxtProcessedProject
			// 
			this.SPtxtProcessedProject.Location = new System.Drawing.Point(78, 12);
			this.SPtxtProcessedProject.Name = "SPtxtProcessedProject";
			this.SPtxtProcessedProject.ReadOnly = true;
			this.SPtxtProcessedProject.Size = new System.Drawing.Size(330, 20);
			this.SPtxtProcessedProject.TabIndex = 18;
			// 
			// SPlblPath
			// 
			this.SPlblPath.Location = new System.Drawing.Point(25, 42);
			this.SPlblPath.Name = "SPlblPath";
			this.SPlblPath.Size = new System.Drawing.Size(35, 18);
			this.SPlblPath.TabIndex = 17;
			this.SPlblPath.Text = "Path:";
			// 
			// SvPrjlblProject
			// 
			this.SvPrjlblProject.Location = new System.Drawing.Point(24, 16);
			this.SvPrjlblProject.Name = "SvPrjlblProject";
			this.SvPrjlblProject.Size = new System.Drawing.Size(45, 16);
			this.SvPrjlblProject.TabIndex = 16;
			this.SvPrjlblProject.Text = "Project:";
			// 
			// OPbtnFill
			// 
			this.OPbtnFill.Location = new System.Drawing.Point(487, 274);
			this.OPbtnFill.Name = "OPbtnFill";
			this.OPbtnFill.Size = new System.Drawing.Size(75, 24);
			this.OPbtnFill.TabIndex = 24;
			this.OPbtnFill.Text = "Nacteni";
			this.OPbtnFill.UseVisualStyleBackColor = true;
			this.OPbtnFill.Click += new System.EventHandler(this.eventOPReadXML);
			// 
			// SPbtnCancel
			// 
			this.SPbtnCancel.Location = new System.Drawing.Point(568, 273);
			this.SPbtnCancel.Name = "SPbtnCancel";
			this.SPbtnCancel.Size = new System.Drawing.Size(69, 26);
			this.SPbtnCancel.TabIndex = 23;
			this.SPbtnCancel.Text = "Cancel";
			this.SPbtnCancel.UseVisualStyleBackColor = true;
			this.SPbtnCancel.Click += new System.EventHandler(this.SPbtnCancelClick);
			// 
			// openDGVTrans
			// 
			this.openDGVTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.openDGVTrans.Location = new System.Drawing.Point(78, 100);
			this.openDGVTrans.Name = "openDGVTrans";
			this.openDGVTrans.Size = new System.Drawing.Size(59, 31);
			this.openDGVTrans.TabIndex = 25;
			// 
			// OtevritProjektXML
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 311);
			this.Controls.Add(this.openDGVTrans);
			this.Controls.Add(this.OPbtnFill);
			this.Controls.Add(this.SPbtnCancel);
			this.Controls.Add(this.SPbtnPath);
			this.Controls.Add(this.OPtxtBxFileName);
			this.Controls.Add(this.OPtxtBxMistoUlozeni);
			this.Controls.Add(this.SPtxtProcessedProject);
			this.Controls.Add(this.SPlblPath);
			this.Controls.Add(this.SvPrjlblProject);
			this.Name = "OtevritProjektXML";
			this.Text = "OtevritProjektXML";
			this.Load += new System.EventHandler(this.eventFrmLoad);
			((System.ComponentModel.ISupportInitialize)(this.openDGVTrans)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridView openDGVTrans;
		private System.Windows.Forms.Button SPbtnCancel;
		private System.Windows.Forms.Button OPbtnFill;
		private System.Windows.Forms.Label SvPrjlblProject;
		private System.Windows.Forms.Label SPlblPath;
		private System.Windows.Forms.TextBox SPtxtProcessedProject;
		private System.Windows.Forms.TextBox OPtxtBxMistoUlozeni;
		private System.Windows.Forms.TextBox OPtxtBxFileName;
		private System.Windows.Forms.Button SPbtnPath;
	}
}
