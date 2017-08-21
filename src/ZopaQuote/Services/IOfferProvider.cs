namespace ZopaQuote.Services
{
    using System.Collections.Generic;
    using Model;

    /// <summary>
    /// Provides offers from storage
    /// </summary>
    internal interface IOfferProvider
    {
        /// <summary>
        /// Load a file of offer data
        /// </summary>
        /// <param name="filePath">The path to the file containing offer data</param>
        void LoadOffers(string filePath);

        /// <summary>
        /// Get all available offers
        /// </summary>
        /// <returns></returns>
        IEnumerable<Offer> GetAllOffers();
    }
}
