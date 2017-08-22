namespace ZopaQuote.UnitTests
{
    using Services;
    using Xunit;

    public class InterestCalculatorTests
    {
        [Theory]
		[InlineData(1000, 0.06, 36, 1196.68)]
		public void GetInterestCalculates(decimal amount, decimal rate, int numberOfPayments, decimal expectedTotalRepayment)
        {
            var interestCalculator = new InterestCalculator();

            var actualTotalRepayment = interestCalculator.CompoundInterest(amount, rate, numberOfPayments);

            Assert.Equal(expectedTotalRepayment, actualTotalRepayment);
        }
    }
}
