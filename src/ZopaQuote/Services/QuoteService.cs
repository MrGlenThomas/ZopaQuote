namespace ZopaQuote.Services
{
    using System;
    using Model;

    internal class QuoteService : IQuoteService
    {
        private readonly IOfferService _offerService;
        private const int LoanTermMonths = 36;

        public QuoteService(IOfferService offerService)
        {
            _offerService = offerService;
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
            decimal totalInterest = 0;

            while (amountToFulfill > 0)
            {
                var bestOffer = _offerService.GetBestOffer();

                if (bestOffer.AmountAvailable < 1) continue;

                var amountUsed = bestOffer.AmountAvailable < amountToFulfill
                    ? bestOffer.AmountAvailable
                    : amountToFulfill;

                amountToFulfill -= amountUsed;
                _offerService.DeductAvailable(bestOffer, amountUsed);

                var offerInterest = LoanTermMonths * bestOffer.Rate * amountUsed;
                totalInterest += offerInterest;

                amountToFulfill -= bestOffer.AmountAvailable;
            }

            decimal totalRepayment = requestAmount + totalInterest;
            decimal monthlyRepayment = totalRepayment / LoanTermMonths;
            var rate = requestAmount / totalRepayment;

            return new Quote(requestAmount, rate, monthlyRepayment, totalRepayment);
        }
    }
}
