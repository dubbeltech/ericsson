using System;
using System.Collections.Generic;
using System.Numerics;

namespace TDETask3b
{
	enum coefs : int
	{
		P = 20,
		Z = 30
	}
	class PARCalculator
	{
		public double ParCalculation(List<Complex> inputIQ)
		{
			double rmsNum = getRMSValue(inputIQ);
			double peakNum = getPeakValue(inputIQ);

			rmsNum = dBConverter(rmsNum, "Z");
			peakNum = dBConverter(peakNum, "Z");

			Console.WriteLine();
			Console.WriteLine(rmsNum + " dB");
			Console.WriteLine(peakNum + " dB");

			double par = peakNum - rmsNum;

			return par;
		}

		private double dBConverter(double rawVal, string unit = "")
		{
			const int RefZ = 50;
			const int RefP = 1;
			const int RefV = 1;
			double output = 0;

			//default case assumes voltage values
			if (unit.Contains(coefs.P.ToString()))
			{
				output = Math.Log10(rawVal / RefP);
				output = ((int)coefs.P) * output;
			}
			else if (unit.Equals(coefs.Z.ToString()))
			{
				output = Math.Log10(rawVal / RefZ);
				output = ((int)coefs.Z) * output;
			}
			else
			{
				output = Math.Log10(rawVal / RefV);
				output = ((int)coefs.Z) * output; //coef for Z and V are the same
			}

			return output;
		}

		private double getRMSValue(List<Complex> inputIQ)
		{
			double meanNum = 0;
			double sum = 0;
			double rmsNum = 0;

			foreach (Complex calVal in inputIQ)
			{
				sum += Complex.Abs(calVal);
			}

			meanNum = sum / inputIQ.Count;
			rmsNum = Math.Sqrt(meanNum);
			Console.WriteLine(rmsNum);

			return rmsNum;
		}

		private double getPeakValue(List<Complex> inputIQ)
		{
			List<Double> absValue = new List<Double>(inputIQ.Count);

			foreach (Complex iqData in inputIQ)
			{
				absValue.Add(Complex.Abs(iqData));
			}

			absValue.Sort();
			absValue.Reverse();

			double peakValPower = absValue[0];
			Console.WriteLine(peakValPower);

			return peakValPower;
		}
	}
}
