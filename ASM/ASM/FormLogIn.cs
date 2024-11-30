using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ASM
{
	public partial class FormLogIn : Form
	{
		string connectstring = @"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
		public FormLogIn()
		{
			InitializeComponent();
		}

		private void btLogIn_Click(object sender, EventArgs e)
		{
			string username = txtUser.Text.Trim();
			string password = txtPass.Text.Trim();

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Sử dụng một kết nối duy nhất cho cả hai truy vấn
			using (SqlConnection connection = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				connection.Open();

				// Kiểm tra tài khoản trong bảng KhachHang
				string queryCustomer = "SELECT COUNT(*) FROM Customers WHERE UserName = @User AND PassWord = @Pass";
				using (SqlCommand cmdCustomer = new SqlCommand(queryCustomer, connection))
				{
					cmdCustomer.Parameters.AddWithValue("@User", username);
					cmdCustomer.Parameters.AddWithValue("@Pass", password);

					int customerCount = (int)cmdCustomer.ExecuteScalar();

					if (customerCount > 0)
					{
						MessageBox.Show("Đăng nhập thành công với tư cách khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						FormMenuShop formMenuShop = new FormMenuShop();
						formMenuShop.Show();
						this.Hide();
						return; // Thoát khi đã đăng nhập thành công với tư cách khách hàng
					}
				}

				// Kiểm tra tài khoản trong bảng Nhân Viên và lấy chức vụ
				string queryEmployee = "SELECT EmployeeRights FROM Employee WHERE UserName = @Username AND PassWord = @Password";
				using (SqlCommand cmdEmployee = new SqlCommand(queryEmployee, connection))
				{
					cmdEmployee.Parameters.AddWithValue("@Username", username);
					cmdEmployee.Parameters.AddWithValue("@Password", password);

					// Lấy vai trò (Role) của nhân viên từ cơ sở dữ liệu
					string EmployeeRights = cmdEmployee.ExecuteScalar() as string;

					if (!string.IsNullOrEmpty(EmployeeRights))
					{
						// Mở form quản lý với vai trò tương ứng
						FormManagement formManagement = new FormManagement(EmployeeRights);
						formManagement.Show();
						this.Hide();
					}
					else
					{
						// Nếu không có tài khoản nào khớp
						MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btRegister_Click(object sender, EventArgs e)
		{
			FormRegister formRegister = new FormRegister();
			formRegister.Show();
			this.Hide();
		}
	}
}

		


