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
            clientProgram.OnSuccessConnected += HandleOnSuccessConnected;
            clientProgram.OnErrorConnected += HandleOnErrorConnected;
            clientProgram.OnErrorReceived += HandleOnErrorReceived;
        }

        private void HandleOnErrorReceived(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        private void HandleOnErrorConnected(string errorMessage)
        {
            this.Text = "Client - Xảy ra lỗi trong quá trình kết nối tới server";
            MessageBox.Show(errorMessage);
        }

        private void HandleOnSuccessConnected()
        {
            this.Text = "Client - Đã kết nối tới server";
        }

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            clientProgram.Connect(txtServerIP.Text, SERVER_PORT);
            btnConnectToServer.Enabled = false;
        }

        private void btnSendStudentInfo_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                ID = "1812756",
                FirstName = "Hieu",
                LastName = "Nguyen Trong"
            };

            ServerResponse response = new ServerResponse(ServerResponseType.SendStudent, student);

            clientProgram.Send(response);
        }
    }
}
