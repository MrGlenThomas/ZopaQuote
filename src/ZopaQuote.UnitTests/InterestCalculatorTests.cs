namespace ZopaQuote.UnitTests
{
    using Services;
    using Xunit;

    public class InterestCalculatorTests
    {
        [Theory]
        [InlineData(2000, 0.5, 10, 10000)]
        public void GetInterestCalculates(decimal amount, decimal rate, int numberOfPayments, decimal expectedInterest)
        {
            var interestCalculator = new InterestCalculator();

            var actualInterest = interestCalculator.GetInterest(amount, rate, numberOfPayments);

            Assert.Equal(expectedInterest, actualInterest);
        }
    }
}
