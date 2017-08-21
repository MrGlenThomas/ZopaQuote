namespace ZopaQuote.Services
{
    using Model;

    /// <summary>
    /// Provides offer related functionality
    /// </summary>
    internal interface IOfferService
    {
        /// <summary>
        /// Retrieve the offer with the lowest rate and funds available
        /// </summary>
        /// <returns>The best offer</returns>
        Offer GetBestOffer();

        /// <summary>
        /// Retrieve the total amount of all available offers
        /// </summary>
        /// <returns>The total</returns>
        int AmountAvailable();

        /// <summary>
        /// Reduce the amount available for an offer
        /// </summary>
        /// <param name="offer">The offer</param>
        /// <param name="amount">The amount to deduct</param>
        void DeductAvailable(Offer offer, int amount);
    }
}
