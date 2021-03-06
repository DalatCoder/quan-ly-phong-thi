namespace Server
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
			this.components = new System.ComponentModel.Container();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnDiemDanh = new System.Windows.Forms.Button();
			this.btnBlock = new System.Windows.Forms.Button();
			this.btnShutdown = new System.Windows.Forms.Button();
			this.btnThuBai = new System.Windows.Forms.Button();
			this.grbTimeLeft = new System.Windows.Forms.GroupBox();
			this.lblTimeLeft = new System.Windows.Forms.Label();
			this.cmdNhapVungIP = new System.Windows.Forms.Button();
			this.cmdKichHoatAllClient = new System.Windows.Forms.Button();
			this.cmdBatDauLamBai = new System.Windows.Forms.Button();
			this.btnGuiTinNhan = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.btnLayDSSinhVienTuCSDL = new System.Windows.Forms.Button();
			this.btnGuiDSSVTuFile = new System.Windows.Forms.Button();
			this.btnDisconnectAll = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnChonClientPath = new System.Windows.Forms.Button();
			this.btnChonServerPath = new System.Windows.Forms.Button();
			this.txtClientPath = new System.Windows.Forms.TextBox();
			this.txtServerPath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnXoaDe = new System.Windows.Forms.Button();
			this.lsvDeThi = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnPhatDe = new System.Windows.Forms.Button();
			this.btnThemDe = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbMonHoc = new System.Windows.Forms.ComboBox();
			this.cmdChapNhan = new System.Windows.Forms.Button();
			this.txtThoiGianLamBai = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.btnBlockApps = new System.Windows.Forms.Button();
			this.ctmShutdown = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox4.SuspendLayout();
			this.grbTimeLeft.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.ctmShutdown.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox4.Controls.Add(this.btnDiemDanh);
			this.groupBox4.Controls.Add(this.btnBlock);
			this.groupBox4.Controls.Add(this.btnShutdown);
			this.groupBox4.Controls.Add(this.btnThuBai);
			this.groupBox4.Controls.Add(this.grbTimeLeft);
			this.groupBox4.Controls.Add(this.cmdNhapVungIP);
			this.groupBox4.Controls.Add(this.cmdKichHoatAllClient);
			this.groupBox4.Controls.Add(this.cmdBatDauLamBai);
			this.groupBox4.Controls.Add(this.btnGuiTinNhan);
			this.groupBox4.Controls.Add(this.button11);
			this.groupBox4.Controls.Add(this.btnLayDSSinhVienTuCSDL);
			this.groupBox4.Controls.Add(this.btnGuiDSSVTuFile);
			this.groupBox4.Controls.Add(this.btnDisconnectAll);
			this.groupBox4.Location = new System.Drawing.Point(12, 11);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(145, 613);
			this.groupBox4.TabIndex = 48;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Chức Năng";
			// 
			// btnDiemDanh
			// 
			this.btnDiemDanh.Location = new System.Drawing.Point(7, 484);
			this.btnDiemDanh.Name = "btnDiemDanh";
			this.btnDiemDanh.Size = new System.Drawing.Size(133, 41);
			this.btnDiemDanh.TabIndex = 50;
			this.btnDiemDanh.Text = "Điểm Danh";
			this.btnDiemDanh.UseVisualStyleBackColor = true;
			this.btnDiemDanh.Click += new System.EventHandler(this.btnDiemDanh_Click);
			// 
			// btnBlock
			// 
			this.btnBlock.Location = new System.Drawing.Point(6, 297);
			this.btnBlock.Name = "btnBlock";
			this.btnBlock.Size = new System.Drawing.Size(133, 40);
			this.btnBlock.TabIndex = 49;
			this.btnBlock.Text = "Chặn chương trình ";
			this.btnBlock.UseVisualStyleBackColor = true;
			this.btnBlock.Click += new System.EventHandler(this.BtnBlockApps_Click);
			// 
			// btnShutdown
			// 
			this.btnShutdown.Location = new System.Drawing.Point(6, 343);
			this.btnShutdown.Name = "btnShutdown";
			this.btnShutdown.Size = new System.Drawing.Size(133, 41);
			this.btnShutdown.TabIndex = 48;
			this.btnShutdown.Text = "Shutdown/Restart";
			this.btnShutdown.UseVisualStyleBackColor = true;
			this.btnShutdown.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnThuBai
			// 
			this.btnThuBai.Location = new System.Drawing.Point(6, 437);
			this.btnThuBai.Name = "btnThuBai";
			this.btnThuBai.Size = new System.Drawing.Size(133, 41);
			this.btnThuBai.TabIndex = 47;
			this.btnThuBai.Text = "Thu Bài";
			this.btnThuBai.UseVisualStyleBackColor = true;
			this.btnThuBai.Click += new System.EventHandler(this.btnThuBai_Click);
			// 
			// grbTimeLeft
			// 
			this.grbTimeLeft.Controls.Add(this.lblTimeLeft);
			this.grbTimeLeft.Location = new System.Drawing.Point(7, 546);
			this.grbTimeLeft.Name = "grbTimeLeft";
			this.grbTimeLeft.Size = new System.Drawing.Size(132, 61);
			this.grbTimeLeft.TabIndex = 0;
			this.grbTimeLeft.TabStop = false;
			this.grbTimeLeft.Text = "Thời gian thi";
			// 
			// lblTimeLeft
			// 
			this.lblTimeLeft.AutoSize = true;
			this.lblTimeLeft.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimeLeft.Location = new System.Drawing.Point(18, 19);
			this.lblTimeLeft.Name = "lblTimeLeft";
			this.lblTimeLeft.Size = new System.Drawing.Size(66, 30);
			this.lblTimeLeft.TabIndex = 37;
			this.lblTimeLeft.Text = "00:00";
			// 
			// cmdNhapVungIP
			// 
			this.cmdNhapVungIP.Location = new System.Drawing.Point(7, 19);
			this.cmdNhapVungIP.Name = "cmdNhapVungIP";
			this.cmdNhapVungIP.Size = new System.Drawing.Size(132, 26);
			this.cmdNhapVungIP.TabIndex = 46;
			this.cmdNhapVungIP.Text = "Nhập Vùng IP";
			this.cmdNhapVungIP.UseVisualStyleBackColor = true;
			this.cmdNhapVungIP.Click += new System.EventHandler(this.cmdNhapVungIP_Click);
			// 
			// cmdKichHoatAllClient
			// 
			this.cmdKichHoatAllClient.Location = new System.Drawing.Point(6, 251);
			this.cmdKichHoatAllClient.Name = "cmdKichHoatAllClient";
			this.cmdKichHoatAllClient.Size = new System.Drawing.Size(133, 40);
			this.cmdKichHoatAllClient.TabIndex = 45;
			this.cmdKichHoatAllClient.Text = "Kích Hoạt Tất Cả Client";
			this.cmdKichHoatAllClient.UseVisualStyleBackColor = true;
			this.cmdKichHoatAllClient.Click += new System.EventHandler(this.cmdKichHoatAllClient_Click);
			// 
			// cmdBatDauLamBai
			// 
			this.cmdBatDauLamBai.Location = new System.Drawing.Point(6, 390);
			this.cmdBatDauLamBai.Name = "cmdBatDauLamBai";
			this.cmdBatDauLamBai.Size = new System.Drawing.Size(133, 41);
			this.cmdBatDauLamBai.TabIndex = 44;
			this.cmdBatDauLamBai.Text = "Bắt Đầu Làm Bài";
			this.cmdBatDauLamBai.UseVisualStyleBackColor = true;
			this.cmdBatDauLamBai.Click += new System.EventHandler(this.cmdBatDauLamBai_Click);
			// 
			// btnGuiTinNhan
			// 
			this.btnGuiTinNhan.Location = new System.Drawing.Point(7, 83);
			this.btnGuiTinNhan.Name = "btnGuiTinNhan";
			this.btnGuiTinNhan.Size = new System.Drawing.Size(132, 30);
			this.btnGuiTinNhan.TabIndex = 40;
			this.btnGuiTinNhan.Text = "Send Message To All";
			this.btnGuiTinNhan.UseVisualStyleBackColor = true;
			this.btnGuiTinNhan.Click += new System.EventHandler(this.btnGuiTinNhan_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(7, 207);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(132, 38);
			this.button11.TabIndex = 40;
			this.button11.Text = "Disable Tất Cả Các Máy Trống";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// btnLayDSSinhVienTuCSDL
			// 
			this.btnLayDSSinhVienTuCSDL.Location = new System.Drawing.Point(6, 163);
			this.btnLayDSSinhVienTuCSDL.Name = "btnLayDSSinhVienTuCSDL";
			this.btnLayDSSinhVienTuCSDL.Size = new System.Drawing.Size(133, 38);
			this.btnLayDSSinhVienTuCSDL.TabIndex = 40;
			this.btnLayDSSinhVienTuCSDL.Text = "Lấy Danh Sách Thi Từ CSDL";
			this.btnLayDSSinhVienTuCSDL.UseVisualStyleBackColor = true;
			this.btnLayDSSinhVienTuCSDL.Click += new System.EventHandler(this.btnLayDSSinhVienTuCSDL_Click);
			// 
			// btnGuiDSSVTuFile
			// 
			this.btnGuiDSSVTuFile.Location = new System.Drawing.Point(6, 119);
			this.btnGuiDSSVTuFile.Name = "btnGuiDSSVTuFile";
			this.btnGuiDSSVTuFile.Size = new System.Drawing.Size(133, 38);
			this.btnGuiDSSVTuFile.TabIndex = 40;
			this.btnGuiDSSVTuFile.Text = "Lấy Danh Sách Thi Từ File";
			this.btnGuiDSSVTuFile.UseVisualStyleBackColor = true;
			this.btnGuiDSSVTuFile.Click += new System.EventHandler(this.btnGuiDSSVTuFile_Click);
			// 
			// btnDisconnectAll
			// 
			this.btnDisconnectAll.Location = new System.Drawing.Point(7, 50);
			this.btnDisconnectAll.Name = "btnDisconnectAll";
			this.btnDisconnectAll.Size = new System.Drawing.Size(132, 26);
			this.btnDisconnectAll.TabIndex = 40;
			this.btnDisconnectAll.Text = "Disconnect All";
			this.btnDisconnectAll.UseVisualStyleBackColor = true;
			this.btnDisconnectAll.Click += new System.EventHandler(this.btnDisconnectAll_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.btnChonClientPath);
			this.groupBox3.Controls.Add(this.btnChonServerPath);
			this.groupBox3.Controls.Add(this.txtClientPath);
			this.groupBox3.Controls.Add(this.txtServerPath);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new System.Drawing.Point(12, 630);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(365, 140);
			this.groupBox3.TabIndex = 50;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Đường Dẫn";
			// 
			// btnChonClientPath
			// 
			this.btnChonClientPath.Location = new System.Drawing.Point(258, 105);
			this.btnChonClientPath.Name = "btnChonClientPath";
			this.btnChonClientPath.Size = new System.Drawing.Size(101, 24);
			this.btnChonClientPath.TabIndex = 36;
			this.btnChonClientPath.Text = "Chọn";
			this.btnChonClientPath.UseVisualStyleBackColor = true;
			this.btnChonClientPath.Click += new System.EventHandler(this.btnChonClientPath_Click);
			// 
			// btnChonServerPath
			// 
			this.btnChonServerPath.Location = new System.Drawing.Point(258, 47);
			this.btnChonServerPath.Name = "btnChonServerPath";
			this.btnChonServerPath.Size = new System.Drawing.Size(101, 23);
			this.btnChonServerPath.TabIndex = 35;
			this.btnChonServerPath.Text = "Chọn";
			this.btnChonServerPath.UseVisualStyleBackColor = true;
			this.btnChonServerPath.Click += new System.EventHandler(this.btnChonServerPath_Click);
			// 
			// txtClientPath
			// 
			this.txtClientPath.Location = new System.Drawing.Point(6, 106);
			this.txtClientPath.Name = "txtClientPath";
			this.txtClientPath.Size = new System.Drawing.Size(246, 23);
			this.txtClientPath.TabIndex = 34;
			this.txtClientPath.Text = "C:\\tam";
			this.txtClientPath.TextChanged += new System.EventHandler(this.txtClientPath_TextChanged);
			// 
			// txtServerPath
			// 
			this.txtServerPath.Location = new System.Drawing.Point(6, 47);
			this.txtServerPath.Name = "txtServerPath";
			this.txtServerPath.Size = new System.Drawing.Size(246, 23);
			this.txtServerPath.TabIndex = 34;
			this.txtServerPath.Text = "c:\\serverPath";
			this.txtServerPath.TextChanged += new System.EventHandler(this.txtServerPath_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 15);
			this.label3.TabIndex = 33;
			this.label3.Text = "Gửi đề thi đến (Máy con)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 15);
			this.label2.TabIndex = 33;
			this.label2.Text = "Lưu bài thi (Máy chủ):";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnXoaDe);
			this.groupBox1.Controls.Add(this.lsvDeThi);
			this.groupBox1.Controls.Add(this.btnPhatDe);
			this.groupBox1.Controls.Add(this.btnThemDe);
			this.groupBox1.Location = new System.Drawing.Point(383, 630);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(347, 140);
			this.groupBox1.TabIndex = 51;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Đề Thi";
			// 
			// btnXoaDe
			// 
			this.btnXoaDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnXoaDe.Location = new System.Drawing.Point(252, 63);
			this.btnXoaDe.Name = "btnXoaDe";
			this.btnXoaDe.Size = new System.Drawing.Size(88, 29);
			this.btnXoaDe.TabIndex = 34;
			this.btnXoaDe.Text = "Xóa";
			this.btnXoaDe.UseVisualStyleBackColor = true;
			this.btnXoaDe.Click += new System.EventHandler(this.btnXoaDe_Click);
			// 
			// lsvDeThi
			// 
			this.lsvDeThi.Alignment = System.Windows.Forms.ListViewAlignment.Left;
			this.lsvDeThi.AllowDrop = true;
			this.lsvDeThi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsvDeThi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lsvDeThi.FullRowSelect = true;
			this.lsvDeThi.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lsvDeThi.HideSelection = false;
			this.lsvDeThi.Location = new System.Drawing.Point(6, 25);
			this.lsvDeThi.MultiSelect = false;
			this.lsvDeThi.Name = "lsvDeThi";
			this.lsvDeThi.Size = new System.Drawing.Size(240, 109);
			this.lsvDeThi.TabIndex = 33;
			this.lsvDeThi.UseCompatibleStateImageBehavior = false;
			this.lsvDeThi.View = System.Windows.Forms.View.List;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Danh sách đề thi";
			this.columnHeader1.Width = 600;
			// 
			// btnPhatDe
			// 
			this.btnPhatDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPhatDe.Location = new System.Drawing.Point(252, 106);
			this.btnPhatDe.Name = "btnPhatDe";
			this.btnPhatDe.Size = new System.Drawing.Size(88, 28);
			this.btnPhatDe.TabIndex = 32;
			this.btnPhatDe.Text = "Phát Đề";
			this.btnPhatDe.UseVisualStyleBackColor = true;
			this.btnPhatDe.Click += new System.EventHandler(this.btnPhatDe_Click);
			// 
			// btnThemDe
			// 
			this.btnThemDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnThemDe.Location = new System.Drawing.Point(252, 27);
			this.btnThemDe.Name = "btnThemDe";
			this.btnThemDe.Size = new System.Drawing.Size(88, 33);
			this.btnThemDe.TabIndex = 31;
			this.btnThemDe.Text = "Thêm";
			this.btnThemDe.UseVisualStyleBackColor = true;
			this.btnThemDe.Click += new System.EventHandler(this.btnThemDe_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.cbMonHoc);
			this.groupBox5.Controls.Add(this.cmdChapNhan);
			this.groupBox5.Controls.Add(this.txtThoiGianLamBai);
			this.groupBox5.Location = new System.Drawing.Point(736, 630);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(239, 140);
			this.groupBox5.TabIndex = 52;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Môn Thi Và Thời Gian";
			// 
			// cbMonHoc
			// 
			this.cbMonHoc.FormattingEnabled = true;
			this.cbMonHoc.Items.AddRange(new object[] {
            "Lập trình mạng",
            "Phương pháp nghiên cứu khoa học",
            "Đồ họa ứng dụng",
            "Toán xác suất thống kê",
            "An toàn và bảo mật hệ thống",
            "Đồ án cơ sở"});
			this.cbMonHoc.Location = new System.Drawing.Point(11, 33);
			this.cbMonHoc.Name = "cbMonHoc";
			this.cbMonHoc.Size = new System.Drawing.Size(222, 23);
			this.cbMonHoc.TabIndex = 30;
			// 
			// cmdChapNhan
			// 
			this.cmdChapNhan.Location = new System.Drawing.Point(52, 106);
			this.cmdChapNhan.Name = "cmdChapNhan";
			this.cmdChapNhan.Size = new System.Drawing.Size(122, 23);
			this.cmdChapNhan.TabIndex = 29;
			this.cmdChapNhan.Text = "Chấp Nhận";
			this.cmdChapNhan.UseVisualStyleBackColor = true;
			this.cmdChapNhan.Click += new System.EventHandler(this.cmdChapNhan_Click);
			// 
			// txtThoiGianLamBai
			// 
			this.txtThoiGianLamBai.Location = new System.Drawing.Point(11, 67);
			this.txtThoiGianLamBai.Name = "txtThoiGianLamBai";
			this.txtThoiGianLamBai.Size = new System.Drawing.Size(222, 23);
			this.txtThoiGianLamBai.TabIndex = 28;
			this.txtThoiGianLamBai.Text = "120";
			this.txtThoiGianLamBai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.flpMain);
			this.groupBox6.Location = new System.Drawing.Point(163, 12);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(815, 612);
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
			this.flpMain.Size = new System.Drawing.Size(809, 590);
			this.flpMain.TabIndex = 0;
			// 
			// btnBlockApps
			// 
			this.btnBlockApps.Location = new System.Drawing.Point(6, 307);
			this.btnBlockApps.Name = "btnBlockApps";
			this.btnBlockApps.Size = new System.Drawing.Size(109, 41);
			this.btnBlockApps.TabIndex = 48;
			this.btnBlockApps.Text = "Cấm chương trình";
			this.btnBlockApps.UseVisualStyleBackColor = true;
			this.btnBlockApps.Click += new System.EventHandler(this.BtnBlockApps_Click);
			// 
			// ctmShutdown
			// 
			this.ctmShutdown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.restartToolStripMenuItem});
			this.ctmShutdown.Name = "ctmShutdown";
			this.ctmShutdown.Size = new System.Drawing.Size(129, 48);
			// 
			// shutdownToolStripMenuItem
			// 
			this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
			this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.shutdownToolStripMenuItem.Text = "Shutdown";
			this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
			// 
			// restartToolStripMenuItem
			// 
			this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
			this.restartToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.restartToolStripMenuItem.Text = "Restart";
			this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 782);
			this.Controls.Add(this.groupBox6);
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
			this.groupBox6.ResumeLayout(false);
			this.ctmShutdown.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button cmdNhapVungIP;
		private System.Windows.Forms.Button cmdKichHoatAllClient;
		private System.Windows.Forms.Button cmdBatDauLamBai;
		private System.Windows.Forms.Button btnGuiTinNhan;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button btnLayDSSinhVienTuCSDL;
		private System.Windows.Forms.Button btnGuiDSSVTuFile;
		private System.Windows.Forms.Button btnDisconnectAll;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnChonClientPath;
		private System.Windows.Forms.Button btnChonServerPath;
		private System.Windows.Forms.TextBox txtClientPath;
		private System.Windows.Forms.TextBox txtServerPath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnThemDe;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button cmdChapNhan;
		private System.Windows.Forms.TextBox txtThoiGianLamBai;
		private System.Windows.Forms.GroupBox grbTimeLeft;
		private System.Windows.Forms.Label lblTimeLeft;
		private System.Windows.Forms.ComboBox cbMonHoc;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.FlowLayoutPanel flpMain;
		private System.Windows.Forms.Button btnPhatDe;
		private System.Windows.Forms.Button btnThuBai;
		private System.Windows.Forms.ListView lsvDeThi;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button btnXoaDe;

		private System.Windows.Forms.Button btnShutdown;
		private System.Windows.Forms.Button btnBlockApps;
		private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.ContextMenuStrip ctmShutdown;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
		private System.Windows.Forms.Button btnDiemDanh;
	}

}

