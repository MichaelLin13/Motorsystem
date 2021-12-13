namespace Motorsystem
{
	partial class Instock_management_Form
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
			this.Instockmanagement_manageInstockForm_button = new System.Windows.Forms.Button();
			this.Instockmanagement_instockcomponents_listBox = new System.Windows.Forms.ListBox();
			this.Instockmanagement_instockcomponents_label = new System.Windows.Forms.Label();
			this.Instockmanagement_typeinstock_button = new System.Windows.Forms.Button();
			this.Instockmanagement_promptwritein_label = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsquantity_label = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsprice_label = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsname_label = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsnumber_label = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsnumber_label2 = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsname_label2 = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsprice_label2 = new System.Windows.Forms.Label();
			this.Instockmanagement_componentsquantity_textBox = new System.Windows.Forms.TextBox();
			this.Instockmanagement_saveinstock_button = new System.Windows.Forms.Button();
			this.Instockmanagement_promptunwritein_label = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Instockmanagement_manageInstockForm_button
			// 
			this.Instockmanagement_manageInstockForm_button.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_manageInstockForm_button.Location = new System.Drawing.Point(660, 170);
			this.Instockmanagement_manageInstockForm_button.Name = "Instockmanagement_manageInstockForm_button";
			this.Instockmanagement_manageInstockForm_button.Size = new System.Drawing.Size(128, 81);
			this.Instockmanagement_manageInstockForm_button.TabIndex = 0;
			this.Instockmanagement_manageInstockForm_button.Text = "零件管理";
			this.Instockmanagement_manageInstockForm_button.UseVisualStyleBackColor = true;
			this.Instockmanagement_manageInstockForm_button.Click += new System.EventHandler(this.Instockmanagement_intoInstockForm_button_Click);
			// 
			// Instockmanagement_instockcomponents_listBox
			// 
			this.Instockmanagement_instockcomponents_listBox.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_instockcomponents_listBox.FormattingEnabled = true;
			this.Instockmanagement_instockcomponents_listBox.ItemHeight = 20;
			this.Instockmanagement_instockcomponents_listBox.Location = new System.Drawing.Point(25, 62);
			this.Instockmanagement_instockcomponents_listBox.Name = "Instockmanagement_instockcomponents_listBox";
			this.Instockmanagement_instockcomponents_listBox.Size = new System.Drawing.Size(262, 364);
			this.Instockmanagement_instockcomponents_listBox.TabIndex = 1;
			// 
			// Instockmanagement_instockcomponents_label
			// 
			this.Instockmanagement_instockcomponents_label.AutoSize = true;
			this.Instockmanagement_instockcomponents_label.Font = new System.Drawing.Font("新細明體", 30F);
			this.Instockmanagement_instockcomponents_label.Location = new System.Drawing.Point(18, 19);
			this.Instockmanagement_instockcomponents_label.Name = "Instockmanagement_instockcomponents_label";
			this.Instockmanagement_instockcomponents_label.Size = new System.Drawing.Size(187, 40);
			this.Instockmanagement_instockcomponents_label.TabIndex = 2;
			this.Instockmanagement_instockcomponents_label.Text = "庫存零件:";
			// 
			// Instockmanagement_typeinstock_button
			// 
			this.Instockmanagement_typeinstock_button.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_typeinstock_button.Location = new System.Drawing.Point(302, 85);
			this.Instockmanagement_typeinstock_button.Name = "Instockmanagement_typeinstock_button";
			this.Instockmanagement_typeinstock_button.Size = new System.Drawing.Size(190, 63);
			this.Instockmanagement_typeinstock_button.TabIndex = 3;
			this.Instockmanagement_typeinstock_button.Text = "進貨量輸入";
			this.Instockmanagement_typeinstock_button.UseVisualStyleBackColor = true;
			this.Instockmanagement_typeinstock_button.Click += new System.EventHandler(this.Instockmanagement_typeinstock_button_Click);
			// 
			// Instockmanagement_promptwritein_label
			// 
			this.Instockmanagement_promptwritein_label.AutoSize = true;
			this.Instockmanagement_promptwritein_label.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_promptwritein_label.Location = new System.Drawing.Point(298, 62);
			this.Instockmanagement_promptwritein_label.Name = "Instockmanagement_promptwritein_label";
			this.Instockmanagement_promptwritein_label.Size = new System.Drawing.Size(281, 20);
			this.Instockmanagement_promptwritein_label.TabIndex = 28;
			this.Instockmanagement_promptwritein_label.Text = "管理現有零件數量(會計入支出)";
			// 
			// Instockmanagement_componentsquantity_label
			// 
			this.Instockmanagement_componentsquantity_label.AutoSize = true;
			this.Instockmanagement_componentsquantity_label.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsquantity_label.Location = new System.Drawing.Point(298, 269);
			this.Instockmanagement_componentsquantity_label.Name = "Instockmanagement_componentsquantity_label";
			this.Instockmanagement_componentsquantity_label.Size = new System.Drawing.Size(94, 20);
			this.Instockmanagement_componentsquantity_label.TabIndex = 32;
			this.Instockmanagement_componentsquantity_label.Text = "零件數量:";
			// 
			// Instockmanagement_componentsprice_label
			// 
			this.Instockmanagement_componentsprice_label.AutoSize = true;
			this.Instockmanagement_componentsprice_label.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsprice_label.Location = new System.Drawing.Point(298, 234);
			this.Instockmanagement_componentsprice_label.Name = "Instockmanagement_componentsprice_label";
			this.Instockmanagement_componentsprice_label.Size = new System.Drawing.Size(94, 20);
			this.Instockmanagement_componentsprice_label.TabIndex = 31;
			this.Instockmanagement_componentsprice_label.Text = "零件單價:";
			// 
			// Instockmanagement_componentsname_label
			// 
			this.Instockmanagement_componentsname_label.AutoSize = true;
			this.Instockmanagement_componentsname_label.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsname_label.Location = new System.Drawing.Point(298, 200);
			this.Instockmanagement_componentsname_label.Name = "Instockmanagement_componentsname_label";
			this.Instockmanagement_componentsname_label.Size = new System.Drawing.Size(94, 20);
			this.Instockmanagement_componentsname_label.TabIndex = 30;
			this.Instockmanagement_componentsname_label.Text = "零件名稱:";
			// 
			// Instockmanagement_componentsnumber_label
			// 
			this.Instockmanagement_componentsnumber_label.AutoSize = true;
			this.Instockmanagement_componentsnumber_label.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsnumber_label.Location = new System.Drawing.Point(298, 166);
			this.Instockmanagement_componentsnumber_label.Name = "Instockmanagement_componentsnumber_label";
			this.Instockmanagement_componentsnumber_label.Size = new System.Drawing.Size(94, 20);
			this.Instockmanagement_componentsnumber_label.TabIndex = 29;
			this.Instockmanagement_componentsnumber_label.Text = "零件編號:";
			// 
			// Instockmanagement_componentsnumber_label2
			// 
			this.Instockmanagement_componentsnumber_label2.AutoSize = true;
			this.Instockmanagement_componentsnumber_label2.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsnumber_label2.Location = new System.Drawing.Point(398, 166);
			this.Instockmanagement_componentsnumber_label2.Name = "Instockmanagement_componentsnumber_label2";
			this.Instockmanagement_componentsnumber_label2.Size = new System.Drawing.Size(18, 20);
			this.Instockmanagement_componentsnumber_label2.TabIndex = 33;
			this.Instockmanagement_componentsnumber_label2.Text = "0";
			// 
			// Instockmanagement_componentsname_label2
			// 
			this.Instockmanagement_componentsname_label2.AutoSize = true;
			this.Instockmanagement_componentsname_label2.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsname_label2.Location = new System.Drawing.Point(398, 200);
			this.Instockmanagement_componentsname_label2.Name = "Instockmanagement_componentsname_label2";
			this.Instockmanagement_componentsname_label2.Size = new System.Drawing.Size(18, 20);
			this.Instockmanagement_componentsname_label2.TabIndex = 34;
			this.Instockmanagement_componentsname_label2.Text = "0";
			// 
			// Instockmanagement_componentsprice_label2
			// 
			this.Instockmanagement_componentsprice_label2.AutoSize = true;
			this.Instockmanagement_componentsprice_label2.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_componentsprice_label2.Location = new System.Drawing.Point(398, 234);
			this.Instockmanagement_componentsprice_label2.Name = "Instockmanagement_componentsprice_label2";
			this.Instockmanagement_componentsprice_label2.Size = new System.Drawing.Size(18, 20);
			this.Instockmanagement_componentsprice_label2.TabIndex = 35;
			this.Instockmanagement_componentsprice_label2.Text = "0";
			// 
			// Instockmanagement_componentsquantity_textBox
			// 
			this.Instockmanagement_componentsquantity_textBox.Enabled = false;
			this.Instockmanagement_componentsquantity_textBox.Location = new System.Drawing.Point(398, 269);
			this.Instockmanagement_componentsquantity_textBox.Name = "Instockmanagement_componentsquantity_textBox";
			this.Instockmanagement_componentsquantity_textBox.Size = new System.Drawing.Size(94, 22);
			this.Instockmanagement_componentsquantity_textBox.TabIndex = 36;
			// 
			// Instockmanagement_saveinstock_button
			// 
			this.Instockmanagement_saveinstock_button.Enabled = false;
			this.Instockmanagement_saveinstock_button.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_saveinstock_button.Location = new System.Drawing.Point(302, 297);
			this.Instockmanagement_saveinstock_button.Name = "Instockmanagement_saveinstock_button";
			this.Instockmanagement_saveinstock_button.Size = new System.Drawing.Size(190, 63);
			this.Instockmanagement_saveinstock_button.TabIndex = 37;
			this.Instockmanagement_saveinstock_button.Text = "進貨量儲存";
			this.Instockmanagement_saveinstock_button.UseVisualStyleBackColor = true;
			this.Instockmanagement_saveinstock_button.Click += new System.EventHandler(this.Instockmanagement_saveinstock_button_Click);
			// 
			// Instockmanagement_promptunwritein_label
			// 
			this.Instockmanagement_promptunwritein_label.AutoSize = true;
			this.Instockmanagement_promptunwritein_label.Font = new System.Drawing.Font("新細明體", 15F);
			this.Instockmanagement_promptunwritein_label.Location = new System.Drawing.Point(598, 142);
			this.Instockmanagement_promptunwritein_label.Name = "Instockmanagement_promptunwritein_label";
			this.Instockmanagement_promptunwritein_label.Size = new System.Drawing.Size(201, 20);
			this.Instockmanagement_promptunwritein_label.TabIndex = 38;
			this.Instockmanagement_promptunwritein_label.Text = "新增零件(不計入支出)";
			// 
			// Instock_management_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(800, 443);
			this.Controls.Add(this.Instockmanagement_promptunwritein_label);
			this.Controls.Add(this.Instockmanagement_saveinstock_button);
			this.Controls.Add(this.Instockmanagement_componentsquantity_textBox);
			this.Controls.Add(this.Instockmanagement_componentsprice_label2);
			this.Controls.Add(this.Instockmanagement_componentsname_label2);
			this.Controls.Add(this.Instockmanagement_componentsnumber_label2);
			this.Controls.Add(this.Instockmanagement_componentsquantity_label);
			this.Controls.Add(this.Instockmanagement_componentsprice_label);
			this.Controls.Add(this.Instockmanagement_componentsname_label);
			this.Controls.Add(this.Instockmanagement_componentsnumber_label);
			this.Controls.Add(this.Instockmanagement_promptwritein_label);
			this.Controls.Add(this.Instockmanagement_typeinstock_button);
			this.Controls.Add(this.Instockmanagement_instockcomponents_label);
			this.Controls.Add(this.Instockmanagement_instockcomponents_listBox);
			this.Controls.Add(this.Instockmanagement_manageInstockForm_button);
			this.MaximizeBox = false;
			this.Name = "Instock_management_Form";
			this.Text = "庫存管理";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Instockmanagement_manageInstockForm_button;
		private System.Windows.Forms.ListBox Instockmanagement_instockcomponents_listBox;
		private System.Windows.Forms.Label Instockmanagement_instockcomponents_label;
		private System.Windows.Forms.Button Instockmanagement_typeinstock_button;
		private System.Windows.Forms.Label Instockmanagement_promptwritein_label;
		private System.Windows.Forms.Label Instockmanagement_componentsquantity_label;
		private System.Windows.Forms.Label Instockmanagement_componentsprice_label;
		private System.Windows.Forms.Label Instockmanagement_componentsname_label;
		private System.Windows.Forms.Label Instockmanagement_componentsnumber_label;
		private System.Windows.Forms.Label Instockmanagement_componentsnumber_label2;
		private System.Windows.Forms.Label Instockmanagement_componentsname_label2;
		private System.Windows.Forms.Label Instockmanagement_componentsprice_label2;
		private System.Windows.Forms.TextBox Instockmanagement_componentsquantity_textBox;
		private System.Windows.Forms.Button Instockmanagement_saveinstock_button;
		private System.Windows.Forms.Label Instockmanagement_promptunwritein_label;
	}
}