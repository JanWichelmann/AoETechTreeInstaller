using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoETechTreeInstaller
{
	public partial class MainForm : Form
	{
		#region Variables


		#endregion

		#region Functions

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			// Load controls
			InitializeComponent();
		}

		#endregion

		#region Event handlers

		private void _exeButton_Click(object sender, EventArgs e)
		{
			// Show file dialog
			if(_exeDialog.ShowDialog() == DialogResult.OK)
				_exeTextBox.Text = _exeDialog.FileName;
		}

		private void _installButton_Click(object sender, EventArgs e)
		{
			// Big try catch
			try
			{
				// Load EXE file
				
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("An error occured during installation: " + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void _uninstallButton_Click(object sender, EventArgs e)
		{

		}

		private void _closeButton_Click(object sender, EventArgs e)
		{
			// Close application
			Close();
		}

		#endregion
	}
}
