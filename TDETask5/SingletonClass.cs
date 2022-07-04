using System;
using System.Collections.Generic;
using System.Text;

namespace TDETask5
{
	public sealed class SingletonClass
	{
		private string ouput;
		public static int count = 0;
		private SingletonClass() { count += 1; }

		public static SingletonClass getInstance
		{
			get
			{
				return Subclass.singletonInstance;
			}
		}

		private class Subclass
		{
			static Subclass() { }

			internal static readonly SingletonClass singletonInstance = new SingletonClass();
		}

		public void writeStr(string str = "1")
		{
			this.ouput = str;
		}

		public void readStr()
		{
			Console.WriteLine(this.ouput);
		}
	}
}
