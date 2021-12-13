using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO; //寫入和讀取資料會用到
using System.Threading;

namespace Motorsystem
{
	public partial class Income_Expenditure_Form : Form
	{
		//MYSQL變數宣告---------------------
		private MySqlConnection dataon;
		private MySqlCommand cmd;
		private MySqlDataReader reader;
		//MYSQL變數宣告---------------------

		//MYSQL連線預設位置與帳號---------------
		private string serverAddress = "localhost";
		private string sqlport = "3306";
		private string databaseName = "motobasedata";
		private string userID = "root";
		private string password = "0911201923";
		//MYSQL連線預設位置與帳號---------------

		//此Form使用變數
		string income_date;
		string income_date_month;
		string income_date_year;
		int count_row;
		int total_amount;
		string income_servicetype;
		string income_servicetype_checked;
		//此Form使用變數

		public Income_Expenditure_Form()
		{
			InitializeComponent();
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			//dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/
		}

		private void Income_datesearching_button_Click(object sender, EventArgs e)
		{
			Income_incomereport_dataGridView.Rows.Clear();
			if (Income_daysearching_radioButton.Checked == false && Income_monthsearching_radioButton.Checked == false && Income_yearsearching_radioButton.Checked == false)
			{
				MessageBox.Show("請選擇報表種類");
			}
			else if (Income_daysearching_radioButton.Checked == true)
			{
				income_date = Income_datesearching_dateTimePicker.Value.Year + "-" + Income_datesearching_dateTimePicker.Value.Month + "-" + Income_datesearching_dateTimePicker.Value.Day;
				string sql = "SELECT total_day , total_name , total_totalamount , total_components , recordnumber FROM total_amount WHERE total_day ='" + income_date + "'";
				SQLsearchingdata_Incomeinformation_date(sql);
			}
			else if (Income_monthsearching_radioButton.Checked == true)
			{
				income_date_year = Income_datesearching_dateTimePicker.Value.Year + "";
				income_date_month = Income_datesearching_dateTimePicker.Value.Month + "";
				string sql = "SELECT total_day , total_name , total_totalamount , total_components , recordnumber FROM total_amount WHERE total_month ='" + income_date_month +
																																	"' AND total_year='" + income_date_year + "'";
				SQLsearchingdata_Incomeinformation_date(sql);
			}
			else if (Income_yearsearching_radioButton.Checked == true)
			{
				income_date_year = Income_datesearching_dateTimePicker.Value.Year + "";
				string sql = "SELECT total_day , total_name , total_totalamount , total_components , recordnumber FROM total_amount WHERE total_year ='" + income_date_year + "'";
				SQLsearchingdata_Incomeinformation_date(sql);
			}
		}

		private string Maintenance_judgefixed()
		{
			if (income_servicetype == "0 ")
			{
				income_servicetype_checked = "保養";
			}
			else if (income_servicetype == "1 ")
			{
				income_servicetype_checked = "維修";
			}
			else if (income_servicetype == "110 ")
			{
				income_servicetype_checked = "事故";
			}
			return income_servicetype_checked;
		}

		private void SQLsearchingdata_Incomeinformation_date(string sql)
		{
			total_amount = 0;
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL查詢資料------------------------------------------------------------------------------------------------/
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				income_servicetype = reader.GetString("total_name");
				if (income_servicetype == "0 " || income_servicetype == "1 " || income_servicetype == "110 ")
				{
					Income_incomereport_dataGridView.Rows.Add(new Object[] { reader.GetString("total_day"), Maintenance_judgefixed(), reader.GetString("total_totalamount"), reader.GetString("total_components"), reader.GetString("recordnumber") });
				}
				else
				{
					Income_incomereport_dataGridView.Rows.Add(new Object[] { reader.GetString("total_day"), reader.GetString("total_name"), reader.GetString("total_totalamount"), reader.GetString("total_components"), reader.GetString("recordnumber") });
				}
				//MessageBox.Show(reader.GetString("servicedate")+"\r\n"+ reader.GetString("reason")+"\r\n"+ reader.GetString("status"));				
			}
			count_row = Income_incomereport_dataGridView.RowCount;
			for (int i = 0; i < count_row; i++) 
			{
				total_amount = total_amount + Convert.ToInt32(Income_incomereport_dataGridView.Rows[i].Cells[2].Value);
			}
			if (total_amount > 0)
			{
				Income_ActualCOST_label2.Text = total_amount + "";
				Income_ActualCOST_label2.ForeColor = Color.Chartreuse;
			}
			else if (total_amount == 0)
			{
				Income_ActualCOST_label2.Text = total_amount + "";
				Income_ActualCOST_label2.ForeColor = Color.Black;
			}
			else if (total_amount < 0)
			{
				Income_ActualCOST_label2.Text = total_amount + "";
				Income_ActualCOST_label2.ForeColor = Color.Red;
			}
			
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL查詢資料------------------------------------------------------------------------------------------------/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/		
		}

	}
}
