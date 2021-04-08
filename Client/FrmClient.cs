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

namespace Client
{
    public partial class FrmClient : Form
    {
        private const int SERVER_PORT = 2010;

        ClientProgram clientProgram;        

        public FrmClient()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            clientProgram = new ClientProgram();

			clientProgram.OnSuccessNotification += HandleOnSuccessNotification;
			clientProgram.OnErrorNotification += HandleOnErrorNotification;
			clientProgram.OnReceivedExam += HandleOnReceivedExam;
        }

		private void HandleOnErrorNotification(string errorMessage, Exception ex)
		{
            string msg = errorMessage;

            if (ex != null && !string.IsNullOrWhiteSpace(ex.Message))
                msg += ". " + ex.Message;

            MessageBox.Show(msg);
		}

		private void HandleOnSuccessNotification(string message)
		{
            MessageBox.Show(message);
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
