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
                var quoteFactory = Substitute.For<IQuoteFactory>();
                var interestCalculator = Substitute.For<IInterestCalculator>();

                var quoteService = new QuoteService(offerService, interestCalculator, quoteFactory);

                Assert.Throws<ArgumentException>("requestAmount", () => quoteService.GetQuote(100));
            }

            [Fact]
            public void AmountGreaterThan15000ThrowsArgumentException()
            {
                var offerService = Substitute.For<IOfferService>();
                var quoteFactory = Substitute.For<IQuoteFactory>();
                var interestCalculator = Substitute.For<IInterestCalculator>();

                var quoteService = new QuoteService(offerService, interestCalculator, quoteFactory);

                Assert.Throws<ArgumentException>("requestAmount", () => quoteService.GetQuote(16000));
            }

            [Fact]
            public void AmountNotMultipleOf100ThrowsArgumentException()
            {
                var offerService = Substitute.For<IOfferService>();
                var quoteFactory = Substitute.For<IQuoteFactory>();
                var interestCalculator = Substitute.For<IInterestCalculator>();

                var quoteService = new QuoteService(offerService, interestCalculator, quoteFactory);

                Assert.Throws<ArgumentException>("requestAmount", () => quoteService.GetQuote(2550));
            }

            [Fact]
            public void NotEnoughFundsThrowsInvalidOperationException()
            {
                var requestAmount = 1500;
                var amountAvailable = 1200;

                var offerService = Substitute.For<IOfferService>();
                offerService.AmountAvailable().Returns(amountAvailable);
                var quoteFactory = Substitute.For<IQuoteFactory>();
                var interestCalculator = Substitute.For<IInterestCalculator>();

                var quoteService = new QuoteService(offerService, interestCalculator, quoteFactory);

                Assert.Throws<InvalidOperationException>(() => quoteService.GetQuote(requestAmount));
            }
        }
    }
}
