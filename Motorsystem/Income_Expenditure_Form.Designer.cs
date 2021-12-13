namespace Motorsystem
{
	partial class Income_Expenditure_Form
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
			this.Income_datesearching_dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.Income_incomereport_dataGridView = new System.Windows.Forms.DataGridView();
			this.Income_daysearching_radioButton = new System.Windows.Forms.RadioButton();
			this.Income_yearsearching_radioButton = new System.Windows.Forms.RadioButton();
			this.Income_monthsearching_radioButton = new System.Windows.Forms.RadioButton();
			this.Income_datesearching_button = new System.Windows.Forms.Button();
			this.date_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cost_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.detail_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.recordnumber_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Income_ActualCOST_label = new System.Windows.Forms.Label();
			this.Income_ActualCOST_label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Income_incomereport_dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// Income_datesearching_dateTimePicker
			// 
			this.Income_datesearching_dateTimePicker.Location = new System.Drawing.Point(235, 39);
			this.Income_datesearching_dateTimePicker.Name = "Income_datesearching_dateTimePicker";
			this.Income_datesearching_dateTimePicker.Size = new System.Drawing.Size(200, 22);
			this.Income_datesearching_dateTimePicker.TabIndex = 0;
			// 
			// Income_incomereport_dataGridView
			// 
			this.Income_incomereport_dataGridView.AllowUserToAddRows = false;
			this.Income_incomereport_dataGridView.AllowUserToDeleteRows = false;
			this.Income_incomereport_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Income_incomereport_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date_Column,
            this.type_Column,
            this.cost_Column,
            this.detail_Column,
            this.recordnumber_Column});
			this.Income_incomereport_dataGridView.Location = new System.Drawing.Point(16, 85);
			this.Income_incomereport_dataGridView.Name = "Income_incomereport_dataGridView";
			this.Income_incomereport_dataGridView.RowHeadersVisible = false;
			this.Income_incomereport_dataGridView.RowTemplate.Height = 24;
			this.Income_incomereport_dataGridView.Size = new System.Drawing.Size(788, 320);
			this.Income_incomereport_dataGridView.TabIndex = 1;
			// 
			// Income_daysearching_radioButton
			// 
			this.Income_daysearching_radioButton.AutoSize = true;
			this.Income_daysearching_radioButton.Location = new System.Drawing.Point(30, 44);
			this.Income_daysearching_radioButton.Name = "Income_daysearching_radioButton";
			this.Income_daysearching_radioButton.Size = new System.Drawing.Size(59, 16);
			this.Income_daysearching_radioButton.TabIndex = 2;
			this.Income_daysearching_radioButton.TabStop = true;
			this.Income_daysearching_radioButton.Text = "日報表";
			this.Income_daysearching_radioButton.UseVisualStyleBackColor = true;
			// 
			// Income_yearsearching_radioButton
			// 
			this.Income_yearsearching_radioButton.AutoSize = true;
			this.Income_yearsearching_radioButton.Location = new System.Drawing.Point(160, 44);
			this.Income_yearsearching_radioButton.Name = "Income_yearsearching_radioButton";
			this.Income_yearsearching_radioButton.Size = new System.Drawing.Size(59, 16);
			this.Income_yearsearching_radioButton.TabIndex = 3;
			this.Income_yearsearching_radioButton.TabStop = true;
			this.Income_yearsearching_radioButton.Text = "年報表";
			this.Income_yearsearching_radioButton.UseVisualStyleBackColor = true;
			// 
			// Income_monthsearching_radioButton
			// 
			this.Income_monthsearching_radioButton.AutoSize = true;
			this.Income_monthsearching_radioButton.Location = new System.Drawing.Point(95, 44);
			this.Income_monthsearching_radioButton.Name = "Income_monthsearching_radioButton";
			this.Income_monthsearching_radioButton.Size = new System.Drawing.Size(59, 16);
			this.Income_monthsearching_radioButton.TabIndex = 4;
			this.Income_monthsearching_radioButton.TabStop = true;
			this.Income_monthsearching_radioButton.Text = "月報表";
			this.Income_monthsearching_radioButton.UseVisualStyleBackColor = true;
			// 
			// Income_datesearching_button
			// 
			this.Income_datesearching_button.Font = new System.Drawing.Font("新細明體", 13F);
			this.Income_datesearching_button.Location = new System.Drawing.Point(458, 25);
			this.Income_datesearching_button.Name = "Income_datesearching_button";
			this.Income_datesearching_button.Size = new System.Drawing.Size(95, 36);
			this.Income_datesearching_button.TabIndex = 5;
			this.Income_datesearching_button.Text = "搜尋";
			this.Income_datesearching_button.UseVisualStyleBackColor = true;
			this.Income_datesearching_button.Click += new System.EventHandler(this.Income_datesearching_button_Click);
			// 
			// date_Column
			// 
			this.date_Column.HeaderText = "日期";
			this.date_Column.Name = "date_Column";
			this.date_Column.ReadOnly = true;
			this.date_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.date_Column.Width = 75;
			// 
			// type_Column
			// 
			this.type_Column.HeaderText = "金額項目";
			this.type_Column.Name = "type_Column";
			this.type_Column.ReadOnly = true;
			this.type_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// cost_Column
			// 
			this.cost_Column.HeaderText = "金額";
			this.cost_Column.Name = "cost_Column";
			this.cost_Column.ReadOnly = true;
			this.cost_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// detail_Column
			// 
			this.detail_Column.HeaderText = "明細";
			this.detail_Column.Name = "detail_Column";
			this.detail_Column.ReadOnly = true;
			this.detail_Column.Width = 350;
			// 
			// recordnumber_Column
			// 
			this.recordnumber_Column.HeaderText = "單號";
			this.recordnumber_Column.Name = "recordnumber_Column";
			this.recordnumber_Column.ReadOnly = true;
			this.recordnumber_Column.Width = 150;
			// 
			// Income_ActualCOST_label
			// 
			this.Income_ActualCOST_label.AutoSize = true;
			this.Income_ActualCOST_label.BackColor = System.Drawing.Color.LightSalmon;
			this.Income_ActualCOST_label.Font = new System.Drawing.Font("新細明體", 12F);
			this.Income_ActualCOST_label.Location = new System.Drawing.Point(127, 417);
			this.Income_ActualCOST_label.Name = "Income_ActualCOST_label";
			this.Income_ActualCOST_label.Size = new System.Drawing.Size(60, 16);
			this.Income_ActualCOST_label.TabIndex = 30;
			this.Income_ActualCOST_label.Text = "總收支:";
			// 
			// Income_ActualCOST_label2
			// 
			this.Income_ActualCOST_label2.AutoSize = true;
			this.Income_ActualCOST_label2.Font = new System.Drawing.Font("新細明體", 12F);
			this.Income_ActualCOST_label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Income_ActualCOST_label2.Location = new System.Drawing.Point(195, 417);
			this.Income_ActualCOST_label2.Name = "Income_ActualCOST_label2";
			this.Income_ActualCOST_label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Income_ActualCOST_label2.Size = new System.Drawing.Size(16, 16);
			this.Income_ActualCOST_label2.TabIndex = 31;
			this.Income_ActualCOST_label2.Text = "0";
			// 
			// Income_Expenditure_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(816, 455);
			this.Controls.Add(this.Income_ActualCOST_label2);
			this.Controls.Add(this.Income_ActualCOST_label);
			this.Controls.Add(this.Income_datesearching_button);
			this.Controls.Add(this.Income_monthsearching_radioButton);
			this.Controls.Add(this.Income_yearsearching_radioButton);
			this.Controls.Add(this.Income_daysearching_radioButton);
			this.Controls.Add(this.Income_incomereport_dataGridView);
			this.Controls.Add(this.Income_datesearching_dateTimePicker);
			this.MaximizeBox = false;
			this.Name = "Income_Expenditure_Form";
			this.Text = "收支計算";
			((System.ComponentModel.ISupportInitialize)(this.Income_incomereport_dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker Income_datesearching_dateTimePicker;
		private System.Windows.Forms.DataGridView Income_incomereport_dataGridView;
		private System.Windows.Forms.RadioButton Income_daysearching_radioButton;
		private System.Windows.Forms.RadioButton Income_yearsearching_radioButton;
		private System.Windows.Forms.RadioButton Income_monthsearching_radioButton;
		private System.Windows.Forms.Button Income_datesearching_button;
		private System.Windows.Forms.DataGridViewTextBoxColumn date_Column;
		private System.Windows.Forms.DataGridViewTextBoxColumn type_Column;
		private System.Windows.Forms.DataGridViewTextBoxColumn cost_Column;
		private System.Windows.Forms.DataGridViewTextBoxColumn detail_Column;
		private System.Windows.Forms.DataGridViewTextBoxColumn recordnumber_Column;
		private System.Windows.Forms.Label Income_ActualCOST_label;
		private System.Windows.Forms.Label Income_ActualCOST_label2;
	}
}