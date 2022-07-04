using System;

namespace TDETest10
{
	class Program
	{
		static int counter = 0;
		static void Main(string[] args)
		{
			string input = "abca";

			string output = getMatchPair(input);
			Console.WriteLine(output);

		}

		public static string getMatchPair(string input)
		{
			int i = 0;
			int j = input.Length;

			if (counter == 0 && input.Length > 4)
			{
				string newInput = ReversedString(input);

				if (input.Equals(newInput))
				{
					return "";
				}
			}

			if (input.Length > 0)
			{
				if (input[i] != input[input.Length - 1])
				{
					return new string(input[i] + "" + input[j - 1]);
				}
				else if (j == 1 || i == (j - 1))
				{
					return "";
				}

				i++;
				counter++;
				return getMatchPair(input.Substring(i, j - 2));
			}

			counter = 0; // clear global variable
			return "";
		}

		private static string ReversedString(string input)
		{
			char[] inputStr = input.ToCharArray();
			Array.Reverse(inputStr);
			return new string(inputStr);
		}

	}
}
