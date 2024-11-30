namespace ASM
{
	partial class FormOrderDsetails
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
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtProductID = new System.Windows.Forms.TextBox();
			this.txtOrderID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataOd = new System.Windows.Forms.DataGridView();
			this.btSearch = new System.Windows.Forms.Button();
			this.btDelete = new System.Windows.Forms.Button();
			this.btEdit = new System.Windows.Forms.Button();
			this.btAdd = new System.Windows.Forms.Button();
			this.btLoad = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataOd)).BeginInit();
			this.SuspendLayout();
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(336, 497);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(126, 22);
			this.txtPrice.TabIndex = 50;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(336, 453);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(126, 22);
			this.txtQuantity.TabIndex = 49;
			// 
			// txtProductID
			// 
			this.txtProductID.Location = new System.Drawing.Point(116, 497);
			this.txtProductID.Name = "txtProductID";
			this.txtProductID.Size = new System.Drawing.Size(122, 22);
			this.txtProductID.TabIndex = 48;
			// 
			// txtOrderID
			// 
			this.txtOrderID.Location = new System.Drawing.Point(116, 453);
			this.txtOrderID.Name = "txtOrderID";
			this.txtOrderID.Size = new System.Drawing.Size(122, 22);
			this.txtOrderID.TabIndex = 47;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(272, 503);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 16);
			this.label5.TabIndex = 46;
			this.label5.Text = "Price:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(272, 459);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 16);
			this.label4.TabIndex = 45;
			this.label4.Text = "Quantity:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(41, 500);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 16);
			this.label2.TabIndex = 44;
			this.label2.Text = "ProductID:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 455);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 16);
			this.label1.TabIndex = 43;
			this.label1.Text = "OrderID: ";
			// 
			// dataOd
			// 
			this.dataOd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataOd.Location = new System.Drawing.Point(-4, 3);
			this.dataOd.Name = "dataOd";
			this.dataOd.RowHeadersWidth = 51;
			this.dataOd.RowTemplate.Height = 24;
			this.dataOd.Size = new System.Drawing.Size(1022, 422);
			this.dataOd.TabIndex = 42;
			this.dataOd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataOd_CellContentClick);
			// 
			// btSearch
			// 
			this.btSearch.Location = new System.Drawing.Point(774, 452);
			this.btSearch.Name = "btSearch";
			this.btSearch.Size = new System.Drawing.Size(75, 23);
			this.btSearch.TabIndex = 41;
			this.btSearch.Text = "Search";
			this.btSearch.UseVisualStyleBackColor = true;
			this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
			// 
			// btDelete
			// 
			this.btDelete.Location = new System.Drawing.Point(651, 497);
			this.btDelete.Name = "btDelete";
			this.btDelete.Size = new System.Drawing.Size(75, 23);
			this.btDelete.TabIndex = 40;
			this.btDelete.Text = "Delete";
			this.btDelete.UseVisualStyleBackColor = true;
			this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
			// 
			// btEdit
			// 
			this.btEdit.Location = new System.Drawing.Point(651, 452);
			this.btEdit.Name = "btEdit";
			this.btEdit.Size = new System.Drawing.Size(75, 23);
			this.btEdit.TabIndex = 39;
			this.btEdit.Text = "Edit";
			this.btEdit.UseVisualStyleBackColor = true;
			this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
			// 
			// btAdd
			// 
			this.btAdd.Location = new System.Drawing.Point(522, 497);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(75, 23);
			this.btAdd.TabIndex = 38;
			this.btAdd.Text = "Add";
			this.btAdd.UseVisualStyleBackColor = true;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// btLoad
			// 
			this.btLoad.Location = new System.Drawing.Point(522, 452);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(75, 23);
			this.btLoad.TabIndex = 37;
			this.btLoad.Text = "Load";
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// FormOrderDsetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1017, 554);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.txtQuantity);
			this.Controls.Add(this.txtProductID);
			this.Controls.Add(this.txtOrderID);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataOd);
			this.Controls.Add(this.btSearch);
			this.Controls.Add(this.btDelete);
			this.Controls.Add(this.btEdit);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.btLoad);
			this.Name = "FormOrderDsetails";
			this.Text = "FormOrderDsetails";
			this.Load += new System.EventHandler(this.FormOrderDsetails_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataOd)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtProductID;
		private System.Windows.Forms.TextBox txtOrderID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataOd;
		private System.Windows.Forms.Button btSearch;
		private System.Windows.Forms.Button btDelete;
		private System.Windows.Forms.Button btEdit;
		private System.Windows.Forms.Button btAdd;
		private System.Windows.Forms.Button btLoad;
	}
}