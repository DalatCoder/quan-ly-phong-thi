using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Client
{
    public partial class FrmClient : Form
    {
        private const int SERVER_PORT = 2010;

        ClientProgram clientProgram;
        PopupNotifier popup;

        public FrmClient()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            clientProgram = new ClientProgram();

			clientProgram.OnSuccessNotification += HandleOnSuccessNotification;
			clientProgram.OnErrorNotification += HandleOnErrorNotification;
			clientProgram.OnReceivedExam += HandleOnReceivedExam;

            InitPopupNotifier();
        }

        void InitPopupNotifier()
		{
            popup = new PopupNotifier();
            popup.ShowOptionsButton = false;
            popup.ContentPadding = new Padding(10, 3, 10, 3);
            popup.TitlePadding = new Padding(10, 3, 10, 3); 
        }

        void RenderNotificationPopup(string title, string content)
		{           
            popup.TitleText = title;
            popup.ContentText = content;

            popup.Popup();
        }

		private void HandleOnErrorNotification(string errorMessage, Exception ex)
		{

            string msg = errorMessage;

            if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
                msg += ". " + ex.Message;

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderNotificationPopup("Thông báo lỗi", msg);
                });
            }
            else
            {
                RenderNotificationPopup("Thông báo lỗi", msg);
            }
		}

		private void HandleOnSuccessNotification(string message)
		{
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderNotificationPopup("Thông báo mới", message);
                });
            }
            else
            {
                RenderNotificationPopup("Thông báo mới", message);
            }

        }

		private void HandleOnReceivedExam(string examFileUrl)
		{
            lblDeThi.Text = examFileUrl;
		}

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            clientProgram.Connect(txtServerIP.Text, SERVER_PORT);
            btnConnectToServer.Enabled = false;
        }
    }
}
