﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        void RenderClientList(List<ClientInfo> clientList)
        {
            flpMain.Controls.Clear();

			foreach (ClientInfo clientInfo in clientList)
			{
                UFrmClient frm = new UFrmClient(clientInfo);
                flpMain.Controls.Add(frm);
			}
        }

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
    }
}
