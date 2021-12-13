using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Motorsystem
{
	public partial class InStock_Form : Form
	{
		//MYSQL連線預設位置與帳號---------------
		private string serverAddress = "localhost";
		private string sqlport = "3306";
		private string databaseName = "motobasedata";
		private string userID = "root";
		private string password = "0911201923";
		//MYSQL連線預設位置與帳號---------------

		//MYSQL變數宣告---------------------
		private MySqlConnection dataon;
		private MySqlCommand cmd;
		private MySqlDataReader reader;
		//MYSQL變數宣告---------------------
		public InStock_Form()
		{
			InitializeComponent();
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			//dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/
		}

		private void InStock_increase_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			InStock_Save_button.Enabled = true;
			InStock_increase_button.Enabled = false;
			InStock_increasenumber_textBox.Enabled = true;
			InStock_increasename_textBox.Enabled = true;
			InStock_increaseunitprice_textBox.Enabled = true;
			InStock_increasevalue_textBox.Enabled = true;
			//按鈕連動-----------------end

			//清空欄位
			InStock_increasenumber_textBox.Text = "";
			InStock_increasename_textBox.Text = "";
			InStock_increaseunitprice_textBox.Text = "";
			InStock_increasevalue_textBox.Text = "";
		}

		private void InStock_Save_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			InStock_Save_button.Enabled = false;
			InStock_increase_button.Enabled = true;
			InStock_increasenumber_textBox.Enabled = false;
			InStock_increasename_textBox.Enabled = false;
			InStock_increaseunitprice_textBox.Enabled = false;
			InStock_increasevalue_textBox.Enabled = false;
			//按鈕連動-----------------end

			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			if (InStock_increasenumber_textBox.Text == "")
			{
				MessageBox.Show("零件編號不可空白");
			}
			else if (InStock_increasename_textBox.Text == "")
			{
				MessageBox.Show("零件名稱不可空白");
			}
			else if (InStock_increaseunitprice_textBox.Text == "")
			{
				MessageBox.Show("零件單價不可空白");
			}
			else if (InStock_increasevalue_textBox.Text == "")
			{
				MessageBox.Show("零件數量不可空白");
			}
			else
			{
				//MYSQL新增table資料-------------------------------------------------------------------------------------------start/
				string ADDnew = "INSERT INTO instock_components( components_id , components_name , components_price , components_quantity )" +
														 "VALUES('" + InStock_increasenumber_textBox.Text + "','" + InStock_increasename_textBox.Text + "',' " + InStock_increaseunitprice_textBox.Text + "'," +
														 "'" + InStock_increasevalue_textBox.Text + "')";
				cmd = new MySqlCommand(ADDnew, dataon);
				cmd.Connection = dataon;
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				//MYSQL新增table資料-------------------------------------------------------------------------------------------end/

				//MYSQL關閉連線-------------------------------------------------------------------------------------------/
				dataon.Close();
				dataon.Dispose();
				//MYSQL關閉連線-------------------------------------------------------------------------------------------/
				MessageBox.Show("儲存成功");
			}
			
		}

		private void InStock_showall_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			InStock_showall_button.Enabled = false;
			InStock_searching_button.Enabled = true;
			InStock_searching_textBox.Enabled = true;
			InStock_increase_button.Enabled = true;
			//按鈕連動-----------------end
		}

		private void InStock_searching_button_Click(object sender, EventArgs e)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//用於查詢之變數
			string sql_where;

			if (InStock_componentsid_radioButton.Checked == false && InStock_componentsname_radioButton.Checked == false)
			{
				MessageBox.Show("請選擇用編號或是名稱進行查詢");
			}
			else if (InStock_searching_textBox.Text == "")
			{
				MessageBox.Show("請輸入要查詢之關鍵字");
			}
			else
			{
				if(InStock_componentsid_radioButton.Checked==true)
				{
					//查詢資料並將資料顯示於對應Text內
					sql_where= "SELECT components_id, components_name, components_price, components_quantity FROM instock_components WHERE components_id='" + InStock_searching_textBox.Text + "'";
					SQLsearchingdata_components_id(sql_where);
				}
				else if(InStock_componentsname_radioButton.Checked==true)
				{
					//查詢資料並將資料顯示於對應Text內
					sql_where = "SELECT components_id, components_name, components_price, components_quantity FROM instock_components WHERE components_name='" + InStock_searching_textBox.Text + "'";
					SQLsearchingdata_components_name(sql_where);
				}
				InStock_modify_button.Enabled = true;
			}
		}

		private void InStock_modify_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			InStock_instockSAVE_button.Enabled = true;
			InStock_modify_button.Enabled = false;
			InStock_increase_button.Enabled = false;

			InStock_searching_textBox.Enabled = false;
			InStock_componentsid_radioButton.Enabled = false;
			InStock_componentsname_radioButton.Enabled = false;
			InStock_instockprice_textBox.Enabled = true;
			InStock_instockquantity_textBox.Enabled = true;
			//按鈕連動-----------------end

			if(InStock_componentsid_radioButton.Checked==true)
			{
				InStock_instockid_textBox.Enabled = false;
				InStock_instockname_textBox.Enabled = true;
			}
			else if(InStock_componentsname_radioButton.Checked==true)
			{
				InStock_instockname_textBox.Enabled = false;
				InStock_instockid_textBox.Enabled = true;
			}
		}

		private void SQLsearchingdata_components_id(string sql)
		{
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			//sql = "select * from client_information";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				InStock_instockid_textBox.Text = (reader.GetString("components_id"));
				InStock_instockname_textBox.Text = (reader.GetString("components_name"));
				InStock_instockprice_textBox.Text = (reader.GetString("components_price"));
				InStock_instockquantity_textBox.Text = (reader.GetString("components_quantity"));				
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/			
		}

		private void SQLsearchingdata_components_name(string sql)
		{
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			//sql = "select * from client_information";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				InStock_instockid_textBox.Text = (reader.GetString("components_id"));
				InStock_instockname_textBox.Text = (reader.GetString("components_name"));
				InStock_instockprice_textBox.Text = (reader.GetString("components_price"));
				InStock_instockquantity_textBox.Text = (reader.GetString("components_quantity"));
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/			
		}

		private void InStock_instockSAVE_button_Click(object sender, EventArgs e)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			if(InStock_componentsid_radioButton.Checked==true)
			{
				//MYSQL更新table資料-------------------------------------------------------------------------------------------/
				string sql = "UPDATE instock_components SET components_name  ='" + InStock_instockname_textBox.Text + "', " +
					" components_price ='" + InStock_instockprice_textBox.Text + "'," +
					" components_quantity ='" + InStock_instockquantity_textBox.Text + "'" +
					" WHERE components_id ='" + InStock_instockid_textBox.Text + "'";
				SQLUPDATE_components_id(sql);
				//MYSQL更新table資料-------------------------------------------------------------------------------------------/
			}
			else if(InStock_componentsname_radioButton.Checked==true)
			{
				//MYSQL更新table資料-------------------------------------------------------------------------------------------/
				string sql = "UPDATE instock_components SET components_id  ='" + InStock_instockid_textBox.Text + "', " +
					" components_price ='" + InStock_instockprice_textBox.Text + "'," +
				    " components_quantity ='" + InStock_instockquantity_textBox.Text + "'" +
				    " WHERE components_name ='" + InStock_instockname_textBox.Text + "'";
				SQLUPDATE_components_name(sql);
				//MYSQL更新table資料-------------------------------------------------------------------------------------------/
			}

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/

			//按鈕連動-----------------start
			InStock_instockSAVE_button.Enabled = false;
			InStock_modify_button.Enabled = true;
			InStock_increase_button.Enabled = true;

			InStock_searching_textBox.Enabled = true;
			InStock_componentsid_radioButton.Enabled = true;
			InStock_componentsname_radioButton.Enabled = true;
			InStock_instockid_textBox.Enabled = false;
			InStock_instockname_textBox.Enabled = false;
			InStock_instockprice_textBox.Enabled = false;
			InStock_instockquantity_textBox.Enabled = false;
			//按鈕連動-----------------end
		}

		private void SQLUPDATE_components_id(string sql)
		{
			//MYSQL更新table資料-------------------------------------------------------------------------------------------/			
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			//MYSQL更新table資料-------------------------------------------------------------------------------------------/
		}

		private void SQLUPDATE_components_name(string sql)
		{
			//MYSQL更新table資料-------------------------------------------------------------------------------------------/
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			//MYSQL更新table資料-------------------------------------------------------------------------------------------/
		}
	}
}
