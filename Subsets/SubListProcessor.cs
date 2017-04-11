using System.Collections.Generic;
using System.Linq;

namespace Subsets
{
	public class SubListProcessor
	{
		public IEnumerable<int> Process(IEnumerable<int> input, int divisor)
		{
			var inputArray = input.ToArray();
			for (var i = (1 << inputArray.Length); --i != 0;)
			{
				var sublist = BitCombinations(i).Select(n => inputArray[n]).ToArray();
				if (sublist.Length > 1 && IsValidList(sublist, divisor)) return sublist;
			}
			return Enumerable.Empty<int>();
		}

		private static IEnumerable<int> BitCombinations(int number)
		{
			for (var i = 0; number != 0; number /= 2, i++)
				if ((number & 1) != 0) yield return i;
		}

		private static bool IsValidList(IReadOnlyCollection<int> input, int divisor)
		{
			return
				input.Count > 1 &&
				(from i in input
					from j in input
					where i < j
					select new {i, j}).All(x => (x.i + x.j) % divisor == 0);
		}
	}
}
