/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/22/2015
 * Time: 8:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EnDusan
{
	partial class SaveProjectXMLForm
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
            this.SvPrjlblProject = new System.Windows.Forms.Label();
            this.SPlblPath = new System.Windows.Forms.Label();
            this.SPtxtBxProjectName = new System.Windows.Forms.TextBox();
            this.SPtxtBxMistoUlozeni = new System.Windows.Forms.TextBox();
            this.SPtxtBxFileName = new System.Windows.Forms.TextBox();
            this.SPbtnOK = new System.Windows.Forms.Button();
            this.SPbtnCancel = new System.Windows.Forms.Button();
            this.SPbtnPath = new System.Windows.Forms.Button();
            this.btnTestSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SvPrjlblProject
            // 
            this.SvPrjlblProject.Location = new System.Drawing.Point(12, 17);
            this.SvPrjlblProject.Name = "SvPrjlblProject";
            this.SvPrjlblProject.Size = new System.Drawing.Size(45, 16);
            this.SvPrjlblProject.TabIndex = 0;
            this.SvPrjlblProject.Text = "Project:";
            // 
            // SPlblPath
            // 
            this.SPlblPath.Location = new System.Drawing.Point(12, 43);
            this.SPlblPath.Name = "SPlblPath";
            this.SPlblPath.Size = new System.Drawing.Size(35, 18);
            this.SPlblPath.TabIndex = 1;
            this.SPlblPath.Text = "Path:";
            // 
            // SPtxtBxProjectName
            // 
            this.SPtxtBxProjectName.Location = new System.Drawing.Point(65, 13);
            this.SPtxtBxProjectName.Name = "SPtxtBxProjectName";
            this.SPtxtBxProjectName.ReadOnly = true;
            this.SPtxtBxProjectName.Size = new System.Drawing.Size(330, 20);
            this.SPtxtBxProjectName.TabIndex = 2;
            // 
            // SPtxtBxMistoUlozeni
            // 
            this.SPtxtBxMistoUlozeni.Location = new System.Drawing.Point(65, 43);
            this.SPtxtBxMistoUlozeni.Name = "SPtxtBxMistoUlozeni";
            this.SPtxtBxMistoUlozeni.Size = new System.Drawing.Size(330, 20);
            this.SPtxtBxMistoUlozeni.TabIndex = 3;
            this.SPtxtBxMistoUlozeni.Leave += new System.EventHandler(this.eventTxtBxPathChanged);
            // 
            // SPtxtBxFileName
            // 
            this.SPtxtBxFileName.Location = new System.Drawing.Point(65, 78);
            this.SPtxtBxFileName.Name = "SPtxtBxFileName";
            this.SPtxtBxFileName.Size = new System.Drawing.Size(330, 20);
            this.SPtxtBxFileName.TabIndex = 4;
            // 
            // SPbtnOK
            // 
            this.SPbtnOK.Location = new System.Drawing.Point(357, 192);
            this.SPbtnOK.Name = "SPbtnOK";
            this.SPbtnOK.Size = new System.Drawing.Size(69, 26);
            this.SPbtnOK.TabIndex = 5;
            this.SPbtnOK.Text = "OK";
            this.SPbtnOK.UseVisualStyleBackColor = true;
            this.SPbtnOK.Click += new System.EventHandler(this.eventSPbtnOK);
            // 
            // SPbtnCancel
            // 
            this.SPbtnCancel.Location = new System.Drawing.Point(432, 192);
            this.SPbtnCancel.Name = "SPbtnCancel";
            this.SPbtnCancel.Size = new System.Drawing.Size(69, 26);
            this.SPbtnCancel.TabIndex = 6;
            this.SPbtnCancel.Text = "Cancel";
            this.SPbtnCancel.UseVisualStyleBackColor = true;
            this.SPbtnCancel.Click += new System.EventHandler(this.eventSPbtnCancel);
            // 
            // SPbtnPath
            // 
            this.SPbtnPath.Location = new System.Drawing.Point(412, 41);
            this.SPbtnPath.Name = "SPbtnPath";
            this.SPbtnPath.Size = new System.Drawing.Size(30, 23);
            this.SPbtnPath.TabIndex = 7;
            this.SPbtnPath.Text = " ... ";
            this.SPbtnPath.UseVisualStyleBackColor = true;
            // 
            // btnTestSave
            // 
            this.btnTestSave.Location = new System.Drawing.Point(326, 128);
            this.btnTestSave.Name = "btnTestSave";
            this.btnTestSave.Size = new System.Drawing.Size(69, 26);
            this.btnTestSave.TabIndex = 8;
            this.btnTestSave.Text = "TestSave";
            this.btnTestSave.UseVisualStyleBackColor = true;
            this.btnTestSave.Click += new System.EventHandler(this.btnTestSave_Click);
            // 
            // SaveProjectXMLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 229);
            this.Controls.Add(this.btnTestSave);
            this.Controls.Add(this.SPbtnPath);
            this.Controls.Add(this.SPbtnCancel);
            this.Controls.Add(this.SPbtnOK);
            this.Controls.Add(this.SPtxtBxFileName);
            this.Controls.Add(this.SPtxtBxMistoUlozeni);
            this.Controls.Add(this.SPtxtBxProjectName);
            this.Controls.Add(this.SPlblPath);
            this.Controls.Add(this.SvPrjlblProject);
            this.Name = "SaveProjectXMLForm";
            this.Text = "SaveProjectXMLForm";
            this.Load += new System.EventHandler(this.eventSPLoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button SPbtnPath;
		private System.Windows.Forms.Button SPbtnCancel;
		private System.Windows.Forms.Button SPbtnOK;
		private System.Windows.Forms.TextBox SPtxtBxFileName;
		private System.Windows.Forms.TextBox SPtxtBxMistoUlozeni;
		private System.Windows.Forms.TextBox SPtxtBxProjectName;
		private System.Windows.Forms.Label SPlblPath;
		private System.Windows.Forms.Label SvPrjlblProject;
        private System.Windows.Forms.Button btnTestSave;
    }
}
