using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
	public partial class FormManagement : Form
	{
		private string Employeerights;
		public FormManagement(string EmployeeRights)
		{
			InitializeComponent();
			Employeerights = EmployeeRights;
		}

		private void FormManagement_Load(object sender, EventArgs e)
		{
			if (Employeerights == "Administrator")
			{
				btCr.Enabled = true;
				btEe.Enabled = true;
				btPr.Enabled = true;
				btOrder.Enabled = true;
				btOrderDs.Enabled = true;
				btSl.Enabled = true;
			}
			else if (Employeerights == "sales agent")
			{
				btCr.Enabled = true;
				btEe.Enabled = false;
				btPr.Enabled = false;
				btOrder.Enabled = true;
				btOrderDs.Enabled = false;
				btSl.Enabled = false;
			}
			else if (Employeerights == "Warehouse staff")
			{
				btCr.Enabled = false;
				btEe.Enabled = false;
				btPr.Enabled = true;
				btOrder.Enabled = false;
				btOrderDs.Enabled = true;
				btSl.Enabled = false;
			}
			else
			{
				btCr.Enabled = false;
				btEe.Enabled = false;
				btPr.Enabled = false;
				btOrder.Enabled = false;
				btOrderDs.Enabled = false;
				btSl.Enabled = false;
			}
		}

		private void btCr_Click(object sender, EventArgs e)
		{
			FormEmployees formInformation = new FormEmployees();
			formInformation.Show();
			this.Hide();
		}

		private void btEe_Click(object sender, EventArgs e)
		{
			FormEmployees formEmployees = new FormEmployees();
			formEmployees.Show();
			this.Hide();
		}

		private void btPr_Click(object sender, EventArgs e)
		{
			FormProduct formProduct = new FormProduct();
			formProduct.Show();
			this.Hide();
		}

		private void btOrder_Click(object sender, EventArgs e)
		{
			FormOrder formOrder = new FormOrder();
			formOrder.Show();
			this.Hide();
		}

		private void btOrderDs_Click(object sender, EventArgs e)
		{

			FormOrderDsetails formOrderDsetails = new FormOrderDsetails();
			formOrderDsetails.Show();
			this.Hide();
		}

		private void btSl_Click(object sender, EventArgs e)
		{
			FormStatistical formStatistical = new FormStatistical();
			formStatistical.Show();
			this.Hide();
		}
	}
}
