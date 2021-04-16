using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Restart : Form
    {
        public Restart()
        {
            InitializeComponent();
        }

        private void Restart_Load(object sender, EventArgs e)
        {
            string cmdText;
            cmdText = "/C shutdown -r -t 2";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = cmdText;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
        }
    }
}
