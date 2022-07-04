using System;
using System.Numerics;
using System.Collections.Generic;

namespace TDETask3b
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Complex> complexValues = new List<Complex>();

			complexValues.Add(new Complex(5, 37));
			complexValues.Add(new Complex(3, 7));
			complexValues.Add(new Complex(10, 7));
			complexValues.Add(new Complex(50, 90));

			Console.WriteLine("(real, imag) : Abs");

			foreach (Complex complexValue in complexValues)
			{
				Console.WriteLine(complexValue +" : "+ Complex.Abs(complexValue));
			}

			Console.WriteLine();
			Console.WriteLine(complexValues.Count);
			Console.WriteLine();

			PARCalculator calculator = new PARCalculator();
			double par = calculator.ParCalculation(complexValues);

			Console.WriteLine();
			Console.WriteLine(par + " dB");
		}
	}
}
