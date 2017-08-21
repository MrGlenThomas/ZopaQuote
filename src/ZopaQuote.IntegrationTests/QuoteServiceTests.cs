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
            [InlineData(1000, "97.81777777777777777777777778", "0.2839747376073424508155754464", "3521.440")]
            [InlineData(1400, "138.54888888888888888888888889", "0.2806871220748392063772114135", "4987.760")]
            [InlineData(2100, "212.05333333333333333333333333", "0.2750880281690140845070422535", "7633.920")]
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
