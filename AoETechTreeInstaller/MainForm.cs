using System;
using System.IO;
using System.Windows.Forms;

namespace AoETechTreeInstaller
{
	public partial class MainForm : Form
	{
		#region Constants

		/// <summary>
		/// The general offset of the executable when loaded to process virtual memory.
		/// </summary>
		private const int VIRTUAL_MEMORY_OFFSET = 0x400000;

		/// <summary>
		/// The offset of the patch data in the executable.
		/// </summary>
		private const int MAIN_PATCH_OFFSET = 0x0022819C;

		/// <summary>
		/// The file name of the tech tree DLL.
		/// </summary>
		private const string TECH_TREE_DLL_NAME = "TechTree.dll";

		/// <summary>
		/// The name of the tech tree DLL init function.
		/// </summary>
		private const string TECH_TREE_DLL_INIT_FUNCTION_NAME = "Init";

		// Create DLL load code
		private byte[] MAIN_PATCH =
		{
			0x68, 0x00, 0x00, 0x00, 0x00, // push [techTreeDllName]
			0xFF, 0x15, 0xE0, 0x51, 0x63, 0x00, // call ds:LoadLibraryA
			0x68, 0x00, 0x00, 0x00, 0x00, // push [techTreeDllInitFunctionName]
			0x50, // push eax
			0xFF, 0x15, 0xC8, 0x50, 0x63, 0x00, // call ds:GetProcAddress
			0xFF, 0xD0, // call eax
			0x8D, 0x84, 0x24, 0x9C, 0x1C, 0x00, 0x00, // lea eax, [esp + 0x1C9C] (opcode overwritten by patch call)
			0xC3 // ret
		};

		#endregion Constants

		#region Functions

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainForm()
		{
			// Load controls
			InitializeComponent();
		}

		#endregion Functions

		#region Event handlers

		private void _exeButton_Click(object sender, EventArgs e)
		{
			// Show file dialog
			if(_exeDialog.ShowDialog() == DialogResult.OK)
			{
				// Save file name
				_exeTextBox.Text = _exeDialog.FileName;

				// Enable buttons
				_installButton.Enabled = true;
				_uninstallButton.Enabled = true;
			}
		}

		private void _installButton_Click(object sender, EventArgs e)
		{
			// Big try catch
			try
			{
				// Load EXE file
				IORAMHelper.RAMBuffer exeFile = new IORAMHelper.RAMBuffer(_exeTextBox.Text);

				// Create patch data
				byte[] mainPatch = new byte[MAIN_PATCH.Length];
				Array.Copy(MAIN_PATCH, mainPatch, MAIN_PATCH.Length);
				Array.Copy(BitConverter.GetBytes(VIRTUAL_MEMORY_OFFSET + MAIN_PATCH_OFFSET), 0, mainPatch, 1, 4); // [techTreeDllName]
				Array.Copy(BitConverter.GetBytes(VIRTUAL_MEMORY_OFFSET + MAIN_PATCH_OFFSET + TECH_TREE_DLL_NAME.Length + 1), 0, mainPatch, 12, 4); // [techTreeDllInitFunctionName]

				// Check destination area
				exeFile.Position = MAIN_PATCH_OFFSET;
				foreach(byte val in exeFile.ReadByteArray(mainPatch.Length))
					if(val != 0)
						throw new Exception("The destination code section is not empty.");

				// Write strings
				exeFile.Position = MAIN_PATCH_OFFSET;
				exeFile.WriteString(TECH_TREE_DLL_NAME, TECH_TREE_DLL_NAME.Length + 1); // Zero byte!
				exeFile.WriteString(TECH_TREE_DLL_INIT_FUNCTION_NAME, TECH_TREE_DLL_INIT_FUNCTION_NAME.Length + 1); // Zero byte!

				// Write load code
				int patchCodeOffset = exeFile.Position;
				exeFile.Write(mainPatch);

				// Write call code
				exeFile.Position = 0x00186B2D;
				exeFile.WriteByte(0xE8); // call
				exeFile.Write(BitConverter.GetBytes(patchCodeOffset - (0x00186B2D + 5)));
				exeFile.WriteByte(0x90); // nop
				exeFile.WriteByte(0x90); // nop

				// Save patched exe
				exeFile.Save(_exeTextBox.Text);

				// Copy DLL if existing
				if(File.Exists(TECH_TREE_DLL_NAME))
					File.Copy(TECH_TREE_DLL_NAME, Path.Combine(Path.GetDirectoryName(_exeTextBox.Text), TECH_TREE_DLL_NAME), true);
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("An error occured during installation: " + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Successful
			MessageBox.Show("The patch was applied successfully!\nDo not forget to manually update your DAT file.", "Patch successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void _uninstallButton_Click(object sender, EventArgs e)
		{
			// Big try catch
			try
			{
				// Load EXE file
				IORAMHelper.RAMBuffer exeFile = new IORAMHelper.RAMBuffer(_exeTextBox.Text);

				// Remove the call
				exeFile.Position = 0x00186B2D;
				exeFile.Write(new byte[] { 0x8D, 0x84, 0x24, 0x98, 0x1C, 0x00, 0x00 }); // lea eax, [esp + 0x1C98]

				// Clear patch section
				exeFile.Position = MAIN_PATCH_OFFSET;
				for(int i = 0; i < TECH_TREE_DLL_NAME.Length + 1 + TECH_TREE_DLL_INIT_FUNCTION_NAME.Length + 1 + MAIN_PATCH.Length; ++i)
					exeFile.WriteByte(0x00);

				// Save patched exe
				exeFile.Save(_exeTextBox.Text);

				// Delete DLL if existing
				string dllPath = Path.Combine(Path.GetDirectoryName(_exeTextBox.Text), TECH_TREE_DLL_NAME);
				if(File.Exists(dllPath))
					File.Delete(dllPath);
			}
			catch(Exception ex)
			{
				// Message
				MessageBox.Show("An error occured during removing: " + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Successful
			MessageBox.Show("The patch was removed successfully!", "Patch removal successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void _closeButton_Click(object sender, EventArgs e)
		{
			// Close application
			Close();
		}

		#endregion Event handlers
	}
}