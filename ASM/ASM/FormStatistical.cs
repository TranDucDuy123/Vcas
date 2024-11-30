using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormStatistical : Form
    {
        // Cấu hình kết nối cơ sở dữ liệu
        String connectstring = @"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();

        public FormStatistical()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                con = new SqlConnection(connectstring);
                con.Open();

                // 1. Thống kê tổng số sản phẩm
                cmd = new SqlCommand("SELECT COUNT(*) FROM Products", con);
                int totalProducts = (int)cmd.ExecuteScalar();
                lbTotalProducts.Text = "" + totalProducts;

                // 2. Thống kê tổng doanh thu trong 1 tháng qua
                cmd = new SqlCommand(@"
                SELECT SUM(oi.Quantity * p.ProductSellingPrice) 
                FROM OrderDetails oi
                JOIN Products p ON oi.ProductID = p.ProductID
                JOIN Orders o ON oi.OrderID = o.OrderID
                WHERE o.OrderDate >= DATEADD(MONTH, -1, GETDATE())", con);

                object result = cmd.ExecuteScalar();
                decimal totalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                lbTotalRevenue.Text = "" + totalRevenue.ToString("C");


                // 3. Thống kê tổng số sản phẩm bán ra trong tháng qua
                cmd = new SqlCommand(@"
                SELECT SUM(oi.Quantity)
                FROM OrderDetails oi
                JOIN Products p ON oi.ProductID = p.ProductID
                JOIN Orders o ON oi.OrderID = o.OrderID
                WHERE o.OrderDate >= DATEADD(MONTH, -1, GETDATE())", con);

                object result1 = cmd.ExecuteScalar();
                int totalSold = result != DBNull.Value ? Convert.ToInt32(result1) : 0;
                lbTotalSold.Text = "" + totalSold.ToString();

                // 4. Thống kê hàng tồn kho (tổng số sản phẩm - tổng số sản phẩm đã bán)
                // Thống kê tổng số sản phẩm trong kho (tính cho từng sản phẩm)
                cmd = new SqlCommand("SELECT SUM(ProductQuantity) FROM Products", con);
                result = cmd.ExecuteScalar();
                int totalStock = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                // Lấy tổng số sản phẩm đã bán trong tháng qua từ bảng OrderDetails, kết hợp với bảng Orders để kiểm tra ngày đặt hàng
                cmd = new SqlCommand(@"
                SELECT SUM(oi.Quantity)
                FROM OrderDetails oi
                JOIN Orders o ON oi.OrderID = o.OrderID
                WHERE o.OrderDate >= DATEADD(MONTH, -1, GETDATE())", con);
                result = cmd.ExecuteScalar();
                int totalSoldInLastMonth = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                // Tính số lượng hàng tồn kho còn lại
                int remainingStock = totalStock - totalSoldInLastMonth;

                // Hiển thị kết quả trên giao diện
                lbRemainingStock.Text = remainingStock.ToString();


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
    }
}
