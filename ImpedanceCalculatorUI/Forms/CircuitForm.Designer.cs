namespace ImpedanceCalculatorUI
{
	partial class CircuitForm
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
			this.CircuitNameLabel = new System.Windows.Forms.Label();
			this.ConnectionTupeGroupBox = new System.Windows.Forms.GroupBox();
			this.ParallelConnectionRadioButton = new System.Windows.Forms.RadioButton();
			this.SerialConnectionRadioButton = new System.Windows.Forms.RadioButton();
			this.CircuitNameTextBox = new System.Windows.Forms.TextBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.ConnectionTupeGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// CircuitNameLabel
			// 
			this.CircuitNameLabel.AutoSize = true;
			this.CircuitNameLabel.Location = new System.Drawing.Point(23, 18);
			this.CircuitNameLabel.Name = "CircuitNameLabel";
			this.CircuitNameLabel.Size = new System.Drawing.Size(41, 13);
			this.CircuitNameLabel.TabIndex = 0;
			this.CircuitNameLabel.Text = "Name: ";
			// 
			// ConnectionTupeGroupBox
			// 
			this.ConnectionTupeGroupBox.Controls.Add(this.ParallelConnectionRadioButton);
			this.ConnectionTupeGroupBox.Controls.Add(this.SerialConnectionRadioButton);
			this.ConnectionTupeGroupBox.Location = new System.Drawing.Point(26, 48);
			this.ConnectionTupeGroupBox.Name = "ConnectionTupeGroupBox";
			this.ConnectionTupeGroupBox.Size = new System.Drawing.Size(151, 53);
			this.ConnectionTupeGroupBox.TabIndex = 1;
			this.ConnectionTupeGroupBox.TabStop = false;
			this.ConnectionTupeGroupBox.Text = "Connection type";
			// 
			// ParallelConnectionRadioButton
			// 
			this.ParallelConnectionRadioButton.AutoSize = true;
			this.ParallelConnectionRadioButton.Location = new System.Drawing.Point(74, 19);
			this.ParallelConnectionRadioButton.Name = "ParallelConnectionRadioButton";
			this.ParallelConnectionRadioButton.Size = new System.Drawing.Size(59, 17);
			this.ParallelConnectionRadioButton.TabIndex = 1;
			this.ParallelConnectionRadioButton.TabStop = true;
			this.ParallelConnectionRadioButton.Text = "Parallel";
			this.ParallelConnectionRadioButton.UseVisualStyleBackColor = true;
			// 
			// SerialConnectionRadioButton
			// 
			this.SerialConnectionRadioButton.AutoSize = true;
			this.SerialConnectionRadioButton.Location = new System.Drawing.Point(6, 19);
			this.SerialConnectionRadioButton.Name = "SerialConnectionRadioButton";
			this.SerialConnectionRadioButton.Size = new System.Drawing.Size(51, 17);
			this.SerialConnectionRadioButton.TabIndex = 0;
			this.SerialConnectionRadioButton.TabStop = true;
			this.SerialConnectionRadioButton.Text = "Serial";
			this.SerialConnectionRadioButton.UseVisualStyleBackColor = true;
			// 
			// CircuitNameTextBox
			// 
			this.CircuitNameTextBox.Location = new System.Drawing.Point(61, 15);
			this.CircuitNameTextBox.Name = "CircuitNameTextBox";
			this.CircuitNameTextBox.Size = new System.Drawing.Size(116, 20);
			this.CircuitNameTextBox.TabIndex = 2;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(26, 107);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(68, 20);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(109, 107);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(68, 20);
			this.CancelButton.TabIndex = 4;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// CircuitForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(206, 141);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.CircuitNameTextBox);
			this.Controls.Add(this.ConnectionTupeGroupBox);
			this.Controls.Add(this.CircuitNameLabel);
			this.Name = "CircuitForm";
			this.Text = "CircuitForm";
			this.ConnectionTupeGroupBox.ResumeLayout(false);
			this.ConnectionTupeGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label CircuitNameLabel;
		private System.Windows.Forms.GroupBox ConnectionTupeGroupBox;
		private System.Windows.Forms.RadioButton ParallelConnectionRadioButton;
		private System.Windows.Forms.RadioButton SerialConnectionRadioButton;
		private System.Windows.Forms.TextBox CircuitNameTextBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelButton;
	}
}