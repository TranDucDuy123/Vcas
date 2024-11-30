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
	public partial class FormOrder : Form
	{
		String connectstring = @"Data Source=Dybaly;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt;
		DataTable dt = new DataTable();
		public FormOrder()
		{
			InitializeComponent();
		}

		private void FormOrder_Load(object sender, EventArgs e)
		{
			LoadOrder();
		}
		private void LoadOrder()
		{
			con = new SqlConnection(connectstring);

			try
			{
				con.Open();
				cmd = new SqlCommand("SELECT * FROM Orders", con);
				adt = new SqlDataAdapter(cmd);
				dt.Clear();  
				adt.Fill(dt);
				dataOr.DataSource = dt; 

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
			finally
			{
				if (con.State == ConnectionState.Open)
				{
					con.Close();
				}
			}
		}

		private void btLoad_Click(object sender, EventArgs e)
		{
			LoadOrder();
			txtOrderID.Clear();
			txtCustomersID.Clear();
			txtEmployeeID.Clear();
			txtOrderDate.Clear();
			txtOrderTotal.Clear();
			MessageBox.Show("Information has been updated!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
			txtOrderID.ReadOnly = false;
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtOrderID.Text) ||
				string.IsNullOrWhiteSpace(txtCustomersID.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
				string.IsNullOrWhiteSpace(txtOrderDate.Text) ||
				string.IsNullOrWhiteSpace(txtOrderTotal.Text))
			{
				MessageBox.Show("Please fill in all information.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (SqlConnection con = new SqlConnection(@"Data Source=Dybaly;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				cmd.Parameters.AddWithValue("@OrderDate", txtOrderDate.Text);
				using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders (OrderID, CustomersID , EmployeeID , OrderDate , OrderTotal) VALUES (@OrderID, @CustomersID,  @EmployeeID, @OrderDate, @OrderTotal)", con))
				{
					cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
					cmd.Parameters.AddWithValue("@CustomersID", txtCustomersID.Text);
					cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
					cmd.Parameters.AddWithValue("@OrderDate", txtOrderDate.Text);
					cmd.Parameters.AddWithValue("@OrderTotal", txtOrderTotal.Text);


					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadOrder(); ; 
							MessageBox.Show("Add order information successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtOrderID.Clear();
							txtCustomersID.Clear();
							txtEmployeeID.Clear();
							txtOrderDate.Clear();
							txtOrderTotal.Clear();
						}
						else
						{
							MessageBox.Show("Add failed order information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void dataOr_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataOr.Rows[e.RowIndex];

				txtOrderID.Text = row.Cells["OrderID"].Value.ToString();
				txtCustomersID.Text = row.Cells["CustomersID"].Value.ToString();
				txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
				txtOrderDate.Text = row.Cells["OrderDate"].Value.ToString();
				txtOrderTotal.Text = row.Cells["OrderTotal"].Value.ToString();
				txtOrderID.ReadOnly = true;
			}
		}
		private void btEdit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtOrderID.Text) ||
				string.IsNullOrWhiteSpace(txtCustomersID.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
				string.IsNullOrWhiteSpace(txtOrderDate.Text) ||
				string.IsNullOrWhiteSpace(txtOrderTotal.Text))
			{
				MessageBox.Show("No information found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string connectionString = @"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";

			string query = "UPDATE Orders SET CustomersID = @CustomersID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, OrderTotal = @OrderTotal WHERE OrderID = @OrderID";

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
					cmd.Parameters.AddWithValue("@CustomersID", txtCustomersID.Text);
					cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
					cmd.Parameters.AddWithValue("@OrderDate", DateTime.Parse(txtOrderDate.Text)); 
					cmd.Parameters.AddWithValue("@OrderTotal", decimal.Parse(txtOrderTotal.Text)); 

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadOrder(); 
							MessageBox.Show("Information updated successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

					
							txtOrderID.Clear();
							txtCustomersID.Clear();
							txtEmployeeID.Clear();
							txtOrderDate.Clear();
							txtOrderTotal.Clear();
							txtOrderID.ReadOnly = false; 
						}
						else
						{
							MessageBox.Show("Update information failed.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btDelete_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtOrderID.Text))
			{
				MessageBox.Show("Please select information to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult confirm = MessageBox.Show("Are you sure you want to delete this information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirm == DialogResult.No)
			{
				return;
			}

			using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				string query = "DELETE FROM Orders WHERE OrderID = @OrderID";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = int.Parse(txtOrderID.Text);

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadOrder(); ;
							MessageBox.Show("Delete information successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtOrderID.Clear();
							txtCustomersID.Clear();
							txtEmployeeID.Clear();
							txtOrderDate.Clear();
							txtOrderTotal.Clear();
							txtOrderID.ReadOnly = false;
						}
						else
						{
							MessageBox.Show("No information found to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btSearch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtOrderID.Text))
			{
				MessageBox.Show("Please enter OrderID to search.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				string query = "SELECT * FROM Orders WHERE OrderID = @OrderID";
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

					try
					{
						con.Open();
						SqlDataAdapter adapter = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();

						adapter.Fill(dt);

						dataOr.DataSource = dt;

						if (dt.Rows.Count > 0)
						{
							MessageBox.Show("Search success!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("No data found with entered OrderID.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
	}
}
