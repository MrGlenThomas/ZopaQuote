namespace ZopaQuote.UnitTests
{
	using NSubstitute;
	using Services;
    using Xunit;

    public class QuoteFactoryTests
    {
        [Theory]
        [InlineData(1000, 100, 1000, "20", "0.5")]
		[InlineData(1000, 30, 400, "46.666666666666666666666666667", "0.7142857142857142857142857143")]
        [InlineData(2600, 24, 3049.51, "32.380952380952380952380952381", "0.7926829268292682926829268293")]
        public void CreatesQuoteWithCorrectData(int requestAmount, int termMonths, decimal totalRepayment,
            string monthlyRepayment, string rate)
        {
            var expectedMonthlyRepayment = decimal.Parse(monthlyRepayment);
            var expectedRate = decimal.Parse(rate);

	        var interestCalculator = Substitute.For<IInterestCalculator>();
	        interestCalculator.CalculateRate(totalRepayment, requestAmount, termMonths).Returns(expectedRate);

            var quoteFactory = new QuoteFactory(interestCalculator);

            var quote = quoteFactory.Create(requestAmount, termMonths, totalRepayment);

            Assert.Equal(requestAmount, quote.RequestedAmount);
            Assert.Equal(expectedMonthlyRepayment, quote.MonthlyRepayment);
            Assert.Equal(expectedRate, quote.Rate);
            Assert.Equal(totalRepayment, quote.TotalRepayment);
        }
    }
}
