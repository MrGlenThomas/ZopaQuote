namespace ZopaQuote.Services
{
    using System;
    using Model;

    internal class QuoteService : IQuoteService
    {
        private readonly IOfferService _offerService;
        private readonly IInterestCalculator _interestCalculator;
        private readonly IQuoteFactory _quoteFactory;
        private const int LoanTermMonths = 36;

        public QuoteService(IOfferService offerService, IInterestCalculator interestCalculator, IQuoteFactory quoteFactory)
        {
            _offerService = offerService;
            _interestCalculator = interestCalculator;
            _quoteFactory = quoteFactory;
        }

        /// <summary>
        /// Process a loan request
        /// </summary>
        /// <param name="requestAmount">The desired loan amount</param>
        /// <returns>The quote</returns>
        public Quote GetQuote(int requestAmount)
        {
            if (requestAmount < 1000
                || requestAmount > 15000
                || requestAmount % 100 != 0)
            {
                throw new ArgumentException("Invalid loan amount", nameof(requestAmount));
            }

            if (_offerService.AmountAvailable() < requestAmount)
            {
                throw new InvalidOperationException("Not enough funds available!");
            }

            var amountToFulfill = requestAmount;
            decimal totalRepayment = 0;

            while (amountToFulfill > 0)
            {
                var bestOffer = _offerService.GetBestOffer();

                if (bestOffer.AmountAvailable < 1) continue;

                var amountUsed = bestOffer.AmountAvailable < amountToFulfill
                    ? bestOffer.AmountAvailable
                    : amountToFulfill;

                _offerService.DeductAvailable(bestOffer, amountUsed);

                var offerInterest = _interestCalculator.CompoundInterest(amountUsed, bestOffer.Rate, LoanTermMonths);
	            totalRepayment += offerInterest;

                amountToFulfill -= amountUsed;
            }

            var quote = _quoteFactory.Create(requestAmount, LoanTermMonths, totalRepayment);

            return quote;
        }
    }
}
