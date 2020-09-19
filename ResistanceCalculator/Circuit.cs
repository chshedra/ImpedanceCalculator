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

       
        public Complex CalculateZ(double frequency)
        {
            Complex impedance = new Complex();
           
            foreach (IElement element in Elements)
            {
                impedance += element.CalculateZ(frequency);
            }
            

            return impedance;
        }

        private void OnCircuitChange(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        public void SubcribeToCircuitChange()
        {
            foreach(IElement element in Elements)
            {
                if (element.HasSubscribers())
                {
                    element.ValueChanged += OnCircuitChange;
                }  
            }
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
