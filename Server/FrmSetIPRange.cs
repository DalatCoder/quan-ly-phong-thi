using System;
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
    public partial class FrmSetIPRange : Form
    {
        public string IPBegin { get; private set; }
        public string IPEnd { get; private set; }
        public string SubnetMask { get; private set; }
        public int ClientNum { get; private set; }

        public FrmSetIPRange()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            IPBegin = txtIPBegin.Text;
            IPEnd = txtIpEnd.Text;
            SubnetMask = txtSubnetMask.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            SubnetMask = txtSubnetMask.Text;
            ClientNum = Convert.ToInt32(txtClientNumbers.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
