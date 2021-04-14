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
	public partial class FrmChooseProgram : Form
	{
		public List<string> selectedPrograms;

		public FrmChooseProgram()
		{
			InitializeComponent();
			selectedPrograms = new List<string>();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "Program files (*.exe)|*.exe";
			DialogResult result = openFile.ShowDialog();

			if (result == DialogResult.OK)
			{
				string filename = Path.GetFileName(openFile.FileName);

				if (!selectedPrograms.Contains(filename))
					selectedPrograms.Add(filename);

				ListViewItem item = new ListViewItem()
				{
					Text = filename
				};

				lvApps.Items.Add(item);
			}
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
