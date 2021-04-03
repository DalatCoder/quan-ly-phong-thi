using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Server
{
    public partial class UFrmClient : UserControl
    {
        public ClientInfo Client { get; private set; }

        public UFrmClient(ClientInfo client)
        {
            InitializeComponent();
            
            Client = new ClientInfo(client);

            SetContent(client);
            SetTooltip(client);
        }

        private void UFrmClient_Load(object sender, EventArgs e)
        {
            txtStudentId.BorderStyle = BorderStyle.None;
            txtPCName.BorderStyle = BorderStyle.None;
            txtClientIP.BorderStyle = BorderStyle.None;
        }

        public void SetClient(ClientInfo client)
        {
            Client = client;

            SetContent(client);
            SetTooltip(client);
        }

		#region Private methods

		void SetContent(ClientInfo client)
		{
            if (!string.IsNullOrWhiteSpace(client.ClientIP))
                txtClientIP.Text = client.ClientIP;
            else
                txtClientIP.Text = "No IP";

            if (!string.IsNullOrWhiteSpace(client.StudentInfo.ID))
                txtStudentId.Text = client.StudentInfo.ID;
            else
                txtStudentId.Text = "N/A";

            if (!string.IsNullOrWhiteSpace(client.PCName))
                txtPCName.Text = client.PCName;
            else
                txtPCName.Text = "N/A";

            string imageName;

            switch (client.Status)
            {
                case ClientInfoStatus.Undefined:
                    imageName = "desktop-undefined.png";
                    break;

                case ClientInfoStatus.ClientConnected:
                    imageName = "desktop-normal.png";
                    break;

                case ClientInfoStatus.StudentConnected:
                    imageName = "desktop-success.png";
                    break;

                case ClientInfoStatus.Disconnected:
                    imageName = "desktop-error.png";
                    break;

                default:
                    imageName = "desktop-undefined.png";
                    break;
            }

            Bitmap bitmap = new Bitmap(Common.PathUtils.GetPathTo("Assets", imageName));
            pbClient.BackgroundImage = bitmap;
        }

        void SetTooltip(ClientInfo client)
		{
            string message = "";

            if (client.Status == ClientInfoStatus.ClientConnected)
                message += "Máy con đã kết nối";
            else if (client.Status == ClientInfoStatus.StudentConnected)
                message += "Sinh viên đã kết nối";
            else if (client.Status == ClientInfoStatus.Disconnected)
                message += "Máy con mất kết nối";
            else
                message += "Máy con chưa kết nối";

            message += Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(client.PCName))
                message += client.PCName + Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(client.StudentInfo.ID))
                message += client.StudentInfo.ID + Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(client.StudentInfo.FullName))
                message += client.StudentInfo.FullName + Environment.NewLine;

            tltInfo.SetToolTip(pbClient, message);
		}

		#endregion
	}
}
