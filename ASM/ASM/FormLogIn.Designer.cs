namespace ASM
{
	partial class FormLogIn
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
			this.btRegister = new System.Windows.Forms.Button();
			this.btLogIn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btRegister
			// 
			this.btRegister.Location = new System.Drawing.Point(446, 349);
			this.btRegister.Name = "btRegister";
			this.btRegister.Size = new System.Drawing.Size(113, 47);
			this.btRegister.TabIndex = 2;
			this.btRegister.Text = "Register";
			this.btRegister.UseVisualStyleBackColor = true;
			this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
			// 
			// btLogIn
			// 
			this.btLogIn.Location = new System.Drawing.Point(446, 272);
			this.btLogIn.Name = "btLogIn";
			this.btLogIn.Size = new System.Drawing.Size(113, 44);
			this.btLogIn.TabIndex = 43;
			this.btLogIn.Text = "Log In";
			this.btLogIn.UseVisualStyleBackColor = true;
			this.btLogIn.Click += new System.EventHandler(this.btLogIn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(455, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 46);
			this.label1.TabIndex = 38;
			this.label1.Text = "Log In";
			// 
			// txtPass
			// 
			this.txtPass.Location = new System.Drawing.Point(409, 205);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(192, 22);
			this.txtPass.TabIndex = 42;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(298, 167);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 16);
			this.label2.TabIndex = 39;
			this.label2.Text = "User Name:";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(409, 164);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(192, 22);
			this.txtUser.TabIndex = 41;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(298, 205);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 16);
			this.label3.TabIndex = 40;
			this.label3.Text = "Pass Word:";
			// 
			// FormLogIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 505);
			this.Controls.Add(this.btLogIn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btRegister);
			this.Name = "FormLogIn";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btRegister;
		private System.Windows.Forms.Button btLogIn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label label3;
	}
}

