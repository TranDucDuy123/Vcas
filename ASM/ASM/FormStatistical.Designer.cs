using System.Windows.Forms;

namespace ASM
{
	partial class FormStatistical
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistical));
            this.lb = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbTotalProducts = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotalRevenue = new System.Windows.Forms.Label();
            this.lbTotalSold = new System.Windows.Forms.Label();
            this.lbRemainingStock = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.ControlText;
            label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label2.Location = new System.Drawing.Point(53, 121);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(95, 13);
            label2.TabIndex = 7;
            label2.Text = "Tổng số sản phẩm";
            // 
            // lb
            // 
            this.lb.ErrorImage = ((System.Drawing.Image)(resources.GetObject("lb.ErrorImage")));
            this.lb.Image = ((System.Drawing.Image)(resources.GetObject("lb.Image")));
            this.lb.InitialImage = ((System.Drawing.Image)(resources.GetObject("lb.InitialImage")));
            this.lb.Location = new System.Drawing.Point(37, 15);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(111, 103);
            this.lb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lb.TabIndex = 1;
            this.lb.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(222, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(105, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(424, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(98, 103);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(621, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(104, 103);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // lbTotalProducts
            // 
            this.lbTotalProducts.AutoSize = true;
            this.lbTotalProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTotalProducts.ForeColor = System.Drawing.Color.Cyan;
            this.lbTotalProducts.Location = new System.Drawing.Point(46, 150);
            this.lbTotalProducts.Name = "lbTotalProducts";
            this.lbTotalProducts.Size = new System.Drawing.Size(0, 55);
            this.lbTotalProducts.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tổng doanh thu trong tháng qua";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng số sản phẩm bán ra tháng qua";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(618, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tình trạng tồn kho";
            // 
            // lbTotalRevenue
            // 
            this.lbTotalRevenue.AutoSize = true;
            this.lbTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTotalRevenue.ForeColor = System.Drawing.Color.Cyan;
            this.lbTotalRevenue.Location = new System.Drawing.Point(235, 150);
            this.lbTotalRevenue.Name = "lbTotalRevenue";
            this.lbTotalRevenue.Size = new System.Drawing.Size(78, 55);
            this.lbTotalRevenue.TabIndex = 11;
            this.lbTotalRevenue.Text = "30";
            // 
            // lbTotalSold
            // 
            this.lbTotalSold.AutoSize = true;
            this.lbTotalSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTotalSold.ForeColor = System.Drawing.Color.Cyan;
            this.lbTotalSold.Location = new System.Drawing.Point(432, 150);
            this.lbTotalSold.Name = "lbTotalSold";
            this.lbTotalSold.Size = new System.Drawing.Size(78, 55);
            this.lbTotalSold.TabIndex = 12;
            this.lbTotalSold.Text = "30";
            // 
            // lbRemainingStock
            // 
            this.lbRemainingStock.AutoSize = true;
            this.lbRemainingStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbRemainingStock.ForeColor = System.Drawing.Color.Cyan;
            this.lbRemainingStock.Location = new System.Drawing.Point(634, 150);
            this.lbRemainingStock.Name = "lbRemainingStock";
            this.lbRemainingStock.Size = new System.Drawing.Size(78, 55);
            this.lbRemainingStock.TabIndex = 13;
            this.lbRemainingStock.Text = "30";
            // 
            // FormStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 444);
            this.Controls.Add(this.lbRemainingStock);
            this.Controls.Add(this.lbTotalSold);
            this.Controls.Add(this.lbTotalRevenue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.lbTotalProducts);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lb);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormStatistical";
            this.Text = "FormStatistical";
            ((System.ComponentModel.ISupportInitialize)(this.lb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion
        private PictureBox lb;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Label lbTotalProducts;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lbTotalRevenue;
        private Label lbTotalSold;
        private Label lbRemainingStock;
    }
}