using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSumClass
{
	static class Extensions
	{
		public static ulong Sum(this IEnumerable<ulong> array)
		{
			ulong sum = 0;
			foreach (ulong item in array)
			{
				sum += item;
			}

			return sum;
		}
	}
}
