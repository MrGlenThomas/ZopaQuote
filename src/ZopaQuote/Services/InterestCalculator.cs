namespace ZopaQuote.Services
{
    internal class InterestCalculator : IInterestCalculator
    {
        public decimal GetInterest(decimal amount, decimal rate, int numberOfPayments)
        {
            return amount * rate * numberOfPayments;
        }
    }
}
