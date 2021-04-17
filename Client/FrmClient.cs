using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Client
{
	public partial class FrmClient : Form
	{
		private const int SERVER_PORT = 2010;

		ClientProgram clientProgram;
		PopupNotifier popup;
		int counter = 0; // Dem nguoc theo tung giay
		System.Timers.Timer countdown;
		ProcessManager processManager;

        LockClient lockClient;
        Shutdown shutdownClient;
        Restart restartClient;

        public FrmClient()
		{
			InitializeComponent();
			InitPopupNotifier();

			CheckForIllegalCrossThreadCalls = false;

			clientProgram = new ClientProgram();

			clientProgram.OnSuccessNotification += HandleOnSuccessNotification;
			clientProgram.OnErrorNotification += HandleOnErrorNotification;
			clientProgram.OnClientDisconnected += HandleOnClientDisconnected;
			clientProgram.OnReceivedExam += HandleOnReceivedExam;
			clientProgram.OnCamChuongTrinh += HandleOnCamChuongTrinh;
			clientProgram.OnNhanMonThiVaThoiGian += HandleOnNhanMonThiVaThoiGian;

			clientProgram.onNhanThongBao = HandleOnNhanThongBao;
			clientProgram.onNhanDanhSachSVTuExcel = HandleOnNhanDanhSachSVTuExcel;
			clientProgram.onNhanThongBaoDiemDanh = HandleOnNhanThongBaoDiemDanh;
			clientProgram.onNhanSoPhut = HandleOnNhanSoPhut;


            clientProgram.OnLockClientReceived = HandleOnLockClientReceived;
            clientProgram.OnUnLockClientReceived = HandleOnUnLockClientReceived;

            clientProgram.OnShutDownClientReceived = HandleOnShutdownClientReceived;
            clientProgram.OnRestartClientReceived = HandleOnRestartClientReceived;

            countdown = new System.Timers.Timer();
			countdown.Elapsed += Countdown_Elapsed; ;
			countdown.Interval = 1000;
		}

        #region Handle ClientProgram events

        void HandleOnLockClientReceived()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lockClient = new LockClient();

                    lockClient.ShowDialog();
                });
            }
            else
            {
                lockClient = new LockClient();
                lockClient.Show();
            }
        }

        void HandleOnUnLockClientReceived()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lockClient.close();
                });
            }
            else
            {
                lockClient.close();
            }
        }

        void HandleOnShutdownClientReceived()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    shutdownClient = new Shutdown();

                    shutdownClient.Show();
                });
            }
            else
            {
                shutdownClient = new Shutdown();

                shutdownClient.Show();
            }
        }

        void HandleOnRestartClientReceived()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    restartClient = new Restart();

                    restartClient.Show();
                });
            }
            else
            {
                restartClient = new Restart();

                restartClient.Show();
            }
        }


        private void HandleOnNhanMonThiVaThoiGian(SubjectAndTime data)
		{
			lblThoiGian.Text = data.Minute.ToString() + " phút";
			lblMonThi.Text = data.Subject;
		}

		private void HandleOnCamChuongTrinh(List<string> programs)
		{
			if (processManager == null)
			{
				InitProcessManager(programs);
				return;
			}

			foreach (string program in programs)
			{
				processManager.AddProcess(program);
			}
		}

		private void HandleOnErrorNotification(string errorMessage, Exception ex)
		{
			string msg = errorMessage;

			if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
				msg += ". " + ex.Message;

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					RenderNotificationPopup("Thông báo lỗi", msg);
				});
			}
			else
			{
				RenderNotificationPopup("Thông báo lỗi", msg);
			}
		}

		private void HandleOnSuccessNotification(string message)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					RenderNotificationPopup("Thông báo mới", message);
				});
			}
			else
			{
				RenderNotificationPopup("Thông báo mới", message);
			}

		}

		private void HandleOnClientDisconnected()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					btnConnectToServer.Enabled = true;
					btnSendStudentInfo.Enabled = false;
					btnNopBaiThi.Enabled = false;
				});
			}
			else
			{
				btnConnectToServer.Enabled = true;
				btnSendStudentInfo.Enabled = false;
				btnNopBaiThi.Enabled = false;
			}
		}

		private void HandleOnReceivedExam(string examFileUrl)
		{
			lblDeThi.Text = examFileUrl;

		}

		void HandleOnNhanThongBao(string message)
		{

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					popup.TitleText = "Thông báo từ server";
					popup.ContentText = message;

					popup.Popup();
				});
			}
			else
			{
				popup.TitleText = "Thông báo từ server";
				popup.ContentText = message;

				popup.Popup();
			}
		}

		void HandleOnNhanDanhSachSVTuExcel(List<Student> students)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					
					popup.TitleText = "Thông báo";
					popup.ContentText = "Đã nhận danh sách sinh viên từ máy chủ";

					popup.Popup();

					cbDSThi.DataSource = students;
					cbDSThi.DisplayMember = "FullNameAndId";
				});
			}
			else
			{
				popup.TitleText = "Thông báo";
				popup.ContentText = "Đã nhận danh sách sinh viên từ máy chủ";

				popup.Popup();

				cbDSThi.DataSource = students;
				cbDSThi.DisplayMember = "FullNameAndId";
			}

		}

		private void HandleOnNhanThongBaoDiemDanh()
		{
			btnDiemDanh.Enabled = true;
		}

		private void HandleOnNhanSoPhut(int minute)
		{
			counter = minute * 60;
			countdown.Enabled = true;
		}

		#endregion

		#region Init state

		void InitPopupNotifier()
		{
			popup = new PopupNotifier();
			popup.ShowOptionsButton = false;
			popup.ContentPadding = new Padding(10, 3, 10, 3);
			popup.TitlePadding = new Padding(10, 3, 10, 3);
		}

		void InitProcessManager(List<string> processes)
		{
			processManager = new ProcessManager(processes);
			processManager.OnInvalidProcessKilled += HandleOnInvalidProcessKilled;
		}

		private void HandleOnInvalidProcessKilled(string processName)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					RenderNotificationPopup("Lỗi", "chương trình không được phép chạy: " + processName);
				});
			}
			else
			{
				RenderNotificationPopup("Lỗi", "chương trình không được phép chạy: " + processName);
			}
		}

		#endregion

		#region Methods

		void RenderNotificationPopup(string title, string content)
		{
			popup.TitleText = title;
			popup.ContentText = content;

			popup.Popup();
		}

		#endregion

		#region Handle UI events

		private void btnConnectToServer_Click(object sender, EventArgs e)
		{
			clientProgram.Connect(txtServerIP.Text, SERVER_PORT);
			btnConnectToServer.Enabled = false;
		}

		private void btnSendStudentInfo_Click(object sender, EventArgs e)
		{
			if (cbDSThi.SelectedItem == null)
				return;

			Student student = cbDSThi.SelectedItem as Student;
			clientProgram.SendStudent(student);

			btnNopBaiThi.Enabled = true;
		}

		private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			counter -= 1;

			int minute = counter / 60;
			int second = counter % 60;

			if (counter % (30 * 60) == 0)
			{
				if (this.InvokeRequired)
				{
					this.BeginInvoke((MethodInvoker)delegate ()
					{
						string msg = "Thời gian còn lại để làm bài là: " + minute + " phút - " + second + " giây";
						RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
					});
				}
				else
				{
					string msg = "Thời gian còn lại để làm bài là: " + minute + " phút - " + second + " giây";
					RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
				}
			}
			else if (counter == (5 * 60))
			{
				if (this.InvokeRequired)
				{
					this.BeginInvoke((MethodInvoker)delegate ()
					{
						string msg = "Bạn cón 5 phút để hoàn thành bài thi";
						RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
					});
				}
				else
				{
					string msg = "Bạn cón 5 phút để hoàn thành bài thi";
					RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
				}
			}
			else if (counter == (3 * 60))
			{
				if (this.InvokeRequired)
				{
					this.BeginInvoke((MethodInvoker)delegate ()
					{
						string msg = "Bạn còn 3 phút để làm bài thi, chú ý thời gian để nén bài thi";
						RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
					});
				}
				else
				{
					string msg = "Bạn còn 3 phút để làm bài thi, chú ý thời gian để nén bài thi";
					RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
				}
			}
			else if (counter == (1 * 60))
			{
				if (this.InvokeRequired)
				{
					this.BeginInvoke((MethodInvoker)delegate ()
					{
						string msg = "Vui lòng nén bài thi để chuẩn bị thu bài, chấp nhận file nén kiểu: zip, 7z, rar";
						RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
					});
				}
				else
				{
					string msg = "Vui lòng nén bài thi để chuẩn bị thu bài, chấp nhận file nén kiểu: zip, 7z, rar";
					RenderNotificationPopup("Chú ý thời gian làm bài thi", msg);
				}
			}

			lblThoiGianConLai.Text = minute + " phút - " + second + " giây";

			if (counter == 0)
			{
				countdown.Stop();

				btnNopBaiThi.PerformClick();
			}
		}

		private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbDSThi.SelectedItem == null)
			{
				return;
			}

			Student student = cbDSThi.SelectedItem as Student;
			lblHoTen.Text = student.FullName;
			lblMaSo.Text = student.MSSV;
		}

		private void btnNopBaiThi_Click(object sender, EventArgs e)
		{
			clientProgram.NopBaiThi();
		}

		#endregion

		private void btnDiemDanh_Click(object sender, EventArgs e)
		{
			if (cbDSThi.SelectedItem == null)
				return;

			Student student = cbDSThi.SelectedItem as Student;
			clientProgram.DiemDanhSinhVien(student);

			btnDiemDanh.Enabled = false;
		}

		private void lblDeThi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{ 
			Process.Start(lblDeThi.Text);
		}
	}
}
