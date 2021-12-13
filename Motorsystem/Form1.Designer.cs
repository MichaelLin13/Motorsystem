namespace Motorsystem
{
	partial class MotorForm_main
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.moto_client_button = new System.Windows.Forms.Button();
			this.moto_Instock_button = new System.Windows.Forms.Button();
			this.moto_Income_Expenditure_button = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// moto_client_button
			// 
			this.moto_client_button.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.moto_client_button.Font = new System.Drawing.Font("新細明體", 20F);
			this.moto_client_button.Location = new System.Drawing.Point(40, 192);
			this.moto_client_button.Name = "moto_client_button";
			this.moto_client_button.Size = new System.Drawing.Size(141, 66);
			this.moto_client_button.TabIndex = 0;
			this.moto_client_button.Text = "客戶管理";
			this.moto_client_button.UseVisualStyleBackColor = false;
			this.moto_client_button.Click += new System.EventHandler(this.moto_client_button_Click);
			// 
			// moto_Instock_button
			// 
			this.moto_Instock_button.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.moto_Instock_button.Font = new System.Drawing.Font("新細明體", 20F);
			this.moto_Instock_button.Location = new System.Drawing.Point(219, 192);
			this.moto_Instock_button.Name = "moto_Instock_button";
			this.moto_Instock_button.Size = new System.Drawing.Size(141, 66);
			this.moto_Instock_button.TabIndex = 1;
			this.moto_Instock_button.Text = "庫存管理";
			this.moto_Instock_button.UseVisualStyleBackColor = false;
			this.moto_Instock_button.Click += new System.EventHandler(this.moto_Instock_button_Click);
			// 
			// moto_Income_Expenditure_button
			// 
			this.moto_Income_Expenditure_button.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.moto_Income_Expenditure_button.Font = new System.Drawing.Font("新細明體", 20F);
			this.moto_Income_Expenditure_button.Location = new System.Drawing.Point(394, 192);
			this.moto_Income_Expenditure_button.Name = "moto_Income_Expenditure_button";
			this.moto_Income_Expenditure_button.Size = new System.Drawing.Size(141, 66);
			this.moto_Income_Expenditure_button.TabIndex = 2;
			this.moto_Income_Expenditure_button.Text = "收支計算";
			this.moto_Income_Expenditure_button.UseVisualStyleBackColor = false;
			this.moto_Income_Expenditure_button.Click += new System.EventHandler(this.moto_Income_Expenditure_button_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Motorsystem.Properties.Resources.Motopic;
			this.pictureBox1.Location = new System.Drawing.Point(160, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(254, 182);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// MotorForm_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(571, 287);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.moto_Income_Expenditure_button);
			this.Controls.Add(this.moto_Instock_button);
			this.Controls.Add(this.moto_client_button);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "MotorForm_main";
			this.Text = "主畫面";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button moto_client_button;
		private System.Windows.Forms.Button moto_Instock_button;
		private System.Windows.Forms.Button moto_Income_Expenditure_button;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

