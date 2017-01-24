/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/22/2015
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EnDusan
{
	partial class ExportProjectRTFForm
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
			this.SPbtnCancel = new System.Windows.Forms.Button();
			this.SPbtnOK = new System.Windows.Forms.Button();
			this.SPtxtBxFileName = new System.Windows.Forms.TextBox();
			this.SPtxtBxMistoUlozeni = new System.Windows.Forms.TextBox();
			this.SPtxtProcessedProject = new System.Windows.Forms.TextBox();
			this.SPlblPath = new System.Windows.Forms.Label();
			this.SvPrjlblProject = new System.Windows.Forms.Label();
			this.rtBoxExport = new System.Windows.Forms.RichTextBox();
			this.ExpRTFbtnFill = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SPbtnPath
			// 
			this.SPbtnPath.Location = new System.Drawing.Point(413, 33);
			this.SPbtnPath.Name = "SPbtnPath";
			this.SPbtnPath.Size = new System.Drawing.Size(30, 23);
			this.SPbtnPath.TabIndex = 15;
			this.SPbtnPath.Text = " ... ";
			this.SPbtnPath.UseVisualStyleBackColor = true;
			// 
			// SPbtnCancel
			// 
			this.SPbtnCancel.Location = new System.Drawing.Point(588, 252);
			this.SPbtnCancel.Name = "SPbtnCancel";
			this.SPbtnCancel.Size = new System.Drawing.Size(69, 26);
			this.SPbtnCancel.TabIndex = 14;
			this.SPbtnCancel.Text = "Cancel";
			this.SPbtnCancel.UseVisualStyleBackColor = true;
			this.SPbtnCancel.Click += new System.EventHandler(this.eventExpPrjRTFOK);
			// 
			// SPbtnOK
			// 
			this.SPbtnOK.Location = new System.Drawing.Point(494, 252);
			this.SPbtnOK.Name = "SPbtnOK";
			this.SPbtnOK.Size = new System.Drawing.Size(89, 26);
			this.SPbtnOK.TabIndex = 13;
			this.SPbtnOK.Text = "OK-Save";
			this.SPbtnOK.UseVisualStyleBackColor = true;
			this.SPbtnOK.Click += new System.EventHandler(this.eventExpProjRTF);
			// 
			// SPtxtBxFileName
			// 
			this.SPtxtBxFileName.Location = new System.Drawing.Point(66, 65);
			this.SPtxtBxFileName.Name = "SPtxtBxFileName";
			this.SPtxtBxFileName.Size = new System.Drawing.Size(330, 20);
			this.SPtxtBxFileName.TabIndex = 12;
			// 
			// SPtxtBxMistoUlozeni
			// 
			this.SPtxtBxMistoUlozeni.Location = new System.Drawing.Point(66, 37);
			this.SPtxtBxMistoUlozeni.Name = "SPtxtBxMistoUlozeni";
			this.SPtxtBxMistoUlozeni.Size = new System.Drawing.Size(330, 20);
			this.SPtxtBxMistoUlozeni.TabIndex = 11;
			this.SPtxtBxMistoUlozeni.Leave += new System.EventHandler(this.eventTxtBxPathChanged);
			// 
			// SPtxtProcessedProject
			// 
			this.SPtxtProcessedProject.Location = new System.Drawing.Point(66, 12);
			this.SPtxtProcessedProject.Name = "SPtxtProcessedProject";
			this.SPtxtProcessedProject.ReadOnly = true;
			this.SPtxtProcessedProject.Size = new System.Drawing.Size(330, 20);
			this.SPtxtProcessedProject.TabIndex = 10;
			// 
			// SPlblPath
			// 
			this.SPlblPath.Location = new System.Drawing.Point(13, 42);
			this.SPlblPath.Name = "SPlblPath";
			this.SPlblPath.Size = new System.Drawing.Size(35, 18);
			this.SPlblPath.TabIndex = 9;
			this.SPlblPath.Text = "Path:";
			// 
			// SvPrjlblProject
			// 
			this.SvPrjlblProject.Location = new System.Drawing.Point(12, 16);
			this.SvPrjlblProject.Name = "SvPrjlblProject";
			this.SvPrjlblProject.Size = new System.Drawing.Size(45, 16);
			this.SvPrjlblProject.TabIndex = 8;
			this.SvPrjlblProject.Text = "Project:";
			// 
			// rtBoxExport
			// 
			this.rtBoxExport.Location = new System.Drawing.Point(19, 91);
			this.rtBoxExport.Name = "rtBoxExport";
			this.rtBoxExport.ReadOnly = true;
			this.rtBoxExport.Size = new System.Drawing.Size(642, 141);
			this.rtBoxExport.TabIndex = 16;
			this.rtBoxExport.Text = "";
			// 
			// ExpRTFbtnFill
			// 
			this.ExpRTFbtnFill.Location = new System.Drawing.Point(413, 238);
			this.ExpRTFbtnFill.Name = "ExpRTFbtnFill";
			this.ExpRTFbtnFill.Size = new System.Drawing.Size(75, 23);
			this.ExpRTFbtnFill.TabIndex = 17;
			this.ExpRTFbtnFill.Text = "Plneni";
			this.ExpRTFbtnFill.UseVisualStyleBackColor = true;
			this.ExpRTFbtnFill.Click += new System.EventHandler(this.eventbtnFill);
			// 
			// ExportProjectRTFForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(673, 286);
			this.Controls.Add(this.ExpRTFbtnFill);
			this.Controls.Add(this.rtBoxExport);
			this.Controls.Add(this.SPbtnPath);
			this.Controls.Add(this.SPbtnCancel);
			this.Controls.Add(this.SPbtnOK);
			this.Controls.Add(this.SPtxtBxFileName);
			this.Controls.Add(this.SPtxtBxMistoUlozeni);
			this.Controls.Add(this.SPtxtProcessedProject);
			this.Controls.Add(this.SPlblPath);
			this.Controls.Add(this.SvPrjlblProject);
			this.Name = "ExportProjectRTFForm";
			this.Text = "ExportProjectRTFForm";
			this.Load += new System.EventHandler(this.eventExpPrjRTFLoadForm);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button ExpRTFbtnFill;
		private System.Windows.Forms.RichTextBox rtBoxExport;
		private System.Windows.Forms.Label SvPrjlblProject;
		private System.Windows.Forms.Label SPlblPath;
		private System.Windows.Forms.TextBox SPtxtProcessedProject;
		private System.Windows.Forms.TextBox SPtxtBxMistoUlozeni;
		private System.Windows.Forms.TextBox SPtxtBxFileName;
		private System.Windows.Forms.Button SPbtnOK;
		private System.Windows.Forms.Button SPbtnCancel;
		private System.Windows.Forms.Button SPbtnPath;
	}
}
