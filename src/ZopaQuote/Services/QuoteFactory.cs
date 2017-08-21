namespace ZopaQuote.Services
{
    using Model;

    internal class QuoteFactory : IQuoteFactory
    {
        public Quote Create(int requestAmount, int termMonths, decimal interest)
        {
            decimal totalRepayment = requestAmount + interest;
            decimal monthlyRepayment = totalRepayment / termMonths;
            var rate = requestAmount / totalRepayment;

            return new Quote(requestAmount, rate, monthlyRepayment, totalRepayment);
        }
    }
}
