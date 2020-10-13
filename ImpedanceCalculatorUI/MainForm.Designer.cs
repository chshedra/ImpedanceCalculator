namespace ImpedanceCalculatorUI
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.CircuitTreeView = new System.Windows.Forms.TreeView();
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.FrequencyTextBox = new System.Windows.Forms.TextBox();
			this.FrequenciesListBox = new System.Windows.Forms.ListBox();
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.ElementInfoTextbox = new System.Windows.Forms.TextBox();
			this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
			this.NodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FrequenciesGroupBox = new System.Windows.Forms.GroupBox();
			this.ImpendancesGroupBox = new System.Windows.Forms.GroupBox();
			this.ElementInfoGroupBox = new System.Windows.Forms.GroupBox();
			this.AddCircuitButton = new System.Windows.Forms.Button();
			this.FrequencyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.RemoveFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.NodeContextMenu.SuspendLayout();
			this.FrequenciesGroupBox.SuspendLayout();
			this.ImpendancesGroupBox.SuspendLayout();
			this.ElementInfoGroupBox.SuspendLayout();
			this.FrequencyContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.BackColor = System.Drawing.Color.White;
			this.CircuitPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CircuitPictureBox.Location = new System.Drawing.Point(195, 12);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(576, 305);
			this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CircuitPictureBox.TabIndex = 0;
			this.CircuitPictureBox.TabStop = false;
			// 
			// CircuitTreeView
			// 
			this.CircuitTreeView.Location = new System.Drawing.Point(12, 39);
			this.CircuitTreeView.Name = "CircuitTreeView";
			this.CircuitTreeView.Size = new System.Drawing.Size(177, 393);
			this.CircuitTreeView.TabIndex = 0;
			this.CircuitTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CircuitTreeView_AfterSelect);
			this.CircuitTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CircuitTreeView_MouseDown);
			this.CircuitTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CircuitTreeView_MouseUp);
			// 
			// FrequencyLabel
			// 
			this.FrequencyLabel.AutoSize = true;
			this.FrequencyLabel.Location = new System.Drawing.Point(0, 117);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(63, 13);
			this.FrequencyLabel.TabIndex = 7;
			this.FrequencyLabel.Text = "Frequency=";
			// 
			// FrequencyTextBox
			// 
			this.FrequencyTextBox.Location = new System.Drawing.Point(66, 115);
			this.FrequencyTextBox.Name = "FrequencyTextBox";
			this.FrequencyTextBox.Size = new System.Drawing.Size(120, 20);
			this.FrequencyTextBox.TabIndex = 6;
			this.FrequencyTextBox.TextChanged += new System.EventHandler(this.FrequencyTextBox_TextChanged);
			// 
			// FrequenciesListBox
			// 
			this.FrequenciesListBox.FormattingEnabled = true;
			this.FrequenciesListBox.Location = new System.Drawing.Point(0, 15);
			this.FrequenciesListBox.Name = "FrequenciesListBox";
			this.FrequenciesListBox.Size = new System.Drawing.Size(186, 95);
			this.FrequenciesListBox.TabIndex = 2;
			this.FrequenciesListBox.SelectedIndexChanged += new System.EventHandler(this.FrequenceListBox_SelectedIndexChanged);
			this.FrequenciesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrequenciesListBox_MouseDown);
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(0, 13);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.Size = new System.Drawing.Size(202, 95);
			this.ImpedanceListBox.TabIndex = 3;
			this.ImpedanceListBox.SelectedIndexChanged += new System.EventHandler(this.ImpedanceListBox_SelectedIndexChanged);
			// 
			// CalculateButton
			// 
			this.CalculateButton.Location = new System.Drawing.Point(0, 114);
			this.CalculateButton.Name = "CalculateButton";
			this.CalculateButton.Size = new System.Drawing.Size(202, 25);
			this.CalculateButton.TabIndex = 8;
			this.CalculateButton.Text = "Calculate";
			this.CalculateButton.UseVisualStyleBackColor = true;
			this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
			// 
			// ElementInfoTextbox
			// 
			this.ElementInfoTextbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ElementInfoTextbox.Location = new System.Drawing.Point(1, 14);
			this.ElementInfoTextbox.Multiline = true;
			this.ElementInfoTextbox.Name = "ElementInfoTextbox";
			this.ElementInfoTextbox.ReadOnly = true;
			this.ElementInfoTextbox.Size = new System.Drawing.Size(175, 95);
			this.ElementInfoTextbox.TabIndex = 10;
			// 
			// CircuitsComboBox
			// 
			this.CircuitsComboBox.FormattingEnabled = true;
			this.CircuitsComboBox.Location = new System.Drawing.Point(13, 12);
			this.CircuitsComboBox.Name = "CircuitsComboBox";
			this.CircuitsComboBox.Size = new System.Drawing.Size(176, 21);
			this.CircuitsComboBox.TabIndex = 13;
			this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsComboBox_SelectedIndexChanged);
			// 
			// NodeContextMenu
			// 
			this.NodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.RemoveToolStripMenuItem});
			this.NodeContextMenu.Name = "NodeContextMenu";
			this.NodeContextMenu.Size = new System.Drawing.Size(118, 70);
			// 
			// AddToolStripMenuItem
			// 
			this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
			this.AddToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.AddToolStripMenuItem.Text = "Add";
			this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.EditToolStripMenuItem.Text = "Edit";
			this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
			// 
			// RemoveToolStripMenuItem
			// 
			this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
			this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.RemoveToolStripMenuItem.Text = "Remove";
			this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
			// 
			// FrequenciesGroupBox
			// 
			this.FrequenciesGroupBox.Controls.Add(this.FrequenciesListBox);
			this.FrequenciesGroupBox.Controls.Add(this.FrequencyTextBox);
			this.FrequenciesGroupBox.Controls.Add(this.FrequencyLabel);
			this.FrequenciesGroupBox.Location = new System.Drawing.Point(377, 323);
			this.FrequenciesGroupBox.Name = "FrequenciesGroupBox";
			this.FrequenciesGroupBox.Size = new System.Drawing.Size(186, 140);
			this.FrequenciesGroupBox.TabIndex = 15;
			this.FrequenciesGroupBox.TabStop = false;
			this.FrequenciesGroupBox.Text = "Frequencies";
			// 
			// ImpendancesGroupBox
			// 
			this.ImpendancesGroupBox.Controls.Add(this.ImpedanceListBox);
			this.ImpendancesGroupBox.Controls.Add(this.CalculateButton);
			this.ImpendancesGroupBox.Location = new System.Drawing.Point(569, 324);
			this.ImpendancesGroupBox.Name = "ImpendancesGroupBox";
			this.ImpendancesGroupBox.Size = new System.Drawing.Size(202, 139);
			this.ImpendancesGroupBox.TabIndex = 16;
			this.ImpendancesGroupBox.TabStop = false;
			this.ImpendancesGroupBox.Text = "Impednces";
			// 
			// ElementInfoGroupBox
			// 
			this.ElementInfoGroupBox.Controls.Add(this.ElementInfoTextbox);
			this.ElementInfoGroupBox.Location = new System.Drawing.Point(195, 323);
			this.ElementInfoGroupBox.Name = "ElementInfoGroupBox";
			this.ElementInfoGroupBox.Size = new System.Drawing.Size(176, 140);
			this.ElementInfoGroupBox.TabIndex = 17;
			this.ElementInfoGroupBox.TabStop = false;
			this.ElementInfoGroupBox.Text = "Information";
			// 
			// AddCircuitButton
			// 
			this.AddCircuitButton.Location = new System.Drawing.Point(12, 438);
			this.AddCircuitButton.Name = "AddCircuitButton";
			this.AddCircuitButton.Size = new System.Drawing.Size(177, 25);
			this.AddCircuitButton.TabIndex = 18;
			this.AddCircuitButton.Text = "Add circuit";
			this.AddCircuitButton.UseVisualStyleBackColor = true;
			this.AddCircuitButton.Click += new System.EventHandler(this.AddCircuitButton_Click);
			// 
			// FrequencyContextMenuStrip
			// 
			this.FrequencyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveFrequencyToolStripMenuItem});
			this.FrequencyContextMenuStrip.Name = "FrequencyContextMenuStrip";
			this.FrequencyContextMenuStrip.Size = new System.Drawing.Size(118, 26);
			// 
			// RemoveFrequencyToolStripMenuItem
			// 
			this.RemoveFrequencyToolStripMenuItem.Name = "RemoveFrequencyToolStripMenuItem";
			this.RemoveFrequencyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.RemoveFrequencyToolStripMenuItem.Text = "Remove";
			this.RemoveFrequencyToolStripMenuItem.Click += new System.EventHandler(this.RemoveFrequencyToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 474);
			this.Controls.Add(this.AddCircuitButton);
			this.Controls.Add(this.ElementInfoGroupBox);
			this.Controls.Add(this.ImpendancesGroupBox);
			this.Controls.Add(this.FrequenciesGroupBox);
			this.Controls.Add(this.CircuitsComboBox);
			this.Controls.Add(this.CircuitTreeView);
			this.Controls.Add(this.CircuitPictureBox);
			this.Name = "MainForm";
			this.Text = "ImpedanceCalculator";
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			this.NodeContextMenu.ResumeLayout(false);
			this.FrequenciesGroupBox.ResumeLayout(false);
			this.FrequenciesGroupBox.PerformLayout();
			this.ImpendancesGroupBox.ResumeLayout(false);
			this.ElementInfoGroupBox.ResumeLayout(false);
			this.ElementInfoGroupBox.PerformLayout();
			this.FrequencyContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.TreeView CircuitTreeView;
		private System.Windows.Forms.Label FrequencyLabel;
		private System.Windows.Forms.TextBox FrequencyTextBox;
		private System.Windows.Forms.ListBox FrequenciesListBox;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.TextBox ElementInfoTextbox;
		private System.Windows.Forms.ComboBox CircuitsComboBox;
		private System.Windows.Forms.ContextMenuStrip NodeContextMenu;
		private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
		private System.Windows.Forms.GroupBox FrequenciesGroupBox;
		private System.Windows.Forms.GroupBox ImpendancesGroupBox;
		private System.Windows.Forms.GroupBox ElementInfoGroupBox;
		private System.Windows.Forms.Button AddCircuitButton;
		private System.Windows.Forms.ContextMenuStrip FrequencyContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem RemoveFrequencyToolStripMenuItem;
	}
}

