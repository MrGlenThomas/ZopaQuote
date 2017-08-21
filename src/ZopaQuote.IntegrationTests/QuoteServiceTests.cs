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
            [InlineData(1000, "63.737777777777777777777777778", "0.4358134021337424168468028729", "2294.560")]
            [InlineData(1400, "98.98888888888888888888888889", "0.3928611516444045347401504097", "3563.600")]
            [InlineData(2100, "132.63333333333333333333333333", "0.439808997235486303091228952", "4774.800")]
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
