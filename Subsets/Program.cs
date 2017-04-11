using System;

namespace Subsets
{
	internal class Program
	{
		private static void Main()
		{
			var sbProcessor = new SubListProcessor();
			var result = sbProcessor.Process(new[] {1, 2, 3, 4, 5}, 4);
			Console.WriteLine(string.Join(",", result));
		}
	}
}
