﻿namespace Server
{
    partial class Server
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.grbTimeLeft = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdNhapVungIP = new System.Windows.Forms.Button();
			this.cmdKichHoatAllClient = new System.Windows.Forms.Button();
			this.cmdBatDauLamBai = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.btnDisconnectAll = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmdChonClientPath = new System.Windows.Forms.Button();
			this.cmdChon = new System.Windows.Forms.Button();
			this.txtClientPath = new System.Windows.Forms.TextBox();
			this.txtServerPath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.lstDeThi = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.cmdChapNhan = new System.Windows.Forms.Button();
			this.txtThoiGianLamBai = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox4.SuspendLayout();
			this.grbTimeLeft.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox4.Controls.Add(this.grbTimeLeft);
			this.groupBox4.Controls.Add(this.cmdNhapVungIP);
			this.groupBox4.Controls.Add(this.cmdKichHoatAllClient);
			this.groupBox4.Controls.Add(this.cmdBatDauLamBai);
			this.groupBox4.Controls.Add(this.button6);
			this.groupBox4.Controls.Add(this.button11);
			this.groupBox4.Controls.Add(this.button10);
			this.groupBox4.Controls.Add(this.button9);
			this.groupBox4.Controls.Add(this.btnDisconnectAll);
			this.groupBox4.Location = new System.Drawing.Point(12, 11);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(124, 422);
			this.groupBox4.TabIndex = 48;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Chức Năng";
			// 
			// grbTimeLeft
			// 
			this.grbTimeLeft.Controls.Add(this.label4);
			this.grbTimeLeft.Location = new System.Drawing.Point(7, 355);
			this.grbTimeLeft.Name = "grbTimeLeft";
			this.grbTimeLeft.Size = new System.Drawing.Size(108, 61);
			this.grbTimeLeft.TabIndex = 0;
			this.grbTimeLeft.TabStop = false;
			this.grbTimeLeft.Text = "Thời gian thi";
			this.grbTimeLeft.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(18, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 30);
			this.label4.TabIndex = 37;
			this.label4.Text = "00:00";
			// 
			// cmdNhapVungIP
			// 
			this.cmdNhapVungIP.Location = new System.Drawing.Point(7, 19);
			this.cmdNhapVungIP.Name = "cmdNhapVungIP";
			this.cmdNhapVungIP.Size = new System.Drawing.Size(109, 26);
			this.cmdNhapVungIP.TabIndex = 46;
			this.cmdNhapVungIP.Text = "Nhập Vùng IP";
			this.cmdNhapVungIP.UseVisualStyleBackColor = true;
			this.cmdNhapVungIP.Click += new System.EventHandler(this.cmdNhapVungIP_Click);
			// 
			// cmdKichHoatAllClient
			// 
			this.cmdKichHoatAllClient.Location = new System.Drawing.Point(7, 263);
			this.cmdKichHoatAllClient.Name = "cmdKichHoatAllClient";
			this.cmdKichHoatAllClient.Size = new System.Drawing.Size(109, 40);
			this.cmdKichHoatAllClient.TabIndex = 45;
			this.cmdKichHoatAllClient.Text = "Kích Hoạt Tất Cả Client";
			this.cmdKichHoatAllClient.UseVisualStyleBackColor = true;
			// 
			// cmdBatDauLamBai
			// 
			this.cmdBatDauLamBai.Location = new System.Drawing.Point(7, 308);
			this.cmdBatDauLamBai.Name = "cmdBatDauLamBai";
			this.cmdBatDauLamBai.Size = new System.Drawing.Size(109, 41);
			this.cmdBatDauLamBai.TabIndex = 44;
			this.cmdBatDauLamBai.Text = "Bắt Đầu Làm Bài";
			this.cmdBatDauLamBai.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(7, 83);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(109, 45);
			this.button6.TabIndex = 40;
			this.button6.Text = "Send Message To All";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(6, 220);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(109, 38);
			this.button11.TabIndex = 40;
			this.button11.Text = "Disable Tất Cả Các Máy Trống";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(6, 176);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(109, 38);
			this.button10.TabIndex = 40;
			this.button10.Text = "Lấy Danh Sách Thi Từ CSDL";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(6, 134);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(109, 38);
			this.button9.TabIndex = 40;
			this.button9.Text = "Lấy Danh Sách Thi Từ File";
			this.button9.UseVisualStyleBackColor = true;
			// 
			// btnDisconnectAll
			// 
			this.btnDisconnectAll.Location = new System.Drawing.Point(7, 50);
			this.btnDisconnectAll.Name = "btnDisconnectAll";
			this.btnDisconnectAll.Size = new System.Drawing.Size(109, 26);
			this.btnDisconnectAll.TabIndex = 40;
			this.btnDisconnectAll.Text = "Disconnect All";
			this.btnDisconnectAll.UseVisualStyleBackColor = true;
			this.btnDisconnectAll.Click += new System.EventHandler(this.btnDisconnectAll_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.cmdChonClientPath);
			this.groupBox3.Controls.Add(this.cmdChon);
			this.groupBox3.Controls.Add(this.txtClientPath);
			this.groupBox3.Controls.Add(this.txtServerPath);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new System.Drawing.Point(12, 439);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(219, 109);
			this.groupBox3.TabIndex = 50;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Chọn Đường Dẫn";
			// 
			// cmdChonClientPath
			// 
			this.cmdChonClientPath.Location = new System.Drawing.Point(139, 71);
			this.cmdChonClientPath.Name = "cmdChonClientPath";
			this.cmdChonClientPath.Size = new System.Drawing.Size(62, 24);
			this.cmdChonClientPath.TabIndex = 36;
			this.cmdChonClientPath.Text = "Chọn";
			this.cmdChonClientPath.UseVisualStyleBackColor = true;
			// 
			// cmdChon
			// 
			this.cmdChon.Location = new System.Drawing.Point(139, 32);
			this.cmdChon.Name = "cmdChon";
			this.cmdChon.Size = new System.Drawing.Size(62, 22);
			this.cmdChon.TabIndex = 35;
			this.cmdChon.Text = "Chọn";
			this.cmdChon.UseVisualStyleBackColor = true;
			// 
			// txtClientPath
			// 
			this.txtClientPath.Location = new System.Drawing.Point(12, 72);
			this.txtClientPath.Name = "txtClientPath";
			this.txtClientPath.Size = new System.Drawing.Size(120, 23);
			this.txtClientPath.TabIndex = 34;
			this.txtClientPath.Text = "C:\\tam";
			// 
			// txtServerPath
			// 
			this.txtServerPath.Location = new System.Drawing.Point(12, 32);
			this.txtServerPath.Name = "txtServerPath";
			this.txtServerPath.Size = new System.Drawing.Size(120, 23);
			this.txtServerPath.TabIndex = 34;
			this.txtServerPath.Text = "c:\\serverPath";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 15);
			this.label3.TabIndex = 33;
			this.label3.Text = "Client Path:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 15);
			this.label2.TabIndex = 33;
			this.label2.Text = "Server Path:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.lstDeThi);
			this.groupBox1.Location = new System.Drawing.Point(237, 439);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(347, 109);
			this.groupBox1.TabIndex = 51;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chọn Đề Thi";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(252, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 26);
			this.button3.TabIndex = 31;
			this.button3.Text = "Thêm Đề Thi";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// lstDeThi
			// 
			this.lstDeThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstDeThi.FormattingEnabled = true;
			this.lstDeThi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lstDeThi.ItemHeight = 15;
			this.lstDeThi.Items.AddRange(new object[] {
            "\\\\192.168.6.1\\dethi\\de1.htm",
            "\\\\192.168.6.1\\dethi\\de2.htm",
            "\\\\192.168.6.1\\dethi\\de3.htm",
            "\\\\192.168.6.3\\dethi\\de4.htm"});
			this.lstDeThi.Location = new System.Drawing.Point(6, 21);
			this.lstDeThi.Name = "lstDeThi";
			this.lstDeThi.Size = new System.Drawing.Size(240, 79);
			this.lstDeThi.TabIndex = 30;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.comboBox1);
			this.groupBox5.Controls.Add(this.cmdChapNhan);
			this.groupBox5.Controls.Add(this.txtThoiGianLamBai);
			this.groupBox5.Location = new System.Drawing.Point(590, 440);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(239, 108);
			this.groupBox5.TabIndex = 52;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Chọn Môn Thi và Thời Gian Làm Bài";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(11, 21);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(222, 23);
			this.comboBox1.TabIndex = 30;
			// 
			// cmdChapNhan
			// 
			this.cmdChapNhan.Location = new System.Drawing.Point(65, 79);
			this.cmdChapNhan.Name = "cmdChapNhan";
			this.cmdChapNhan.Size = new System.Drawing.Size(122, 23);
			this.cmdChapNhan.TabIndex = 29;
			this.cmdChapNhan.Text = "Chấp Nhận";
			this.cmdChapNhan.UseVisualStyleBackColor = true;
			// 
			// txtThoiGianLamBai
			// 
			this.txtThoiGianLamBai.Location = new System.Drawing.Point(11, 50);
			this.txtThoiGianLamBai.Name = "txtThoiGianLamBai";
			this.txtThoiGianLamBai.Size = new System.Drawing.Size(222, 23);
			this.txtThoiGianLamBai.TabIndex = 28;
			this.txtThoiGianLamBai.Text = "120";
			this.txtThoiGianLamBai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(835, 440);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(143, 108);
			this.groupBox2.TabIndex = 33;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chọn Noi Lưu Bài Thi";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(10, 74);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(57, 19);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Server";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(10, 51);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(56, 19);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Client";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bài thi được lưu ở";
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.flpMain);
			this.groupBox6.Location = new System.Drawing.Point(142, 12);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(836, 421);
			this.groupBox6.TabIndex = 53;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Danh sách các máy con trong phòng";
			// 
			// flpMain
			// 
			this.flpMain.AutoScroll = true;
			this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpMain.Location = new System.Drawing.Point(3, 19);
			this.flpMain.Name = "flpMain";
			this.flpMain.Size = new System.Drawing.Size(830, 399);
			this.flpMain.TabIndex = 0;
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 560);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox4);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Server";
			this.Text = "Server";
			this.groupBox4.ResumeLayout(false);
			this.grbTimeLeft.ResumeLayout(false);
			this.grbTimeLeft.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdNhapVungIP;
        private System.Windows.Forms.Button cmdKichHoatAllClient;
        private System.Windows.Forms.Button cmdBatDauLamBai;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnDisconnectAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdChonClientPath;
        private System.Windows.Forms.Button cmdChon;
        private System.Windows.Forms.TextBox txtClientPath;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox lstDeThi;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button cmdChapNhan;
        private System.Windows.Forms.TextBox txtThoiGianLamBai;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbTimeLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}

