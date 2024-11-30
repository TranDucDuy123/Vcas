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
	public partial class FormOrderDsetails : Form
	{
		String connectstring = @"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt;
		DataTable dt = new DataTable();
		public FormOrderDsetails()
		{
			InitializeComponent();
		}

		private void FormOrderDsetails_Load(object sender, EventArgs e)
		{
			LoadOrderDetails();
		}
		private void LoadOrderDetails()
		{
			con = new SqlConnection(connectstring);

			try
			{
				con.Open();
				cmd = new SqlCommand("SELECT * FROM OrderDetails", con);
				adt = new SqlDataAdapter(cmd);
				dt.Clear();  
				adt.Fill(dt); 
				dataOd.DataSource = dt; 

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
			LoadOrderDetails();
			txtOrderID.Clear();
			txtProductID.Clear();
			txtQuantity.Clear();
			txtPrice.Clear();
			MessageBox.Show("Data has been refreshed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
			txtOrderID.ReadOnly = false;
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtOrderID.Text) ||
				string.IsNullOrWhiteSpace(txtProductID.Text) ||
				string.IsNullOrWhiteSpace(txtQuantity.Text) ||
				string.IsNullOrWhiteSpace(txtPrice.Text))
			{
				MessageBox.Show("Please fill in all information.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES (@OrderID, @ProductID, @Quantity, @Price)", con))
				{
					cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
					cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
					cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
					cmd.Parameters.AddWithValue("@Price", txtPrice.Text);

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadOrderDetails(); ; 
							MessageBox.Show("Add information successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtOrderID.Clear();
							txtProductID.Clear();
							txtQuantity.Clear();
							txtPrice.Clear();
						}
						else
						{
							MessageBox.Show("Add failure information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void dataOd_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataOd.Rows[e.RowIndex];

				txtOrderID.Text = row.Cells["OrderID"].Value.ToString();
				txtProductID.Text = row.Cells["ProductID"].Value.ToString();
				txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
				txtPrice.Text = row.Cells["Price"].Value.ToString();
				txtOrderID.ReadOnly = true;
			}
		}

		private void btEdit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtOrderID.Text) ||
				string.IsNullOrWhiteSpace(txtProductID.Text) ||
				string.IsNullOrWhiteSpace(txtQuantity.Text) ||
				string.IsNullOrWhiteSpace(txtPrice.Text))
			{
				MessageBox.Show("No information found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string connectionString = @"Data Source=DESKTOP-708AVGT;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string checkProductQuery = "SELECT COUNT(*) FROM Products WHERE ProductID = @ProductID";
					using (SqlCommand checkCmd = new SqlCommand(checkProductQuery, con))
					{
						checkCmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
						int productExists = (int)checkCmd.ExecuteScalar();

						if (productExists == 0)
						{
							MessageBox.Show("Information does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
					}
					string updateQuery = "UPDATE OrderDetails SET ProductID = @ProductID, Quantity = @Quantity, Price = @Price WHERE OrderID = @OrderID";
					using (SqlCommand cmd = new SqlCommand(updateQuery, con))
					{
						cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
						cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
						cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));
						cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));

						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadOrderDetails();
							MessageBox.Show("Order details updated successfully!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

							txtOrderID.Clear();
							txtProductID.Clear();
							txtQuantity.Clear();
							txtPrice.Clear();
							txtOrderID.ReadOnly = false;
						}
						else
						{
							MessageBox.Show("No records found to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				string query = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = int.Parse(txtOrderID.Text);

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadOrderDetails(); ;
							MessageBox.Show("Delete information successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtOrderID.Clear();
							txtProductID.Clear();
							txtQuantity.Clear();
							txtPrice.Clear();
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
				string query = "SELECT * FROM OrderDetails WHERE OrderID = @OrderID";
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

					try
					{
						con.Open();
						SqlDataAdapter adapter = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();

						adapter.Fill(dt);

						dataOd.DataSource = dt;

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
