using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        ServerProgram serverProgram;

        public Server()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            serverProgram = new ServerProgram();

            serverProgram.SetClientPath(txtClientPath.Text);
            serverProgram.SetServerPath(txtServerPath.Text);

            serverProgram.OnServerStarted += HandleOnServerStarted;
            serverProgram.OnClientListChanged += HandleOnClientListChanged;

            serverProgram.Start();
        }

        #region Server Program Events

        private void HandleOnClientListChanged(List<ClientInfo> clientList)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    RenderClientList(clientList);
                });
            }
            else
            {
                RenderClientList(clientList);
            }
        }

        private void HandleOnServerStarted(System.Net.IPEndPoint serverIPendpoint)
        {
            this.Text = "Server is running at: " + serverIPendpoint.ToString();
        }

		#endregion

		#region Methods

		void RenderClientList(List<ClientInfo> clientList)
        {
            if (flpMain.Controls.Count == 0)
			{
                foreach (ClientInfo clientInfo in clientList)
                {
                    UFrmClient frm = new UFrmClient(clientInfo);
                    flpMain.Controls.Add(frm);
                }

                return;
            }

            int clientControlLength = flpMain.Controls.Count;
            int i = 0;
            for (i = 0; i < clientList.Count; i++)
			{
                ClientInfo clientInfoInList = clientList[i];

                if (i < clientControlLength)
				{
                    UFrmClient frm = flpMain.Controls[i] as UFrmClient;
                    ClientInfo clientInfoInControl = frm.Client;

                    frm.SetClient(clientInfoInList);
				}
				else
				{
                    UFrmClient frm = new UFrmClient(clientInfoInList);
                    flpMain.Controls.Add(frm);
                }
			}

            if (i < flpMain.Controls.Count)
                for (int j = flpMain.Controls.Count - 1; j >= i; j--)
                    flpMain.Controls.RemoveAt(j);
        }

		#endregion

		#region Handle events on UI

		private void cmdNhapVungIP_Click(object sender, EventArgs e)
        {
            FrmSetIPRange frm = new FrmSetIPRange();
            DialogResult result = frm.ShowDialog();

            if (result != DialogResult.OK) return;

            string FirstIP = frm.IPBegin;
            string LastIP = frm.IPEnd;
            string SubnetMask = frm.SubnetMask;
            int clientNum = frm.ClientNum;

            if (clientNum == 0)
            {
                serverProgram.SetClientInfoList(FirstIP, LastIP, SubnetMask);
            }
            else
            {
                serverProgram.SetClientInfoList(clientNum);
            }

        }

		private void btnDisconnectAll_Click(object sender, EventArgs e)
		{
            serverProgram.DisconnectAll();
		}

		private void btnThemDe_Click(object sender, EventArgs e)
		{
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All files (*.*)|*.*";
            openFile.Multiselect = true;

            if (openFile.ShowDialog() != DialogResult.OK)
                return;

			foreach (string filename in openFile.FileNames)
			{
                ListViewItem row = new ListViewItem();
                row.Text = Path.GetFileName(filename);
                row.Tag = filename;
                lsvDeThi.Items.Add(row);
            }
        }

        private void btnXoaDe_Click(object sender, EventArgs e)
        {
            if (lsvDeThi.SelectedItems.Count == 0)
                return;

            lsvDeThi.Items.Remove(lsvDeThi.SelectedItems[0]);
        }

        private void btnPhatDe_Click(object sender, EventArgs e)
		{
            if (lsvDeThi.Items.Count == 0)
			{
                MessageBox.Show("Vui long chon de thi");
                return;
			}                

            List<string> listOfDeThiURL = new List<string>();
            string clientPath = txtClientPath.Text;
            string serverPath = txtServerPath.Text;

            if (string.IsNullOrWhiteSpace(clientPath))
			{
                MessageBox.Show("Vui long nhap duong dan phat bai thi hop le");
                return;
			}
            if (string.IsNullOrWhiteSpace(serverPath))
			{
                MessageBox.Show("Vui long nhap duong dan luu bai hop le");
                return;
			}

			foreach (ListViewItem row in lsvDeThi.Items)
			{
                string deThiURL = row.Tag as string;
                listOfDeThiURL.Add(deThiURL);
			}

            serverProgram.PhatDeThi(listOfDeThiURL);
		}

		private void btnThuBai_Click(object sender, EventArgs e)
		{
            serverProgram.ThuBai();
		}

		private void btnChonServerPath_Click(object sender, EventArgs e)
		{
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtServerPath.Text = fbd.SelectedPath;
                    serverProgram.SetServerPath(fbd.SelectedPath);
                }
            }
        }

		private void btnChonClientPath_Click(object sender, EventArgs e)
		{
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtClientPath.Text = fbd.SelectedPath;
                    serverProgram.SetClientPath(fbd.SelectedPath);
                }
            }
        }

		#endregion


	}
}
