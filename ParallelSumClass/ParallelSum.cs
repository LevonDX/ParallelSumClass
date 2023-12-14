using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSumClass
{
	public class ParallelSum
	{
		private int threadCount;
		private long max;
		private long[] partialSums;
		public long CalcTime { get; private set; }

		public ParallelSum(int threadCount, long max)
		{
			this.threadCount = threadCount;
			this.max = max;

			partialSums = new long[threadCount];
		}

		private void PartialSum(object? r)
		{
			Range? range = r as Range;
			if (range == null)
			{
				return;
			}

			long partialSum = 0;
			for (long i = range.Start + 1; i <= range.End; i++)
			{
				partialSum += i;
			}

			partialSums[range.Index] = partialSum;
		}

		public long Calc()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			Thread[] threads = new Thread[threadCount];
			long range = max / threadCount;

			for (int i = 0; i < threads.Length; i++)
			{
				// devide max to threadCount threads, considering that the last thread should take the rest of the division
				long start = i * range;
				long end = (i == threadCount - 1) ? max : (i + 1) * range;

				// This code is correct as well!!!
				//threads[i] = new Thread(() =>
				//{
				//	for (long j = start; j < end; j++)
				//	{
				//		partialSums[j] += j;
				//	}
				//});

				threads[i] = new Thread(PartialSum);
				threads[i].Name = $"Sum Thread {i}";
				threads[i].Start(new Range()
				{
					Start = start,
					End = end,
					Index = i
				});
			}

			foreach (Thread thread in threads)
			{
				thread.Join();
			}

			long result = partialSums.Sum();
			stopwatch.Stop();

			this.CalcTime = stopwatch.ElapsedMilliseconds;

			return partialSums.Sum();
		}

		private class Range
		{
			public long Start { get; set; }
			public long End { get; set; }
			public int Index { get; set; }
		}
	}
}