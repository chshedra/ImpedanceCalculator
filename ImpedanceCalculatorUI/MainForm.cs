using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpedanceCalculator;
using System.Numerics;
using System.IO;

namespace ImpedanceCalculatorUI
{
	public partial class MainForm : Form
	{

		private List<Circuit> _circuits;
		private double[] _frequencies;
		private Complex[] _impedancies;

		private Image[] _circuitsImage;

		

		public MainForm()
		{
			InitializeComponent();
			_circuits = Project.CreateCircuits();

			for(int i = 0; i < 5; i++)
			{
				CircuitsListBox.Items.Add("Circuit №" + (i + 1));
			}

			_circuitsImage = new Image[5];
			DirectoryInfo dir = new DirectoryInfo("../../Resources");
			int j = 0;
			foreach (FileInfo file in dir.EnumerateFiles("*.jpg"))
			{
				_circuitsImage[j] = Image.FromFile(file.FullName);
				j++;
			}

			
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void CircuitsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CircuitPictureBox.Image = _circuitsImage[CircuitsListBox.SelectedIndex];

			switch(CircuitsListBox.SelectedIndex)
			{
				case 0:
					{
						R1TextBox.ReadOnly = false;
						C1TextBox.ReadOnly = false;					
						L1TextBox.ReadOnly = false;						
						R2TextBox.ReadOnly = true;						
						C2TextBox.ReadOnly = true;						
						L2TextBox.ReadOnly = true;
						break;
					}
				case 1:
					{
						
						R1TextBox.ReadOnly = false;					
						C1TextBox.ReadOnly = false;				
						L1TextBox.ReadOnly = false;						
						R2TextBox.ReadOnly = true;						
						C2TextBox.ReadOnly = false;					
						L2TextBox.ReadOnly = true;
						break;
					}
				case 2:
					{
						
						R1TextBox.ReadOnly = false;						
						C1TextBox.ReadOnly = false;						
						L1TextBox.ReadOnly = false;						
						R2TextBox.ReadOnly = true;						
						C2TextBox.ReadOnly = true;						
						L2TextBox.ReadOnly = false;
						break;
					}
				case 3:
					{
						
						R1TextBox.ReadOnly = false;						
						C1TextBox.ReadOnly = true;					
						L1TextBox.ReadOnly = false;						
						R2TextBox.ReadOnly = false;
						C2TextBox.ReadOnly = true;						
						L2TextBox.ReadOnly = false;
						break;
					}
				case 4:
					{
						
						R1TextBox.ReadOnly = true;						
						C1TextBox.ReadOnly = false;
						L1TextBox.ReadOnly = false;
						R2TextBox.ReadOnly = true;
						C2TextBox.ReadOnly = false;
						L2TextBox.ReadOnly = false;
						break;
					}
				
				
			}
		
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void CalculateButton_Click(object sender, EventArgs e)
		{
			
			if(R1TextBox != null)
			{
				foreach(IElement element in _circuits[CircuitsListBox.SelectedIndex].Elements)
				{

					if(element.Name == "R1")
					{
						element.Value = double.Parse(R1TextBox.Text);
					}
					if (element.Name == "R2")
					{
						element.Value = double.Parse(R2TextBox.Text);
					}
					if (element.Name == "C1")
					{
						element.Value = double.Parse(C1TextBox.Text);
					}
					if (element.Name == "C2")
					{
						element.Value = double.Parse(C2TextBox.Text);
					}
					if (element.Name == "L1")
					{
						element.Value = double.Parse(L1TextBox.Text);
					}
					if (element.Name == "L2")
					{
						element.Value = double.Parse(L2TextBox.Text);
					}

				}
			}
		}
	}
}
