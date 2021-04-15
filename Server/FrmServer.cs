using Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Server
{
	public partial class Server : Form
	{
		ServerProgram serverProgram;
		PopupNotifier popup;
		int counter = 0; // Dem nguoc theo tung giay
		System.Timers.Timer countdown;

		public Server()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;

			serverProgram = new ServerProgram();

			serverProgram.SetClientPath(txtClientPath.Text);
			serverProgram.SetServerPath(txtServerPath.Text);

			serverProgram.OnServerStarted += HandleOnServerStarted;
			serverProgram.OnClientListChanged += HandleOnClientListChanged;
			countdown = new System.Timers.Timer();
			countdown.Elapsed += Countdown_Elapsed;
			countdown.Interval = 1000;

			serverProgram.Start();



			InitPopupNotifier();
		}



		void InitPopupNotifier()
		{
			popup = new PopupNotifier();
			popup.ShowOptionsButton = false;
			popup.ContentPadding = new Padding(10, 3, 10, 3);
			popup.TitlePadding = new Padding(10, 3, 10, 3);
		}

		#region Server Program Events

		private void HandleOnClientListChanged(List<ClientInfo> clientList)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					RenderClientList(clientList);
				});
			}
			else
			{
				RenderClientList(clientList);
			}
		}

		private void HandleOnServerStarted(System.Net.IPEndPoint serverIPendpoint)
		{
			this.Text = "Server is running at: " + serverIPendpoint.ToString();
		}

		#endregion

		#region Methods

		void RenderClientList(List<ClientInfo> clientList)
		{
			if (flpMain.Controls.Count == 0)
			{
				foreach (ClientInfo clientInfo in clientList)
				{
					UFrmClient frm = new UFrmClient(clientInfo);
					flpMain.Controls.Add(frm);
				}

				return;
			}

			int clientControlLength = flpMain.Controls.Count;
			int i = 0;
			for (i = 0; i < clientList.Count; i++)
			{
				ClientInfo clientInfoInList = clientList[i];

				if (i < clientControlLength)
				{
					UFrmClient frm = flpMain.Controls[i] as UFrmClient;
					ClientInfo clientInfoInControl = frm.Client;

					frm.SetClient(clientInfoInList);
				}
				else
				{
					UFrmClient frm = new UFrmClient(clientInfoInList);
					flpMain.Controls.Add(frm);
				}
			}

			if (i < flpMain.Controls.Count)
				for (int j = flpMain.Controls.Count - 1; j >= i; j--)
					flpMain.Controls.RemoveAt(j);
		}

		#endregion

		#region Handle events on UI

		private void cmdNhapVungIP_Click(object sender, EventArgs e)
		{
			FrmSetIPRange frm = new FrmSetIPRange();
			DialogResult result = frm.ShowDialog();

			if (result != DialogResult.OK) return;

			string FirstIP = frm.IPBegin;
			string LastIP = frm.IPEnd;
			string SubnetMask = frm.SubnetMask;
			int clientNum = frm.ClientNum;

			if (clientNum == 0)
			{
				serverProgram.SetClientInfoList(FirstIP, LastIP, SubnetMask);
			}
			else
			{
				serverProgram.SetClientInfoList(clientNum);
			}

		}

		private void btnDisconnectAll_Click(object sender, EventArgs e)
		{
			serverProgram.DisconnectAll();
		}

		private void btnThemDe_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "All files (*.*)|*.*";
			openFile.Multiselect = true;

			if (openFile.ShowDialog() != DialogResult.OK)
				return;

			foreach (string filename in openFile.FileNames)
			{
				ListViewItem row = new ListViewItem();
				row.Text = Path.GetFileName(filename);
				row.Tag = filename;
				lsvDeThi.Items.Add(row);
			}
		}

		private void btnXoaDe_Click(object sender, EventArgs e)
		{
			if (lsvDeThi.SelectedItems.Count == 0)
				return;

			lsvDeThi.Items.Remove(lsvDeThi.SelectedItems[0]);
		}

		private void btnPhatDe_Click(object sender, EventArgs e)
		{
			if (lsvDeThi.Items.Count == 0)
			{
				MessageBox.Show("Vui long chon de thi");
				return;
			}

			List<string> listOfDeThiURL = new List<string>();
			string clientPath = txtClientPath.Text;
			string serverPath = txtServerPath.Text;

			if (string.IsNullOrWhiteSpace(clientPath))
			{
				MessageBox.Show("Vui long nhap duong dan phat bai thi hop le");
				return;
			}
			if (string.IsNullOrWhiteSpace(serverPath))
			{
				MessageBox.Show("Vui long nhap duong dan luu bai hop le");
				return;
			}

			foreach (ListViewItem row in lsvDeThi.Items)
			{
				string deThiURL = row.Tag as string;
				listOfDeThiURL.Add(deThiURL);
			}

			serverProgram.PhatDeThi(listOfDeThiURL);
		}

		private void btnThuBai_Click(object sender, EventArgs e)
		{
			serverProgram.ThuBai();
		}

		private void btnChonServerPath_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txtServerPath.Text = fbd.SelectedPath;
					serverProgram.SetServerPath(fbd.SelectedPath);
				}
			}
		}

		private void btnChonClientPath_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txtClientPath.Text = fbd.SelectedPath;
					serverProgram.SetClientPath(fbd.SelectedPath);
				}
			}
		}


		private void button1_Click(object sender, EventArgs e)
		{
			string cmdText;
			cmdText = "/C shutdown -i";

			Process p = new Process();
			p.StartInfo.FileName = "cmd.exe";
			p.StartInfo.Arguments = cmdText;
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			p.Start();
		}

		#endregion

		private void btnGuiTinNhan_Click(object sender, EventArgs e)
		{
			FrmSendMessage frmSendMessage = new FrmSendMessage();

			frmSendMessage.onClickSendButton = HandleOnClickSendButton;

			frmSendMessage.ShowDialog();
		}

		void HandleOnClickSendButton(string tinnhan)
		{
			// gui tin nhan toi client
			serverProgram.GuiTinNhanChoTatCaMayCon(tinnhan);
		}

		List<Student> DocNoiDungFileExcel(string duongDanFileExcel)
		{
			// Doc file excel
			List<Student> students = new List<Student>();
			try
			{
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

				//mở file excel
				var package = new ExcelPackage(new FileInfo(duongDanFileExcel));

				//lấy ra sheet đầu tiên để thao tác
				ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

				//duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. Lưu ý file excel bắt đầu từ số 1 không phải số 0
				for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
				{
					try
					{
						// biến j biểu thị cho một column trong file
						int j = 1;

						// lấy ra cột mã số sinh viên tương ứng giá trị tại vị trí [i, 1]. i lần đầu là 2
						//tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
						string mssv = worksheet.Cells[i, j++].Value.ToString();

						// lấy ra cột họ và tên đệm tương ứng giá trị tại vị trí [i, 2]. i lần đầu là 2
						//tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
						string hoDem = worksheet.Cells[i, j++].Value.ToString();

						// lấy ra cột tên tương ứng giá trị tại vị trí [i, 3]. i lần đầu là 2
						//tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
						string ten = worksheet.Cells[i, j++].Value.ToString();

						// tạo student từ dữ liệu đã lấy được 
						Student student = new Student()
						{
							MSSV = mssv,
							LastName = hoDem,
							FirstName = ten
						};

						// add student vào danh sách students
						students.Add(student);
					}
					catch (Exception exe)
					{


					}

				}
			}
			catch (Exception ee)
			{

				MessageBox.Show("Error!" + ee.Message);
			}


			return students;
		}

		private void btnGuiDSSVTuFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			DialogResult result = fileDialog.ShowDialog();
			if (result==DialogResult.OK)
			{
				string duongdan = fileDialog.FileName;
				List<Student> danhSachSV = DocNoiDungFileExcel(duongdan);

				if (danhSachSV.Count == 0)
					return;

				serverProgram.GuiDanhSachSinhVien(danhSachSV);
			}
			
		}

		private void btnLayDSSinhVienTuCSDL_Click(object sender, EventArgs e)
		{
			List<Student> danhSachSV = StudentDAO.Instance.GetStudents();

			if (danhSachSV.Count == 0)
				return;

			serverProgram.GuiDanhSachSinhVien(danhSachSV);
		}

		private void cmdBatDauLamBai_Click(object sender, EventArgs e)
		{
			int minute = Convert.ToInt32(txtThoiGianLamBai.Text);
			counter = minute * 60;
			countdown.Enabled = true;

			serverProgram.batDauLamBai(minute);


		}
		private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			counter -= 1;

			int minute = counter / 60;
			int second = counter % 60;

			lblTimeLeft.Text = minute + ":" + second;
			if (counter == 0)
			{
				countdown.Stop();

				serverProgram.GuiTinNhanChoTatCaMayCon("Đã Hết Thời Gian Làm bài");
			}
		}

		private void BtnBlockApps_Click(object sender, EventArgs e)
		{
			FrmChooseProgram frm = new FrmChooseProgram();
			frm.ShowDialog();

			List<string> selectedPrograms = frm.selectedPrograms;
			serverProgram.CamChuongTrinh(selectedPrograms);
		}

		private void cmdChapNhan_Click(object sender, EventArgs e)
		{
			SubjectAndTime data = new SubjectAndTime();
			data.Subject = cbMonHoc.SelectedItem.ToString();
			data.Minute = Convert.ToInt32(txtThoiGianLamBai.Text);

			serverProgram.GuiMonThiVaThoiGian(data);
		}

		private void txtServerPath_TextChanged(object sender, EventArgs e)
		{
			serverProgram.SetServerPath(txtServerPath.Text);
		}

		private void txtClientPath_TextChanged(object sender, EventArgs e)
		{
			serverProgram.SetClientPath(txtClientPath.Text);
		}
	}
}
