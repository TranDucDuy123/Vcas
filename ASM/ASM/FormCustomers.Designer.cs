namespace ASM
{
	partial class FormCustomers
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
			this.btLoadCr = new System.Windows.Forms.Button();
			this.txtPassCr = new System.Windows.Forms.TextBox();
			this.txtUserCr = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.dataCr = new System.Windows.Forms.DataGridView();
			this.txtCustomerAddress = new System.Windows.Forms.TextBox();
			this.txtCustomerEmail = new System.Windows.Forms.TextBox();
			this.txtCustomerPhone = new System.Windows.Forms.TextBox();
			this.txtCustomerName = new System.Windows.Forms.TextBox();
			this.txtCustomerID = new System.Windows.Forms.TextBox();
			this.btSearchCr = new System.Windows.Forms.Button();
			this.btDeleteCr = new System.Windows.Forms.Button();
			this.btEditCr = new System.Windows.Forms.Button();
			this.btAddCr = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataCr)).BeginInit();
			this.SuspendLayout();
			// 
			// btLoadCr
			// 
			this.btLoadCr.Location = new System.Drawing.Point(152, 154);
			this.btLoadCr.Name = "btLoadCr";
			this.btLoadCr.Size = new System.Drawing.Size(73, 23);
			this.btLoadCr.TabIndex = 60;
			this.btLoadCr.Text = "Load";
			this.btLoadCr.UseVisualStyleBackColor = true;
			this.btLoadCr.Click += new System.EventHandler(this.btLoadCr_Click);
			// 
			// txtPassCr
			// 
			this.txtPassCr.Location = new System.Drawing.Point(753, 69);
			this.txtPassCr.Name = "txtPassCr";
			this.txtPassCr.Size = new System.Drawing.Size(152, 22);
			this.txtPassCr.TabIndex = 59;
			// 
			// txtUserCr
			// 
			this.txtUserCr.Location = new System.Drawing.Point(755, 30);
			this.txtUserCr.Name = "txtUserCr";
			this.txtUserCr.Size = new System.Drawing.Size(152, 22);
			this.txtUserCr.TabIndex = 58;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(670, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(77, 16);
			this.label13.TabIndex = 57;
			this.label13.Text = "Pass Word:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(670, 33);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(79, 16);
			this.label12.TabIndex = 56;
			this.label12.Text = "User Name:";
			// 
			// dataCr
			// 
			this.dataCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataCr.Location = new System.Drawing.Point(-30, 198);
			this.dataCr.Name = "dataCr";
			this.dataCr.RowHeadersWidth = 51;
			this.dataCr.RowTemplate.Height = 24;
			this.dataCr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataCr.Size = new System.Drawing.Size(1080, 305);
			this.dataCr.TabIndex = 55;
			this.dataCr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCr_CellContentClick);
			// 
			// txtCustomerAddress
			// 
			this.txtCustomerAddress.Location = new System.Drawing.Point(483, 66);
			this.txtCustomerAddress.Name = "txtCustomerAddress";
			this.txtCustomerAddress.Size = new System.Drawing.Size(153, 22);
			this.txtCustomerAddress.TabIndex = 54;
			// 
			// txtCustomerEmail
			// 
			this.txtCustomerEmail.Location = new System.Drawing.Point(483, 30);
			this.txtCustomerEmail.Name = "txtCustomerEmail";
			this.txtCustomerEmail.Size = new System.Drawing.Size(153, 22);
			this.txtCustomerEmail.TabIndex = 53;
			// 
			// txtCustomerPhone
			// 
			this.txtCustomerPhone.Location = new System.Drawing.Point(152, 103);
			this.txtCustomerPhone.Name = "txtCustomerPhone";
			this.txtCustomerPhone.Size = new System.Drawing.Size(142, 22);
			this.txtCustomerPhone.TabIndex = 52;
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.Location = new System.Drawing.Point(153, 66);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(141, 22);
			this.txtCustomerName.TabIndex = 51;
			// 
			// txtCustomerID
			// 
			this.txtCustomerID.Location = new System.Drawing.Point(152, 30);
			this.txtCustomerID.Name = "txtCustomerID";
			this.txtCustomerID.Size = new System.Drawing.Size(142, 22);
			this.txtCustomerID.TabIndex = 50;
			// 
			// btSearchCr
			// 
			this.btSearchCr.Location = new System.Drawing.Point(640, 154);
			this.btSearchCr.Name = "btSearchCr";
			this.btSearchCr.Size = new System.Drawing.Size(75, 23);
			this.btSearchCr.TabIndex = 49;
			this.btSearchCr.Text = "Search";
			this.btSearchCr.UseVisualStyleBackColor = true;
			this.btSearchCr.Click += new System.EventHandler(this.btSearchCr_Click);
			// 
			// btDeleteCr
			// 
			this.btDeleteCr.Location = new System.Drawing.Point(503, 154);
			this.btDeleteCr.Name = "btDeleteCr";
			this.btDeleteCr.Size = new System.Drawing.Size(75, 23);
			this.btDeleteCr.TabIndex = 48;
			this.btDeleteCr.Text = "Delete";
			this.btDeleteCr.UseVisualStyleBackColor = true;
			this.btDeleteCr.Click += new System.EventHandler(this.btDeleteCr_Click);
			// 
			// btEditCr
			// 
			this.btEditCr.Location = new System.Drawing.Point(391, 154);
			this.btEditCr.Name = "btEditCr";
			this.btEditCr.Size = new System.Drawing.Size(75, 23);
			this.btEditCr.TabIndex = 47;
			this.btEditCr.Text = "Edit";
			this.btEditCr.UseVisualStyleBackColor = true;
			this.btEditCr.Click += new System.EventHandler(this.btEditCr_Click);
			// 
			// btAddCr
			// 
			this.btAddCr.Location = new System.Drawing.Point(274, 154);
			this.btAddCr.Name = "btAddCr";
			this.btAddCr.Size = new System.Drawing.Size(75, 23);
			this.btAddCr.TabIndex = 46;
			this.btAddCr.Text = "Add";
			this.btAddCr.UseVisualStyleBackColor = true;
			this.btAddCr.Click += new System.EventHandler(this.btAddCr_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(338, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 45;
			this.label5.Text = "Customers Address:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(338, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 16);
			this.label4.TabIndex = 44;
			this.label4.Text = "Customers Email:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 16);
			this.label3.TabIndex = 43;
			this.label3.Text = "Customer Phone:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 16);
			this.label2.TabIndex = 42;
			this.label2.Text = "Customers Name:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 16);
			this.label1.TabIndex = 41;
			this.label1.Text = "Customers ID:";
			// 
			// FormCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 533);
			this.Controls.Add(this.btLoadCr);
			this.Controls.Add(this.txtPassCr);
			this.Controls.Add(this.txtUserCr);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.dataCr);
			this.Controls.Add(this.txtCustomerAddress);
			this.Controls.Add(this.txtCustomerEmail);
			this.Controls.Add(this.txtCustomerPhone);
			this.Controls.Add(this.txtCustomerName);
			this.Controls.Add(this.txtCustomerID);
			this.Controls.Add(this.btSearchCr);
			this.Controls.Add(this.btDeleteCr);
			this.Controls.Add(this.btEditCr);
			this.Controls.Add(this.btAddCr);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormCustomers";
			this.Text = "FormCustomers";
			this.Load += new System.EventHandler(this.FormCustomers_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataCr)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btLoadCr;
		private System.Windows.Forms.TextBox txtPassCr;
		private System.Windows.Forms.TextBox txtUserCr;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DataGridView dataCr;
		private System.Windows.Forms.TextBox txtCustomerAddress;
		private System.Windows.Forms.TextBox txtCustomerEmail;
		private System.Windows.Forms.TextBox txtCustomerPhone;
		private System.Windows.Forms.TextBox txtCustomerName;
		private System.Windows.Forms.TextBox txtCustomerID;
		private System.Windows.Forms.Button btSearchCr;
		private System.Windows.Forms.Button btDeleteCr;
		private System.Windows.Forms.Button btEditCr;
		private System.Windows.Forms.Button btAddCr;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}