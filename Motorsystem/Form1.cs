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

namespace Motorsystem
{
	public partial class MotorForm_main : Form
	{		
		public MotorForm_main()
		{
			InitializeComponent();			
		}
		
		private void moto_client_button_Click(object sender, EventArgs e)
		{			
			//按鈕連動-----------------start
			Client_Form Client_1 = new Client_Form();
			Client_1.ShowDialog();
			if(Client_1.DialogResult==DialogResult.OK) //關掉Client_1視窗 會返回ok值  才可以再開啟其他視窗
			{
				Application.Run(new Client_Form());
			}
			//按鈕連動-----------------end
		}
		private void moto_Instock_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			Instock_management_Form Instock_management_1 = new Instock_management_Form();
			Instock_management_1.ShowDialog();
			if(Instock_management_1.DialogResult==DialogResult.OK)
			{
				Application.Run(new Instock_management_Form());  //關掉Client_1視窗 會返回ok值  才可以再開啟其他視窗
			}
			//按鈕連動-----------------end
		}

		private void moto_Income_Expenditure_button_Click(object sender, EventArgs e)
		{
			//按鈕連動-----------------start
			Income_Expenditure_Form IncomeExpenditure_1 = new Income_Expenditure_Form();
			IncomeExpenditure_1.ShowDialog();
			if(IncomeExpenditure_1.DialogResult==DialogResult.OK)  //關掉Client_1視窗 會返回ok值  才可以再開啟其他視窗
			{
				Application.Run(new Income_Expenditure_Form());
			}
			//按鈕連動-----------------end
		}
	}
}
