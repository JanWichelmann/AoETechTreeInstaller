namespace AoETechTreeInstaller
{
	partial class MainForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this._exeLabel = new System.Windows.Forms.Label();
			this._exeTextBox = new System.Windows.Forms.TextBox();
			this._exeButton = new System.Windows.Forms.Button();
			this._installButton = new System.Windows.Forms.Button();
			this._uninstallButton = new System.Windows.Forms.Button();
			this._closeButton = new System.Windows.Forms.Button();
			this._exeDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// _exeLabel
			// 
			this._exeLabel.AutoSize = true;
			this._exeLabel.Location = new System.Drawing.Point(12, 13);
			this._exeLabel.Name = "_exeLabel";
			this._exeLabel.Size = new System.Drawing.Size(73, 13);
			this._exeLabel.TabIndex = 0;
			this._exeLabel.Text = "EXE to patch:";
			// 
			// _exeTextBox
			// 
			this._exeTextBox.Location = new System.Drawing.Point(91, 10);
			this._exeTextBox.Name = "_exeTextBox";
			this._exeTextBox.ReadOnly = true;
			this._exeTextBox.Size = new System.Drawing.Size(324, 20);
			this._exeTextBox.TabIndex = 1;
			// 
			// _exeButton
			// 
			this._exeButton.Location = new System.Drawing.Point(421, 9);
			this._exeButton.Name = "_exeButton";
			this._exeButton.Size = new System.Drawing.Size(31, 22);
			this._exeButton.TabIndex = 2;
			this._exeButton.Text = "...";
			this._exeButton.UseVisualStyleBackColor = true;
			this._exeButton.Click += new System.EventHandler(this._exeButton_Click);
			// 
			// _installButton
			// 
			this._installButton.Enabled = false;
			this._installButton.Location = new System.Drawing.Point(140, 36);
			this._installButton.Name = "_installButton";
			this._installButton.Size = new System.Drawing.Size(100, 23);
			this._installButton.TabIndex = 3;
			this._installButton.Text = "Install";
			this._installButton.UseVisualStyleBackColor = true;
			this._installButton.Click += new System.EventHandler(this._installButton_Click);
			// 
			// _uninstallButton
			// 
			this._uninstallButton.Enabled = false;
			this._uninstallButton.Location = new System.Drawing.Point(246, 36);
			this._uninstallButton.Name = "_uninstallButton";
			this._uninstallButton.Size = new System.Drawing.Size(100, 23);
			this._uninstallButton.TabIndex = 4;
			this._uninstallButton.Text = "Uninstall";
			this._uninstallButton.UseVisualStyleBackColor = true;
			this._uninstallButton.Click += new System.EventHandler(this._uninstallButton_Click);
			// 
			// _closeButton
			// 
			this._closeButton.Location = new System.Drawing.Point(352, 36);
			this._closeButton.Name = "_closeButton";
			this._closeButton.Size = new System.Drawing.Size(100, 23);
			this._closeButton.TabIndex = 5;
			this._closeButton.Text = "Close";
			this._closeButton.UseVisualStyleBackColor = true;
			this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
			// 
			// _exeDialog
			// 
			this._exeDialog.FileName = "age2_x1.exe";
			this._exeDialog.Filter = "EXE files (*.exe)|*.exe";
			this._exeDialog.Title = "Pick \"Age of Empires II: The Conquerors\" EXE file to patch...";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 71);
			this.Controls.Add(this._closeButton);
			this.Controls.Add(this._uninstallButton);
			this.Controls.Add(this._installButton);
			this.Controls.Add(this._exeButton);
			this.Controls.Add(this._exeTextBox);
			this.Controls.Add(this._exeLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Age of Empires II :: New Tech Tree Installer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _exeLabel;
		private System.Windows.Forms.TextBox _exeTextBox;
		private System.Windows.Forms.Button _exeButton;
		private System.Windows.Forms.Button _installButton;
		private System.Windows.Forms.Button _uninstallButton;
		private System.Windows.Forms.Button _closeButton;
		private System.Windows.Forms.OpenFileDialog _exeDialog;
	}
}

