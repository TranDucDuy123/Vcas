namespace ASM
{
	partial class FormManagement
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
			this.btCr = new System.Windows.Forms.Button();
			this.btEe = new System.Windows.Forms.Button();
			this.btPr = new System.Windows.Forms.Button();
			this.btOrder = new System.Windows.Forms.Button();
			this.btOrderDs = new System.Windows.Forms.Button();
			this.btSl = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btCr
			// 
			this.btCr.Location = new System.Drawing.Point(163, 92);
			this.btCr.Name = "btCr";
			this.btCr.Size = new System.Drawing.Size(97, 54);
			this.btCr.TabIndex = 0;
			this.btCr.Text = "Customer Management";
			this.btCr.UseVisualStyleBackColor = true;
			this.btCr.Click += new System.EventHandler(this.btCr_Click);
			// 
			// btEe
			// 
			this.btEe.Location = new System.Drawing.Point(332, 92);
			this.btEe.Name = "btEe";
			this.btEe.Size = new System.Drawing.Size(97, 54);
			this.btEe.TabIndex = 1;
			this.btEe.Text = "Employee Management";
			this.btEe.UseVisualStyleBackColor = true;
			this.btEe.Click += new System.EventHandler(this.btEe_Click);
			// 
			// btPr
			// 
			this.btPr.Location = new System.Drawing.Point(526, 92);
			this.btPr.Name = "btPr";
			this.btPr.Size = new System.Drawing.Size(97, 54);
			this.btPr.TabIndex = 2;
			this.btPr.Text = "Product Management";
			this.btPr.UseVisualStyleBackColor = true;
			this.btPr.Click += new System.EventHandler(this.btPr_Click);
			// 
			// btOrder
			// 
			this.btOrder.Location = new System.Drawing.Point(163, 215);
			this.btOrder.Name = "btOrder";
			this.btOrder.Size = new System.Drawing.Size(97, 54);
			this.btOrder.TabIndex = 3;
			this.btOrder.Text = "Order";
			this.btOrder.UseVisualStyleBackColor = true;
			this.btOrder.Click += new System.EventHandler(this.btOrder_Click);
			// 
			// btOrderDs
			// 
			this.btOrderDs.Location = new System.Drawing.Point(332, 215);
			this.btOrderDs.Name = "btOrderDs";
			this.btOrderDs.Size = new System.Drawing.Size(97, 54);
			this.btOrderDs.TabIndex = 4;
			this.btOrderDs.Text = "Order Dsetails";
			this.btOrderDs.UseVisualStyleBackColor = true;
			this.btOrderDs.Click += new System.EventHandler(this.btOrderDs_Click);
			// 
			// btSl
			// 
			this.btSl.Location = new System.Drawing.Point(526, 215);
			this.btSl.Name = "btSl";
			this.btSl.Size = new System.Drawing.Size(97, 54);
			this.btSl.TabIndex = 5;
			this.btSl.Text = "Statistical";
			this.btSl.UseVisualStyleBackColor = true;
			this.btSl.Click += new System.EventHandler(this.btSl_Click);
			// 
			// FormManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(809, 415);
			this.Controls.Add(this.btSl);
			this.Controls.Add(this.btOrderDs);
			this.Controls.Add(this.btOrder);
			this.Controls.Add(this.btPr);
			this.Controls.Add(this.btEe);
			this.Controls.Add(this.btCr);
			this.Name = "FormManagement";
			this.Text = "FormManagement";
			this.Load += new System.EventHandler(this.FormManagement_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btCr;
		private System.Windows.Forms.Button btEe;
		private System.Windows.Forms.Button btPr;
		private System.Windows.Forms.Button btOrder;
		private System.Windows.Forms.Button btOrderDs;
		private System.Windows.Forms.Button btSl;
	}
}