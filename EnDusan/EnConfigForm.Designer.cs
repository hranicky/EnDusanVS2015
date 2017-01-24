/*
 * Created by SharpDevelop.
 * User: lchmela
 * Date: 11/17/2015
 * Time: 4:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EnDusan
{
	partial class EnConfigForm
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
			this.EnCnfbtnOK = new System.Windows.Forms.Button();
			this.EnCnfbtnCancel = new System.Windows.Forms.Button();
			this.EnCnfDGVConfig = new System.Windows.Forms.DataGridView();
			this.EnCnfTxtBoxPopis = new System.Windows.Forms.TextBox();
			this.EnCNFtxtBxSaveXML = new System.Windows.Forms.TextBox();
			this.btnReadRunCNF = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.EnCnfDGVConfig)).BeginInit();
			this.SuspendLayout();
			// 
			// EnCnfbtnOK
			// 
			this.EnCnfbtnOK.Location = new System.Drawing.Point(575, 369);
			this.EnCnfbtnOK.Name = "EnCnfbtnOK";
			this.EnCnfbtnOK.Size = new System.Drawing.Size(75, 23);
			this.EnCnfbtnOK.TabIndex = 0;
			this.EnCnfbtnOK.Text = "OK";
			this.EnCnfbtnOK.UseVisualStyleBackColor = true;
			this.EnCnfbtnOK.Click += new System.EventHandler(this.eventBtnOKClick);
			// 
			// EnCnfbtnCancel
			// 
			this.EnCnfbtnCancel.Location = new System.Drawing.Point(677, 369);
			this.EnCnfbtnCancel.Name = "EnCnfbtnCancel";
			this.EnCnfbtnCancel.Size = new System.Drawing.Size(75, 23);
			this.EnCnfbtnCancel.TabIndex = 1;
			this.EnCnfbtnCancel.Text = "Cancel";
			this.EnCnfbtnCancel.UseVisualStyleBackColor = true;
			this.EnCnfbtnCancel.Click += new System.EventHandler(this.eventBtnCancelClick);
			// 
			// EnCnfDGVConfig
			// 
			this.EnCnfDGVConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.EnCnfDGVConfig.Location = new System.Drawing.Point(22, 55);
			this.EnCnfDGVConfig.Name = "EnCnfDGVConfig";
			this.EnCnfDGVConfig.Size = new System.Drawing.Size(661, 235);
			this.EnCnfDGVConfig.TabIndex = 2;
			this.EnCnfDGVConfig.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.eventRowAdd);
			// 
			// EnCnfTxtBoxPopis
			// 
			this.EnCnfTxtBoxPopis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EnCnfTxtBoxPopis.Location = new System.Drawing.Point(22, 12);
			this.EnCnfTxtBoxPopis.Name = "EnCnfTxtBoxPopis";
			this.EnCnfTxtBoxPopis.ReadOnly = true;
			this.EnCnfTxtBoxPopis.Size = new System.Drawing.Size(661, 29);
			this.EnCnfTxtBoxPopis.TabIndex = 3;
			this.EnCnfTxtBoxPopis.Text = "Zakladni konfiguracni polozky systemu EnProjekt";
			// 
			// EnCNFtxtBxSaveXML
			// 
			this.EnCNFtxtBxSaveXML.Location = new System.Drawing.Point(22, 309);
			this.EnCNFtxtBxSaveXML.Name = "EnCNFtxtBxSaveXML";
			this.EnCNFtxtBxSaveXML.ReadOnly = true;
			this.EnCNFtxtBxSaveXML.Size = new System.Drawing.Size(661, 20);
			this.EnCNFtxtBxSaveXML.TabIndex = 0;
			this.EnCNFtxtBxSaveXML.Visible = false;
			// 
			// btnReadRunCNF
			// 
			this.btnReadRunCNF.Location = new System.Drawing.Point(473, 335);
			this.btnReadRunCNF.Name = "btnReadRunCNF";
			this.btnReadRunCNF.Size = new System.Drawing.Size(97, 23);
			this.btnReadRunCNF.TabIndex = 4;
			this.btnReadRunCNF.Text = "ReadRunCNF";
			this.btnReadRunCNF.UseVisualStyleBackColor = true;
			this.btnReadRunCNF.Click += new System.EventHandler(this.eventReadRunCNF);
			// 
			// EnConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 405);
			this.Controls.Add(this.btnReadRunCNF);
			this.Controls.Add(this.EnCNFtxtBxSaveXML);
			this.Controls.Add(this.EnCnfTxtBoxPopis);
			this.Controls.Add(this.EnCnfDGVConfig);
			this.Controls.Add(this.EnCnfbtnCancel);
			this.Controls.Add(this.EnCnfbtnOK);
			this.Name = "EnConfigForm";
			this.Text = "ConfigForm";
			this.Load += new System.EventHandler(this.eventLoadForm);
			this.Shown += new System.EventHandler(this.eventFormShown);
			((System.ComponentModel.ISupportInitialize)(this.EnCnfDGVConfig)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnReadRunCNF;
		private System.Windows.Forms.TextBox EnCNFtxtBxSaveXML;
		private System.Windows.Forms.TextBox EnCnfTxtBoxPopis;
		private System.Windows.Forms.DataGridView EnCnfDGVConfig;
		private System.Windows.Forms.Button EnCnfbtnCancel;
		private System.Windows.Forms.Button EnCnfbtnOK;
	}
}
