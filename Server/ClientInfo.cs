using System.Net;
using System.Net.Sockets;
using Common;

namespace Server
{
    public enum ClientInfoStatus
    {
        Undefined,
        ClientConnected,
        StudentConnected,
        Disconnected
    }

    public class ClientInfo
    {
        public string PCName { get;  set; }

        public Student StudentInfo { get; set; }

        public IPEndPoint Endpoint { get; set; }

        public string ClientIP { get; set; }

        public ClientInfoStatus Status { get; set; }

        public ClientInfo()
        {
            StudentInfo = new Student();
            Endpoint = new IPEndPoint(IPAddress.Any, 0);
            Status = ClientInfoStatus.Undefined;
        }

        public ClientInfo(ClientInfo client)
        {
            PCName = client.PCName;
            StudentInfo = client.StudentInfo;
            Endpoint = client.Endpoint;
            ClientIP = client.ClientIP;
            Status = client.Status;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ClientInfo client = obj as ClientInfo;

            return client.ClientIP == ClientIP && client.PCName == PCName && client.Status == Status && client.StudentInfo.ID == StudentInfo.ID;
        }

		public override string ToString()
		{
			return base.ToString();
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
