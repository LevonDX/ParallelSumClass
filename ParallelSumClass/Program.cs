namespace ParallelSumClass
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ParallelSum parallelSum = new ParallelSum(10, (long)5E09);
			long result = parallelSum.Calc();

			Console.WriteLine($"result = {result}; time = {parallelSum.CalcTime}");
		}
	}
}
