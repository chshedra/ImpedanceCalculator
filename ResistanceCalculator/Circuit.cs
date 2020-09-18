using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace ImpedanceCalculator
{
    public class Circuit : ICloneable
    {
       
        public List<IElement> Elements { get; set; } = new List<IElement>();

        public event EventHandler CircuitChanged;

        Complex[] CalculateZ(double[] frequences)
        {
            Complex[] impedance = new Complex[frequences.Length];

            int i = 0;
            foreach (double frequence in frequences)
            {
                foreach (IElement element in Elements)
                {
                    element.ValueChanged += OnCircuitChange;
                    impedance[i] += element.CalculateZ(frequences[i]);
                }
                i++;
            }


            return impedance;
        }

        private void OnCircuitChange(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        public object Clone()
        {
            var circuit = new Circuit
            {
                Elements = new List<IElement>()
            };
            foreach (IElement e in Elements)
            {
                circuit.Elements.Add(e);
            }

            return circuit;
        }
    }
}
