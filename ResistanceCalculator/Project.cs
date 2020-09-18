using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImpedanceCalculator
{
	public static class Project
	{
		
		public static List<Circuit> CreateCircuits()
		{
			List<Circuit> circuits = new List<Circuit>();
		


			var R1 = new Resistor("R1", 0);
			var C1 = new Capacitor("C1", 0);
			var L1 = new Inductor("L1", 0);
			var R2 = new Resistor("R2", 0);
			var C2 = new Capacitor("C2", 0);
			var L2 = new Inductor("L2", 0);

			var circuit1 = new Circuit();
			circuit1.Elements.Add(R1);
			circuit1.Elements.Add(C1);
			circuit1.Elements.Add(L1);

			var circuit2 = new Circuit();
			circuit2.Elements.Add(R1);
			circuit2.Elements.Add(C1);
			circuit2.Elements.Add(L1);
			circuit2.Elements.Add(C2);

			var circuit3 = new Circuit();
			circuit3.Elements.Add(R1);
			circuit3.Elements.Add(L1);
			circuit3.Elements.Add(L2);
			circuit3.Elements.Add(C1);

			var circuit4 = new Circuit();
			circuit4.Elements.Add(R1);
			circuit4.Elements.Add(L1);
			circuit4.Elements.Add(L2);
			circuit4.Elements.Add(R2);

			var circuit5 = new Circuit();
			circuit5.Elements.Add(C1);
			circuit5.Elements.Add(L1);
			circuit5.Elements.Add(L2);
			circuit5.Elements.Add(C2);


			circuits.Add(circuit1);
			circuits.Add(circuit2);
			circuits.Add(circuit3);
			circuits.Add(circuit4);
			circuits.Add(circuit5);

			return circuits;
			
		}

		
	}
}
