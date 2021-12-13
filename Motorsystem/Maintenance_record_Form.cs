using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO; //寫入和讀取資料會用到
using System.Threading;
//using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

namespace Motorsystem
{
	public partial class Maintenance_record_Form : Form
	{
		//宣告此form的變數
		//string maintenance_toDesktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //桌面路徑		
		int maintenance_servicetype;
		string maintenance_date;
		string maintenance_datetime;
		string maintenance_datetime_check;
		string maintenance_name;
		string maintenance_motolicense;
		string maintenance_servicetype_checked;
		bool check_yesno;		
		int check_num;
		int MYSQL_count_row;
		string[] MYSQL_components_name;
		string ADDTOdatagridview_components_name;
		string components_name_get;
		int components_quantity_caculate;
		string quentity_cacu;
		int becaculated_quantity;
		//宣告此form的變數

		//MYSQL變數宣告---------------------
		private MySqlConnection dataon;
		private MySqlCommand cmd;
		private MySqlDataReader reader;
		//MYSQL變數宣告---------------------

		//宣告來自Client_Form的變數------------------------

		//宣告來自Client_Form的變數------------------------

		//宣告印表機變數-----------------------------
		private Font printFont;
		private Font titleFont;
		private Font dateFont;		
		private PrintDocument pd;
		
		//宣告印表機變數-----------------------------

		//MYSQL連線預設位置與帳號---------------
		private string serverAddress = "localhost";
		private string sqlport = "3306";
		private string databaseName = "motobasedata";
		private string userID = "root";
		private string password = "0911201923";
		//MYSQL連線預設位置與帳號---------------

		public string Maintenance_from_Client_name
		{
			set
			{
				Maintenance_name_label2.Text = value;
			}
		}

		public string Maintenance_from_Client_motolicense
		{
			set
			{
				Maintenance_motolicense_label2.Text = value;
			}
			get
			{
				return Maintenance_motolicense_label2.Text;
			}
		}
		//宣告來自Client_Form的變數------------------------
		public Maintenance_record_Form()
		{
			InitializeComponent();
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			//dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//維修狀態combobox讀取
			status_comboBox_text();
			//維修狀態combobox讀取

			//零件combobox讀取
			SQLsearchingdata_showcomponents_dataGrid();
			//零件combobox讀取

			//將零件名稱放到ListBox中
			string a = "";
			SQLsearchingdata_componentsINlist_name(a);
			//將零件名稱放到ListBox中

			//印表機名字抓取
			GetPrinterList();
			//印表機名字抓取

			//Maintenance_name_label2.Text = maintenance_name;
			//Maintenance_motolicense_label2.Text = maintenance_motolicense;
		}

		private void Maintenance_SAVE_button_Click(object sender, EventArgs e)
		{
			if (Maintenance_maintenance_radioButton.Checked == false && Maintenance_service_radioButton.Checked == false && Maintenance_accident_radioButton.Checked == false)
			{
				MessageBox.Show("選擇維修類別");
			}
			else if (Maintenance_servicestaff_textBox.Text == "")
			{
				MessageBox.Show("維修人員不能是空白");
			}
			else if (Maintenance_milage_textBox.Text == "")
			{
				MessageBox.Show("里程數不能是空白");
			}
			else if (Maintenance_status_comboBox.Text == "")
			{
				MessageBox.Show("請選擇處理狀況");
			}
			else
			{
				//日期
				maintenance_date=Maintenance_intofactorytime_dateTimePicker.Value.Year+"-"+ Maintenance_intofactorytime_dateTimePicker.Value.Month+"-"+ Maintenance_intofactorytime_dateTimePicker.Value.Day;
				//日期和時間
				maintenance_datetime =""+ Maintenance_intofactorytime_dateTimePicker.Value.Year + Maintenance_intofactorytime_dateTimePicker.Value.Month + Maintenance_intofactorytime_dateTimePicker.Value.Day +
					Maintenance_intofactorytime_dateTimePicker.Value.Hour + Maintenance_intofactorytime_dateTimePicker.Value.Minute + Maintenance_intofactorytime_dateTimePicker.Value.Second ;
				Maintenance_recordnumber_label2.Text = maintenance_datetime;


				if (maintenance_datetime == maintenance_datetime_check)
				{
					MessageBox.Show("重複儲存");
				}
				else
				{
					//獲取使用零件名稱--------------------------------------------------------------------------------------//
					components_name_get = Maintenance_Components_name_get();
					//獲取使用零件名稱--------------------------------------------------------------------------------------/

					//MYSQL新增table資料-------------------------------------------------------------------------------------------/
					string ADDnew = "INSERT INTO maintenance_record( motolicense , servicetype , guestquestion , servicestaff , milage , servicedate , reason , components , recordnumber , PS , status )" +
															 "VALUES('" + Maintenance_motolicense_label2.Text + "','" + maintenance_servicetype + "',' " + Maintenance_guestquestion_richTextBox.Text + "'," +
															 "'" + Maintenance_servicestaff_textBox.Text + " ','" + Maintenance_milage_textBox.Text + "','" + maintenance_date + "'," +
															 "'" + Maintenance_reasonofbug_richTextBox.Text + "*" + components_name_get  + "','" + components_name_get + "','" + Maintenance_recordnumber_label2.Text + "'," +
															 "'" + Maintenance_PS_richTextBox.Text + "','" + Maintenance_status_comboBox.Text + "')";
					Maintenance_maintenance_record_SAVE(ADDnew);
					//MYSQL新增table資料-------------------------------------------------------------------------------------------/

					//MYSQL新增table資料-------------------------------------------------------------------------------------------/
					ADDnew = "INSERT INTO total_amount(  total_day , total_month , total_year , total_name , total_motolicense , total_components , total_servicestaff , total_componentsprice , total_totalamount , recordnumber  )" +
															 "VALUES('" + maintenance_date + "','" + Maintenance_intofactorytime_dateTimePicker.Value.Month + "',' " + Maintenance_intofactorytime_dateTimePicker.Value.Year + "'," +
															 "'" + maintenance_servicetype + " ','" + Maintenance_motolicense_label2.Text + "','" + Maintenance_reasonofbug_richTextBox.Text+"，" +components_name_get + "'," +
															 "'" + Maintenance_servicestaff_textBox.Text + "','" + Maintenance_ComponentsCOST_label2.Text + "','" + Maintenance_ActualCOST_label2.Text + "'," +
															 "'" + Maintenance_recordnumber_label2.Text + "')";
					Maintenance_total_amount_SAVE(ADDnew);
					//MYSQL新增table資料-------------------------------------------------------------------------------------------/

					//MYSQL更新零件數量----------------------------------------------------------------------------------------/
					Maintenance_inctockvalue_caculate();
					//MYSQL更新零件數量----------------------------------------------------------------------------------------/
					MessageBox.Show("儲存成功");
					this.Close();
				}
				maintenance_datetime_check = maintenance_datetime;
				
			}

		}

		private void Maintenance_maintenance_radioButton_CheckedChanged(object sender, EventArgs e)
		{
			maintenance_servicetype = 0;
		}

		private void Maintenance_service_radioButton_CheckedChanged(object sender, EventArgs e)
		{
			maintenance_servicetype = 1;
		}

		private void Maintenance_accident_radioButton_CheckedChanged(object sender, EventArgs e)
		{
			maintenance_servicetype = 110;
		}

		

		private void Maintenance_recordsearching_button_Click(object sender, EventArgs e)
		{
			Maintenance_recordsearching_button.Enabled = false;
			Maintenance_deleterecord_button.Enabled = true;
			////MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			//dataon.Open();
			////MYSQL連線-------------------------------------------------------------------------------------------/
			if (Maintenance_motolicense_label2.Text == "")
			{
				MessageBox.Show("請回到上一頁輸入要查詢之客人的資料");
			}
			else
			{
				string sql = "SELECT recordnumber , servicedate, reason, status FROM maintenance_record WHERE motolicense='" + Maintenance_motolicense_label2.Text + "'";
				SQLsearchingdata_maintenancerecord_motolicense(sql);
			}
		}

		private void status_comboBox_text()
		{
			Maintenance_status_comboBox.DropDownStyle=ComboBoxStyle.DropDownList;
			Maintenance_status_comboBox.Items.Add("已完成");
			Maintenance_status_comboBox.Items.Add("維修中");
			Maintenance_status_comboBox.SelectedValueChanged += new System.EventHandler(Maintenance_status_comboBox_SelectedIndexChanged);
		}

		private void SQLsearchingdata_maintenancerecord_motolicense(string sql)
		{
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
				Maintenance_event_dataGridView.Rows.Add(new Object[] { reader.GetString("recordnumber"), reader.GetString("servicedate"), reader.GetString("reason"), reader.GetString("status") });
				//MessageBox.Show(reader.GetString("servicedate")+"\r\n"+ reader.GetString("reason")+"\r\n"+ reader.GetString("status"));				
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/		


			////新增資料至dataGridView-----------------------範例---------------------------
			//for (int i = 0; i < 30; i++)
			//{
			//	Maintenance_event_dataGridView.Rows.Add(new Object[] { "紅茶", 25, "???" });
			//}
			////新增資料至dataGridView-----------------------
		}

		private void Maintenance_callrecord_button_Click(object sender, EventArgs e)
		{
			int check_num2;
			//按鈕連動-----------------start
			Maintenance_SAVErecordCover_button.Enabled = true;
			Maintenance_SAVE_button.Enabled = false;
			if (Maintenance_event_dataGridView.CurrentCell.ColumnIndex != 0)
			{
				Maintenance_callrecord_button.Enabled = true;
			}
			else if (Maintenance_event_dataGridView.CurrentCell.ColumnIndex == 0)
			{
				Maintenance_callrecord_button.Enabled = false;
			}
			Maintenance_maintenance_radioButton.Enabled = false;
			Maintenance_service_radioButton.Enabled = false;
			Maintenance_accident_radioButton.Enabled = false;
			Maintenance_guestquestion_richTextBox.Enabled = false;
			Maintenance_PS_richTextBox.Enabled = false;
			Maintenance_servicestaff_textBox.Enabled = false;
			Maintenance_milage_textBox.Enabled = false;
			Maintenance_intofactorytime_dateTimePicker.Enabled = false;
			Maintenance_reasonofbug_richTextBox.Enabled = false;

			Maintenance_componentssearching_textBox.Enabled = false;
			Maintenance_componentssearching_button.Enabled = false;
			Maintenance_componentssearching_listBox.Enabled = false;
			Maintenance_addcomponents_button.Enabled = false;
			Maintenance_deletecomponents_button.Enabled = false;
			Maintenance_LaborCOST_label2.Enabled = false;
			Maintenance_DiscountCOST_label2.Enabled = false;
			//按鈕連動-----------------end
			if (Maintenance_event_dataGridView.CurrentCell==null)
			{
				MessageBox.Show("沒搜尋到任何資訊");
			}
			else if (Maintenance_event_dataGridView.CurrentCell.ColumnIndex != 0)
			{
				MessageBox.Show("請選擇要查看之單號");
			}
			else
			{
				string sql = "SELECT servicetype , guestquestion , PS , servicestaff , milage , servicedate , reason , status , recordnumber FROM maintenance_record WHERE recordnumber ='" + Maintenance_event_dataGridView.CurrentCell.Value + "'";
				check_num2=SQLsearchingdata_maintenancerecord_recordnumber(sql);

				if (check_num2 == 0) 
				{
					Maintenance_maintenance_radioButton.Checked = true;
				}
				else if(check_num2 == 1)
				{
					Maintenance_service_radioButton.Checked = true;
				}
				else if(check_num2 == 110)
				{
					Maintenance_accident_radioButton.Checked = true;
				}
			}
		}

		private int SQLsearchingdata_maintenancerecord_recordnumber(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			//sql = "select * from client_information";  //查詢
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				check_num = reader.GetInt32("servicetype");
				Maintenance_guestquestion_richTextBox.Text = reader.GetString("guestquestion");
				Maintenance_PS_richTextBox.Text = reader.GetString("PS");
				Maintenance_servicestaff_textBox.Text = reader.GetString("servicestaff");
				Maintenance_milage_textBox.Text = reader.GetString("milage");
				Maintenance_intofactorytime_dateTimePicker.Value = reader.GetDateTime("servicedate");
				Maintenance_reasonofbug_richTextBox.Text = reader.GetString("reason");
				Maintenance_status_comboBox.Text = reader.GetString("status");
				Maintenance_recordnumber_label2.Text= reader.GetString("recordnumber");
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/	

			return check_num;
		}

		private void SQLsearchingdata_componentsINlist_name(string sql)
		{
			int i = 0;
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
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
				Maintenance_componentssearching_listBox.Items.Add(MYSQL_components_name[j]);
				//MessageBox.Show(MYSQL_components_name[j]);
			}
			//將資料放置於ListBox中

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/	
			
		}

		private void Maintenance_SAVErecordCover_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			Maintenance_SAVErecordCover_button.Enabled = false;
			Maintenance_SAVE_button.Enabled = true;
			Maintenance_callrecord_button.Enabled = true;
			Maintenance_deleterecord_button.Enabled = false;

			Maintenance_maintenance_radioButton.Enabled = true;
			Maintenance_service_radioButton.Enabled = true;
			Maintenance_accident_radioButton.Enabled = true;
			Maintenance_guestquestion_richTextBox.Enabled = true;
			Maintenance_PS_richTextBox.Enabled = true;
			Maintenance_servicestaff_textBox.Enabled = true;
			Maintenance_milage_textBox.Enabled = true;
			Maintenance_intofactorytime_dateTimePicker.Enabled = true;
			Maintenance_reasonofbug_richTextBox.Enabled = true;

			Maintenance_maintenance_radioButton.Checked= false;
			Maintenance_service_radioButton.Checked = false;
			Maintenance_accident_radioButton.Checked = false;
			Maintenance_guestquestion_richTextBox.Text = null;
			Maintenance_PS_richTextBox.Text = null;
			Maintenance_servicestaff_textBox.Text = null;
			Maintenance_milage_textBox.Text = null;
			Maintenance_reasonofbug_richTextBox.Text = null;
			Maintenance_status_comboBox.Text = "";

			Maintenance_componentssearching_textBox.Enabled = true;
			Maintenance_componentssearching_button.Enabled = true;
			Maintenance_componentssearching_listBox.Enabled = true;
			Maintenance_addcomponents_button.Enabled = true;
			Maintenance_deletecomponents_button.Enabled = true;
			Maintenance_LaborCOST_label2.Enabled = true;
			Maintenance_DiscountCOST_label2.Enabled = true;
			//按鈕連動-----------------end		

			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL更新table資料-------------------------------------------------------------------------------------------/
			string sql = "UPDATE maintenance_record SET status  ='" + Maintenance_status_comboBox.Text + "' "+
				" WHERE motolicense ='" + Maintenance_motolicense_label2.Text + "'";
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();			
			//MYSQL更新table資料-------------------------------------------------------------------------------------------/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
		}

		private void SQLsearchingdata_showcomponents_dataGrid()
		{
			
			DataGridViewComboBoxColumn Maintenance_componentsnumber = new DataGridViewComboBoxColumn();
			
			Maintenance_Components_dataGridView.ColumnCount = 5;
			Maintenance_Components_dataGridView.Columns[0].Name = "編號";
			Maintenance_Components_dataGridView.Columns[0].Width = 125;
			Maintenance_Components_dataGridView.Columns[0].ReadOnly = true;
			Maintenance_Components_dataGridView.Columns[1].Name = "名稱";
			Maintenance_Components_dataGridView.Columns[1].Width = 125;
			Maintenance_Components_dataGridView.Columns[1].ReadOnly = true;
			Maintenance_Components_dataGridView.Columns[2].Name = "單價";
			Maintenance_Components_dataGridView.Columns[2].ReadOnly = true;
			Maintenance_Components_dataGridView.Columns[3].Name = "數量";
			Maintenance_Components_dataGridView.Columns[4].Name = "小計";
			Maintenance_Components_dataGridView.Columns[4].ReadOnly = true;

			Maintenance_Components_dataGridView.AllowUserToResizeColumns = false;
			Maintenance_Components_dataGridView.AllowUserToResizeRows = false;
		}

		private void Maintenance_status_comboBox_SelectedIndexChanged(object sender,System.EventArgs e)
		{
			//MessageBox.Show(Maintenance_status_comboBox.Text);
		}

		private void Maintenance_componentssearching_button_Click(object sender, EventArgs e)
		{
			if (Maintenance_componentssearching_textBox.Text == "")
			{
				MessageBox.Show("請輸入要查詢的零件名稱");
			}
			else
			{
				//Maintenance_componentssearching_listBox.FindString(Maintenance_componentssearching_textBox.Text);
				Maintenance_componentssearching_listBox.SelectedItem = Maintenance_componentssearching_textBox.Text;
				//MessageBox.Show( Maintenance_componentssearching_listBox.SelectedItem.ToString());
				if(!string.IsNullOrEmpty(Maintenance_componentssearching_textBox.Text))
				{
					int index = Maintenance_componentssearching_listBox.FindString(Maintenance_componentssearching_textBox.Text);
					if(index !=-1)
					{
						Maintenance_componentssearching_listBox.SetSelected(index, true);
					}
					else
					{
						//MessageBox.Show("The search string did not match any items in the ListBox");
						MessageBox.Show("沒有任何零件名稱符合你要找的零件，請在確認一次關鍵字");
					}
				}
			}
		}

		private void Maintenance_addcomponents_button_Click(object sender, EventArgs e)
		{
			if(Maintenance_componentssearching_listBox.SelectedItem==null)			
			{
				MessageBox.Show("請選擇要加入的零件");
			}
			else
			{
				ADDTOdatagridview_components_name = Maintenance_componentssearching_listBox.SelectedItem.ToString();
				string sql = "SELECT components_id , components_name, components_price FROM instock_components WHERE components_name='" + ADDTOdatagridview_components_name + "'";
				SQLsearchingdata_showcomponentsname_name(sql);
			}
		}

		private void SQLsearchingdata_showcomponentsname_name(string sql)
		{
			int Presetquantity = 1;
			int total_components=0;
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			// MYSQL查詢table資料------------------------------------------------------------------------------------------ -/			
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read()) 
			{
				Maintenance_Components_dataGridView.Rows.Add(new Object[] { reader.GetString("components_id"), reader.GetString("components_name"), reader.GetInt32("components_price"), ""+ Presetquantity , reader.GetInt32("components_price")* Presetquantity });
			}
			for (int j = 0; j < Maintenance_Components_dataGridView.RowCount; j++) 
			{
				total_components = total_components + Convert.ToInt32(Maintenance_Components_dataGridView.Rows[j].Cells[4].Value);
			}
			Maintenance_ComponentsCOST_label2.Text = total_components + "";
			Maintenance_Components_totalprice_caculate(Maintenance_ComponentsCOST_label2.Text, Maintenance_LaborCOST_label2.Text, Maintenance_DiscountCOST_label2.Text, Maintenance_ActualCOST_label2.Text);
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
		}

		private void caculate_price() //總金額計算
		{
			//Maintenance_Components_dataGridView.
			//Total_components_price = Convert.ToInt32(Maintenance_Components_dataGridView.Rows[rowIndex].Cells[4].Value);
			//Maintenance_ComponentsCOST_label2.Text = Total_components_price + "";
		}

		private void Maintenance_LaborCOST_label2_Click(object sender, EventArgs e)
		{
			//按鈕連動..................................start
			Maintenance_LaborCOST_textBox.Visible = true;
			Maintenance_LaborCOST_button.Visible = true;
			//按鈕連動..................................end
		}

		private void Maintenance_DiscountCOST_label2_Click(object sender, EventArgs e)
		{
			//按鈕連動..................................start
			Maintenance_DiscountCOST_textBox.Visible = true;
			Maintenance_DiscountCOST_button.Visible = true;
			//按鈕連動..................................end
		}

		private void Maintenance_LaborCOST_button_Click(object sender, EventArgs e)
		{
			//按鈕連動..................................start
			Maintenance_LaborCOST_textBox.Visible = false;
			Maintenance_LaborCOST_button.Visible = false;
			//按鈕連動..................................end

			if (Maintenance_LaborCOST_textBox.Text == "" || Maintenance_LaborCOST_textBox.Text == null) 
			{
				MessageBox.Show("不能為空白");
				Maintenance_LaborCOST_label2.Text = "0";
			}
			else
			{
				Maintenance_LaborCOST_label2.Text = Maintenance_LaborCOST_textBox.Text;
				Maintenance_Components_totalprice_caculate(Maintenance_ComponentsCOST_label2.Text, Maintenance_LaborCOST_label2.Text, Maintenance_DiscountCOST_label2.Text, Maintenance_ActualCOST_label2.Text);
			}
		}

		private void Maintenance_DiscountCOST_button_Click(object sender, EventArgs e)
		{
			//按鈕連動..................................start
			Maintenance_DiscountCOST_textBox.Visible = false;
			Maintenance_DiscountCOST_button.Visible = false;
			//按鈕連動..................................end

			if (Maintenance_DiscountCOST_textBox.Text == "" || Maintenance_DiscountCOST_textBox.Text == null) 
			{
				MessageBox.Show("不能為空白");
				Maintenance_DiscountCOST_label2.Text = "0";
			}
			else
			{
				Maintenance_DiscountCOST_label2.Text = Maintenance_DiscountCOST_textBox.Text;
				Maintenance_Components_totalprice_caculate(Maintenance_ComponentsCOST_label2.Text, Maintenance_LaborCOST_label2.Text, Maintenance_DiscountCOST_label2.Text, Maintenance_ActualCOST_label2.Text);
			}
		}

		private void Maintenance_deletecomponents_button_Click(object sender, EventArgs e)
		{
			int total_components = 0;
			//小於1筆資料則無動作			
			if (Maintenance_Components_dataGridView.RowCount > 1 && Maintenance_Components_dataGridView.CurrentRow.Index < Maintenance_Components_dataGridView.RowCount - 1) 
			{
				Maintenance_Components_dataGridView.Rows.Remove(Maintenance_Components_dataGridView.Rows[Maintenance_Components_dataGridView.CurrentRow.Index]);
				for (int j = 0; j < Maintenance_Components_dataGridView.RowCount; j++)
				{
					total_components = total_components + Convert.ToInt32(Maintenance_Components_dataGridView.Rows[j].Cells[4].Value);
				}
				Maintenance_ComponentsCOST_label2.Text = total_components + "";
				Maintenance_Components_totalprice_caculate(Maintenance_ComponentsCOST_label2.Text, Maintenance_LaborCOST_label2.Text, Maintenance_DiscountCOST_label2.Text, Maintenance_ActualCOST_label2.Text);
			}

		}

		//零件金額計算--------------------------------------------------------------------------------
		private void Maintenance_Components_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int total_components = 0;
			try
			{
				Maintenance_Components_dataGridView.Rows[e.RowIndex].Cells[4].Value = (Convert.ToDouble(Maintenance_Components_dataGridView.Rows[e.RowIndex].Cells[2].Value) * Convert.ToDouble(Maintenance_Components_dataGridView.Rows[e.RowIndex].Cells[3].Value)).ToString();
				for (int j = 0; j < Maintenance_Components_dataGridView.RowCount; j++)
				{
					total_components = total_components + Convert.ToInt32(Maintenance_Components_dataGridView.Rows[j].Cells[4].Value);
				}
				Maintenance_ComponentsCOST_label2.Text = total_components + "";
				Maintenance_Components_totalprice_caculate(Maintenance_ComponentsCOST_label2.Text, Maintenance_LaborCOST_label2.Text, Maintenance_DiscountCOST_label2.Text, Maintenance_ActualCOST_label2.Text);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		//零件金額計算--------------------------------------------------------------------------------

		//零件總金額計算--------------------------------------------------------------------------------
		private void Maintenance_Components_totalprice_caculate(string components_price,string laborcost,string discountcost,string Total_price)
		{
			Total_price = (Convert.ToInt32(components_price) + Convert.ToInt32(laborcost) - Convert.ToInt32(discountcost)) + "";
			Maintenance_ActualCOST_label2.Text = Total_price;
		}		
		//零件總金額計算--------------------------------------------------------------------------------


		//獲取零件名稱----------------------------------------------------------
		private string Maintenance_Components_name_get()
		{
			if (Maintenance_Components_dataGridView.RowCount > 1)
			{
				for (int j = 0; j < Maintenance_Components_dataGridView.RowCount; j++)
				{
					components_name_get = components_name_get + " " + Maintenance_Components_dataGridView.Rows[j].Cells[1].Value + "*" + Maintenance_Components_dataGridView.Rows[j].Cells[3].Value;
				}
				//MessageBox.Show(components_name_get);
			}
			return components_name_get;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Maintenance_inctockvalue_caculate();
		}
		//獲取零件名稱----------------------------------------------------------

		private void Maintenance_maintenance_record_SAVE(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL新增table資料-------------------------------------------------------------------------------------------/
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();			
			dataon.Close();
			//MYSQL新增table資料-------------------------------------------------------------------------------------------/
		}

		private void Maintenance_total_amount_SAVE(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL新增table資料-------------------------------------------------------------------------------------------/
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			dataon.Close();
			dataon.Dispose();
			//MYSQL新增table資料-------------------------------------------------------------------------------------------/
		}

		private void Maintenance_deleterecord_button_Click(object sender, EventArgs e)
		{			
			//MessageBox.Show(Maintenance_event_dataGridView.CurrentCell.Value + "");
			//MYSQL刪除table中的1筆資料-------------------------------------------------------------------------------------------/
			string sql = "DELETE from maintenance_record WHERE recordnumber ='" + Maintenance_event_dataGridView.CurrentCell.Value + "'";
			SQLDELETE_income_totalamount_recordnumber(sql);
			//MYSQL刪除table中的1筆資料-------------------------------------------------------------------------------------------/

			//MYSQL刪除table中的1筆資料-------------------------------------------------------------------------------------------/
			sql = "DELETE from total_amount WHERE recordnumber ='" + Maintenance_event_dataGridView.CurrentCell.Value + "'";
			SQLDELETE_income_totalamount_recordnumber(sql);
			//MYSQL刪除table中的1筆資料-------------------------------------------------------------------------------------------/

			//清空DATAgridview表格---------------------------------------------
			Maintenance_event_dataGridView.Rows.Clear();
			//清空DATAgridview表格---------------------------------------------

			//MYSQL搜尋資料----------------------------------------------------------------------------/
			sql = "SELECT recordnumber , servicedate, reason, status FROM maintenance_record WHERE motolicense='" + Maintenance_motolicense_label2.Text + "'";
			SQLsearchingdata_maintenancerecord_motolicense(sql);
			//MYSQL搜尋資料----------------------------------------------------------------------------/
		}

		private void SQLDELETE_income_totalamount_recordnumber(string sql)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL刪除table中的1筆資料-------------------------------------------------------------------------------------------/
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			dataon.Close();
			dataon.Dispose();
			//MYSQL刪除table中的1筆資料-------------------------------------------------------------------------------------------/
		}

		private void Maintenance_inctockvalue_caculate()
		{
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			for (int j = 0; j < Maintenance_Components_dataGridView.RowCount; j++)
			{
				quentity_cacu=Convert.ToString(Maintenance_Components_dataGridView.Rows[j].Cells[1].Value);
				becaculated_quantity=MYSQL_instock_components_getquantity(quentity_cacu, j);
				MYSQL_instock_components_updata_quantity(becaculated_quantity, quentity_cacu);
			}
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/


		}

		private int MYSQL_instock_components_getquantity(string rowcellvalue,int j)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			string sql = "SELECT components_quantity FROM instock_components WHERE components_name='" + rowcellvalue + "'";
			cmd = new MySqlCommand(sql, dataon);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				components_quantity_caculate = reader.GetInt32("components_quantity") - Convert.ToInt32(Maintenance_Components_dataGridView.Rows[j].Cells[3].Value);
				//MessageBox.Show(components_quantity_caculate + "");
			}
			reader.Close();
			reader.Dispose();
			cmd.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/	
			//MYSQL查詢table資料------------------------------------------------------------------------------------------ -/
			return components_quantity_caculate;
		}

		private void MYSQL_instock_components_updata_quantity(int quantity, string components_name)
		{
			//MYSQL連線-------------------------------------------------------------------------------------------/
			//String connectMYSQL = "server=" + serverAddress + ";port=" + sqlport + ";user=" + userID + ";password=" + password + ";database=" + databaseName + ";";
			//dataon = new MySqlConnection(connectMYSQL);
			dataon.Open();
			//MYSQL連線-------------------------------------------------------------------------------------------/

			//MYSQL更新table資料-------------------------------------------------------------------------------------------/
			string sql = "UPDATE instock_components SET components_quantity  ='" + quantity + "' " +
				" WHERE components_name ='" + components_name + "'";
			cmd = new MySqlCommand(sql, dataon);
			cmd.Connection = dataon;
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			//MYSQL更新table資料-------------------------------------------------------------------------------------------/

			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
			dataon.Close();
			dataon.Dispose();
			//MYSQL關閉連線-------------------------------------------------------------------------------------------/
		}

		private void Maintenance_Print_button_Click(object sender, EventArgs e)
		{
			PrintDocument PD = new PrintDocument();
			
			PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);

			PrintPreviewDialog PPD = new PrintPreviewDialog();

			PPD.Document = PD;

			PPD.ShowDialog();
		}

		private void GetPrinterList()
		{

			//獲取本地連線印表機列表載入到下拉框中
			PrinterSettings.StringCollection list = PrinterSettings.InstalledPrinters;
			foreach (string pkInstalledPrinters in list)
			{
				Maintenance_Printlist_comboBox.Items.Add(pkInstalledPrinters);
				//本地預設的印表機為預設選擇項
				PrintDocument prtdoc = new PrintDocument();
				string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//獲取預設的印表機名
				if (pkInstalledPrinters == strDefaultPrinter)
				//把本地預設印表機設為預設值
				{
					//DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(pkInstalledPrinters);
				}
			}
		}

		private string Maintenance_judgefixed()
		{
			if(maintenance_servicetype==0)
			{
				maintenance_servicetype_checked = "保養";
			}
			else if(maintenance_servicetype==1)
			{
				maintenance_servicetype_checked = "維修";
			}
			else if(maintenance_servicetype==110)
			{
				maintenance_servicetype_checked = "事故";
			}
			return maintenance_servicetype_checked;
		}
		Point b;
		void PD_PrintPage(object sender, PrintPageEventArgs e)
		{
			string str;
			int i = 4;
			int count, row,zero=0;			
			string datestr = Maintenance_intofactorytime_dateTimePicker.Value.Year + "-" + Maintenance_intofactorytime_dateTimePicker.Value.Month + "-" + Maintenance_intofactorytime_dateTimePicker.Value.Day;
			//(列印的程式)
			try
			{
				//列印文字
				SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
				printFont = new Font("標楷體", 20);
				dateFont = new Font("標楷體", 15);
				titleFont = new Font("標楷體", 50);
				int spqce_distance = 50;
				float topMargin = e.MarginBounds.Top+40; //上邊距
				float leftMargin = e.MarginBounds.Left; //左邊距
				float recordnumber_top = 100; //上邊距
				float recordnumber_left= 600; //左邊距
				float title_top = 50;
				float title_left = 300;
				float datew_top = 20;
				float date_left = 50;
				Graphics g = e.Graphics; //獲得繪圖物件
				pd = new PrintDocument();
				PaperSize ps = new PaperSize();
				
				pd.DocumentName = "維修單";
				g.DrawString("維修單", titleFont, myBrush, title_left, title_top, new StringFormat());
				g.DrawString("日期:"+ datestr, dateFont, myBrush, date_left, datew_top, new StringFormat());
				g.DrawString("單號:" + Maintenance_recordnumber_label2.Text, dateFont, myBrush, recordnumber_left, recordnumber_top, new StringFormat());
				g.DrawString("客戶名稱:" + Maintenance_name_label2.Text, printFont, myBrush, leftMargin, topMargin, new StringFormat());
				g.DrawString("機車車牌:" + Maintenance_motolicense_label2.Text, printFont, myBrush, leftMargin, topMargin+ (1*spqce_distance), new StringFormat());
				g.DrawString("維修類別: " + Maintenance_judgefixed(), printFont, myBrush, leftMargin, topMargin + (2 * spqce_distance), new StringFormat());
				g.DrawString("里 程 數:" + Maintenance_milage_textBox.Text, printFont, myBrush, leftMargin, topMargin + (3 * spqce_distance), new StringFormat());
				g.DrawString("維修說明:" , printFont, myBrush, leftMargin, topMargin + (4 * spqce_distance), new StringFormat());
				if (("維修說明:" + Maintenance_reasonofbug_richTextBox.Text).Trim().Length < 50)
				{
					g.DrawString( Maintenance_reasonofbug_richTextBox.Text, printFont, myBrush, leftMargin, topMargin + (5 * spqce_distance), new StringFormat());
				}
				else
				{
					StringFormat fmt = new StringFormat();
					fmt.LineAlignment = StringAlignment.Near;
					fmt.FormatFlags = StringFormatFlags.LineLimit;
					b.X = 230;
					b.Y = 340;
					//設定文本打印區域 b是左上角坐標，Size是打印區域（矩形） 
					float mmtopt = 2.835f;
					Rectangle r = new Rectangle(b, new Size(Convert.ToInt32(200* mmtopt), Convert.ToInt32(100 * mmtopt)));
					r.Y = r.Y - Convert.ToInt32(2 * mmtopt);
					g.DrawString(Maintenance_reasonofbug_richTextBox.Text, printFont, myBrush, r, fmt);

				}
				//SizeF sf = e.Graphics.MeasureString("維修說明:" + Maintenance_reasonofbug_richTextBox.Text, printFont, e.MarginBounds.Size, new StringFormat(), out count, out row);				

				//e.Graphics.DrawString(("維修說明:" + Maintenance_reasonofbug_richTextBox.Text).Substring(zero, count), printFont, myBrush, e.MarginBounds, new StringFormat());
				//		i++;
				//	}
				//}
				//if(str.Length>1000)
				//{
				//	e.HasMorePages = true;
				//}
				//else
				//{
				//	e.HasMorePages = false;
				//}

				pd.Print();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
						
			
		}
	}


}
