namespace Client
{
    partial class FrmClient
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
			this.btnConnectToServer = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtServerIP = new System.Windows.Forms.TextBox();
			this.btnNopBaiThi = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblDeThi = new System.Windows.Forms.LinkLabel();
			this.lblMaSo = new System.Windows.Forms.Label();
			this.lblThoiGianConLai = new System.Windows.Forms.Label();
			this.lblThoiGian = new System.Windows.Forms.Label();
			this.lblMonThi = new System.Windows.Forms.Label();
			this.lblHoTen = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSendStudentInfo = new System.Windows.Forms.Button();
			this.cbDSThi = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnDiemDanh = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnConnectToServer);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtServerIP);
			this.groupBox1.Location = new System.Drawing.Point(16, 15);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(696, 86);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nhập địa chỉ IP Server";
			// 
			// btnConnectToServer
			// 
			this.btnConnectToServer.Location = new System.Drawing.Point(497, 33);
			this.btnConnectToServer.Margin = new System.Windows.Forms.Padding(4);
			this.btnConnectToServer.Name = "btnConnectToServer";
			this.btnConnectToServer.Size = new System.Drawing.Size(176, 25);
			this.btnConnectToServer.TabIndex = 2;
			this.btnConnectToServer.Text = "Kết Nối";
			this.btnConnectToServer.UseVisualStyleBackColor = true;
			this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 37);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP Server:";
			// 
			// txtServerIP
			// 
			this.txtServerIP.Location = new System.Drawing.Point(103, 33);
			this.txtServerIP.Margin = new System.Windows.Forms.Padding(4);
			this.txtServerIP.Name = "txtServerIP";
			this.txtServerIP.Size = new System.Drawing.Size(385, 22);
			this.txtServerIP.TabIndex = 0;
			this.txtServerIP.Text = "127.0.0.1";
			this.txtServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnNopBaiThi
			// 
			this.btnNopBaiThi.Enabled = false;
			this.btnNopBaiThi.Location = new System.Drawing.Point(168, 620);
			this.btnNopBaiThi.Margin = new System.Windows.Forms.Padding(4);
			this.btnNopBaiThi.Name = "btnNopBaiThi";
			this.btnNopBaiThi.Size = new System.Drawing.Size(387, 31);
			this.btnNopBaiThi.TabIndex = 7;
			this.btnNopBaiThi.Text = "Nộp Bài Thi";
			this.btnNopBaiThi.UseVisualStyleBackColor = true;
			this.btnNopBaiThi.Click += new System.EventHandler(this.btnNopBaiThi_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblDeThi);
			this.groupBox3.Controls.Add(this.lblMaSo);
			this.groupBox3.Controls.Add(this.lblThoiGianConLai);
			this.groupBox3.Controls.Add(this.lblThoiGian);
			this.groupBox3.Controls.Add(this.lblMonThi);
			this.groupBox3.Controls.Add(this.lblHoTen);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Location = new System.Drawing.Point(16, 228);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox3.Size = new System.Drawing.Size(696, 212);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Thông Tin Sinh Viên";
			// 
			// lblDeThi
			// 
			this.lblDeThi.AutoSize = true;
			this.lblDeThi.Location = new System.Drawing.Point(168, 144);
			this.lblDeThi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDeThi.Name = "lblDeThi";
			this.lblDeThi.Size = new System.Drawing.Size(31, 17);
			this.lblDeThi.TabIndex = 2;
			this.lblDeThi.TabStop = true;
			this.lblDeThi.Text = "N/A";
			this.lblDeThi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeThi_LinkClicked);
			// 
			// lblMaSo
			// 
			this.lblMaSo.AutoSize = true;
			this.lblMaSo.Location = new System.Drawing.Point(168, 58);
			this.lblMaSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblMaSo.Name = "lblMaSo";
			this.lblMaSo.Size = new System.Drawing.Size(31, 17);
			this.lblMaSo.TabIndex = 1;
			this.lblMaSo.Text = "N/A";
			// 
			// lblThoiGianConLai
			// 
			this.lblThoiGianConLai.AutoSize = true;
			this.lblThoiGianConLai.Location = new System.Drawing.Point(168, 174);
			this.lblThoiGianConLai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblThoiGianConLai.Name = "lblThoiGianConLai";
			this.lblThoiGianConLai.Size = new System.Drawing.Size(31, 17);
			this.lblThoiGianConLai.TabIndex = 1;
			this.lblThoiGianConLai.Text = "N/A";
			// 
			// lblThoiGian
			// 
			this.lblThoiGian.AutoSize = true;
			this.lblThoiGian.Location = new System.Drawing.Point(168, 114);
			this.lblThoiGian.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblThoiGian.Name = "lblThoiGian";
			this.lblThoiGian.Size = new System.Drawing.Size(31, 17);
			this.lblThoiGian.TabIndex = 1;
			this.lblThoiGian.Text = "N/A";
			// 
			// lblMonThi
			// 
			this.lblMonThi.AutoSize = true;
			this.lblMonThi.Location = new System.Drawing.Point(168, 87);
			this.lblMonThi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblMonThi.Name = "lblMonThi";
			this.lblMonThi.Size = new System.Drawing.Size(31, 17);
			this.lblMonThi.TabIndex = 1;
			this.lblMonThi.Text = "N/A";
			// 
			// lblHoTen
			// 
			this.lblHoTen.AutoSize = true;
			this.lblHoTen.Location = new System.Drawing.Point(168, 31);
			this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblHoTen.Name = "lblHoTen";
			this.lblHoTen.Size = new System.Drawing.Size(31, 17);
			this.lblHoTen.TabIndex = 1;
			this.lblHoTen.Text = "N/A";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 58);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 17);
			this.label4.TabIndex = 0;
			this.label4.Text = "MSSV:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(21, 144);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 17);
			this.label10.TabIndex = 0;
			this.label10.Text = "Đề Thi:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(21, 174);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(126, 17);
			this.label11.TabIndex = 0;
			this.label11.Text = "Thời Gian Còn Lại:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(21, 114);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(129, 17);
			this.label8.TabIndex = 0;
			this.label8.Text = "Thời Gian Làm Bài:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 87);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "Môn Thi:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(21, 31);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Họ Tên Sinh Viên:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.btnSendStudentInfo);
			this.groupBox2.Controls.Add(this.cbDSThi);
			this.groupBox2.Location = new System.Drawing.Point(17, 108);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(696, 112);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chọn Tên Sinh Viên";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 36);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(344, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Chọn Tên  của mình sau đó nhấn vào nút Chấp Nhận";
			// 
			// btnSendStudentInfo
			// 
			this.btnSendStudentInfo.Location = new System.Drawing.Point(497, 65);
			this.btnSendStudentInfo.Margin = new System.Windows.Forms.Padding(4);
			this.btnSendStudentInfo.Name = "btnSendStudentInfo";
			this.btnSendStudentInfo.Size = new System.Drawing.Size(176, 26);
			this.btnSendStudentInfo.TabIndex = 1;
			this.btnSendStudentInfo.Text = "Chấp Nhận";
			this.btnSendStudentInfo.UseVisualStyleBackColor = true;
			this.btnSendStudentInfo.Click += new System.EventHandler(this.btnSendStudentInfo_Click);
			// 
			// cbDSThi
			// 
			this.cbDSThi.FormattingEnabled = true;
			this.cbDSThi.Location = new System.Drawing.Point(16, 65);
			this.cbDSThi.Margin = new System.Windows.Forms.Padding(4);
			this.cbDSThi.Name = "cbDSThi";
			this.cbDSThi.Size = new System.Drawing.Size(472, 24);
			this.cbDSThi.TabIndex = 0;
			this.cbDSThi.SelectedIndexChanged += new System.EventHandler(this.cbDSThi_SelectedIndexChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnDiemDanh);
			this.groupBox4.Location = new System.Drawing.Point(16, 459);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox4.Size = new System.Drawing.Size(696, 130);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Điểm danh sinh viên";
			// 
			// btnDiemDanh
			// 
			this.btnDiemDanh.Enabled = false;
			this.btnDiemDanh.Location = new System.Drawing.Point(152, 59);
			this.btnDiemDanh.Margin = new System.Windows.Forms.Padding(4);
			this.btnDiemDanh.Name = "btnDiemDanh";
			this.btnDiemDanh.Size = new System.Drawing.Size(387, 31);
			this.btnDiemDanh.TabIndex = 8;
			this.btnDiemDanh.Text = "Điểm danh sinh viên";
			this.btnDiemDanh.UseVisualStyleBackColor = true;
			this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
			// 
			// FrmClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(731, 666);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnNopBaiThi);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmClient";
			this.Text = "Client";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnectToServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button btnNopBaiThi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel lblDeThi;
        private System.Windows.Forms.Label lblMaSo;
        private System.Windows.Forms.Label lblThoiGianConLai;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblMonThi;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSendStudentInfo;
        private System.Windows.Forms.ComboBox cbDSThi;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnDiemDanh;
	}
}

