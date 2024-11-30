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
	public partial class FormEmployees : Form
	{
		String connectstring = @"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt;
		DataTable dt = new DataTable();
		public FormEmployees()
		{
			InitializeComponent();
		}

		private void FormEmployee_Load(object sender, EventArgs e)
		{
			LoadEmployees();
		}
		private void LoadEmployees()
		{
			con = new SqlConnection(connectstring);
			try
			{
				con.Open();
				cmd = new SqlCommand("SELECT * FROM Employee", con);
				adt = new SqlDataAdapter(cmd);
				dt.Clear();
				adt.Fill(dt);
				dataEe.DataSource = dt;
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

		private void btLoadEe_Click(object sender, EventArgs e)
		{
			LoadEmployees();
			txtEmployeeID.Clear();
			txtEmployeeName.Clear();
			txtEmployeePhone.Clear();
			txtEmployeeEmail.Clear();
			txtEmployeeAddress.Clear();
			txtUserEe.Clear();
			txtPassEe.Clear();
			cbEmployeeRights.SelectedIndex = -1;
			MessageBox.Show("Data has been refreshed successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
			txtEmployeeID.ReadOnly = false;
			txtEmployeeName.ReadOnly = false;
			txtUserEe.ReadOnly = false;
		}

		private void btAddEe_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeePhone.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeEmail.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeAddress.Text) ||
				string.IsNullOrWhiteSpace(txtUserEe.Text) ||
				string.IsNullOrWhiteSpace(txtPassEe.Text) ||
				cbEmployeeRights.SelectedIndex == -1)
			{
				MessageBox.Show("Please fill in all information.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string selectedRole = cbEmployeeRights.SelectedItem.ToString();

			using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				using (SqlCommand cmd = new SqlCommand("INSERT INTO Employee (EmployeeName, EmployeePhone, EmployeeEmail, EmployeeAddress, UserName, PassWord, EmployeeRights) VALUES (@Name, @Phone, @Email, @Address, @UserName, @Pass, @Rights)", con))
				{
					cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
					cmd.Parameters.AddWithValue("@Phone", txtEmployeePhone.Text);
					cmd.Parameters.AddWithValue("@Email", txtEmployeeEmail.Text);
					cmd.Parameters.AddWithValue("@Address", txtEmployeeAddress.Text);
					cmd.Parameters.AddWithValue("@UserName", txtUserEe.Text);
					cmd.Parameters.AddWithValue("@Pass", txtPassEe.Text);
					cmd.Parameters.AddWithValue("@Rights", selectedRole);

					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadEmployees();
							MessageBox.Show("Add employee successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

							txtEmployeeID.Clear();
							txtEmployeeName.Clear();
							txtEmployeePhone.Clear();
							txtEmployeeEmail.Clear();
							txtEmployeeAddress.Clear();
							txtUserEe.Clear();
							txtPassEe.Clear();

							cbEmployeeRights.SelectedIndex = -1;
						}
						else
						{
							MessageBox.Show("Add employee failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					catch (Exception ex)
					{

						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void dataEe_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataEe.Rows[e.RowIndex];

				txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
				txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
				txtEmployeePhone.Text = row.Cells["EmployeePhone"].Value.ToString();
				txtEmployeeEmail.Text = row.Cells["EmployeeEmail"].Value.ToString();
				txtEmployeeAddress.Text = row.Cells["EmployeeAddress"].Value.ToString();
				txtUserEe.Text = row.Cells["UserName"].Value.ToString();
				txtPassEe.Text = row.Cells["PassWord"].Value.ToString();

				txtEmployeeID.ReadOnly = true;
				txtEmployeeName.ReadOnly = true;
				txtUserEe.ReadOnly = true;

				string employeeRights = row.Cells["EmployeeRights"].Value.ToString();
				if (cbEmployeeRights.Items.Contains(employeeRights))
				{
					cbEmployeeRights.SelectedItem = employeeRights;
				}
				else
				{
					cbEmployeeRights.SelectedIndex = -1;
				}
			}
		}

		private void btEditEe_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtEmployeePhone.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeEmail.Text) ||
				string.IsNullOrWhiteSpace(txtEmployeeAddress.Text) ||
				cbEmployeeRights.SelectedIndex == -1)
			{
				MessageBox.Show("No information found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
			{
				string query = "UPDATE Employee SET EmployeePhone = @Phone, EmployeeEmail = @Email, EmployeeAddress = @Address, PassWord = @Pass, EmployeeRights = @Rights  WHERE EmployeeID = @ID";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@ID", txtEmployeeID.Text);
					cmd.Parameters.AddWithValue("@Phone", txtEmployeePhone.Text);
					cmd.Parameters.AddWithValue("@Email", txtEmployeeEmail.Text);
					cmd.Parameters.AddWithValue("@Address", txtEmployeeAddress.Text);
					cmd.Parameters.AddWithValue("@Pass", txtPassEe.Text);
					cmd.Parameters.AddWithValue("@Rights", cbEmployeeRights.SelectedItem.ToString());
					try
					{
						con.Open();
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							MessageBox.Show("Edit employee successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

							txtEmployeeID.Clear();
							txtEmployeeName.Clear();
							txtEmployeePhone.Clear();
							txtEmployeeEmail.Clear();
							txtEmployeeAddress.Clear();
							txtUserEe.Clear();
							txtPassEe.Clear();
							cbEmployeeRights.SelectedIndex = -1;
							txtEmployeeID.ReadOnly = false;
							txtEmployeeName.ReadOnly = false;
							txtUserEe.ReadOnly = false;

							LoadEmployees();
						}
						else
						{
							MessageBox.Show("Cannot change employee information.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btDeleteEe_Click(object sender, EventArgs e)
		{
			if (dataEe.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select employee information to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string employeeID = dataEe.SelectedRows[0].Cells["EmployeeID"].Value.ToString();

			DialogResult confirmResult = MessageBox.Show(
				"Are you sure you want to delete this employee?",
				"Confirm deletion",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (confirmResult == DialogResult.Yes)
			{
				using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True"))
				{
					string query = "DELETE FROM Employee WHERE EmployeeID = @ID";

					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@ID", employeeID);

						try
						{
							con.Open();
							int rowsAffected = cmd.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								LoadEmployees();
								txtEmployeeID.Clear();
								txtEmployeeName.Clear();
								txtEmployeePhone.Clear();
								txtEmployeeEmail.Clear();
								txtEmployeeAddress.Clear();
								txtUserEe.Clear();
								txtPassEe.Clear();
								cbEmployeeRights.SelectedIndex = -1;
								txtEmployeeID.ReadOnly = false;
								txtEmployeeName.ReadOnly = false;
								txtUserEe.ReadOnly = false;
								txtPassEe.ReadOnly = false;

								MessageBox.Show("Delete employee successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show("No employee information found to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		private void btSearchEe_Click(object sender, EventArgs e)
		{
			string employeeID = txtEmployeeID.Text.Trim();
			string employeeName = txtEmployeeName.Text.Trim();

			if (string.IsNullOrWhiteSpace(employeeID) && string.IsNullOrWhiteSpace(employeeName))
			{
				MessageBox.Show("Please enter at least one search condition (ID or Name).");
				return;
			}

			StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Employee WHERE 1 = 1");

			if (!string.IsNullOrWhiteSpace(employeeID))
			{
				queryBuilder.Append(" AND EmployeeID = @ID");
			}

			if (!string.IsNullOrWhiteSpace(employeeName))
			{
				queryBuilder.Append(" AND EmployeeName LIKE @Name");
			}

			using (SqlConnection con = new SqlConnection(@"Data Source=DYBALY;Initial Catalog=ASM1;Integrated Security=True;TrustServerCertificate=True"))
			{
				using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con))
				{
					if (!string.IsNullOrWhiteSpace(employeeID))
					{
						cmd.Parameters.AddWithValue("@ID", employeeID);
					}

					if (!string.IsNullOrWhiteSpace(employeeName))
					{
						cmd.Parameters.AddWithValue("@Name", "%" + employeeName + "%");
					}
					try
					{
						con.Open();
						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();
						da.Fill(dt);

						dataEe.DataSource = dt;

						if (dt.Rows.Count > 0)
						{

							MessageBox.Show("Find Employee!");
							txtEmployeeID.Clear();
							txtEmployeeName.Clear();
							txtEmployeeID.ReadOnly = false;
							txtEmployeeName.ReadOnly = false;
							txtUserEe.ReadOnly = false;
							txtPassEe.ReadOnly = false;
						}
						else
						{
							MessageBox.Show("No Employee found!");
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
