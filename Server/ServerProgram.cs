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

		ClientInfoManager clientInfoManager;

		public ServerProgram()
		{
			clientList = new List<Socket>();
			clientInfoManager = new ClientInfoManager();
		}

		#region Events

		event Action<List<ClientInfo>> _onClientListChanged;
		public event Action<List<ClientInfo>> OnClientListChanged
		{
			add
			{
				_onClientListChanged += value;
			}
			remove
			{
				_onClientListChanged -= value;
			}
		}

		event Action<IPEndPoint> _onServerStarted;
		public event Action<IPEndPoint> OnServerStarted
		{
			add
			{
				_onServerStarted += value;
			}
			remove
			{
				_onServerStarted -= value;
			}
		}

		#endregion

		#region Init client info list

		public void SetClientInfoList(string FirstIP, string LastIP, string SubnetMask)
		{
			clientInfoManager = new ClientInfoManager(FirstIP, LastIP, SubnetMask);

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoManager.Clients);
		}

		public void SetClientInfoList(int numberOfClients)
		{
			clientInfoManager = new ClientInfoManager(numberOfClients);

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoManager.Clients);
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
						Status = ClientInfoStatus.ClientConnected
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

					DataContainer response = DataContainer.Deserialize(buffer);

					switch (response.Type)
					{
						case DataContainerType.SendPcName:

							string pcName = response.Data as string;
							clientInfo.PCName = pcName;
							clientInfo.Status = ClientInfoStatus.ClientConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.SendStudent:

							Student student = response.Data as Student;
							clientInfo.StudentInfo = student;
							clientInfo.Status = ClientInfoStatus.StudentConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoManager.Clients);

							break;

						case DataContainerType.ThuBai:
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

		public void PhatDeThi(List<string> danhSachDeThi, string savePath)
		{
			if (danhSachDeThi.Count == 0)
				return;

			List<FileContainer> listOfFiles = new List<FileContainer>();
			foreach (string deThiURL in danhSachDeThi)
			{
				listOfFiles.Add(new FileContainer(deThiURL, savePath));
			}

			if (danhSachDeThi.Count == 1)
				foreach (Socket client in clientList)
				{
					DataContainer container = new DataContainer(DataContainerType.PhatDe, listOfFiles[0]);
					client.Send(container.Serialize());
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
			}
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

		#endregion
	}
}
