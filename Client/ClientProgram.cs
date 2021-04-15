using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;
using Common;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
	public class ClientProgram
	{
		private const int BUFFER_SIZE = 1 * 1024 * 1024 * 20; // 20Mb

		IPEndPoint IP;
		Socket server;

		string savePath = null; // Thu muc luu de thi

		#region Define events

		event Action<string> _onSuccessNotification;
		public event Action<string> OnSuccessNotification
		{
			add { _onSuccessNotification += value; }
			remove { _onSuccessNotification -= value; }
		}

		event Action<string, Exception> _onErrorNotification;
		public event Action<string, Exception> OnErrorNotification
		{
			add { _onErrorNotification += value; }
			remove { _onErrorNotification -= value; }
		}

		event Action _onClientDisconnected;
		public event Action OnClientDisconnected
		{
			add { _onClientDisconnected += value; }
			remove { _onClientDisconnected -= value; }
		}

		event Action<string> _onReceivedExam;
		public event Action<string> OnReceivedExam
		{
			add { _onReceivedExam += value; }
			remove { _onReceivedExam -= value; }
		}

		event Action<List<string>> _onCamChuongTrinh;
		public event Action<List<string>> OnCamChuongTrinh
		{
			add { _onCamChuongTrinh += value; }
			remove { _onCamChuongTrinh -= value; }
		}

		event Action<SubjectAndTime> _onNhanMonThiVaThoiGian;
		public event Action<SubjectAndTime> OnNhanMonThiVaThoiGian
		{
			add { _onNhanMonThiVaThoiGian += value; }
			remove { _onNhanMonThiVaThoiGian -= value; }
		}

		public Action<string> onNhanThongBao;
		public Action<List<Student>> onNhanDanhSachSVTuExcel;
		public Action<int> onNhanSoPhut;

		#endregion

		public void Connect(string hostname, int port)
		{
			IP = new IPEndPoint(IPAddress.Parse(hostname), port);
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			string computerName = System.Environment.MachineName;

			try
			{
				server.Connect(IP);

				if (_onSuccessNotification != null)
					_onSuccessNotification("Kết nối đến máy chủ thành công");

				DataContainer container = new DataContainer(DataContainerType.SendPcName, computerName);
				SendDataToServer(container);

				Thread listen = new Thread(Receive);
				listen.IsBackground = true;
				listen.Start();
			}
			catch (Exception ex)
			{
				if (_onErrorNotification != null)
					_onErrorNotification("Có lỗi xảy ra trong quá trình kết nối đến máy chủ", ex);

				if (_onClientDisconnected != null)
					_onClientDisconnected();
			}
		}

		void SendDataToServer(DataContainer container)
		{
			try
			{
				if (container == null)
					throw new ArgumentException("Dữ liệu trống");

				server.Send(container.Serialize());
			}
			catch (ArgumentException ex)
			{
				if (_onErrorNotification != null)
					_onErrorNotification("Dữ liệu gửi đi không hợp lệ", ex);
			}
			catch (Exception ex)
			{
				if (_onErrorNotification != null)
					_onErrorNotification("Có lỗi xảy ra trong quá trình gửi dữ liệu đến máy chủ", ex);
			}
		}

		public void CloseConnection()
		{
			if (server != null)
				server.Close();
		}

		public void SendStudent(Student student)
		{
			DataContainer container = new DataContainer(DataContainerType.GuiSinhVien, student);
			SendDataToServer(container);

			if (_onSuccessNotification != null)
				_onSuccessNotification("Đã gửi thông tin sinh viên lên máy chủ");
		}

		void Receive()
		{
			try
			{
				while (true)
				{
					byte[] buffer = new byte[BUFFER_SIZE];
					server.Receive(buffer);

					DataContainer dataContainer = DataContainer.Deserialize(buffer);

					switch (dataContainer.Type)
					{
						case DataContainerType.PhatDe:
							FileContainer fileContainer = dataContainer.Data as FileContainer;

							string savePath = fileContainer.SavePath;
							this.savePath = fileContainer.SavePath;

							if (Directory.Exists(savePath))
								Common.DirectoryHelper.DeleteAllFileInDirectory(savePath);

							Directory.CreateDirectory(savePath);

							string fileName = fileContainer.FileInfo.Name;

							string fullPath = Path.Combine(savePath, fileName);
							byte[] fileContent = fileContainer.FileContent;

							using (var fileStream = File.Create(fullPath))
							{
								fileStream.Write(fileContent, 0, fileContent.Length);
							}

							if (_onReceivedExam != null)
								_onReceivedExam(fullPath);

							if (_onSuccessNotification != null)
								_onSuccessNotification("Đã nhận đề thi thành công");

							break;

						case DataContainerType.ThuBai:
							NopBaiThi();
							break;

						case DataContainerType.CamChuongTrinh:
							List<string> programs = dataContainer.Data as List<string>;

							if (_onCamChuongTrinh != null)
								_onCamChuongTrinh(programs);

							break;

						case DataContainerType.GuiThongBaoAll:
							string message = dataContainer.Data.ToString();

							if (onNhanThongBao != null)
								onNhanThongBao(message);

							break;

						case DataContainerType.GuiDanhSachSV:
							List<Student> students = dataContainer.Data as List<Student>;

							if (onNhanDanhSachSVTuExcel != null)
								onNhanDanhSachSVTuExcel(students);

							break;

						case DataContainerType.BatDauLamBai:
							int minnute = Convert.ToInt32(dataContainer.Data);

							if (onNhanSoPhut != null)
								onNhanSoPhut(minnute);

							break;

						case DataContainerType.GuiThoiGianLamBai:

							SubjectAndTime data = dataContainer.Data as SubjectAndTime;

							if (_onNhanMonThiVaThoiGian != null)
								_onNhanMonThiVaThoiGian(data);

							break;

						case DataContainerType.DisconnectAll:

							if (_onSuccessNotification != null)
								_onSuccessNotification("Đã ngắt đường truyền do nhận được yêu cầu đóng kết nối từ máy chủ");

							CloseConnection();

							if (_onClientDisconnected != null)
								_onClientDisconnected();

							break;

						default:

							if (_onErrorNotification != null)
								_onErrorNotification("Lỗi không xác định, vui lòng khởi động lại phần mềm", null);

							break;
					}
				}
			}
			catch (Exception ex)
			{
				if (_onErrorNotification != null)
				{
					string msg = "Có lỗi xảy ra trong quá trình tương tác với server. Đã ngắt đường truyền";
					_onErrorNotification(msg, ex);
				}

				CloseConnection();

				if (_onClientDisconnected != null)
					_onClientDisconnected();
			}
		}

		public void NopBaiThi()
		{
			// Khong co duong dan chua de thi
			if (string.IsNullOrWhiteSpace(this.savePath))
			{

				if (_onErrorNotification != null)
					_onErrorNotification("Không tìm thấy đường dẫn chứa bài thi", null);

				return;
			}

			// Khong co thu muc luu bai thi
			if (!Directory.Exists(this.savePath))
			{
				// Handle error
				if (_onErrorNotification != null)
				{
					string msg = "Không tìm thấy thư mục lưu bài thi tại: " + this.savePath;

					_onErrorNotification(msg, null);
				}

				return;
			}

			List<string> allowFileExtensions = new List<string>()
							{
								".zip",
								".7z",
								".rar"
							};

			// Tim file .zip trong thu muc luu bai thi
			DirectoryInfo d = new DirectoryInfo(this.savePath);
			FileInfo[] Files = d.GetFiles("*.*");

			string fileNopBai = null;
			foreach (FileInfo file in Files)
			{
				string filename = file.Name;
				string extension = Path.GetExtension(filename);

				if (allowFileExtensions.Contains(extension))
				{
					fileNopBai = file.FullName;
					break;
				}
			}

			if (string.IsNullOrWhiteSpace(fileNopBai))
			{
				if (_onErrorNotification != null)
					_onErrorNotification("Không tìm thấy file nén bài làm", null);

				return;
			}

			// Gui file .zip len server
			FileContainer fileNopBaiContainer = new FileContainer(fileNopBai, null);

			DataContainer dataContainerNopBai = new DataContainer(DataContainerType.ThuBai, fileNopBaiContainer);

			SendDataToServer(dataContainerNopBai);

			if (_onSuccessNotification != null)
				_onSuccessNotification("Đã gửi file nén bài làm lên máy chủ");
		}
	}
}
