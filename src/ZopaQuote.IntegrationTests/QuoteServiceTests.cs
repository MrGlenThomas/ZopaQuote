namespace ZopaQuote.IntegrationTests
{
    using System.IO;
    using Services;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class QuoteServiceTests
    {
        public class GetQuoteTests
        {
            [Theory]
            [InlineData(1000, "34.252167010380288888888888889", "0.07004144744028", "1233.07801237369040")]
            [InlineData(1400, "48.117905750362494444444444444", "0.07119227985312", "1732.24460701304980")]
            [InlineData(2100, "72.61467196196005", "0.07322024876076", "2614.12819063056180")]
            public void CalculatesCorrectAmounts(int requestAmount, string monthlyRepayment, string rate, string totalRepayment)
            {
                var expectedMonthlyRepayment = decimal.Parse(monthlyRepayment);
                var expectedRate = decimal.Parse(rate);
                var expectedTotalRepayment = decimal.Parse(totalRepayment);

                var services = ServiceRegistry.BuildContainer();

                var csvPath = Path.GetFullPath("..\\..\\..\\..\\offers.csv");

                var offerProvider = services.GetService<IOfferProvider>();
                offerProvider.LoadOffers(csvPath);

                var quoteService = services.GetService<IQuoteService>();
                
                var quote = quoteService.GetQuote(requestAmount);

                Assert.Equal(requestAmount, quote.RequestedAmount);
                Assert.Equal(expectedMonthlyRepayment, quote.MonthlyRepayment);
                Assert.Equal(expectedRate, quote.Rate);
                Assert.Equal(expectedTotalRepayment, quote.TotalRepayment);
            }
        }
    }
}
