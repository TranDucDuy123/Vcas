namespace ASM
{
	partial class FormOrder
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
			this.txtOrderTotal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtOrderDate = new System.Windows.Forms.TextBox();
			this.txtEmployeeID = new System.Windows.Forms.TextBox();
			this.txtCustomersID = new System.Windows.Forms.TextBox();
			this.txtOrderID = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btSearch = new System.Windows.Forms.Button();
			this.btDelete = new System.Windows.Forms.Button();
			this.btEdit = new System.Windows.Forms.Button();
			this.btAdd = new System.Windows.Forms.Button();
			this.btLoad = new System.Windows.Forms.Button();
			this.dataOr = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataOr)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOrderTotal
			// 
			this.txtOrderTotal.Location = new System.Drawing.Point(392, 453);
			this.txtOrderTotal.Name = "txtOrderTotal";
			this.txtOrderTotal.Size = new System.Drawing.Size(126, 22);
			this.txtOrderTotal.TabIndex = 55;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(313, 459);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 16);
			this.label3.TabIndex = 54;
			this.label3.Text = "Order Total: ";
			// 
			// txtOrderDate
			// 
			this.txtOrderDate.Location = new System.Drawing.Point(392, 425);
			this.txtOrderDate.Name = "txtOrderDate";
			this.txtOrderDate.Size = new System.Drawing.Size(126, 22);
			this.txtOrderDate.TabIndex = 53;
			// 
			// txtEmployeeID
			// 
			this.txtEmployeeID.Location = new System.Drawing.Point(157, 491);
			this.txtEmployeeID.Name = "txtEmployeeID";
			this.txtEmployeeID.Size = new System.Drawing.Size(122, 22);
			this.txtEmployeeID.TabIndex = 52;
			// 
			// txtCustomersID
			// 
			this.txtCustomersID.Location = new System.Drawing.Point(157, 453);
			this.txtCustomersID.Name = "txtCustomersID";
			this.txtCustomersID.Size = new System.Drawing.Size(122, 22);
			this.txtCustomersID.TabIndex = 51;
			// 
			// txtOrderID
			// 
			this.txtOrderID.Location = new System.Drawing.Point(157, 422);
			this.txtOrderID.Name = "txtOrderID";
			this.txtOrderID.Size = new System.Drawing.Size(122, 22);
			this.txtOrderID.TabIndex = 50;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(313, 428);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 16);
			this.label6.TabIndex = 49;
			this.label6.Text = "Order Date:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(56, 494);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 48;
			this.label7.Text = "Employee ID:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(54, 459);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 16);
			this.label8.TabIndex = 47;
			this.label8.Text = "Customers ID:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(54, 422);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 16);
			this.label9.TabIndex = 46;
			this.label9.Text = "Order ID: ";
			// 
			// btSearch
			// 
			this.btSearch.Location = new System.Drawing.Point(808, 422);
			this.btSearch.Name = "btSearch";
			this.btSearch.Size = new System.Drawing.Size(75, 23);
			this.btSearch.TabIndex = 45;
			this.btSearch.Text = "Search";
			this.btSearch.UseVisualStyleBackColor = true;
			this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
			// 
			// btDelete
			// 
			this.btDelete.Location = new System.Drawing.Point(685, 467);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(75, 23);
			this.btDelete.TabIndex = 44;
			this.btDelete.Text = "Delete";
			this.btDelete.UseVisualStyleBackColor = true;
			this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
			// 
			// btEdit
			// 
			this.btEdit.Location = new System.Drawing.Point(685, 422);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(75, 23);
			this.btEdit.TabIndex = 43;
			this.btEdit.Text = "Edit";
			this.btEdit.UseVisualStyleBackColor = true;
			this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
			// 
			// btAdd
			// 
			this.btAdd.Location = new System.Drawing.Point(556, 467);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(75, 23);
			this.btAdd.TabIndex = 42;
			this.btAdd.Text = "Add";
			this.btAdd.UseVisualStyleBackColor = true;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// btLoad
			// 
			this.btLoad.Location = new System.Drawing.Point(556, 422);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(75, 23);
			this.btLoad.TabIndex = 41;
			this.btLoad.Text = "Load";
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// dataOr
			// 
			this.dataOr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataOr.Location = new System.Drawing.Point(0, 1);
			this.dataOr.Name = "dataOr";
			this.dataOr.RowHeadersWidth = 51;
			this.dataOr.RowTemplate.Height = 24;
			this.dataOr.Size = new System.Drawing.Size(1022, 387);
			this.dataOr.TabIndex = 56;
			this.dataOr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataOr_CellContentClick);
			// 
			// FormOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1018, 544);
			this.Controls.Add(this.dataOr);
			this.Controls.Add(this.txtOrderTotal);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtOrderDate);
			this.Controls.Add(this.txtEmployeeID);
			this.Controls.Add(this.txtCustomersID);
			this.Controls.Add(this.txtOrderID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btSearch);
			this.Controls.Add(this.btDelete);
			this.Controls.Add(this.btEdit);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.btLoad);
			this.Name = "FormOrder";
			this.Text = "FormOrder";
			this.Load += new System.EventHandler(this.FormOrder_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataOr)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOrderTotal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtOrderDate;
		private System.Windows.Forms.TextBox txtEmployeeID;
		private System.Windows.Forms.TextBox txtCustomersID;
		private System.Windows.Forms.TextBox txtOrderID;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btSearch;
		private System.Windows.Forms.Button btDelete;
		private System.Windows.Forms.Button btEdit;
		private System.Windows.Forms.Button btAdd;
		private System.Windows.Forms.Button btLoad;
		private System.Windows.Forms.DataGridView dataOr;
	}
}