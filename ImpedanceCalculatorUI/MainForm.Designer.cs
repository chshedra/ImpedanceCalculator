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
			this.AddButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.FrequencyTextBox = new System.Windows.Forms.TextBox();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.FrequenciesListBox = new System.Windows.Forms.ListBox();
			this.FrequenciesLabel = new System.Windows.Forms.Label();
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.ImpedanceLabel = new System.Windows.Forms.Label();
			this.CircuitsListBox = new System.Windows.Forms.ListBox();
			this.ElementInfoTextbox = new System.Windows.Forms.TextBox();
			this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.CircuitsLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.BackColor = System.Drawing.Color.White;
			this.CircuitPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CircuitPictureBox.Location = new System.Drawing.Point(195, 12);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(633, 305);
			this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CircuitPictureBox.TabIndex = 0;
			this.CircuitPictureBox.TabStop = false;
			// 
			// CircuitTreeView
			// 
			this.CircuitTreeView.Location = new System.Drawing.Point(12, 12);
			this.CircuitTreeView.Name = "CircuitTreeView";
			this.CircuitTreeView.Size = new System.Drawing.Size(177, 348);
			this.CircuitTreeView.TabIndex = 0;
			this.CircuitTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CircuitTreeView_AfterSelect);
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(12, 422);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(55, 22);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// EditButton
			// 
			this.EditButton.Location = new System.Drawing.Point(73, 422);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(55, 22);
			this.EditButton.TabIndex = 2;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = true;
			// 
			// FrequencyLabel
			// 
			this.FrequencyLabel.AutoSize = true;
			this.FrequencyLabel.Location = new System.Drawing.Point(340, 336);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(63, 13);
			this.FrequencyLabel.TabIndex = 7;
			this.FrequencyLabel.Text = "Frequency=";
			// 
			// FrequencyTextBox
			// 
			this.FrequencyTextBox.Location = new System.Drawing.Point(409, 336);
			this.FrequencyTextBox.Name = "FrequencyTextBox";
			this.FrequencyTextBox.Size = new System.Drawing.Size(91, 20);
			this.FrequencyTextBox.TabIndex = 6;
			this.FrequencyTextBox.TextChanged += new System.EventHandler(this.FrequencyTextBox_TextChanged);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(134, 422);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(55, 22);
			this.RemoveButton.TabIndex = 3;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			// 
			// FrequenciesListBox
			// 
			this.FrequenciesListBox.FormattingEnabled = true;
			this.FrequenciesListBox.Location = new System.Drawing.Point(506, 336);
			this.FrequenciesListBox.Name = "FrequenciesListBox";
			this.FrequenciesListBox.Size = new System.Drawing.Size(155, 108);
			this.FrequenciesListBox.TabIndex = 2;
			this.FrequenciesListBox.SelectedIndexChanged += new System.EventHandler(this.FrequenceListBox_SelectedIndexChanged);
			// 
			// FrequenciesLabel
			// 
			this.FrequenciesLabel.AutoSize = true;
			this.FrequenciesLabel.Location = new System.Drawing.Point(503, 320);
			this.FrequenciesLabel.Name = "FrequenciesLabel";
			this.FrequenciesLabel.Size = new System.Drawing.Size(65, 13);
			this.FrequenciesLabel.TabIndex = 4;
			this.FrequenciesLabel.Text = "Frequencies";
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(667, 336);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.Size = new System.Drawing.Size(161, 108);
			this.ImpedanceListBox.TabIndex = 3;
			this.ImpedanceListBox.SelectedIndexChanged += new System.EventHandler(this.ImpedanceListBox_SelectedIndexChanged);
			// 
			// CalculateButton
			// 
			this.CalculateButton.Location = new System.Drawing.Point(343, 422);
			this.CalculateButton.Name = "CalculateButton";
			this.CalculateButton.Size = new System.Drawing.Size(157, 21);
			this.CalculateButton.TabIndex = 8;
			this.CalculateButton.Text = "Calculate";
			this.CalculateButton.UseVisualStyleBackColor = true;
			this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
			// 
			// ImpedanceLabel
			// 
			this.ImpedanceLabel.AutoSize = true;
			this.ImpedanceLabel.Location = new System.Drawing.Point(664, 320);
			this.ImpedanceLabel.Name = "ImpedanceLabel";
			this.ImpedanceLabel.Size = new System.Drawing.Size(60, 13);
			this.ImpedanceLabel.TabIndex = 5;
			this.ImpedanceLabel.Text = "Impedance";
			// 
			// CircuitsListBox
			// 
			this.CircuitsListBox.FormattingEnabled = true;
			this.CircuitsListBox.Location = new System.Drawing.Point(195, 336);
			this.CircuitsListBox.Name = "CircuitsListBox";
			this.CircuitsListBox.Size = new System.Drawing.Size(127, 108);
			this.CircuitsListBox.TabIndex = 9;
			this.CircuitsListBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsListBox_SelectedIndexChanged);
			// 
			// ElementInfoTextbox
			// 
			this.ElementInfoTextbox.Location = new System.Drawing.Point(13, 366);
			this.ElementInfoTextbox.Multiline = true;
			this.ElementInfoTextbox.Name = "ElementInfoTextbox";
			this.ElementInfoTextbox.Size = new System.Drawing.Size(176, 50);
			this.ElementInfoTextbox.TabIndex = 10;
			// 
			// projectBindingSource
			// 
			this.projectBindingSource.DataSource = typeof(ImpedanceCalculator.Project);
			// 
			// CircuitsLabel
			// 
			this.CircuitsLabel.AutoSize = true;
			this.CircuitsLabel.Location = new System.Drawing.Point(195, 320);
			this.CircuitsLabel.Name = "CircuitsLabel";
			this.CircuitsLabel.Size = new System.Drawing.Size(41, 13);
			this.CircuitsLabel.TabIndex = 11;
			this.CircuitsLabel.Text = "Circuits";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(836, 456);
			this.Controls.Add(this.CircuitsLabel);
			this.Controls.Add(this.ElementInfoTextbox);
			this.Controls.Add(this.CircuitsListBox);
			this.Controls.Add(this.FrequencyTextBox);
			this.Controls.Add(this.CalculateButton);
			this.Controls.Add(this.FrequencyLabel);
			this.Controls.Add(this.ImpedanceLabel);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.FrequenciesLabel);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.CircuitTreeView);
			this.Controls.Add(this.ImpedanceListBox);
			this.Controls.Add(this.FrequenciesListBox);
			this.Controls.Add(this.CircuitPictureBox);
			this.Name = "MainForm";
			this.Text = "ImpedanceCalculator";
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.BindingSource projectBindingSource;
		public System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.TreeView CircuitTreeView;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Label FrequencyLabel;
		private System.Windows.Forms.TextBox FrequencyTextBox;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.ListBox FrequenciesListBox;
		private System.Windows.Forms.Label FrequenciesLabel;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.Label ImpedanceLabel;
		private System.Windows.Forms.ListBox CircuitsListBox;
		private System.Windows.Forms.TextBox ElementInfoTextbox;
		private System.Windows.Forms.Label CircuitsLabel;
	}
}

