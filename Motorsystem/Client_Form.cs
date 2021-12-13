using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //寫入和讀取資料會用到
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Motorsystem
{
	public partial class Client_Form : Form
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

		//使用變數--------------------------
		string putintext;
		//使用變數--------------------------
		MotorForm_main motoform = new MotorForm_main();
		public Client_Form()
		{
			InitializeComponent();
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			//dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/
		}


		private void Client_regularclient_Modify_button_Click(object sender, EventArgs e)
		{
			if (Client_regularclient_name_textBox.Text == "")
			{
				MessageBox.Show("請輸入要查詢客戶的手機或車牌");
			}
			else
			{
				//按鈕連動-----------------start
				Client_regularclient_Save_button.Enabled = true;
				Client_regularclient_Modify_button.Enabled = false;
				Client_regularclient_searching_button.Enabled = false;
				Client_regularclient_fixrecord_button.Enabled = false;

				Client_regularclient_name_textBox.Enabled = true;
				Client_regularclient_telephone_textBox.Enabled = true;
				Client_regularclient_cellphone_textBox.Enabled = true;
				Client_regularclient_email_textBox.Enabled = true;
				Client_regularclient_personID_textBox.Enabled = true;
				Client_regularclient_address_textBox.Enabled = true;
				Client_regularclient_motolicense_textBox.Enabled = true;
				Client_regularclient_motocompany_comboBox.Enabled = true;
				Client_regularclient_mototype_comboBox.Enabled = true;
				Client_regularclient_motoID_textBox.Enabled = true;
				Client_regularclient_motocolor_textBox.Enabled = true;
				Client_regularclient_PS_textBox.Enabled = true;

				Client_regularclient_phonesearch_radioButton.Enabled = false;
				Client_regularclient_motolicensesearch_radioButton.Enabled = false;
				//按鈕連動-----------------end
			}



		}

		private void Client_regularclient_Save_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			Client_regularclient_Save_button.Enabled = false;
			Client_regularclient_Modify_button.Enabled = true;
			Client_regularclient_searching_button.Enabled = true;
			Client_regularclient_fixrecord_button.Enabled = true;

			Client_regularclient_phonesearch_radioButton.Enabled = true;
			Client_regularclient_motolicensesearch_radioButton.Enabled = true;
			//按鈕連動-----------------end

			if (Client_regularclient_name_textBox.Text == "")
			{
				MessageBox.Show("客戶名稱不能是空白");
			}
			else if (Client_regularclient_cellphone_textBox.Text == "")
			{
				MessageBox.Show("行動電話不能是空白");
			}
			else if (Client_regularclient_motolicense_textBox.Text == "")
			{
				MessageBox.Show("機車車牌不能是空白");
			}
			else
			{
				//MYSQL連線-------------------------------------------------------------------------------------------/
				//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
				//dataon = new MySqlConnection(connectMYSQL);
				dataon.Open();
				//MYSQL連線-------------------------------------------------------------------------------------------/

				//MYSQL更新table資料-------------------------------------------------------------------------------------------/
				string sql = "UPDATE client_information SET name  ='" + Client_regularclient_name_textBox.Text + "', " +
					" telephone ='" + Client_regularclient_telephone_textBox.Text + "'," +
					" cellphone ='" + Client_regularclient_cellphone_textBox.Text + "'," +
					" email ='" + Client_regularclient_email_textBox.Text + "'," +
					" personalID ='" + Client_regularclient_personID_textBox.Text + "'," +
					" address ='" + Client_regularclient_address_textBox.Text + "'," +
					" motolicense ='" + Client_regularclient_motolicense_textBox.Text + "'," +
					" motocompany ='" + Client_regularclient_motocompany_comboBox.Text + "'," +
					" mototype ='" + Client_regularclient_mototype_comboBox.Text + "'," +
					" motoID ='" + Client_regularclient_motoID_textBox.Text + "'," +
					" motocolor ='" + Client_regularclient_motocolor_textBox.Text + "'," +
					" PS ='" + Client_regularclient_PS_textBox.Text + "'" +
					" WHERE id ='" + Client_regularclient_ID_label2.Text + "'";

				//cmd = new MySqlCommand(sql, dataon);
				//cmd.Connection = dataon;
				//cmd.ExecuteNonQuery();
				//cmd.Dispose();
				SQLUPDATE_clientinformation_id(sql);
				//MYSQL更新table資料-------------------------------------------------------------------------------------------/

				//MYSQL關閉連線-------------------------------------------------------------------------------------------/
				dataon.Close();
				dataon.Dispose();
				//MYSQL關閉連線-------------------------------------------------------------------------------------------/

				//按鈕連動-----------------------------------------------------start/
				Client_regularclient_name_textBox.Enabled = false;
				Client_regularclient_telephone_textBox.Enabled = false;
				Client_regularclient_cellphone_textBox.Enabled = false;
				Client_regularclient_email_textBox.Enabled = false;
				Client_regularclient_personID_textBox.Enabled = false;
				Client_regularclient_address_textBox.Enabled = false;
				Client_regularclient_motolicense_textBox.Enabled = false;
				Client_regularclient_motocompany_comboBox.Enabled = false;
				Client_regularclient_mototype_comboBox.Enabled = false;
				Client_regularclient_motoID_textBox.Enabled = false;
				Client_regularclient_motocolor_textBox.Enabled = false;
				Client_regularclient_PS_textBox.Enabled = false;
				//按鈕連動-----------------------------------------------------end/
			}
		}

		

		private void Client_newclient_Saveinformation_button_Click(object sender, EventArgs e)
		{
			if (Client_newclient_name_textBox.Text == "")
			{
				MessageBox.Show("請輸入客戶名稱");
			}
			else if (Client_newclient_cellphone_textBox.Text == "")
			{
				MessageBox.Show("請輸入行動電話");
			}
			else if (Client_newclient_motolicense_textBox.Text == "")
			{
				MessageBox.Show("請輸入機車車牌");
			}
			else
			{
				//MYSQL連線-------------------------------------------------------------------------------------------/
				//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
				//dataon = new MySqlConnection(connectMYSQL);
				dataon.Open();
				//MYSQL連線-------------------------------------------------------------------------------------------/

				//MYSQL查詢table資料-------------------------------------------------------------------------------------------/
				string sql = "select * from client_information";  //查詢
				cmd = new MySqlCommand(sql, dataon);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					//MessageBox.Show(reader.GetInt32("id") + reader.GetString("name") /*+ reader.GetString("notolicense")*/);
					Client_regularclient_ID_label2.Text = reader.GetInt32("id") + "";
					//Client_regularclient_name_label.Text = reader.GetString("name");
				}
				string newid = "" + (Convert.ToInt32(Client_regularclient_ID_label2.Text) + 1);
				reader.Close();
				reader.Dispose();
				//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/

				//MYSQL新增table資料-------------------------------------------------------------------------------------------start/
				string ADDnew = "INSERT INTO client_information( id , name , telephone , cellphone ,email , personalID , address , motolicense , motocompany , mototype , motoID , motocolor , PS )" +
														 "VALUES('" + newid + "','" + Client_newclient_name_textBox.Text + "',' " + Client_newclient_telphone_textBox.Text + "'," +
														 "'" + Client_newclient_cellphone_textBox.Text + " ','" + Client_newclient_email_textBox.Text + "','" + Client_newclient_personID_textBox.Text + "'," +
														 "'" + Client_newclient_address_textBox.Text + "','" + Client_newclient_motolicense_textBox.Text + "','" + Client_newclient_motocompany_comboBox.Text + "'," +
														 "'" + Client_newclient_mototype_comboBox.Text + "','" + Client_newclient_motoID_textBox.Text + "','" + Client_newclient_motocolor_textBox.Text + "'," +
														 "'" + Client_newclient_PS_textBox.Text + "')";
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

		private void Client_regularclient_searching_button_Click(object sender, EventArgs e)
		{			
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//用於查詢之變數
			string sql_where;
			//用於查詢之變數
			if ( Client_regularclient_phonesearch_radioButton.Checked == false && Client_regularclient_motolicensesearch_radioButton.Checked == false)
			{
				MessageBox.Show("請選擇姓名或電話或車牌號碼以供查詢");
			}
			else if (Client_regularclient_searching_textBox.Text == "")
			{
				MessageBox.Show("請輸入要查詢的客戶資料");
			}
			else
			{
				if (Client_regularclient_motolicensesearch_radioButton.Checked == true)
				{
					//查詢資料並將資料顯示於對應Text內
					sql_where = "SELECT id, name, telephone, cellphone, email, personalID, address, motolicense, motocompany, mototype, motoID, motocolor, PS FROM client_information WHERE motolicense='" + Client_regularclient_searching_textBox.Text+"'";
					SQLsearchingdata_name(sql_where);
				}
				//使用手機查詢
				if (Client_regularclient_phonesearch_radioButton.Checked == true)
				{					
					//查詢資料並將資料顯示於對應Text內
					sql_where = "SELECT id, name, telephone, cellphone, email, personalID, address, motolicense, motocompany, mototype, motoID, motocolor, PS FROM client_information WHERE cellphone=" + Client_regularclient_searching_textBox.Text;
					SQLsearchingdata_cellphone(sql_where);					
				}
			}

			dataon.Close();
			dataon.Dispose();
		}

		private void SQLsearchingdata_cellphone(string sql)
		{		 
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			//sql = "select * from client_information";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				Client_regularclient_ID_label2.Text = (reader.GetString("id"));
				Client_regularclient_name_textBox.Text= (reader.GetString("name"));
				Client_regularclient_telephone_textBox.Text = (reader.GetString("telephone"));
				Client_regularclient_cellphone_textBox.Text = (reader.GetString("cellphone"));
				Client_regularclient_email_textBox.Text = (reader.GetString("email"));
				Client_regularclient_personID_textBox.Text = (reader.GetString("personalID"));
				Client_regularclient_address_textBox.Text = (reader.GetString("address"));
				Client_regularclient_motolicense_textBox.Text = (reader.GetString("motolicense"));
				Client_regularclient_motocompany_comboBox.Text = (reader.GetString("motocompany"));
				Client_regularclient_mototype_comboBox.Text = (reader.GetString("mototype"));
				Client_regularclient_motoID_textBox.Text = (reader.GetString("motoID"));
				Client_regularclient_motocolor_textBox.Text = (reader.GetString("motocolor"));
				Client_regularclient_PS_textBox.Text = (reader.GetString("PS"));
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/			
		}
		private void SQLsearchingdata_name(string sql)
		{
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			//sql = "select * from client_information";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				Client_regularclient_ID_label2.Text = (reader.GetString("id"));
				Client_regularclient_name_textBox.Text = (reader.GetString("name"));
				Client_regularclient_telephone_textBox.Text = (reader.GetString("telephone"));
				Client_regularclient_cellphone_textBox.Text = (reader.GetString("cellphone"));
				Client_regularclient_email_textBox.Text = (reader.GetString("email"));
				Client_regularclient_personID_textBox.Text = (reader.GetString("personalID"));
				Client_regularclient_address_textBox.Text = (reader.GetString("address"));
				Client_regularclient_motolicense_textBox.Text = (reader.GetString("motolicense"));
				Client_regularclient_motocompany_comboBox.Text = (reader.GetString("motocompany"));
				Client_regularclient_mototype_comboBox.Text = (reader.GetString("mototype"));
				Client_regularclient_motoID_textBox.Text = (reader.GetString("motoID"));
				Client_regularclient_motocolor_textBox.Text = (reader.GetString("motocolor"));
				Client_regularclient_PS_textBox.Text = (reader.GetString("PS"));
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/			
		}

		//清空text的function
		private void Client_regularclient_textclear()
		{
			Client_regularclient_ID_label2.Text = "";
			Client_regularclient_name_textBox.Text = "";
			Client_regularclient_telephone_textBox.Text = "";
			Client_regularclient_cellphone_textBox.Text = "";
			Client_regularclient_email_textBox.Text = "";
			Client_regularclient_personID_textBox.Text = "";
			Client_regularclient_address_textBox.Text = "";
			Client_regularclient_motolicense_textBox.Text = "";
			Client_regularclient_motoID_textBox.Text = "";
			Client_regularclient_motocolor_textBox.Text = "";
			Client_regularclient_PS_textBox.Text = "";
			Client_regularclient_motocompany_comboBox.Text = "";
			Client_regularclient_mototype_comboBox.Text = "";
		}

		private void Client_regularclient_fixrecord_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			Maintenance_record_Form mainteance_record_1 = new Maintenance_record_Form();
			mainteance_record_1.Maintenance_from_Client_name = Client_regularclient_name_textBox.Text; //將字串傳送到 Maintenance_record_Form
			mainteance_record_1.Maintenance_from_Client_motolicense = Client_regularclient_motolicense_textBox.Text; //將字串傳送到 Maintenance_record_Form
			mainteance_record_1.ShowDialog();
			//按鈕連動-----------------end
			//mainteance_record_1.Maintenance_from_Client_name = Client_regularclient_name_textBox.Text;
			//mainteance_record_1.Maintenance_from_Client_motolicense = Client_regularclient_motolicense_textBox.Text;
			//按鈕連動-----------------start
			if (mainteance_record_1.DialogResult == DialogResult.OK) //關掉Client_1視窗 會返回ok值  才可以再開啟其他視窗
			{
				Application.Run(new Maintenance_record_Form());
				
			}
			//按鈕連動-----------------end

			////按鈕連動-----------------start
			//InStock_Form Instock_1 = new InStock_Form();
			//Instock_1.ShowDialog();
			//if (Instock_1.DialogResult == DialogResult.OK)  //關掉Client_1視窗 會返回ok值  才可以再開啟其他視窗
			//{
			//	Application.Run(new InStock_Form());
			//}
			////按鈕連動-----------------end


		}

		private void SQLUPDATE_clientinformation_id(string sql)
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
