namespace ImpedanceCalculatorUI
{
	partial class ElementForm
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
			this.EditNameLabel = new System.Windows.Forms.Label();
			this.EditValueLabel = new System.Windows.Forms.Label();
			this.EditNameTextBox = new System.Windows.Forms.TextBox();
			this.EditValueTextBox = new System.Windows.Forms.TextBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelEditButton = new System.Windows.Forms.Button();
			this.ElementTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.CRadioButton = new System.Windows.Forms.RadioButton();
			this.LRadioButton = new System.Windows.Forms.RadioButton();
			this.RRadioButton = new System.Windows.Forms.RadioButton();
			this.MeasurementLabel = new System.Windows.Forms.Label();
			this.AddGroupBox = new System.Windows.Forms.GroupBox();
			this.AddParallelRadioButton = new System.Windows.Forms.RadioButton();
			this.AddSerialRadioButton = new System.Windows.Forms.RadioButton();
			this.ElementTypeGroupBox.SuspendLayout();
			this.AddGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// EditNameLabel
			// 
			this.EditNameLabel.AutoSize = true;
			this.EditNameLabel.Location = new System.Drawing.Point(12, 68);
			this.EditNameLabel.Name = "EditNameLabel";
			this.EditNameLabel.Size = new System.Drawing.Size(41, 13);
			this.EditNameLabel.TabIndex = 0;
			this.EditNameLabel.Text = "Name=";
			// 
			// EditValueLabel
			// 
			this.EditValueLabel.AutoSize = true;
			this.EditValueLabel.Location = new System.Drawing.Point(13, 101);
			this.EditValueLabel.Name = "EditValueLabel";
			this.EditValueLabel.Size = new System.Drawing.Size(40, 13);
			this.EditValueLabel.TabIndex = 1;
			this.EditValueLabel.Text = "Value=";
			// 
			// EditNameTextBox
			// 
			this.EditNameTextBox.Location = new System.Drawing.Point(59, 61);
			this.EditNameTextBox.Name = "EditNameTextBox";
			this.EditNameTextBox.Size = new System.Drawing.Size(86, 20);
			this.EditNameTextBox.TabIndex = 2;
			// 
			// EditValueTextBox
			// 
			this.EditValueTextBox.Location = new System.Drawing.Point(59, 98);
			this.EditValueTextBox.Name = "EditValueTextBox";
			this.EditValueTextBox.Size = new System.Drawing.Size(86, 20);
			this.EditValueTextBox.TabIndex = 3;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(65, 132);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(64, 23);
			this.OkButton.TabIndex = 5;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CancelEditButton
			// 
			this.CancelEditButton.Location = new System.Drawing.Point(135, 132);
			this.CancelEditButton.Name = "CancelEditButton";
			this.CancelEditButton.Size = new System.Drawing.Size(59, 23);
			this.CancelEditButton.TabIndex = 6;
			this.CancelEditButton.Text = "Cancel";
			this.CancelEditButton.UseVisualStyleBackColor = true;
			this.CancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
			// 
			// ElementTypeGroupBox
			// 
			this.ElementTypeGroupBox.Controls.Add(this.CRadioButton);
			this.ElementTypeGroupBox.Controls.Add(this.LRadioButton);
			this.ElementTypeGroupBox.Controls.Add(this.RRadioButton);
			this.ElementTypeGroupBox.Location = new System.Drawing.Point(16, 11);
			this.ElementTypeGroupBox.Name = "ElementTypeGroupBox";
			this.ElementTypeGroupBox.Size = new System.Drawing.Size(222, 40);
			this.ElementTypeGroupBox.TabIndex = 7;
			this.ElementTypeGroupBox.TabStop = false;
			this.ElementTypeGroupBox.Text = "Type";
			// 
			// CRadioButton
			// 
			this.CRadioButton.AutoSize = true;
			this.CRadioButton.Location = new System.Drawing.Point(146, 17);
			this.CRadioButton.Name = "CRadioButton";
			this.CRadioButton.Size = new System.Drawing.Size(32, 17);
			this.CRadioButton.TabIndex = 2;
			this.CRadioButton.TabStop = true;
			this.CRadioButton.Text = "C";
			this.CRadioButton.UseVisualStyleBackColor = true;
			// 
			// LRadioButton
			// 
			this.LRadioButton.AutoSize = true;
			this.LRadioButton.Location = new System.Drawing.Point(82, 17);
			this.LRadioButton.Name = "LRadioButton";
			this.LRadioButton.Size = new System.Drawing.Size(31, 17);
			this.LRadioButton.TabIndex = 1;
			this.LRadioButton.TabStop = true;
			this.LRadioButton.Text = "L";
			this.LRadioButton.UseVisualStyleBackColor = true;
			// 
			// RRadioButton
			// 
			this.RRadioButton.AutoSize = true;
			this.RRadioButton.Location = new System.Drawing.Point(8, 17);
			this.RRadioButton.Name = "RRadioButton";
			this.RRadioButton.Size = new System.Drawing.Size(33, 17);
			this.RRadioButton.TabIndex = 0;
			this.RRadioButton.TabStop = true;
			this.RRadioButton.Text = "R";
			this.RRadioButton.UseVisualStyleBackColor = true;
			// 
			// MeasurementLabel
			// 
			this.MeasurementLabel.AutoSize = true;
			this.MeasurementLabel.Location = new System.Drawing.Point(155, 102);
			this.MeasurementLabel.Name = "MeasurementLabel";
			this.MeasurementLabel.Size = new System.Drawing.Size(0, 13);
			this.MeasurementLabel.TabIndex = 8;
			// 
			// AddGroupBox
			// 
			this.AddGroupBox.Controls.Add(this.AddParallelRadioButton);
			this.AddGroupBox.Controls.Add(this.AddSerialRadioButton);
			this.AddGroupBox.Location = new System.Drawing.Point(162, 57);
			this.AddGroupBox.Name = "AddGroupBox";
			this.AddGroupBox.Size = new System.Drawing.Size(76, 69);
			this.AddGroupBox.TabIndex = 9;
			this.AddGroupBox.TabStop = false;
			this.AddGroupBox.Text = "Add";
			// 
			// AddParallelRadioButton
			// 
			this.AddParallelRadioButton.AutoSize = true;
			this.AddParallelRadioButton.Location = new System.Drawing.Point(0, 47);
			this.AddParallelRadioButton.Name = "AddParallelRadioButton";
			this.AddParallelRadioButton.Size = new System.Drawing.Size(59, 17);
			this.AddParallelRadioButton.TabIndex = 1;
			this.AddParallelRadioButton.TabStop = true;
			this.AddParallelRadioButton.Text = "Parallel";
			this.AddParallelRadioButton.UseVisualStyleBackColor = true;
			// 
			// AddSerialRadioButton
			// 
			this.AddSerialRadioButton.AutoSize = true;
			this.AddSerialRadioButton.Location = new System.Drawing.Point(0, 19);
			this.AddSerialRadioButton.Name = "AddSerialRadioButton";
			this.AddSerialRadioButton.Size = new System.Drawing.Size(51, 17);
			this.AddSerialRadioButton.TabIndex = 0;
			this.AddSerialRadioButton.TabStop = true;
			this.AddSerialRadioButton.Text = "Serial";
			this.AddSerialRadioButton.UseVisualStyleBackColor = true;
			// 
			// AddEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 167);
			this.Controls.Add(this.AddGroupBox);
			this.Controls.Add(this.MeasurementLabel);
			this.Controls.Add(this.ElementTypeGroupBox);
			this.Controls.Add(this.CancelEditButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.EditValueTextBox);
			this.Controls.Add(this.EditNameTextBox);
			this.Controls.Add(this.EditValueLabel);
			this.Controls.Add(this.EditNameLabel);
			this.Name = "AddEditForm";
			this.Text = "AddEditForm";
			this.ElementTypeGroupBox.ResumeLayout(false);
			this.ElementTypeGroupBox.PerformLayout();
			this.AddGroupBox.ResumeLayout(false);
			this.AddGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label EditNameLabel;
		private System.Windows.Forms.Label EditValueLabel;
		private System.Windows.Forms.TextBox EditNameTextBox;
		private System.Windows.Forms.TextBox EditValueTextBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelEditButton;
		private System.Windows.Forms.GroupBox ElementTypeGroupBox;
		private System.Windows.Forms.RadioButton CRadioButton;
		private System.Windows.Forms.RadioButton LRadioButton;
		private System.Windows.Forms.RadioButton RRadioButton;
		private System.Windows.Forms.Label MeasurementLabel;
		private System.Windows.Forms.GroupBox AddGroupBox;
		private System.Windows.Forms.RadioButton AddParallelRadioButton;
		private System.Windows.Forms.RadioButton AddSerialRadioButton;
	}
}