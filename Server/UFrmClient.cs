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

            txtStudentId.BorderStyle = BorderStyle.None;
            txtPCName.BorderStyle = BorderStyle.None;
            txtClientIP.BorderStyle = BorderStyle.None;

            Client = new ClientInfo(client);

            txtStudentId.Text = client.StudentInfo.ID;
            txtPCName.Text = client.PCName;
            txtClientIP.Text = client.ClientIP;

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

        private void UFrmClient_Load(object sender, EventArgs e)
        {

        }

        public void SetClient(ClientInfo client)
        {
            Client = client;

            txtStudentId.Text = client.StudentInfo.ID;
            txtPCName.Text = client.PCName;
            txtClientIP.Text = client.ClientIP;

            string imageName;

            switch (client.Status)
            {
                case ClientInfoStatus.Undefined:
                    imageName = "desktop-normal.png";
                    break;

                case ClientInfoStatus.StudentConnected:
                    imageName = "desktop-success.png";
                    break;

                case ClientInfoStatus.Disconnected:
                    imageName = "desktop-error.png";
                    break;

                default:
                    imageName = "desktop-normal.png";
                    break;
            }

            Bitmap bitmap = new Bitmap(Common.PathUtils.GetPathTo("Assets", imageName));
            pbClient.BackgroundImage = bitmap;
        }
    }
}
