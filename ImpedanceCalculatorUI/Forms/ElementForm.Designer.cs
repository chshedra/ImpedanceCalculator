namespace ImpedanceCalculatorUI.Forms
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementForm));
			this.EditNameLabel = new System.Windows.Forms.Label();
			this.EditValueLabel = new System.Windows.Forms.Label();
			this.EditNameTextBox = new System.Windows.Forms.TextBox();
			this.EditValueTextBox = new System.Windows.Forms.TextBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelEditButton = new System.Windows.Forms.Button();
			this.ElementTypeGroupBox = new System.Windows.Forms.GroupBox();
			this.ElementTypeComboBox = new System.Windows.Forms.ComboBox();
			this.MeasurementLabel = new System.Windows.Forms.Label();
			this.AddGroupBox = new System.Windows.Forms.GroupBox();
			this.ConnectionComboBox = new System.Windows.Forms.ComboBox();
			this.ValueGroupBox = new System.Windows.Forms.GroupBox();
			this.SILabel = new System.Windows.Forms.Label();
			this.NameGroupBox = new System.Windows.Forms.GroupBox();
			this.ElementTypeGroupBox.SuspendLayout();
			this.AddGroupBox.SuspendLayout();
			this.ValueGroupBox.SuspendLayout();
			this.NameGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// EditNameLabel
			// 
			this.EditNameLabel.AutoSize = true;
			this.EditNameLabel.BackColor = System.Drawing.Color.Transparent;
			this.EditNameLabel.Location = new System.Drawing.Point(6, 12);
			this.EditNameLabel.Name = "EditNameLabel";
			this.EditNameLabel.Size = new System.Drawing.Size(41, 13);
			this.EditNameLabel.TabIndex = 0;
			this.EditNameLabel.Text = "Name=";
			// 
			// EditValueLabel
			// 
			this.EditValueLabel.AutoSize = true;
			this.EditValueLabel.Location = new System.Drawing.Point(11, 12);
			this.EditValueLabel.Name = "EditValueLabel";
			this.EditValueLabel.Size = new System.Drawing.Size(40, 13);
			this.EditValueLabel.TabIndex = 1;
			this.EditValueLabel.Text = "Value=";
			// 
			// EditNameTextBox
			// 
			this.EditNameTextBox.Location = new System.Drawing.Point(51, 7);
			this.EditNameTextBox.Name = "EditNameTextBox";
			this.EditNameTextBox.Size = new System.Drawing.Size(62, 20);
			this.EditNameTextBox.TabIndex = 2;
			// 
			// EditValueTextBox
			// 
			this.EditValueTextBox.Location = new System.Drawing.Point(52, 9);
			this.EditValueTextBox.Name = "EditValueTextBox";
			this.EditValueTextBox.Size = new System.Drawing.Size(63, 20);
			this.EditValueTextBox.TabIndex = 3;
			this.EditValueTextBox.TextChanged += new System.EventHandler(this.EditValueTextBox_TextChanged);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(158, 102);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(64, 23);
			this.OkButton.TabIndex = 5;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CancelEditButton
			// 
			this.CancelEditButton.Location = new System.Drawing.Point(226, 102);
			this.CancelEditButton.Name = "CancelEditButton";
			this.CancelEditButton.Size = new System.Drawing.Size(59, 23);
			this.CancelEditButton.TabIndex = 6;
			this.CancelEditButton.Text = "Cancel";
			this.CancelEditButton.UseVisualStyleBackColor = true;
			this.CancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
			// 
			// ElementTypeGroupBox
			// 
			this.ElementTypeGroupBox.Controls.Add(this.ElementTypeComboBox);
			this.ElementTypeGroupBox.Location = new System.Drawing.Point(14, 13);
			this.ElementTypeGroupBox.Name = "ElementTypeGroupBox";
			this.ElementTypeGroupBox.Size = new System.Drawing.Size(113, 40);
			this.ElementTypeGroupBox.TabIndex = 7;
			this.ElementTypeGroupBox.TabStop = false;
			this.ElementTypeGroupBox.Text = "Type";
			// 
			// ElementTypeComboBox
			// 
			this.ElementTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ElementTypeComboBox.FormattingEnabled = true;
			this.ElementTypeComboBox.Location = new System.Drawing.Point(0, 19);
			this.ElementTypeComboBox.Name = "ElementTypeComboBox";
			this.ElementTypeComboBox.Size = new System.Drawing.Size(113, 21);
			this.ElementTypeComboBox.TabIndex = 0;
			this.ElementTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ElementTypeComboBox_SelectedIndexChanged);
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
			this.AddGroupBox.Controls.Add(this.ConnectionComboBox);
			this.AddGroupBox.Location = new System.Drawing.Point(172, 14);
			this.AddGroupBox.Name = "AddGroupBox";
			this.AddGroupBox.Size = new System.Drawing.Size(113, 39);
			this.AddGroupBox.TabIndex = 9;
			this.AddGroupBox.TabStop = false;
			this.AddGroupBox.Text = "Add";
			// 
			// ConnectionComboBox
			// 
			this.ConnectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ConnectionComboBox.FormattingEnabled = true;
			this.ConnectionComboBox.Location = new System.Drawing.Point(0, 18);
			this.ConnectionComboBox.Name = "ConnectionComboBox";
			this.ConnectionComboBox.Size = new System.Drawing.Size(113, 21);
			this.ConnectionComboBox.TabIndex = 0;
			// 
			// ValueGroupBox
			// 
			this.ValueGroupBox.Controls.Add(this.SILabel);
			this.ValueGroupBox.Controls.Add(this.EditValueTextBox);
			this.ValueGroupBox.Controls.Add(this.EditValueLabel);
			this.ValueGroupBox.Location = new System.Drawing.Point(133, 63);
			this.ValueGroupBox.Name = "ValueGroupBox";
			this.ValueGroupBox.Size = new System.Drawing.Size(152, 33);
			this.ValueGroupBox.TabIndex = 10;
			this.ValueGroupBox.TabStop = false;
			// 
			// SILabel
			// 
			this.SILabel.AutoSize = true;
			this.SILabel.Location = new System.Drawing.Point(117, 12);
			this.SILabel.Name = "SILabel";
			this.SILabel.Size = new System.Drawing.Size(29, 13);
			this.SILabel.TabIndex = 4;
			this.SILabel.Text = "Ohm";
			// 
			// NameGroupBox
			// 
			this.NameGroupBox.Controls.Add(this.EditNameLabel);
			this.NameGroupBox.Controls.Add(this.EditNameTextBox);
			this.NameGroupBox.Location = new System.Drawing.Point(12, 63);
			this.NameGroupBox.Name = "NameGroupBox";
			this.NameGroupBox.Size = new System.Drawing.Size(115, 33);
			this.NameGroupBox.TabIndex = 11;
			this.NameGroupBox.TabStop = false;
			// 
			// ElementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(297, 140);
			this.Controls.Add(this.NameGroupBox);
			this.Controls.Add(this.ValueGroupBox);
			this.Controls.Add(this.AddGroupBox);
			this.Controls.Add(this.MeasurementLabel);
			this.Controls.Add(this.ElementTypeGroupBox);
			this.Controls.Add(this.CancelEditButton);
			this.Controls.Add(this.OkButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(313, 179);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(313, 179);
			this.Name = "ElementForm";
			this.Text = "AddEditForm";
			this.ElementTypeGroupBox.ResumeLayout(false);
			this.AddGroupBox.ResumeLayout(false);
			this.ValueGroupBox.ResumeLayout(false);
			this.ValueGroupBox.PerformLayout();
			this.NameGroupBox.ResumeLayout(false);
			this.NameGroupBox.PerformLayout();
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
		private System.Windows.Forms.Label MeasurementLabel;
		private System.Windows.Forms.GroupBox AddGroupBox;
		private System.Windows.Forms.ComboBox ElementTypeComboBox;
		private System.Windows.Forms.ComboBox ConnectionComboBox;
		private System.Windows.Forms.GroupBox ValueGroupBox;
		private System.Windows.Forms.Label SILabel;
		private System.Windows.Forms.GroupBox NameGroupBox;
	}
}