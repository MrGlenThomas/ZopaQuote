namespace ZopaQuote.Services
{
    internal interface IInterestCalculator
    {
        decimal CompoundInterest(decimal amount, decimal rate, int numberOfPayments);
    }
}
