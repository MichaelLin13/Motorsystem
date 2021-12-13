using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Motorsystem
{
	class Client_information
	{
        //開啟連結到資料庫
        public bool ConnectionOpen()
        {
            try
            {
                //MYSQL連線-------------------------------------------------------------------------------------------/
                String connectMYSQL = "server=localhost;port=3306;user=root;password=0911201923;database=motobasedata";
                MySqlConnection dataon = new MySqlConnection(connectMYSQL);
                dataon.Open();
                //MYSQL連線-------------------------------------------------------------------------------------------/
                //MySqlConnection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //例外處理，常見的兩種錯誤
                //ex.Number=0:無法連接到伺服器.
                //ex.Number=1045: 無效的使用者名稱或密碼.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("無法連接到伺服器");
                        break;
                    case 1042:
                        MessageBox.Show("無效的主機名稱");
                        break;
                    case 1045:
                        MessageBox.Show("使用者名稱/密碼錯誤");
                        break;
                }
                return false;
            }

        }
    }
}
