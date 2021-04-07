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

        event Action _onSuccessConnected;
        public event Action OnSuccessConnected 
        { 
            add
            {
                _onSuccessConnected += value;
            }
            remove
            {
                _onSuccessConnected -= value;
            }
        }

        event Action<string> _onErrorConnected;
        public event Action<string> OnErrorConnected
        {
            add
            {
                _onErrorConnected += value;
            }
            remove
            {
                _onErrorConnected -= value;
            }
        }

        event Action<string> _onErrorReceived;
        public event Action<string> OnErrorReceived
        {
            add
            {
                _onErrorReceived += value;
            }
            remove
            {
                _onErrorReceived -= value;
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

                if (_onSuccessConnected != null)
                    _onSuccessConnected();

                DataContainer response = new DataContainer(DataContainerType.SendPcName, computerName);            
                client.Send(response.Serialize());
            }
            catch (Exception ex)
            {
                if (_onErrorConnected != null)
                    _onErrorConnected("Có lỗi trong quá trình kết nối đến server. " + ex.Message);

                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        public void CloseConnection()
        {
            if (client != null)
                client.Close();
        }

        public void Send(DataContainer response)
        {
            try
            {
                client.Send(response.Serialize());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                client.Close();
            }
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

                            if (!Directory.Exists(savePath))
                                Directory.CreateDirectory(savePath);

                            string fileName = fileContainer.FileInfo.Name;

                            string fullPath = Path.Combine(savePath, fileName);

                            using (var fileStream = File.Create(fullPath))
                            {
                                fileStream.Write(fileContainer.FileContent, 0, fileContainer.FileContent.Length);
                            }

							if (_onReceivedExam != null)
								_onReceivedExam(fullPath);

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
                            MessageBox.Show("Yêu cầu đóng kết nối từ server.");
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
                if (_onErrorReceived != null)
                    _onErrorReceived("Có lỗi xảy ra trong quá trình nhận phản hồi từ server. Đóng kết nối. " + ex.Message);

                CloseConnection();
            }
        }
    }
}
