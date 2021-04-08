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
		IPEndPoint IP;
		Socket client;

		string savePath = null; // Thu muc luu de thi

		event Action<string> _onSuccessNotification;
		public event Action<string> OnSuccessNotification
		{
			add
			{
				_onSuccessNotification += value;
			}
			remove
			{
				_onSuccessNotification -= value;
			}
		}

		event Action<string, Exception> _onErrorNotification;
		public event Action<string, Exception> OnErrorNotification
		{
			add
			{
				_onErrorNotification += value;
			}
			remove
			{
				_onErrorNotification -= value;
			}
		}

		event Action<string> _onReceivedExam;
		public event Action<string> OnReceivedExam
		{
			add
			{
				_onReceivedExam += value;
			}
			remove
			{
				_onReceivedExam -= value;
			}
		}

		public void Connect(string hostname, int port)
		{
			IP = new IPEndPoint(IPAddress.Parse(hostname), port);
			client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			string computerName = System.Environment.MachineName;

			try
			{
				client.Connect(IP);

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
			}
		}

		void SendDataToServer(DataContainer container)
		{
			try
			{
				if (container == null)
					throw new ArgumentException("Dữ liệu trống");

				client.Send(container.Serialize());
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
			if (client != null)
				client.Close();
		}

		void Receive()
		{
			try
			{
				while (true)
				{
					byte[] buffer = new byte[1024 * 1024 * 20];
					client.Receive(buffer);

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

							// Khong co duong dan chua de thi
							if (string.IsNullOrWhiteSpace(this.savePath))
							{
								// Handle error
								break;
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

								break;
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
									_onErrorNotification("Không tìm thấy thư mục lưu bài", null);

								break;
							}

							// Gui file .zip len server
							FileContainer fileNopBaiContainer = new FileContainer(fileNopBai, null);

							DataContainer dataContainerNopBai = new DataContainer(DataContainerType.ThuBai, fileNopBaiContainer);

							SendDataToServer(dataContainerNopBai);

							break;

						case DataContainerType.SendList:
							break;
						case DataContainerType.SendStudent:
							break;
						case DataContainerType.SendString:
							break;
						case DataContainerType.SendPcName:
							break;

						case DataContainerType.DisconnectAll:

							if (_onSuccessNotification != null)
								_onSuccessNotification("Đã ngắt đường truyền do nhận được yêu cầu đóng kết nối từ máy chủ");

							CloseConnection();
							break;

						case DataContainerType.BeginExam:
							break;

						case DataContainerType.FinishExam:

							break;

						case DataContainerType.LockClient:
							break;
						case DataContainerType.Undefined:
							break;
						default:
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
			}
		}	
	}
}
