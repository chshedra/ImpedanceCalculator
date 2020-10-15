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
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.FrequencyTextBox = new System.Windows.Forms.TextBox();
			this.FrequenciesListBox = new System.Windows.Forms.ListBox();
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.ElementInfoTextbox = new System.Windows.Forms.TextBox();
			this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
			this.FrequenciesGroupBox = new System.Windows.Forms.GroupBox();
			this.ImpendancesGroupBox = new System.Windows.Forms.GroupBox();
			this.ElementInfoGroupBox = new System.Windows.Forms.GroupBox();
			this.FrequencyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.RemoveFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CircuitTreeView = new ImpedanceCalculatorUI.Controls.CircuitTreeViewControl();
			this.RemoveCircuitButton = new System.Windows.Forms.Button();
			this.AddCircuitButton = new System.Windows.Forms.Button();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.FrequenciesGroupBox.SuspendLayout();
			this.ImpendancesGroupBox.SuspendLayout();
			this.ElementInfoGroupBox.SuspendLayout();
			this.FrequencyContextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.SuspendLayout();
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
			this.FrequenciesListBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxes_SelectedIndexChanged);
			this.FrequenciesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrequenciesListBox_MouseDown);
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(0, 13);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.Size = new System.Drawing.Size(202, 95);
			this.ImpedanceListBox.TabIndex = 3;
			this.ImpedanceListBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxes_SelectedIndexChanged);
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
			this.ElementInfoTextbox.Location = new System.Drawing.Point(1, 15);
			this.ElementInfoTextbox.Multiline = true;
			this.ElementInfoTextbox.Name = "ElementInfoTextbox";
			this.ElementInfoTextbox.ReadOnly = true;
			this.ElementInfoTextbox.Size = new System.Drawing.Size(175, 95);
			this.ElementInfoTextbox.TabIndex = 10;
			// 
			// CircuitsComboBox
			// 
			this.CircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CircuitsComboBox.FormattingEnabled = true;
			this.CircuitsComboBox.Location = new System.Drawing.Point(14, 12);
			this.CircuitsComboBox.Name = "CircuitsComboBox";
			this.CircuitsComboBox.Size = new System.Drawing.Size(112, 21);
			this.CircuitsComboBox.TabIndex = 13;
			this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsComboBox_SelectedIndexChanged);
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
			this.ElementInfoGroupBox.Text = "Current Segment";
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
			// CircuitTreeView
			// 
			this.CircuitTreeView.Location = new System.Drawing.Point(12, 43);
			this.CircuitTreeView.Name = "CircuitTreeView";
			this.CircuitTreeView.Size = new System.Drawing.Size(175, 420);
			this.CircuitTreeView.TabIndex = 19;
			// 
			// RemoveCircuitButton
			// 
			this.RemoveCircuitButton.BackgroundImage = global::ImpedanceCalculatorUI.Properties.Resources.Remove;
			this.RemoveCircuitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.RemoveCircuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.RemoveCircuitButton.Location = new System.Drawing.Point(161, 12);
			this.RemoveCircuitButton.Name = "RemoveCircuitButton";
			this.RemoveCircuitButton.Size = new System.Drawing.Size(23, 21);
			this.RemoveCircuitButton.TabIndex = 20;
			this.RemoveCircuitButton.UseVisualStyleBackColor = true;
			this.RemoveCircuitButton.Click += new System.EventHandler(this.RemoveCircuitButton_Click);
			// 
			// AddCircuitButton
			// 
			this.AddCircuitButton.BackColor = System.Drawing.SystemColors.Control;
			this.AddCircuitButton.BackgroundImage = global::ImpedanceCalculatorUI.Properties.Resources.Add;
			this.AddCircuitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AddCircuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.AddCircuitButton.Location = new System.Drawing.Point(132, 12);
			this.AddCircuitButton.Name = "AddCircuitButton";
			this.AddCircuitButton.Size = new System.Drawing.Size(23, 21);
			this.AddCircuitButton.TabIndex = 18;
			this.AddCircuitButton.UseVisualStyleBackColor = false;
			this.AddCircuitButton.Click += new System.EventHandler(this.AddCircuitButton_Click);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 474);
			this.Controls.Add(this.RemoveCircuitButton);
			this.Controls.Add(this.CircuitTreeView);
			this.Controls.Add(this.AddCircuitButton);
			this.Controls.Add(this.ElementInfoGroupBox);
			this.Controls.Add(this.ImpendancesGroupBox);
			this.Controls.Add(this.FrequenciesGroupBox);
			this.Controls.Add(this.CircuitsComboBox);
			this.Controls.Add(this.CircuitPictureBox);
			this.Name = "MainForm";
			this.Text = "ImpedanceCalculator";
			this.FrequenciesGroupBox.ResumeLayout(false);
			this.FrequenciesGroupBox.PerformLayout();
			this.ImpendancesGroupBox.ResumeLayout(false);
			this.ElementInfoGroupBox.ResumeLayout(false);
			this.ElementInfoGroupBox.PerformLayout();
			this.FrequencyContextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.Label FrequencyLabel;
		private System.Windows.Forms.TextBox FrequencyTextBox;
		private System.Windows.Forms.ListBox FrequenciesListBox;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.TextBox ElementInfoTextbox;
		private System.Windows.Forms.ComboBox CircuitsComboBox;
		private System.Windows.Forms.GroupBox FrequenciesGroupBox;
		private System.Windows.Forms.GroupBox ImpendancesGroupBox;
		private System.Windows.Forms.GroupBox ElementInfoGroupBox;
		private System.Windows.Forms.Button AddCircuitButton;
		private System.Windows.Forms.ContextMenuStrip FrequencyContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem RemoveFrequencyToolStripMenuItem;
		private Controls.CircuitTreeViewControl CircuitTreeView;
		private System.Windows.Forms.Button RemoveCircuitButton;
	}
}

