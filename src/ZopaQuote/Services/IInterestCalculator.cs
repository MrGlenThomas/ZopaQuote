namespace ZopaQuote.Services
{
    internal interface IInterestCalculator
    {
        decimal CompoundInterest(decimal amount, decimal rate, int numberOfPayments);

	    decimal CalculateRate(decimal totalRepayment, decimal principalAmount, int numberOfPayments);
    }
}
