using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Client
{
	public partial class FrmClient : Form
	{
		private const int SERVER_PORT = 2010;

		ClientProgram clientProgram;
		PopupNotifier popup;
		ProcessManager processManager;

		public FrmClient()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;

			clientProgram = new ClientProgram();

			clientProgram.OnSuccessNotification += HandleOnSuccessNotification;
			clientProgram.OnErrorNotification += HandleOnErrorNotification;
			clientProgram.OnReceivedExam += HandleOnReceivedExam;
			clientProgram.OnCamChuongTrinh += HandleOnCamChuongTrinh;

			clientProgram.onNhanThongBao = HandleOnNhanThongBao;
			clientProgram.onNhanDanhSachSVTuExcel = HandleOnNhanDanhSachSVTuExcel;

			InitProcessManager();
			InitPopupNotifier();
		}

		private void HandleOnCamChuongTrinh(List<string> programs)
		{
			foreach (string program in programs)
			{
				processManager.AddProcess(program);
			}
		}

		void InitProcessManager()
		{
			processManager = new ProcessManager();
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

		void InitPopupNotifier()
		{
			popup = new PopupNotifier();
			popup.ShowOptionsButton = false;
			popup.ContentPadding = new Padding(10, 3, 10, 3);
			popup.TitlePadding = new Padding(10, 3, 10, 3);
		}

		void RenderNotificationPopup(string title, string content)
		{
			popup.TitleText = title;
			popup.ContentText = content;

			popup.Popup();
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

		private void HandleOnReceivedExam(string examFileUrl)
		{
			lblDeThi.Text = examFileUrl;
		}

		private void btnConnectToServer_Click(object sender, EventArgs e)
		{
			clientProgram.Connect(txtServerIP.Text, SERVER_PORT);
			btnConnectToServer.Enabled = false;
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

		private void btnSendStudentInfo_Click(object sender, EventArgs e)
		{
			if (cbDSThi.SelectedItem == null)
				return;

			Student student = cbDSThi.SelectedItem as Student;
			clientProgram.SendStudent(student);
		}
	}
}
