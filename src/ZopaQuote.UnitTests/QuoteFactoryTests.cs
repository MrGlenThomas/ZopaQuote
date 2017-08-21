namespace ZopaQuote.UnitTests
{
    using Services;
    using Xunit;

    public class QuoteFactoryTests
    {
        [Theory]
        [InlineData(1000, 30, 400, "46.666666666666666666666666667", "0.7142857142857142857142857143", "1400")]
        [InlineData(2600, 21, 680, "156.19047619047619047619047619", "0.7926829268292682926829268293", "3280")]
        public void CreatesQuoteWithCorrectData(int requestAmount, int termMonths, decimal interest,
            string monthlyRepayment, string rate, string totalRepayment)
        {
            var expectedMonthlyRepayment = decimal.Parse(monthlyRepayment);
            var expectedRate = decimal.Parse(rate);
            var expectedTotalRepayment = decimal.Parse(totalRepayment);

            var quoteFactory = new QuoteFactory();

            var quote = quoteFactory.Create(requestAmount, termMonths, interest);

            Assert.Equal(requestAmount, quote.RequestedAmount);
            Assert.Equal(expectedMonthlyRepayment, quote.MonthlyRepayment);
            Assert.Equal(expectedRate, quote.Rate);
            Assert.Equal(expectedTotalRepayment, quote.TotalRepayment);
        }
    }
}
