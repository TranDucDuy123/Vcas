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
using System.Security.Cryptography;

namespace ASM
{
	public partial class FormCustomers : Form
	{
		String connectstring = @"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt;
		DataTable dt = new DataTable();
		public FormCustomers()
		{
			InitializeComponent();
		}

		private void FormCustomers_Load(object sender, EventArgs e)
		{
			LoadCustomers();
		}
		private void LoadCustomers()
		{
			con = new SqlConnection(connectstring);
			try
			{
				con.Open();
				cmd = new SqlCommand("SELECT * FROM Customers", con);
				adt = new SqlDataAdapter(cmd);
				dt.Clear();
				adt.Fill(dt);
				dataCr.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
			finally
			{
				if (con.State == ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		private void btLoadCr_Click(object sender, EventArgs e)
		{
			LoadCustomers(); // Làm mới bảng dữ liệu khách hàng
			txtCustomerID.Clear();
			txtCustomerName.Clear();
			txtCustomerPhone.Clear();
			txtCustomerEmail.Clear();
			txtCustomerAddress.Clear();
			txtUserCr.Clear();
			txtPassCr.Clear();
			MessageBox.Show("Bảng dữ liệu đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btAddCr_Click(object sender, EventArgs e)
		{
			// Kiểm tra các TextBox không được để trống
			if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
				string.IsNullOrWhiteSpace(txtCustomerPhone.Text) ||
				string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
				string.IsNullOrWhiteSpace(txtCustomerAddress.Text) ||
				string.IsNullOrWhiteSpace(txtUserCr.Text) ||
				string.IsNullOrWhiteSpace(txtPassCr.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin vào tất cả các trường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CustomersName, CustomersPhone, CustomersEmail, CustomersAddress, UserName, PassWord) VALUES (@Name, @Phone, @Email, @Address, @UserName, @Pass)", con))
				{
					// Mã hóa mật khẩu bằng SHA256
					string hashedPassword = HashPassword(txtPassCr.Text);

					cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
					cmd.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text);
					cmd.Parameters.AddWithValue("@Email", txtCustomerEmail.Text);
					cmd.Parameters.AddWithValue("@Address", txtCustomerAddress.Text);
					cmd.Parameters.AddWithValue("@UserName", txtUserCr.Text);
					cmd.Parameters.AddWithValue("@Pass", hashedPassword);

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadCustomers(); // Tải lại dữ liệu sau khi thêm
							MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCustomerID.Clear();
							txtCustomerName.Clear();
							txtCustomerPhone.Clear();
							txtCustomerEmail.Clear();
							txtCustomerAddress.Clear();
							txtUserCr.Clear();
							txtPassCr.Clear();
						}
						else
						{
							MessageBox.Show("Thêm khách hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		// Phương thức mã hóa mật khẩu
		private string HashPassword(string password)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// Chuyển mật khẩu thành mảng byte
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

				// Chuyển mảng byte thành chuỗi hex
				StringBuilder builder = new StringBuilder();
				foreach (byte b in bytes)
				{
					builder.Append(b.ToString("x2"));
				}
				return builder.ToString();
			}
		}

		private void dataCr_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Kiểm tra nếu không có hàng nào được chọn
			if (e.RowIndex >= 0)
			{
				// Lấy dữ liệu từ hàng được chọn
				DataGridViewRow row = dataCr.Rows[e.RowIndex];

				// Đẩy dữ liệu từ hàng lên các TextBox
				txtCustomerID.Text = row.Cells["CustomersID"].Value.ToString();
				txtCustomerName.Text = row.Cells["CustomersName"].Value.ToString();
				txtCustomerPhone.Text = row.Cells["CustomersPhone"].Value.ToString();
				txtCustomerEmail.Text = row.Cells["CustomersEmail"].Value.ToString();
				txtCustomerAddress.Text = row.Cells["CustomersAddress"].Value.ToString();
				txtUserCr.Text = row.Cells["UserName"].Value.ToString();
				txtPassCr.Text = row.Cells["PassWord"].Value.ToString();

				// Khóa các TextBox: ID, Name, UserName, Password
				txtCustomerID.ReadOnly = true;
				txtCustomerName.ReadOnly = true;
				txtUserCr.ReadOnly = true;
				txtPassCr.ReadOnly = true;
			}
		}


		private void btEditCr_Click(object sender, EventArgs e)
		{
			// Kiểm tra các text (phone, email, address) có trống không
			if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text) ||
				string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
				string.IsNullOrWhiteSpace(txtCustomerAddress.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				string query = "UPDATE Customers SET CustomersPhone = @Phone, CustomersEmail = @Email, CustomersAddress = @Address WHERE CustomersID = @ID";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					// Gán giá trị từ TextBox vào các tham số
					cmd.Parameters.AddWithValue("@ID", txtCustomerID.Text); // ID không sửa nhưng dùng để tìm hàng cần chỉnh sửa
					cmd.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text);
					cmd.Parameters.AddWithValue("@Email", txtCustomerEmail.Text);
					cmd.Parameters.AddWithValue("@Address", txtCustomerAddress.Text);

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show("Chỉnh sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtCustomerID.Clear();
							txtCustomerName.Clear();
							txtCustomerPhone.Clear();
							txtCustomerEmail.Clear();
							txtCustomerAddress.Clear();
							txtUserCr.Clear();
							txtPassCr.Clear();

							// Mở khóa 4 TextBox sau khi chỉnh sửa
							txtCustomerID.ReadOnly = false;
							txtCustomerName.ReadOnly = false;
							txtUserCr.ReadOnly = false;
							txtPassCr.ReadOnly = false;

							LoadCustomers(); // Tải lại dữ liệu sau khi chỉnh sửa
						}
						else
						{
							MessageBox.Show("Không có thay đổi nào được thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btDeleteCr_Click(object sender, EventArgs e)
		{
			// Kiểm tra nếu không có hàng nào được chọn
			if (dataCr.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Lấy ID từ hàng được chọn
			string customerID = dataCr.SelectedRows[0].Cells["CustomersID"].Value.ToString();

			// Hiển thị hộp thoại xác nhận
			DialogResult confirmResult = MessageBox.Show(
				"Bạn có chắc chắn muốn xóa khách hàng này?",
				"Xác nhận xóa",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (confirmResult == DialogResult.Yes)
			{
				using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
				{
					string query = "DELETE FROM Customers WHERE CustomersID = @ID";

					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@ID", customerID);

						try
						{
							con.Open();
							int rowsAffected = cmd.ExecuteNonQuery();

							if (rowsAffected > 0)
							{

								LoadCustomers(); // Tải lại dữ liệu sau khi xóa
								txtCustomerID.Clear();
								txtCustomerName.Clear();
								txtCustomerPhone.Clear();
								txtCustomerEmail.Clear();
								txtCustomerAddress.Clear();
								txtUserCr.Clear();
								txtPassCr.Clear();
								txtCustomerID.ReadOnly = false;
								txtCustomerName.ReadOnly = false;
								txtUserCr.ReadOnly = false;
								txtPassCr.ReadOnly = false;
								MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void btSearchCr_Click(object sender, EventArgs e)
		{
			// Lấy giá trị từ ô nhập
			string customerID = txtCustomerID.Text.Trim();
			string customerName = txtCustomerName.Text.Trim();

			// Kiểm tra nếu không có điều kiện tìm kiếm nào
			if (string.IsNullOrWhiteSpace(customerID) && string.IsNullOrWhiteSpace(customerName))
			{
				MessageBox.Show("Vui lòng nhập ít nhất một điều kiện tìm kiếm (ID hoặc Tên).");
				return;
			}

			// Tạo câu lệnh SQL
			StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Customers WHERE 1 = 1");

			// Thêm điều kiện vào câu lệnh nếu có thông tin tìm kiếm
			if (!string.IsNullOrWhiteSpace(customerID))
			{
				queryBuilder.Append(" AND CustomersID = @ID");
			}

			if (!string.IsNullOrWhiteSpace(customerName))
			{
				queryBuilder.Append(" AND CustomersName LIKE @Name");
			}

			// Kết nối tới cơ sở dữ liệu và thực thi truy vấn
			using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con))
				{
					// Thêm tham số cho câu lệnh SQL
					if (!string.IsNullOrWhiteSpace(customerID))
					{
						cmd.Parameters.AddWithValue("@ID", customerID); // Gán giá trị cho @ID
					}

					if (!string.IsNullOrWhiteSpace(customerName))
					{
						cmd.Parameters.AddWithValue("@Name", "%" + customerName + "%"); // Thêm dấu % để tìm kiếm theo tên
					}

					try
					{
						con.Open(); // Mở kết nối
						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();
						da.Fill(dt);

						// Kiểm tra và hiển thị dữ liệu
						if (dt.Rows.Count > 0)
						{
							dataCr.DataSource = dt; // Gắn dữ liệu vào DataGridView
							MessageBox.Show("Tìm thấy khách hàng!");

							// Reset các ô nhập liệu
							txtCustomerID.Clear();
							txtCustomerName.Clear();
						}
						else
						{
							MessageBox.Show("Không tìm thấy khách hàng nào!");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi: " + ex.Message); // Hiển thị lỗi
					}
				}
			}
		}
	}
}

