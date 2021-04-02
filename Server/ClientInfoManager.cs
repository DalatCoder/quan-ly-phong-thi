using System;
using System.Collections.Generic;

namespace Server
{
	public class ClientInfoManager
	{
		private const string DEFAULT_IP = "0.0.0.0";

		private readonly List<ClientInfo> _clients;
		private bool _generateByNumberOfClients;

		public List<ClientInfo> Clients
		{
			get
			{
				return new List<ClientInfo>(_clients);
			}
		}

		public ClientInfoManager()
		{
			_generateByNumberOfClients = false;
			_clients = new List<ClientInfo>();
		}

		public ClientInfoManager(string firstIP, string lastIP, string subnetMask)
		{
			_generateByNumberOfClients = false;
			_clients = new List<ClientInfo>();

			try
			{
				string s1 = "", s2 = "";
				int y = 0, x = 0, z = 0, t = 0;
				if (firstIP != "")
				{
					s1 = firstIP.Substring(0, firstIP.LastIndexOf("."));
					x = int.Parse(firstIP.Substring(firstIP.LastIndexOf(".") + 1));
				}

				if (lastIP != "")
				{
					s2 = lastIP.Substring(0, lastIP.LastIndexOf("."));
					y = int.Parse(lastIP.Substring(lastIP.LastIndexOf(".") + 1));
				}

				t = y - x;
				if (subnetMask != "")
					z = 256 - int.Parse(subnetMask.Substring(subnetMask.LastIndexOf(".") + 1));

				if (x < 255 && y < 255 && s1.CompareTo(s2) == 0)
				{
					for (int i = x; i < z && i <= y; i++)
					{
						string ip = s1 + "." + i.ToString();

						ClientInfo clientInfo = new ClientInfo();
						clientInfo.ClientIP = ip;
						_clients.Add(clientInfo);
					}
				}
				else
				{
					throw new Exception("Thông tin dãy IP của máy con không hợp lệ");
				}	
			}
			catch
			{
				throw new Exception("Thông tin dãy IP của máy con không hợp lệ");
			}
		}

		public ClientInfoManager(int numberOfClients)
		{
			_generateByNumberOfClients = true;
			_clients = new List<ClientInfo>();

			for (int i = 0; i < numberOfClients; i++)
			{
				ClientInfo clientInfo = new ClientInfo();
				clientInfo.ClientIP = DEFAULT_IP;
				_clients.Add(clientInfo);
			}
		}
	
		public void Add(ClientInfo client)
		{
			int? index = IndexOf(client);
			if (index != null)
			{
				_clients[(int)index] = client;
				return;
			}

			if (_generateByNumberOfClients)
			{
				AddNewClient_GenerateByNumberOfClients(client);
			}
			else
			{
				AddTail(client);
			}
		}

		void AddNewClient_GenerateByNumberOfClients(ClientInfo client)
		{
			int i = 0;
			while (true)
			{
				if (_clients[i].ClientIP.Equals(DEFAULT_IP)) break;
				i++;
			}

			_clients[i] = client;
		}

		void AddTail(ClientInfo client)
		{
			_clients.Add(client);
		}

		public ClientInfo Find(ClientInfo client)
		{
			for (int i = 0; i < _clients.Count; i++)
			{
				if (_clients[i].ClientIP.Equals(client.ClientIP))
					return _clients[i];
			}

			return null;
		}

		public ClientInfo Find(string ipAddress)
		{
			for (int i = 0; i < _clients.Count; i++)
			{
				if (_clients[i].ClientIP.Equals(ipAddress))
					return _clients[i];
			}

			return null;
		}

		public int? IndexOf(ClientInfo client)
		{
			for (int i = 0; i < _clients.Count; i++)
			{
				if (_clients[i].ClientIP.Equals(client.ClientIP))
					return i;
			}

			return null;
		}

		public int? IndexOf(string ipAddress)
		{
			for (int i = 0; i < _clients.Count; i++)
			{
				if (_clients[i].ClientIP.Equals(ipAddress))
					return i;
			}

			return null;
		}

		public void DisconnectAll()
		{
			foreach (ClientInfo item in _clients)
			{
				if (item.Status != ClientInfoStatus.Undefined)
					item.Status = ClientInfoStatus.Disconnected;
			}
		}
	}
}
