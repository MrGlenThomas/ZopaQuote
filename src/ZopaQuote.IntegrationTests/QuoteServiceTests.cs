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
            [InlineData(1000, "34.252167010380288888888888889", "0.6099398038254353587210365189", "1639.50605244677520")]
            [InlineData(1400, "68.332023816527966666666666667", "0.5691165974142060861569292177", "2459.95285739500680")]
            [InlineData(2100, "94.64651409345985555555555556", "0.6163283866506839474528540661", "3407.27450736455480")]
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
