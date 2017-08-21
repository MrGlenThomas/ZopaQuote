namespace ZopaQuote.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Model;
    using NSubstitute;
    using Services;
    using Xunit;

    public class OfferServiceTests
    {
        public class GetBestOfferTests
        {
            [Fact]
            public void ReturnsOfferWithLowestRate()
            {
                var expectedBestOffer = new Offer("Tim", 0.0001m, 15);

                var offers = new[] 
                {
                    new Offer("Bob", 0.23m, 345),
                    new Offer("Alice", 0.05m, 5000),
                    expectedBestOffer
                };

                var offerProvider = Substitute.For<IOfferProvider>();
                offerProvider.GetAllOffers().Returns(offers);

                var offerService = new OfferService(offerProvider);

                var actualBestOffer = offerService.GetBestOffer();

                Assert.Equal(expectedBestOffer, actualBestOffer);
            }

            [Fact]
            public void DoesntReturnOffersWithNoFundsAvailable()
            {
                var excpectedBestOffer = new Offer("Jeff", 0.003m, 642);

                var offers = new[]
                {
                    new Offer("Bob", 0.23m, 345),
                    new Offer("Alice", 0.05m, 0),
                    new Offer("Tim", 0.0001m, 15),
                    new Offer("Henry", 0.0541m, 0),
                    excpectedBestOffer
                };

                var offerProvider = Substitute.For<IOfferProvider>();
                offerProvider.GetAllOffers().Returns(offers);

                var offerService = new OfferService(offerProvider);

                var actualBestOffer = offerService.GetBestOffer();

                Assert.Equal(excpectedBestOffer, actualBestOffer);
            }
        }

        public class AmountAvailableTests
        {
            public static IEnumerable<object[]> CalculatesSumData()
            {
                var bob = new Offer("Bob", 0.23m, 345);
                var alice = new Offer("Alice", 0.05m, 55);
                var tim = new Offer("Tim", 0.0001m, 15);
                var henry = new Offer("Henry", 0.0541m, 25);

                yield return new object[] { new[] { bob, alice, tim, henry}, 440 };
                yield return new object[] { new[] { bob, tim, henry }, 385 };
                yield return new object[] { new[] { alice, tim }, 70 };
            }

            [Theory]
            [MemberData(nameof(CalculatesSumData))]
            public void CalculatesSum(IEnumerable<Offer> offers, int expectedTotal)
            {
                var offerProvider = Substitute.For<IOfferProvider>();
                offerProvider.GetAllOffers().Returns(offers);

                var offerService = new OfferService(offerProvider);

                var actualTotal = offerService.AmountAvailable();

                Assert.Equal(expectedTotal, actualTotal);
            }
        }

        public class DeductAvailableTests
        {
            [Fact]
            public void AmountGreaterThanAvailableThrowsException()
            {
                var offer = new Offer("Dave", 234m, 10);
                var deductAmount = 11;

                var offerProvider = Substitute.For<IOfferProvider>();
                var offerService = new OfferService(offerProvider);

                Assert.Throws<InvalidOperationException>(() => offerService.DeductAvailable(offer, deductAmount));
            }

            [Fact]
            public void ReducesAvailableAmount()
            {
                var offer = new Offer("Dave", 234m, 10);
                var deductAmount = 5;

                var offerProvider = Substitute.For<IOfferProvider>();
                var offerService = new OfferService(offerProvider);

                offerService.DeductAvailable(offer, deductAmount);

                Assert.Equal(5, offer.AmountAvailable);
            }
        }
    }
}
