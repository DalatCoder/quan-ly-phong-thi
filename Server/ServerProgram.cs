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

		List<ClientInfo> clientInfoList;

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
			clientInfoList = new List<ClientInfo>();
			try
			{
				string s1 = "", s2 = "";
				int y = 0, x = 0, z = 0, t = 0;
				if (FirstIP != "")
				{
					s1 = FirstIP.Substring(0, FirstIP.LastIndexOf("."));
					x = int.Parse(FirstIP.Substring(FirstIP.LastIndexOf(".") + 1));
				}
				if (LastIP != "")
				{
					s2 = LastIP.Substring(0, LastIP.LastIndexOf("."));
					y = int.Parse(LastIP.Substring(LastIP.LastIndexOf(".") + 1));
				}
				t = y - x;
				if (SubnetMask != "")
					z = 256 - int.Parse(SubnetMask.Substring(SubnetMask.LastIndexOf(".") + 1));

				if (x < 255 && y < 255 && s1.CompareTo(s2) == 0)
				{
					for (int i = x; i < z && i <= y; i++)
					{
						string ip = s1 + "." + i.ToString();

						ClientInfo clientInfo = new ClientInfo();
						clientInfo.ClientIP = ip;
						clientInfoList.Add(clientInfo);
					}

					if (_onClientListChanged != null)
						_onClientListChanged(clientInfoList);
				}
				// else
				// MessageBox.Show("Nhập sai");
			}
			catch
			{
				// MessageBox.Show("Nhập IP sai");
			}
		}

		public void SetClientInfoList(int clientNum)
		{
			clientInfoList = new List<ClientInfo>();

			for (int i = 0; i < clientNum; i++)
			{
				string ip = "0.0.0.0";

				ClientInfo clientInfo = new ClientInfo();
				clientInfo.ClientIP = ip;
				clientInfoList.Add(clientInfo);
			}

			if (_onClientListChanged != null)
				_onClientListChanged(clientInfoList);
		}

		#endregion

		#region Start server

		public void Start()
		{
			IP = new IPEndPoint(IPAddress.Any, PORT);
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			clientList = new List<Socket>();
			clientInfoList = new List<ClientInfo>();

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

					ClientInfo clientInfo = FindClientInfo(clientIP);
					if (clientInfo != null)
					{
						clientInfo.Endpoint = clientSocket.RemoteEndPoint as IPEndPoint;
					}
					else
					{
						clientInfo = new ClientInfo();
						clientInfo.ClientIP = clientIP;
						clientInfo.Endpoint = clientSocket.RemoteEndPoint as IPEndPoint;
						clientInfoList.Add(clientInfo);
					}

					clientInfo.Status = ClientInfoStatus.ClientConnected;

					if (_onClientListChanged != null)
						_onClientListChanged(clientInfoList);

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
			ClientInfo clientInfo = FindClientInfo(clientIP);

			try
			{
				while (true)
				{
					byte[] buffer = new byte[BUFFER_SIZE];
					client.Receive(buffer);

					ServerResponse response = ServerResponse.Deserialize(buffer);

					switch (response.Type)
					{
						case ServerResponseType.SendPcName:

							string pcName = response.Data as string;
							clientInfo.PCName = pcName;
							clientInfo.Status = ClientInfoStatus.ClientConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoList);

							break;

						case ServerResponseType.SendStudent:

							Student student = response.Data as Student;
							clientInfo.StudentInfo = student;
							clientInfo.Status = ClientInfoStatus.StudentConnected;

							if (_onClientListChanged != null)
								_onClientListChanged(clientInfoList);

							break;

						case ServerResponseType.SendFile:
							break;

						case ServerResponseType.SendList:
							break;

						case ServerResponseType.SendString:
							break;

						case ServerResponseType.BeginExam:
							break;

						case ServerResponseType.FinishExam:
							break;

						case ServerResponseType.LockClient:
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
					_onClientListChanged(clientInfoList);

				clientList.Remove(client);
				client.Close();
			}
		}

		#endregion

		ClientInfo FindClientInfo(string ipAddress)
		{
			return clientInfoList.Find(c => c.ClientIP.Equals(ipAddress));
		}
	}
}
