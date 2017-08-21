namespace ZopaQuote.Services
{
    internal interface IInterestCalculator
    {
        decimal GetInterest(decimal amount, decimal rate, int numberOfPayments);
    }
}
