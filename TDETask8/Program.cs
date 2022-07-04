using System;
using System.Collections.Generic;

namespace TDETask8
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> input = new List<int>();

			input.Add(5);
			input.Add(3);
			input.Add(4);


			int result = getMaximumValue(input);

			Console.WriteLine(result);


		}

		private static int getMaximumValue(List<int> input)
		{
			if (input.Count == 1)
			{
				return input[0];
			}

			if (input.Count == 2)
			{
				return input[0] + input[1];
			}

			List<int> output = getValues(input);

			output.Sort();
			output.Reverse();

			int max = output[0];
			return max;
		}

		public static List<int> getValues(List<int> input)
		{
			List<int> outputList = new List<int>();

			outputList.Add(getSum(input));

			List<int> tempList = sortList(input);
			outputList.Add(getSum(tempList));

			tempList = sortList(input, 1);
			outputList.Add(getSum(tempList));

			tempList = sortList(input, 2);
			outputList.Add(getSum(tempList));

			return outputList;
		}

		public static int getSum(List<int> input)
		{
			int i;
			int j;
			int Sum = 0;
			for (i = 0, j = i + 1; i < input.Count - 1; i++, j++)
			{
				Sum += input[i] + input[j];
			}

			return Sum;
		}

		public static List<int> sortList(List<int> input, int flag = 0)
		{
			int length = input.Count;
			List<int> output = new List<int>(length);
			List<int> tempList = new List<int>();

			input.Sort();

			if (flag == 0)
			{
				tempList.AddRange(input);
				// first do sorted list 
			}
			else if (flag == 1)
			{
				tempList = getList(input, length);
			}
			else
			{
				tempList = getVList(input, length);
			}

			output.AddRange(tempList);

			return output;
		}

		private static List<int> getList(List<int> input, int length)
		{
			int middle = length / 2;
			int range = length - middle;

			List<int> tempListOne = input.GetRange(middle, range);
			tempListOne.Reverse();

			List<int> tempListTwo = input.GetRange(0, middle);
			tempListTwo.AddRange(tempListOne);

			return tempListTwo;
		}
		private static List<int> getVList(List<int> input, int length)
		{
			int middle = (length / 2) + 1;
			int range = length - middle;

			List<int> tempListOne = input.GetRange(middle, range);

			List<int> tempListTwo = input.GetRange(0, middle);
			tempListTwo.Reverse();
			tempListTwo.AddRange(tempListOne);

			return tempListTwo;
		}
	}
}
