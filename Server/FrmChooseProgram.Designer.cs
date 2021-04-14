
namespace Server
{
	partial class FrmChooseProgram
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.lvApps = new System.Windows.Forms.ListView();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvApps);
			this.groupBox1.Location = new System.Drawing.Point(12, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(644, 317);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Danh sách chương trình được chọn";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 30);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(186, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Thêm chương trình";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(456, 30);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(200, 23);
			this.btnAccept.TabIndex = 2;
			this.btnAccept.Text = "Gửi danh sách xuống máy con";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// lvApps
			// 
			this.lvApps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvApps.HideSelection = false;
			this.lvApps.Location = new System.Drawing.Point(3, 19);
			this.lvApps.Name = "lvApps";
			this.lvApps.Size = new System.Drawing.Size(638, 295);
			this.lvApps.TabIndex = 0;
			this.lvApps.UseCompatibleStateImageBehavior = false;
			this.lvApps.View = System.Windows.Forms.View.List;
			// 
			// FrmChooseProgram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 388);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmChooseProgram";
			this.Text = "Chọn chương trình";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.ListView lvApps;
	}
}