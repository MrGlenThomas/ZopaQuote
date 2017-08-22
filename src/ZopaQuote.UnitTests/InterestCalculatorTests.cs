namespace ZopaQuote.UnitTests
{
    using Services;
    using Xunit;

    public class InterestCalculatorTests
    {
        [Theory]
		[InlineData(1000, 0.06, 36, 1196.68052482341000)]
		public void CompoundInterestCalculates(decimal amount, decimal rate, int numberOfPayments, decimal expectedTotalRepayment)
        {
            var interestCalculator = new InterestCalculator();

            var actualTotalRepayment = interestCalculator.CompoundInterest(amount, rate, numberOfPayments);

            Assert.Equal(expectedTotalRepayment, actualTotalRepayment);
        }

	    [Theory]
	    [InlineData(3049.51, 2600, 24, 0.08000022735552)]
	    [InlineData(2197.61, 1800, 48, 0.04999981276536)]
		public void GetInterestRateCalculates(decimal totalRepayment, decimal amount, int numberOfPayments, decimal expectedRate)
	    {
		    var interestCalculator = new InterestCalculator();

		    var actualRate = interestCalculator.CalculateRate(totalRepayment, amount, numberOfPayments);

		    Assert.Equal(expectedRate, actualRate);
	    }
	}
}
