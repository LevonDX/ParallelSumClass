using ParallelSumClass;

namespace TestProject
{
	public class TestParallelCalc
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void TestSum()
		{
			// Init
			ParallelSum sumDiv = new ParallelSum(5, 1000);
			ParallelSum sumNotDiv = new ParallelSum(7, 1000);

			// Action
			long divResult = sumDiv.Calc();
			long sumNotDivResult = sumNotDiv.Calc();

			// Assert
			Assert.That(divResult == 500500, $"result is {divResult}");
			Assert.That(sumNotDivResult == 500500, $"result is {sumNotDivResult}");
		}
	}
}