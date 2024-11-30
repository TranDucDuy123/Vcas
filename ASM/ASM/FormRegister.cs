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
	public partial class FormRegister : Form
	{
		string connectstring = @"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
		public FormRegister()
		{
			InitializeComponent();
		}

		private void btRegisterCr_Click(object sender, EventArgs e)
		{
			string UserName = txtUserCr.Text;
			string PassWord = txtPassCr.Text;
			string FullName = txtEmployeeName.Text;
			string Phone = txtEmployeePhone.Text;
			string Email = txtEmployeeEmail.Text;
			string Address = txtEmployeeAddress.Text;

			if (string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeePhone.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeEmail.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeAddress.Text) ||
				string.IsNullOrWhiteSpace(txtUserCr.Text) ||
				string.IsNullOrWhiteSpace(txtPassCr.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
				return;
			}

			string query = "INSERT INTO Customers (CustomersName, CustomersPhone, CustomersEmail, CustomersAddress, UserName, PassWord) VALUES (@FullName, @Phone, @Email, @Address, @UserName, @PassWord)";

			using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				try
				{
					con.Open();

					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@FullName", FullName);
						cmd.Parameters.AddWithValue("@Phone", Phone);
						cmd.Parameters.AddWithValue("@Email", Email);
						cmd.Parameters.AddWithValue("@Address", Address);
						cmd.Parameters.AddWithValue("@UserName", UserName);
						cmd.Parameters.AddWithValue("@PassWord", PassWord);

						cmd.ExecuteNonQuery();

						MessageBox.Show("Đăng ký khách hàng thành công!");

						txtEmployeeName.Clear();
						txtEmployeePhone.Clear();
						txtEmployeeEmail.Clear();
						txtEmployeeAddress.Clear();
						txtUserCr.Clear();
						txtPassCr.Clear();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
				}
			}
		}

		private void btLoginCr_Click(object sender, EventArgs e)
		{
			FormLogIn formLogIn = new FormLogIn();
			formLogIn.Show();
			this.Hide(); 
		}

		private void btRegisterEe_Click(object sender, EventArgs e)
		{
			string UserName = txtUserEe.Text;
			string PassWord = txtPassEe.Text;
			string FullName = txtNameEe.Text;
			string Phone = txtPhoneEe.Text;
			string Email = txtEmailEe.Text;
			string Address = txtAddressEe.Text;

			if (string.IsNullOrWhiteSpace(txtNameEe.Text) ||
				string.IsNullOrWhiteSpace(txtPhoneEe.Text) ||
				string.IsNullOrWhiteSpace(txtEmailEe.Text) ||
				string.IsNullOrWhiteSpace(txtAddressEe.Text) ||
				string.IsNullOrWhiteSpace(txtUserEe.Text) ||
				string.IsNullOrWhiteSpace(txtPassEe.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
				return;
			}

			string query = "INSERT INTO Employee (EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress, UserName, PassWord) VALUES (@FullName, @Phone, @Email, @Address, @UserName, @PassWord)";

			using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				try
				{
					con.Open();

					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@FullName", FullName);
						cmd.Parameters.AddWithValue("@Phone", Phone);
						cmd.Parameters.AddWithValue("@Email", Email);
						cmd.Parameters.AddWithValue("@Address", Address);
						cmd.Parameters.AddWithValue("@UserName", UserName);
						cmd.Parameters.AddWithValue("@PassWord", PassWord);

						cmd.ExecuteNonQuery();

						MessageBox.Show("Đăng ký khách hàng thành công!");

						txtNameEe.Clear();
						txtPhoneEe.Clear();
						txtEmailEe.Clear();
						txtAddressEe.Clear();
						txtUserEe.Clear();
						txtPassEe.Clear();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
				}
			}
		}

		private void btLogInEe_Click(object sender, EventArgs e)
		{
			FormLogIn formLogIn = new FormLogIn();
			formLogIn.Show();
			this.Hide();
		}
	}
}

