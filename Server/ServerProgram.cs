using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using Common;
using System.Runtime.InteropServices;
using System.IO;

namespace Server
{
	public class ServerProgram
	{
		private const int PORT = 2010;
		private const int BUFFER_SIZE = 1 * 1024 * 1024 * 20; // 20Mb

		IPEndPoint IP;
		Socket server;
		List<Socket> clientList;

		string clientPath = null; // Đường dẫn lưu trữ đề thi ở phía client
		string serverPath = null; // Đường dẫn lưu trữ bài làm ở phía server

		ClientInfoManager clientInfoManager;

		public ServerProgram()
		{
			clientList = new List<Socket>();
			clientInfoManager = new ClientInfoManager();
		}

		#region Events

		event Action<string> _onNotification;
		public event Action<string> OnNotification
		{
			add { _onNotification += value; }
			remove { _onNotification -= value; }
		}

		event Action<List<ClientInfo>> _onClientListChanged;
		public event Action<List<ClientInfo>> OnClientListChanged
		{
			add { _onClientListChanged += value; }
			remove { _onClientListChanged -= value; }
		}

		event Action<IPEndPoint> _onServerStarted;
		public event Action<IPEndPoint> OnServerStarted
		{
			add { _onServerStarted += value; }
			remove { _onServerStarted -= value; }
		}

		public Action<Student> onNhanSinhVien;

		#endregion

		#region Init client info list

		public void SetClientInfoList(string FirstIP, string LastIP, string SubnetMask)
		{
			clientInfoManager = new ClientInfoManager(FirstIP, LastIP, SubnetMask);

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoManager.Clients);

			if (_onNotification != null)
			{
				string numClients = clientInfoManager.Clients.Count.ToString();
				string message =
					"Đã khởi tạo " + numClients + 
					" máy con trong vùng IP từ " + 
					FirstIP + " đến " + LastIP + ".";

				_onNotification(message);
			}

		}

		public void SetClientInfoList(int numberOfClients)
		{
			clientInfoManager = new ClientInfoManager(numberOfClients);

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoManager.Clients);

			if (_onNotification != null)
				_onNotification("Đã khởi tạo " + clientInfoManager.Clients.Count + " máy con");
		}

		#endregion

		#region Start server

		public void Start()
		{
			IP = new IPEndPoint(IPAddress.Any, PORT);
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			server.Bind(IP);

			Thread listen = new Thread(StartServer)
			{
				IsBackground = true
			};

			listen.Start();

			IPEndPoint serverIP = null;

			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					serverIP = new IPEndPoint(ip, PORT);
					break;
				}
			}

			if (_onServerStarted != null && serverIP != null)
				_onServerStarted(serverIP);

			if (_onNotification != null)
				_onNotification("Máy chủ đã khởi động tại cổng " + PORT);
		}

		void StartServer()
		{
			try
			{
				while (true)
				{
					server.Listen(100);

					Socket clientSocket = server.Accept();

					clientList.Add(clientSocket);

					string clientIP = clientSocket.RemoteEndPoint.ToString().Split(':')[0];

					ClientInfo newClient = new ClientInfo()
					{
						Endpoint = clientSocket.RemoteEndPoint as IPEndPoint,
						ClientIP = clientIP,
						Status = ClientInfoStatus.ClientConnected,
						StudentInfo = new Student()
					};

					// Thêm mới nếu chưa có, tự cập nhật nếu đã có
					clientInfoManager.Add(newClient);

					if (_onClientListChanged != null)
						_onClientListChanged(clientInfoManager.Clients);

					Thread receive = new Thread(Receive);
					receive.IsBackground = true;
					receive.Start(clientSocket);
				}
			}
			catch (Exception ex)
			{
				IP = new IPEndPoint(IPAddress.Any, PORT);
				server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			}
		}

		#endregion

		#region Receive and close server connection

		public void CloseConnection()
		{
			server.Close();
		}

		void Receive(object obj)
		{
			Socket client = obj as Socket;
			string clientIP = client.RemoteEndPoint.ToString().Split(':')[0];
			ClientInfo clientInfo = clientInfoManager.Find(clientIP);

			try
			{
				while (true)
				{
					byte[] buffer = new byte[BUFFER_SIZE];
					client.Receive(buffer);

					DataContainer dataContainer = DataContainer.Deserialize(buffer);

					switch (dataContainer.Type)
					{
						case DataContainerType.SendPcName:

							string pcName = dataContainer.Data as string;
							clientInfo.PCName = pcName;
							clientInfo.Status = ClientInfoStatus.ClientConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.SendStudent:

							Student student = dataContainer.Data as Student;
							clientInfo.StudentInfo = student;
							clientInfo.Status = ClientInfoStatus.StudentConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.ThuBai:

							FileContainer fileNopBaiContainer = dataContainer.Data as FileContainer;

							string savePath = this.serverPath;

							if (!Directory.Exists(savePath))
								Directory.CreateDirectory(savePath);

							string fileName = fileNopBaiContainer.FileInfo.Name;
							string fullPath = Path.Combine(savePath, fileName);

							byte[] fileContent = fileNopBaiContainer.FileContent;

							using (var fileStream = File.Create(fullPath))
								fileStream.Write(fileContent, 0, fileContent.Length);

							break;

						case DataContainerType.GuiSinhVien:
							Student student1 = dataContainer.Data as Student;

							clientInfo.StudentInfo = student1;
							clientInfo.Status = ClientInfoStatus.StudentConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.SendList:
							break;

						case DataContainerType.SendString:
							break;

						case DataContainerType.BeginExam:
							break;

						case DataContainerType.FinishExam:
							break;

						case DataContainerType.LockClient:
							break;

						default:
							break;
					}
				}
			}
			catch (Exception ex)
			{
				clientInfo.Status = ClientInfoStatus.Disconnected;

				if (_onClientListChanged != null)
					_onClientListChanged(clientInfoManager.Clients);

				clientList.Remove(client);
				client.Close();
			}
		}

		#endregion

		#region Methods

		public void SetClientPath(string clientPath)
		{
			this.clientPath = clientPath;

			if (_onNotification != null)
				_onNotification("Đã cập nhật đường dẫn lưu đề thi ở máy con");
		}

		public void SetServerPath(string serverPath)
		{
			this.serverPath = serverPath;

			if (_onNotification != null)
				_onNotification("Đã cập nhật đường dẫn lưu bài thi ở máy chủ");
		}

		public void PhatDeThi(List<string> danhSachDeThi)
		{
			if (danhSachDeThi.Count == 0)
				return;

			List<FileContainer> listOfFiles = new List<FileContainer>();
			foreach (string deThiURL in danhSachDeThi)
			{
				listOfFiles.Add(new FileContainer(deThiURL, this.clientPath));
			}

			if (danhSachDeThi.Count == 1)
			{
				FileContainer fileDeThi = listOfFiles[0];
				foreach (Socket client in clientList)
				{
					DataContainer container = new DataContainer(DataContainerType.PhatDe, fileDeThi);
					client.Send(container.Serialize());
				}

				if (_onNotification != null)
					_onNotification("Đã phát 1 đề cho tất cả máy con");
			}

			if (danhSachDeThi.Count > 1)
			{
				int soLuongDeThi = danhSachDeThi.Count;

				int counter = 0;

				foreach (Socket client in clientList)
				{
					DataContainer container = new DataContainer(DataContainerType.PhatDe, listOfFiles[counter]);
					client.Send(container.Serialize());

					counter++;

					if (counter == soLuongDeThi)
						counter = 0;
				}

				if (_onNotification != null)
					_onNotification("Đã phát xen kẽ đề thi cho tất cả máy con");
			}
		}

		public void batDauLamBai(int sophut)
		{
			DataContainer container = new DataContainer(DataContainerType.BatDauLamBai, sophut);
			foreach (Socket item in clientList)
			{
				item.Send(container.Serialize());
			}

			if (_onNotification != null)
				_onNotification("Bắt đầu tính thời gian làm bài");
		}

		public void ThuBai()
		{
			DataContainer container = new DataContainer(DataContainerType.ThuBai, null);

			foreach (Socket socket in clientList)
			{
				socket.Send(container.Serialize());
			}

			if (_onNotification != null)
				_onNotification("Đã gửi yêu cầu thu bài đến tất cả máy con");
		}

		public void DisconnectAll()
		{
			foreach (Socket socket in clientList)
			{
				DataContainer response = new DataContainer(DataContainerType.DisconnectAll, null);
				socket.Send(response.Serialize());
			}

			clientList.Clear();

			clientInfoManager.DisconnectAll();
		}

		public void CamChuongTrinh(List<string> programs)
		{
			DataContainer container = new DataContainer(DataContainerType.CamChuongTrinh, programs);

			foreach (Socket item in clientList)
			{
				item.Send(container.Serialize());
			}

			if (_onNotification != null)
				_onNotification("Đã gửi danh sách các chương trình bị cấm tới tất cả máy con");
		}

		public void GuiTinNhanChoTatCaMayCon(string tinNhan)
		{
			DataContainer dataContainer = new DataContainer(DataContainerType.GuiThongBaoAll, tinNhan);

			byte[] buffer = dataContainer.Serialize();

			foreach (Socket item in clientList)
			{
				item.Send(buffer);
			}

			if (_onNotification != null)
				_onNotification("Đã gửi tin nhắn đến tất cả máy con");
		}

		public void GuiDanhSachSinhVien(List<Student> students)
		{
			DataContainer dataContainer = new DataContainer(DataContainerType.GuiDanhSachSV, students);

			byte[] buffer = dataContainer.Serialize();

			foreach (Socket item in clientList)
			{
				item.Send(buffer);
			}

			if (_onNotification != null)
				_onNotification("Đã gửi danh sách sinh viên tới tất cả máy con");
		}

		public void GuiMonThiVaThoiGian(SubjectAndTime data)
		{
			DataContainer container = new DataContainer(DataContainerType.GuiThoiGianLamBai, data);

			byte[] buffer = container.Serialize();

			foreach (Socket socket in clientList)
			{
				socket.Send(buffer);
			}

			if (_onNotification != null)
				_onNotification("Đã gửi thông tin môn thi và thời gian làm bài tới tất cả máy con");
		}

        public void Disable()
        {
            List<ClientInfo> disableClients = clientInfoManager.GetEmptyClients();

            foreach (Socket socket in clientList)
            {
                string ip = socket.RemoteEndPoint.ToString().Split(':')[0];

                if (disableClients.Exists(c => c.ClientIP.Equals(ip)))
                {
                    DataContainer response = new DataContainer(DataContainerType.LockClient, null);
                    socket.Send(response.Serialize());
                }
            }
        }

        public void Enable()
        {
            foreach (Socket socket in clientList)
            {
                DataContainer response = new DataContainer(DataContainerType.UnlockClient, null);
                socket.Send(response.Serialize());
            }
        }

        public void Shutdown()
        {
            foreach (Socket socket in clientList)
            {
                DataContainer response = new DataContainer(DataContainerType.Shutdown, null);
                socket.Send(response.Serialize());
            }
        }

        public void Restart()
        {
            foreach (Socket socket in clientList)
            {
                DataContainer response = new DataContainer(DataContainerType.Restart, null);
                socket.Send(response.Serialize());
            }
        }

        #endregion
    }
}
