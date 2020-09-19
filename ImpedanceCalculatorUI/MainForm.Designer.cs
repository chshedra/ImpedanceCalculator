﻿namespace ImpedanceCalculatorUI
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
			this.MainFormSplitContainer = new System.Windows.Forms.SplitContainer();
			this.CircuitsListBox = new System.Windows.Forms.ListBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.FrequenceListBox = new System.Windows.Forms.ListBox();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.ValuePanel = new System.Windows.Forms.Panel();
			this.FrequenceTextBox = new System.Windows.Forms.TextBox();
			this.FrequenceLabel = new System.Windows.Forms.Label();
			this.C1TextBox = new System.Windows.Forms.TextBox();
			this.R1Label = new System.Windows.Forms.Label();
			this.R1TextBox = new System.Windows.Forms.TextBox();
			this.L2TextBox = new System.Windows.Forms.TextBox();
			this.C2TextBox = new System.Windows.Forms.TextBox();
			this.R2TextBox = new System.Windows.Forms.TextBox();
			this.L2Label = new System.Windows.Forms.Label();
			this.C2Label = new System.Windows.Forms.Label();
			this.R2Label = new System.Windows.Forms.Label();
			this.L1TextBox = new System.Windows.Forms.TextBox();
			this.L1Label = new System.Windows.Forms.Label();
			this.C1Label = new System.Windows.Forms.Label();
			this.FrequenciesLabel = new System.Windows.Forms.Label();
			this.ImpedanceLabel = new System.Windows.Forms.Label();
			this.EditButton = new System.Windows.Forms.Button();
			this.MessageTextBox = new System.Windows.Forms.TextBox();
			this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.MainFormSplitContainer)).BeginInit();
			this.MainFormSplitContainer.Panel1.SuspendLayout();
			this.MainFormSplitContainer.Panel2.SuspendLayout();
			this.MainFormSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.ValuePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// MainFormSplitContainer
			// 
			this.MainFormSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainFormSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.MainFormSplitContainer.Name = "MainFormSplitContainer";
			// 
			// MainFormSplitContainer.Panel1
			// 
			this.MainFormSplitContainer.Panel1.Controls.Add(this.MessageTextBox);
			this.MainFormSplitContainer.Panel1.Controls.Add(this.CircuitsListBox);
			// 
			// MainFormSplitContainer.Panel2
			// 
			this.MainFormSplitContainer.Panel2.Controls.Add(this.EditButton);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.ImpedanceLabel);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.FrequenciesLabel);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.CalculateButton);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.ImpedanceListBox);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.FrequenceListBox);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.CircuitPictureBox);
			this.MainFormSplitContainer.Panel2.Controls.Add(this.ValuePanel);
			this.MainFormSplitContainer.Size = new System.Drawing.Size(784, 402);
			this.MainFormSplitContainer.SplitterDistance = 261;
			this.MainFormSplitContainer.TabIndex = 0;
			// 
			// CircuitsListBox
			// 
			this.CircuitsListBox.FormattingEnabled = true;
			this.CircuitsListBox.Location = new System.Drawing.Point(9, 10);
			this.CircuitsListBox.Name = "CircuitsListBox";
			this.CircuitsListBox.Size = new System.Drawing.Size(249, 173);
			this.CircuitsListBox.TabIndex = 0;
			this.CircuitsListBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsListBox_SelectedIndexChanged);
			// 
			// CalculateButton
			// 
			this.CalculateButton.Location = new System.Drawing.Point(3, 324);
			this.CalculateButton.Name = "CalculateButton";
			this.CalculateButton.Size = new System.Drawing.Size(96, 23);
			this.CalculateButton.TabIndex = 1;
			this.CalculateButton.Text = "Calculate";
			this.CalculateButton.UseVisualStyleBackColor = true;
			this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(356, 207);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.Size = new System.Drawing.Size(150, 186);
			this.ImpedanceListBox.TabIndex = 3;
			this.ImpedanceListBox.SelectedIndexChanged += new System.EventHandler(this.ImpedanceListBox_SelectedIndexChanged);
			// 
			// FrequenceListBox
			// 
			this.FrequenceListBox.FormattingEnabled = true;
			this.FrequenceListBox.Location = new System.Drawing.Point(206, 207);
			this.FrequenceListBox.Name = "FrequenceListBox";
			this.FrequenceListBox.Size = new System.Drawing.Size(144, 186);
			this.FrequenceListBox.TabIndex = 2;
			this.FrequenceListBox.SelectedIndexChanged += new System.EventHandler(this.FrequenceListBox_SelectedIndexChanged);
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.BackColor = System.Drawing.Color.White;
			this.CircuitPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CircuitPictureBox.Location = new System.Drawing.Point(3, 12);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(504, 171);
			this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CircuitPictureBox.TabIndex = 0;
			this.CircuitPictureBox.TabStop = false;
			// 
			// ValuePanel
			// 
			this.ValuePanel.Controls.Add(this.FrequenceTextBox);
			this.ValuePanel.Controls.Add(this.FrequenceLabel);
			this.ValuePanel.Controls.Add(this.C1TextBox);
			this.ValuePanel.Controls.Add(this.R1Label);
			this.ValuePanel.Controls.Add(this.R1TextBox);
			this.ValuePanel.Controls.Add(this.L2TextBox);
			this.ValuePanel.Controls.Add(this.C2TextBox);
			this.ValuePanel.Controls.Add(this.R2TextBox);
			this.ValuePanel.Controls.Add(this.L2Label);
			this.ValuePanel.Controls.Add(this.C2Label);
			this.ValuePanel.Controls.Add(this.R2Label);
			this.ValuePanel.Controls.Add(this.L1TextBox);
			this.ValuePanel.Controls.Add(this.L1Label);
			this.ValuePanel.Controls.Add(this.C1Label);
			this.ValuePanel.Location = new System.Drawing.Point(3, 189);
			this.ValuePanel.Name = "ValuePanel";
			this.ValuePanel.Size = new System.Drawing.Size(197, 129);
			this.ValuePanel.TabIndex = 1;
			// 
			// FrequenceTextBox
			// 
			this.FrequenceTextBox.Location = new System.Drawing.Point(82, 96);
			this.FrequenceTextBox.Name = "FrequenceTextBox";
			this.FrequenceTextBox.Size = new System.Drawing.Size(103, 20);
			this.FrequenceTextBox.TabIndex = 13;
			this.FrequenceTextBox.TextChanged += new System.EventHandler(this.FrequenceTextBox_TextChanged);
			// 
			// FrequenceLabel
			// 
			this.FrequenceLabel.AutoSize = true;
			this.FrequenceLabel.Location = new System.Drawing.Point(12, 99);
			this.FrequenceLabel.Name = "FrequenceLabel";
			this.FrequenceLabel.Size = new System.Drawing.Size(64, 13);
			this.FrequenceLabel.TabIndex = 12;
			this.FrequenceLabel.Text = "Frequence=";
			// 
			// C1TextBox
			// 
			this.C1TextBox.Location = new System.Drawing.Point(42, 36);
			this.C1TextBox.Name = "C1TextBox";
			this.C1TextBox.Size = new System.Drawing.Size(54, 20);
			this.C1TextBox.TabIndex = 4;
			this.C1TextBox.TextChanged += new System.EventHandler(this.C1TextBox_TextChanged);
			// 
			// R1Label
			// 
			this.R1Label.AutoSize = true;
			this.R1Label.Location = new System.Drawing.Point(12, 13);
			this.R1Label.Name = "R1Label";
			this.R1Label.Size = new System.Drawing.Size(27, 13);
			this.R1Label.TabIndex = 0;
			this.R1Label.Text = "R1=";
			// 
			// R1TextBox
			// 
			this.R1TextBox.Location = new System.Drawing.Point(42, 10);
			this.R1TextBox.Name = "R1TextBox";
			this.R1TextBox.Size = new System.Drawing.Size(54, 20);
			this.R1TextBox.TabIndex = 3;
			this.R1TextBox.TextChanged += new System.EventHandler(this.R1TextBox_TextChanged);
			// 
			// L2TextBox
			// 
			this.L2TextBox.Location = new System.Drawing.Point(133, 62);
			this.L2TextBox.Name = "L2TextBox";
			this.L2TextBox.Size = new System.Drawing.Size(52, 20);
			this.L2TextBox.TabIndex = 11;
			this.L2TextBox.TextChanged += new System.EventHandler(this.L2TextBox_TextChanged);
			// 
			// C2TextBox
			// 
			this.C2TextBox.Location = new System.Drawing.Point(133, 36);
			this.C2TextBox.Name = "C2TextBox";
			this.C2TextBox.Size = new System.Drawing.Size(52, 20);
			this.C2TextBox.TabIndex = 10;
			this.C2TextBox.TextChanged += new System.EventHandler(this.C2TextBox_TextChanged);
			// 
			// R2TextBox
			// 
			this.R2TextBox.Location = new System.Drawing.Point(132, 10);
			this.R2TextBox.Name = "R2TextBox";
			this.R2TextBox.Size = new System.Drawing.Size(53, 20);
			this.R2TextBox.TabIndex = 9;
			this.R2TextBox.TextChanged += new System.EventHandler(this.R2TextBox_TextChanged);
			// 
			// L2Label
			// 
			this.L2Label.AutoSize = true;
			this.L2Label.Location = new System.Drawing.Point(102, 65);
			this.L2Label.Name = "L2Label";
			this.L2Label.Size = new System.Drawing.Size(25, 13);
			this.L2Label.TabIndex = 8;
			this.L2Label.Text = "L2=";
			// 
			// C2Label
			// 
			this.C2Label.AutoSize = true;
			this.C2Label.Location = new System.Drawing.Point(102, 39);
			this.C2Label.Name = "C2Label";
			this.C2Label.Size = new System.Drawing.Size(26, 13);
			this.C2Label.TabIndex = 7;
			this.C2Label.Text = "C2=";
			// 
			// R2Label
			// 
			this.R2Label.AutoSize = true;
			this.R2Label.Location = new System.Drawing.Point(102, 13);
			this.R2Label.Name = "R2Label";
			this.R2Label.Size = new System.Drawing.Size(27, 13);
			this.R2Label.TabIndex = 6;
			this.R2Label.Text = "R2=";
			// 
			// L1TextBox
			// 
			this.L1TextBox.Location = new System.Drawing.Point(42, 62);
			this.L1TextBox.Name = "L1TextBox";
			this.L1TextBox.Size = new System.Drawing.Size(54, 20);
			this.L1TextBox.TabIndex = 5;
			this.L1TextBox.TextChanged += new System.EventHandler(this.L1TextBox_TextChanged);
			// 
			// L1Label
			// 
			this.L1Label.AutoSize = true;
			this.L1Label.Location = new System.Drawing.Point(12, 65);
			this.L1Label.Name = "L1Label";
			this.L1Label.Size = new System.Drawing.Size(25, 13);
			this.L1Label.TabIndex = 2;
			this.L1Label.Text = "L1=";
			// 
			// C1Label
			// 
			this.C1Label.AutoSize = true;
			this.C1Label.Location = new System.Drawing.Point(12, 39);
			this.C1Label.Name = "C1Label";
			this.C1Label.Size = new System.Drawing.Size(26, 13);
			this.C1Label.TabIndex = 1;
			this.C1Label.Text = "C1=";
			// 
			// FrequenciesLabel
			// 
			this.FrequenciesLabel.AutoSize = true;
			this.FrequenciesLabel.Location = new System.Drawing.Point(203, 189);
			this.FrequenciesLabel.Name = "FrequenciesLabel";
			this.FrequenciesLabel.Size = new System.Drawing.Size(65, 13);
			this.FrequenciesLabel.TabIndex = 4;
			this.FrequenciesLabel.Text = "Frequencies";
			// 
			// ImpedanceLabel
			// 
			this.ImpedanceLabel.AutoSize = true;
			this.ImpedanceLabel.Location = new System.Drawing.Point(353, 189);
			this.ImpedanceLabel.Name = "ImpedanceLabel";
			this.ImpedanceLabel.Size = new System.Drawing.Size(60, 13);
			this.ImpedanceLabel.TabIndex = 5;
			this.ImpedanceLabel.Text = "Impedance";
			// 
			// EditButton
			// 
			this.EditButton.Location = new System.Drawing.Point(105, 324);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(95, 23);
			this.EditButton.TabIndex = 6;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// MessageTextBox
			// 
			this.MessageTextBox.Location = new System.Drawing.Point(9, 189);
			this.MessageTextBox.Multiline = true;
			this.MessageTextBox.Name = "MessageTextBox";
			this.MessageTextBox.ReadOnly = true;
			this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MessageTextBox.Size = new System.Drawing.Size(249, 204);
			this.MessageTextBox.TabIndex = 1;
			// 
			// projectBindingSource
			// 
			this.projectBindingSource.DataSource = typeof(ImpedanceCalculator.Project);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 402);
			this.Controls.Add(this.MainFormSplitContainer);
			this.Name = "MainForm";
			this.Text = "ImpedanceCalculator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainFormSplitContainer.Panel1.ResumeLayout(false);
			this.MainFormSplitContainer.Panel1.PerformLayout();
			this.MainFormSplitContainer.Panel2.ResumeLayout(false);
			this.MainFormSplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainFormSplitContainer)).EndInit();
			this.MainFormSplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			this.ValuePanel.ResumeLayout(false);
			this.ValuePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer MainFormSplitContainer;
		private System.Windows.Forms.ListBox CircuitsListBox;
		private System.Windows.Forms.Panel ValuePanel;
		private System.Windows.Forms.TextBox L1TextBox;
		private System.Windows.Forms.TextBox C1TextBox;
		private System.Windows.Forms.TextBox R1TextBox;
		private System.Windows.Forms.Label L1Label;
		private System.Windows.Forms.Label C1Label;
		private System.Windows.Forms.Label R1Label;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.TextBox L2TextBox;
		private System.Windows.Forms.TextBox C2TextBox;
		private System.Windows.Forms.TextBox R2TextBox;
		private System.Windows.Forms.Label L2Label;
		private System.Windows.Forms.Label C2Label;
		private System.Windows.Forms.Label R2Label;
		public System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.BindingSource projectBindingSource;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.ListBox FrequenceListBox;
		private System.Windows.Forms.TextBox FrequenceTextBox;
		private System.Windows.Forms.Label FrequenceLabel;
		private System.Windows.Forms.Label ImpedanceLabel;
		private System.Windows.Forms.Label FrequenciesLabel;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.TextBox MessageTextBox;
	}
}

