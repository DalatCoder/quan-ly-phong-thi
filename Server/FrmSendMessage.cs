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
	public partial class FrmSendMessage : Form
	{
		public Action<string> onClickSendButton;

		public FrmSendMessage()
		{
			InitializeComponent();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			onClickSendButton(txtMessage.Text);
		}
	}
}
