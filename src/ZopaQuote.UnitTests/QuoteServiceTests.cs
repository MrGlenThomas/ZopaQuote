namespace ZopaQuote.UnitTests
{
    using System;
    using NSubstitute;
    using Services;
    using Xunit;

    public class QuoteServiceTests
    {
        public class GetQuoteTests
        {
            [Fact]
            public void AmountLessThan1000ThrowsArgumentException()
            {
                var offerService = Substitute.For<IOfferService>();

                var quoteService = new QuoteService(offerService);

                Assert.Throws<ArgumentException>("requestAmount", () => quoteService.GetQuote(100));
            }

            [Fact]
            public void AmountGreaterThan15000ThrowsArgumentException()
            {
                var offerService = Substitute.For<IOfferService>();

                var quoteService = new QuoteService(offerService);

                Assert.Throws<ArgumentException>("requestAmount", () => quoteService.GetQuote(16000));
            }

            [Fact]
            public void AmountNotMultipleOf100ThrowsArgumentException()
            {
                var offerService = Substitute.For<IOfferService>();

                var quoteService = new QuoteService(offerService);

                Assert.Throws<ArgumentException>("requestAmount", () => quoteService.GetQuote(2550));
            }
        }
    }
}
