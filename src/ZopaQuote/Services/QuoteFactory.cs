namespace ZopaQuote.Services
{
    using Model;

    internal class QuoteFactory : IQuoteFactory
    {
        public Quote Create(int requestAmount, int termMonths, decimal totalRepayment)
        {
	        var numberOfYears = termMonths / 12;

            var monthlyRepayment = totalRepayment / termMonths;
	        var rate = (totalRepayment - requestAmount) / numberOfYears / 100;

            return new Quote(requestAmount, rate, monthlyRepayment, totalRepayment);
        }
    }
}
