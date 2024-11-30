using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;
using System.Drawing;


namespace ASM
{
    public partial class FormProduct : Form
    {
        string connectString = @"Data Source=DYBALY;Initial Catalog=ASMDATA;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        string imageDirectory = ConfigurationSettings.AppSettings["ImageDirectory"];
        string applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string selectedImagePath;

        public FormProduct()
        {
            InitializeComponent();
        }

        // Hàm Load sản phẩm từ cơ sở dữ liệu
        private void LoadProducts()
        {
            con = new SqlConnection(connectString);
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT TOP (1000) [ProductID], [ProductName], [ProductImportPrice], [ProductSellingPrice], [ProductSize], [ProductQuantity], [ProductStock], [ProductPhoto] FROM [ASMDATA].[dbo].[Products]", con);
                adt = new SqlDataAdapter(cmd);
                dt.Clear();
                adt.Fill(dt);
                dataPr.DataSource = dt; // Hiển thị dữ liệu vào DataGridView
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

      

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            string fullPath = Path.Combine(applicationDirectory, imageDirectory);
            LoadImageFiles(fullPath);
        }

        private void dataPr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu của dòng đã chọn
                DataGridViewRow row = dataPr.Rows[e.RowIndex];

                // Hiển thị các giá trị vào các TextBox
                txtID.Text = row.Cells["ProductID"].Value.ToString();
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtImport.Text = row.Cells["ProductImportPrice"].Value.ToString();
                txtSellling.Text = row.Cells["ProductSellingPrice"].Value.ToString();
                txtSize.Text = row.Cells["ProductSize"].Value.ToString();
                txtQuantity.Text = row.Cells["ProductQuantity"].Value.ToString();
                txtStock.Text = row.Cells["ProductStock"].Value.ToString();

                // Lấy giá trị của cột "ProductPhoto" (tên ảnh) từ dòng đã chọn
                string selectedImageName = row.Cells["ProductPhoto"].Value.ToString();

                // Kiểm tra xem có dữ liệu ảnh không
                if (!string.IsNullOrEmpty(selectedImageName))
                {
                    // Nếu có, gán giá trị ảnh cho ComboBox (giả sử ảnh đã có trong comboBox1)
                    comboBox1.SelectedItem = selectedImageName;
                }
            }
        }


        private void btSearch_Click(object sender, EventArgs e)
        {

        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            con = new SqlConnection(connectString);
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", txtID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product deleted successfully.");
                LoadProducts(); // Load lại danh sách sản phẩm
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
        private void btEdit_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            // Kiểm tra xem ComboBox có lựa chọn hợp lệ không (Ảnh sản phẩm)
            string selectedImageName = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedImageName))
            {
                MessageBox.Show("Please select an image from the combo box.");
                return;
            }

            con = new SqlConnection(connectString);
            try
            {
                con.Open();

                // Tạo câu lệnh SQL để cập nhật thông tin sản phẩm
                cmd = new SqlCommand("UPDATE Products SET ProductName = @ProductName, ProductImportPrice = @ProductImportPrice, ProductSellingPrice = @ProductSellingPrice, ProductSize = @ProductSize, ProductQuantity = @ProductQuantity, ProductStock = @ProductStock, ProductPhoto = @ProductPhoto WHERE ProductID = @ProductID", con);

                // Thêm các tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@ProductID", txtID.Text);
                cmd.Parameters.AddWithValue("@ProductName", txtName.Text);
                cmd.Parameters.AddWithValue("@ProductImportPrice", txtImport.Text);
                cmd.Parameters.AddWithValue("@ProductSellingPrice", txtSellling.Text);
                cmd.Parameters.AddWithValue("@ProductSize", txtSize.Text);
                cmd.Parameters.AddWithValue("@ProductQuantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@ProductStock", txtStock.Text);
                cmd.Parameters.AddWithValue("@ProductPhoto", selectedImageName);  // Thêm ảnh đã chọn từ ComboBox vào câu lệnh SQL

                // Thực thi câu lệnh UPDATE
                cmd.ExecuteNonQuery();

                // Thông báo thành công
                MessageBox.Show("Product updated successfully.");

                // Load lại danh sách sản phẩm
                LoadProducts();
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


        private void btAdd_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection(connectString);
            try
            {
                con.Open();

                // Kiểm tra xem ComboBox có lựa chọn hợp lệ không
                string selectedImageName = comboBox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedImageName))
                {
                    MessageBox.Show("Please select an image from the combo box.");
                    return; // Nếu không có ảnh nào được chọn, dừng thao tác thêm.
                }

                // Tạo câu lệnh SQL để thêm sản phẩm vào cơ sở dữ liệu
                cmd = new SqlCommand("INSERT INTO Products (ProductName, ProductImportPrice, ProductSellingPrice, ProductSize, ProductQuantity, ProductStock, ProductPhoto) " +
                                     "VALUES (@ProductName, @ProductImportPrice, @ProductSellingPrice, @ProductSize, @ProductQuantity, @ProductStock, @ProductPhoto)", con);

                // Thêm các tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@ProductName", txtName.Text);
                cmd.Parameters.AddWithValue("@ProductImportPrice", txtImport.Text);
                cmd.Parameters.AddWithValue("@ProductSellingPrice", txtSellling.Text);
                cmd.Parameters.AddWithValue("@ProductSize", txtSize.Text);
                cmd.Parameters.AddWithValue("@ProductQuantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@ProductStock", txtStock.Text);

                // Thêm tên ảnh được chọn vào tham số ProductPhoto
                cmd.Parameters.AddWithValue("@ProductPhoto", selectedImageName);

                // Thực thi câu lệnh SQL
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product added successfully.");

                // Tải lại danh sách sản phẩm
                LoadProducts();
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


        // Hàm để tải danh sách file ảnh từ thư mục và thêm vào comboBox
        private void LoadImageFiles(string directoryPath)
        {
            try
            {
                // Kiểm tra xem thư mục có tồn tại hay không
                if (Directory.Exists(directoryPath))
                {
                    // Lấy danh sách các file ảnh trong thư mục (chỉ lọc các file .jpg, .png, .jpeg, .bmp)
                    var imageFiles = Directory.GetFiles(directoryPath, "*.*")
                                              .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".jpeg") || s.EndsWith(".bmp"))
                                              .ToArray();

                    // Clear dữ liệu cũ trong comboBox trước khi thêm mới
                    comboBox1.Items.Clear();

                    // Thêm các tên file ảnh vào comboBox
                    foreach (var file in imageFiles)
                    {
                        comboBox1.Items.Add(Path.GetFileName(file)); // Lấy tên file mà không bao gồm đường dẫn
                    }
                }
                else
                {
                    MessageBox.Show("Thư mục không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải các file ảnh: " + ex.Message);
            }
        }

        // Sự kiện khi chọn item trong ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex >= 0)
    {
                // Lấy tên ảnh từ comboBox
                string selectedImageName = comboBox1.SelectedItem.ToString();

                // Đọc đường dẫn ảnh từ App.config
                string imageDirectory = ConfigurationSettings.AppSettings["ImageDirectory"];

                // Kiểm tra và đảm bảo rằng đường dẫn thư mục có dấu phân cách cuối
                if (!imageDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    imageDirectory += Path.DirectorySeparatorChar;
                }

                // Kết hợp đường dẫn thư mục và tên ảnh để có đường dẫn đầy đủ
                string selectedImagePath = Path.Combine(imageDirectory, selectedImageName);

                // Kiểm tra nếu ảnh tồn tại
                if (File.Exists(selectedImagePath))
                {
                    try
                    {
                        // Hiển thị ảnh trong PictureBox
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Image = Image.FromFile(selectedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ảnh: " + selectedImagePath);
                    pictureBox.Image = null; // Xóa ảnh cũ nếu có lỗi
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Chỉ lọc các file ảnh
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";

            // Mở hộp thoại chọn file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file ảnh đã chọn
                string selectedImagePath = openFileDialog.FileName;

                // Lấy tên file ảnh từ đường dẫn
                string selectedImageName = Path.GetFileName(selectedImagePath);

                // Lấy đường dẫn thư mục Images từ app.config
                string imagesDirectory = ConfigurationSettings.AppSettings["ImageDirectory"];

                // Kiểm tra nếu thư mục Images không tồn tại, tạo thư mục mới
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                // Đường dẫn đầy đủ đến file ảnh trong thư mục Images
                string destinationImagePath = Path.Combine(imagesDirectory, selectedImageName);

                // Sao chép ảnh vào thư mục Images
                try
                {
                    File.Copy(selectedImagePath, destinationImagePath, true); // true: ghi đè nếu đã tồn tại file
                    MessageBox.Show("Image uploaded successfully.");

                    // Hiển thị ảnh trong PictureBox
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    pictureBox.Image = Image.FromFile(destinationImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading image: " + ex.Message);
                }
            }
        }

        // Hàm được gọi khi Form khởi động để load ảnh vào ComboBox
    }
}
