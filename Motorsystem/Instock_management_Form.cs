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

namespace Motorsystem
{
	public partial class Instock_management_Form : Form
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

		//宣告此FORM的變數
		int MYSQL_count_row;
		string[] MYSQL_components_name;
		string components_name;
		string currentTime_day;
		string currentTime_month;
		string currentTime_year;
		int total_price;
		int total_quantity;
		string record_number;
		//宣告此FORM的變數

		public Instock_management_Form()
		{
			InitializeComponent();

			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			//dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//將零件名稱放到ListBox中
			string a = "";
			SQLsearchingdata_componentsINlist_name(a);
			//將零件名稱放到ListBox中
		}

		private void Instockmanagement_intoInstockForm_button_Click(object sender, EventArgs e)
		{
			
			//按鈕連動-----------------start
			InStock_Form Instock_1 = new InStock_Form();
			Instock_1.ShowDialog();
			if (Instock_1.DialogResult == DialogResult.OK)  //關掉Client_1視窗 會返回ok值  才可以再開啟其他視窗
			{				
				Application.Run(new InStock_Form());				
			}
			//按鈕連動-----------------start

			//清空listbox
			Instockmanagement_listboxclearn();
			//清空listbox

			//將零件名稱放到ListBox中
			string a = "";
			SQLsearchingdata_componentsINlist_name(a);
			//將零件名稱放到ListBox中
		}
		private void SQLsearchingdata_componentsINlist_name(string sql)
		{
			//計算有幾個零件
			int i = 0;
			//計算有幾個零件

			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL查詢table有幾筆資料-------------------------------------------------------------------------------------------/
			sql = "select COUNT(*) as instock_number from instock_components";  //查詢有幾筆資料
			cmd = new MySqlCommand(sql, dataon);
			MYSQL_count_row = Convert.ToInt32(cmd.ExecuteScalar());
			//MessageBox.Show(MYSQL_count_row);
			cmd.Dispose();
			//MYSQL查詢table有幾筆資料------------------------------------------------------------------------------------------ -/  

			//初始化矩陣  用來裝零件之名稱
			MYSQL_components_name = new string[MYSQL_count_row];
			//初始化矩陣  用來裝零件之名稱

			// MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			sql = "select * from instock_components";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				//MessageBox.Show(reader.GetInt32("id") + reader.GetString("name") /*+ reader.GetString("notolicense")*/);
				MYSQL_components_name[i] = reader.GetString("components_name");
				//Client_regularclient_name_label.Text = reader.GetString("name");
				i++;
			}
			reader.Close();
			reader.Dispose();
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/

			//將資料放置於ListBox中
			for (int j = 0; j < i; j++)
			{
				Instockmanagement_instockcomponents_listBox.Items.Add(MYSQL_components_name[j]);
				//MessageBox.Show(MYSQL_components_name[j]);
			}
			//將資料放置於ListBox中

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/	

		}

		private void Instockmanagement_listboxclearn()
		{
			Instockmanagement_instockcomponents_listBox.Items.Clear();
		}

		private void Instockmanagement_typeinstock_button_Click(object sender, EventArgs e)
		{
			if (Instockmanagement_instockcomponents_listBox.SelectedItem == null)
			{
				MessageBox.Show("選擇零件");
			}
			else 
			{
				//按鈕連動................................................................./
				Instockmanagement_typeinstock_button.Enabled = false;
				Instockmanagement_saveinstock_button.Enabled = true;
				Instockmanagement_manageInstockForm_button.Enabled = false;
				Instockmanagement_componentsquantity_textBox.Enabled = true;
				//按鈕連動................................................................./

				components_name = Instockmanagement_instockcomponents_listBox.SelectedItem.ToString();
				string sql = "SELECT components_id , components_name, components_price , components_quantity FROM instock_components WHERE components_name='" + components_name + "'";
				MYSQLsearching_componentstomodify_componentsname(sql);
			}
		}

		private void Instockmanagement_saveinstock_button_Click(object sender, EventArgs e)
		{
			//定義為現在時間
			System.DateTime currentTime = new System.DateTime(); //定義存儲系統時間的變數
			currentTime = System.DateTime.Now;
			currentTime_day = currentTime.Year + "-" + currentTime.Month + "-" + currentTime.Day;
			currentTime_month = currentTime.Month + "";
			currentTime_year = currentTime.Year + "";
			//定義為現在時間

			total_price = (-1) * Convert.ToInt32(Instockmanagement_componentsprice_label2.Text) * Convert.ToInt32(Instockmanagement_componentsquantity_textBox.Text);
			record_number = "" + currentTime.Year + currentTime.Month + currentTime.Day + currentTime.Hour + currentTime.Minute + currentTime.Second;

			//按鈕連動................................................................./
			Instockmanagement_typeinstock_button.Enabled = true;
			Instockmanagement_saveinstock_button.Enabled = false;
			Instockmanagement_manageInstockForm_button.Enabled = true;
			Instockmanagement_componentsquantity_textBox.Enabled = false;
			//按鈕連動................................................................./

			//MYSQL新增資料-------------------------------------------------------------------------------------------/
			string sql = "INSERT INTO total_amount( total_day , total_month , total_year , total_name , total_motolicense , total_components , total_servicestaff , total_componentsprice , total_totalamount , recordnumber )" +
													 "VALUES('" + currentTime_day + "','" + currentTime_month + "',' " + currentTime_year + "'," +
													 "'" + "零件進貨數量:" + Instockmanagement_componentsquantity_textBox.Text + "','" + Instockmanagement_componentsnumber_label2.Text + "','" + Instockmanagement_componentsname_label2.Text + "'," +
													 "'" + "零件進貨" + "','" + Instockmanagement_componentsprice_label2.Text + "','" + total_price + "','" + record_number + "')";

			SQLADD_componentsadd(sql);
			//MYSQL新增資料-------------------------------------------------------------------------------------------/

			//MYSQL更新資料-------------------------------------------------------------------------------------------/
			sql = "UPDATE instock_components SET components_quantity  ='" + (Convert.ToInt32(Instockmanagement_componentsquantity_textBox.Text) + MYSQLserching_componentsquantity()) + "' " +
				" WHERE components_name ='" + Instockmanagement_componentsname_label2.Text + "'";
			//MYSQL更新資料-------------------------------------------------------------------------------------------/
			MYSQLUPDATE_components_quantity(sql);
			//MessageBox.Show(currentTime.Year  + "-"+ currentTime.Month+"-"+ currentTime.Day);
		}

		private void MYSQLUPDATE_components_quantity(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQLe更新table資料-------------------------------------------------------------------------------------------start/			
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			//MYSQL更新table資料-------------------------------------------------------------------------------------------end/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/

			//按鈕連動................................................................./
			Instockmanagement_componentsnumber_label2.Text = "0";
			Instockmanagement_componentsname_label2.Text = "0";
			Instockmanagement_componentsprice_label2.Text = "0";
			Instockmanagement_componentsquantity_textBox.Text = "0";
			//按鈕連動................................................................./
		}

		//查詢零件庫存數量---------------------------------------------------------------------------------------------------
		private int MYSQLserching_componentsquantity()
		{
			string sql = "SELECT components_quantity FROM instock_components WHERE components_name='" + Instockmanagement_componentsname_label2.Text + "'";
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/


			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			//sql = "select * from client_information";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				total_quantity = reader.GetInt32("components_quantity");				
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			return total_quantity;
		}
		//查詢零件庫存數量---------------------------------------------------------------------------------------------------

		private void MYSQLsearching_componentstomodify_componentsname(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			// MYSQL查詢table資料------------------------------------------------------------------------------------------ -/			
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				Instockmanagement_componentsnumber_label2.Text = reader.GetString("components_id");
				Instockmanagement_componentsname_label2.Text = reader.GetString("components_name");
				Instockmanagement_componentsprice_label2.Text = reader.GetInt32("components_price") + "";
				Instockmanagement_componentsquantity_textBox.Text = reader.GetInt32("components_quantity") + "";
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
		}

		private void SQLADD_componentsadd(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL新增table資料-------------------------------------------------------------------------------------------start/
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			//MYSQL新增table資料-------------------------------------------------------------------------------------------end/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
		}
	}
}
