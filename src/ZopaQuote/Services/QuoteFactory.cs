namespace ZopaQuote.Services
{
    using Model;

    internal class QuoteFactory : IQuoteFactory
    {
	    private readonly IInterestCalculator _interestCalculator;

	    public QuoteFactory(IInterestCalculator interestCalculator)
	    {
		    _interestCalculator = interestCalculator;
	    }

        public Quote Create(int requestAmount, int termMonths, decimal totalRepayment)
        {
            var monthlyRepayment = totalRepayment / termMonths;
	        var rate = _interestCalculator.CalculateRate(totalRepayment, requestAmount, termMonths);

            return new Quote(requestAmount, rate, monthlyRepayment, totalRepayment);
        }
    }
}
