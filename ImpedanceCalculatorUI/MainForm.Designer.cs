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
			this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.CircuitTreeView = new System.Windows.Forms.TreeView();
			this.AddButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.FrequenceTextBox = new System.Windows.Forms.TextBox();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.FrequenceListBox = new System.Windows.Forms.ListBox();
			this.FrequenciesLabel = new System.Windows.Forms.Label();
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.ImpedanceLabel = new System.Windows.Forms.Label();
			this.CircuitsListBox = new System.Windows.Forms.ListBox();
			this.ElementInfoTextbox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// projectBindingSource
			// 
			this.projectBindingSource.DataSource = typeof(ImpedanceCalculator.Project);
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
			this.FrequencyLabel.Location = new System.Drawing.Point(656, 383);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(63, 13);
			this.FrequencyLabel.TabIndex = 7;
			this.FrequencyLabel.Text = "Frequency=";
			// 
			// FrequenceTextBox
			// 
			this.FrequenceTextBox.Location = new System.Drawing.Point(725, 380);
			this.FrequenceTextBox.Name = "FrequenceTextBox";
			this.FrequenceTextBox.Size = new System.Drawing.Size(91, 20);
			this.FrequenceTextBox.TabIndex = 6;
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
			// FrequenceListBox
			// 
			this.FrequenceListBox.FormattingEnabled = true;
			this.FrequenceListBox.Location = new System.Drawing.Point(328, 336);
			this.FrequenceListBox.Name = "FrequenceListBox";
			this.FrequenceListBox.Size = new System.Drawing.Size(155, 108);
			this.FrequenceListBox.TabIndex = 2;
			this.FrequenceListBox.SelectedIndexChanged += new System.EventHandler(this.FrequenceListBox_SelectedIndexChanged);
			// 
			// FrequenciesLabel
			// 
			this.FrequenciesLabel.AutoSize = true;
			this.FrequenciesLabel.Location = new System.Drawing.Point(325, 320);
			this.FrequenciesLabel.Name = "FrequenciesLabel";
			this.FrequenciesLabel.Size = new System.Drawing.Size(65, 13);
			this.FrequenciesLabel.TabIndex = 4;
			this.FrequenciesLabel.Text = "Frequencies";
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(489, 336);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.Size = new System.Drawing.Size(161, 108);
			this.ImpedanceListBox.TabIndex = 3;
			this.ImpedanceListBox.SelectedIndexChanged += new System.EventHandler(this.ImpedanceListBox_SelectedIndexChanged);
			// 
			// CalculateButton
			// 
			this.CalculateButton.Location = new System.Drawing.Point(659, 422);
			this.CalculateButton.Name = "CalculateButton";
			this.CalculateButton.Size = new System.Drawing.Size(157, 21);
			this.CalculateButton.TabIndex = 8;
			this.CalculateButton.Text = "Calculate";
			this.CalculateButton.UseVisualStyleBackColor = true;
			// 
			// ImpedanceLabel
			// 
			this.ImpedanceLabel.AutoSize = true;
			this.ImpedanceLabel.Location = new System.Drawing.Point(486, 320);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(836, 456);
			this.Controls.Add(this.ElementInfoTextbox);
			this.Controls.Add(this.CircuitsListBox);
			this.Controls.Add(this.FrequenceTextBox);
			this.Controls.Add(this.CalculateButton);
			this.Controls.Add(this.FrequencyLabel);
			this.Controls.Add(this.ImpedanceLabel);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.FrequenciesLabel);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.CircuitTreeView);
			this.Controls.Add(this.ImpedanceListBox);
			this.Controls.Add(this.FrequenceListBox);
			this.Controls.Add(this.CircuitPictureBox);
			this.Name = "MainForm";
			this.Text = "ImpedanceCalculator";
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
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
		private System.Windows.Forms.TextBox FrequenceTextBox;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.ListBox FrequenceListBox;
		private System.Windows.Forms.Label FrequenciesLabel;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.Label ImpedanceLabel;
		private System.Windows.Forms.ListBox CircuitsListBox;
		private System.Windows.Forms.TextBox ElementInfoTextbox;
	}
}

