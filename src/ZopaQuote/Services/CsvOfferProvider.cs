namespace ZopaQuote.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Model;

    /// <summary>
    /// Provides offers from storage
    /// </summary>
    internal class CsvOfferProvider : IOfferProvider
    {
        private IEnumerable<Offer> _offers;

        /// <summary>
        /// Load a file of offer data
        /// </summary>
        /// <param name="filePath">The path to the file containing offer data</param>
        public void LoadOffers(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Offers file not found", filePath);
            }

            var offers = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(s => s.Split(','))
                .Select(s => new Offer(s[0], s[1], s[2]));

            // Cache offers to save repeated file access
            _offers = offers.ToList();
        }

        /// <summary>
        /// Get all available offers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Offer> GetAllOffers()
        {
            return _offers;
        }
    }
}
