namespace ZopaQuote.Services
{
    using System;
    using System.Linq;
    using Model;

    /// <summary>
    /// Provides offer related functionality
    /// </summary>
    internal class OfferService : IOfferService
    {
        private readonly IOfferProvider _offerProvider;

        /// <summary>
        /// Provides offer related functionality
        /// </summary>
        /// <param name="offerProvider">Supplies the offer data</param>
        public OfferService(IOfferProvider offerProvider)
        {
            _offerProvider = offerProvider;
        }

        /// <summary>
        /// Retrieve the offer with the lowest rate and funds available
        /// </summary>
        /// <returns>The best offer</returns>
        public Offer GetBestOffer()
        {
            var offers = _offerProvider.GetAllOffers();

            var bestOffer = offers.Where(offer => offer.AmountAvailable > 0).Aggregate((o1, o2) => o1.Rate < o2.Rate ? o1 : o2);

            return bestOffer;
        }

        /// <summary>
        /// Retrieve the total amount of all available offers
        /// </summary>
        /// <returns>The total</returns>
        public int AmountAvailable()
        {
            return _offerProvider.GetAllOffers().Sum(offer => offer.AmountAvailable);
        }

        /// <summary>
        /// Reduce the amount available for an offer
        /// </summary>
        /// <param name="offer">The offer</param>
        /// <param name="amount">The amount to deduct</param>
        public void DeductAvailable(Offer offer, int amount)
        {
            if (amount > offer.AmountAvailable)
            {
                throw new InvalidOperationException("Can't deduct more than available");
            }

            offer.AmountAvailable -= amount;
        }
    }
}
