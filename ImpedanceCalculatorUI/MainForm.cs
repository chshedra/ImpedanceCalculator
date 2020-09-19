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
		private List<double> _frequencies;
		private List<Complex> _impedancies = new List<Complex>();

		private Image[] _circuitsImage;

		

		public MainForm()
		{
			InitializeComponent();
			_circuits = Project.CreateCircuits();

			foreach(Circuit circuit in _circuits)
			{
				circuit.CircuitChanged += ElementChangeMessage;
			}

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

			_frequencies = new List<double>();
			FrequenceListBox.DataSource = _frequencies;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			CircuitsListBox.SelectedIndex = 0;

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
			if (R1TextBox.BackColor == Color.IndianRed ||
				R2TextBox.BackColor == Color.IndianRed ||
				C1TextBox.BackColor == Color.IndianRed ||
				C2TextBox.BackColor == Color.IndianRed ||
				L1TextBox.BackColor == Color.IndianRed ||
				L2TextBox.BackColor == Color.IndianRed ||
				FrequenceTextBox.BackColor != Color.White)
			{
				MessageBox.Show("Incorrect values", "Values must be contains positive numbers",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageTextBox.Clear();
				_frequencies.Add(double.Parse(FrequenceTextBox.Text));

				foreach (IElement element in _circuits[CircuitsListBox.SelectedIndex].Elements)
				{
					if (element.Name == "R1")
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

				_impedancies.Add(_circuits[CircuitsListBox.SelectedIndex].CalculateZ(double.Parse(FrequenceTextBox.Text)));

				FrequenceListBox.DataSource = null;
				FrequenceListBox.DataSource = _frequencies;

				ImpedanceListBox.Items.Clear();
				foreach (Complex imp in _impedancies)
				{
					ImpedanceListBox.Items.Add(Convert.ToString(Math.Round(imp.Real, 2) + "+" + Math.Round(imp.Imaginary, 2) + "i"));
				}
			}
		}

		private void R1TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(R1TextBox);
		}

		private void C1TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(C1TextBox);
		}

		private void L1TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(L1TextBox);
		}

		private void R2TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(R2TextBox);
		}

		private void C2TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(C2TextBox);
		}

		private void L2TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(L2TextBox);
		}

		private void FrequenceTextBox_TextChanged(object sender, EventArgs e)
		{
			TextBoxCheck(FrequenceTextBox);
		}

		private void FrequenceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImpedanceListBox.SelectedIndex = FrequenceListBox.SelectedIndex;
		}

		private void ImpedanceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			FrequenceListBox.SelectedIndex = ImpedanceListBox.SelectedIndex;
		}

		/// <summary>
		/// Метод проверки ввода значений 
		/// </summary>
		/// <param name="textBox"></param>
		private void TextBoxCheck(TextBox textBox)
		{
			double num = 0.0;

			textBox.BackColor = (textBox.Text == null || !double.TryParse(textBox.Text, out num))
				? Color.IndianRed
				: Color.White;
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			if(FrequenceListBox.SelectedItem == null)
			{
				MessageBox.Show("Message", "Choose the frequence from the listbox", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				
				
			}
		}

		/// <summary>
		/// Обработчик события измененения цепи
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ElementChangeMessage(object sender, EventArgs e)
		{
			IElement element = (IElement)sender;
			MessageTextBox.Text += element.Name + " new value is " + element.Value + Environment.NewLine;
		}
	}
}
