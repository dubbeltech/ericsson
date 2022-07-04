using System;
using System.Threading;

namespace TDETask5
{
    class Program
    {
		static void Main(string[] args)
		{
			SingletonClass singletonClassOne = SingletonClass.getInstance;
			singletonClassOne.writeStr();
			singletonClassOne.readStr();

			SingletonClass singletonClassTwo = SingletonClass.getInstance;
			singletonClassTwo.writeStr("kehinde 4");

			singletonClassOne.writeStr("4");

			singletonClassOne.readStr();
			singletonClassTwo.readStr();

			Thread myThreadOne = new Thread(() => {
				SingletonClass singletonClassThree = SingletonClass.getInstance;
				singletonClassThree.writeStr("64");
				singletonClassThree.readStr();
			});
			myThreadOne.Start();

			Thread myThreadTwo = new Thread(() => {
				SingletonClass singletonClassFour = SingletonClass.getInstance;
				singletonClassFour.writeStr("21");
				singletonClassFour.readStr();
			});
			myThreadTwo.Start();

			Console.WriteLine(TDETask5.SingletonClass.count);
		}

	}
}
