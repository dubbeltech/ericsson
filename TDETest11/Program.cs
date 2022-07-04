using System;
using System.Collections.Generic;
using System.Linq;

namespace TDETask11
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<int, SortedSet<char>> output = new Dictionary<int, SortedSet<char>>();

			output = get_dict_by_occurences("EdithSiaw");
			Console.WriteLine();
			Console.WriteLine("wait while processing...");
			Console.WriteLine();
			outputFinal(output);
		}

		private static void outputFinal(Dictionary<int, SortedSet<char>> tempOutput)
		{
			int length = tempOutput.Keys.Count;
			List<int> listOfKeys = tempOutput.Keys.ToList();
			listOfKeys.Sort();
			length = listOfKeys.Count;

			Console.Write("{");

			for (int i = 0; i < length; i++)
			{
				Console.Write(listOfKeys[i] + ": ");
				Console.Write("['" + string.Join("', '", tempOutput[listOfKeys[i]]) + "']");
				if (i != length - 1)
				{
					Console.Write(", ");
				}
			}

			Console.Write("}");
		}

		public static Dictionary<int, SortedSet<char>> get_dict_by_occurences(string input)
		{
			Dictionary<int, SortedSet<char>> output = new Dictionary<int, SortedSet<char>>();
			SortedSet<char> unique = new SortedSet<char>();
			int length = input.Length;

			List<int> counts;
			List<char> counted;
			numOfOccurrences(input, length, out counts, out counted);

			pTempOutput(counts, counted);

			length = counts.Count;

			int max = getMaximumCount(counts, length);

			// add counted items to dictionary
			for (int i = 1; i <= length; i++)
			{
				unique = new SortedSet<char>();
				if (!unique.Contains(counted[i - 1]))
				{
					for (int j = 0; j < length; j++)
					{
						if ((counts[j] == i) && (!unique.Contains(counted[j])))
						{
							unique.Add(counted[j]);
						}
					}
				}

				if (!output.ContainsKey(i))
				{
					output.Add(i, unique);
				}
				if (i == max) { break; }
			}

			return output;
		}

		private static void numOfOccurrences(string input, int length, out List<int> counts, out List<char> counted)
		{
			counts = new List<int>();
			counted = new List<char>();
			int counter = 0;

			for (int i = 0; i < length; i++)
			{
				counter = 0;

				if (!counted.Contains((char)input[i]))
				{
					for (int j = 0; j < length; j++)
					{
						if (input[i] == input[j])
						{
							counter++;
							if (!counted.Contains((char)input[i]))
							{
								counted.Add(input[i]);
							}
						}
					}
				}
				if (counter != 0) { counts.Add(counter); }
			}
		}

		private static int getMaximumCount(List<int> counts, int length)
		{
			List<int> tempList = new List<int>();
			tempList.AddRange(counts);
			tempList.Sort();
			int maxCount = tempList[length - 1];
			return maxCount;
		}

		private static void pTempOutput(List<int> counts, List<char> counted)
		{
			foreach (int count in counts)
			{
				Console.Write(count + " ");
			}

			Console.WriteLine();

			foreach (var alphaNum in counted)
			{
				Console.Write(alphaNum + " ");
			}

			Console.WriteLine();
		}
	}

}
