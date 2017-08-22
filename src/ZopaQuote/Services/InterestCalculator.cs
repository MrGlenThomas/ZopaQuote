namespace ZopaQuote.Services
{
	using System;

	internal class InterestCalculator : IInterestCalculator
	{
		private const int PaymentsPerYear = 12;

		/// <summary>
		/// Calculates repayment amount with compound interest added
		/// finalTotal = principal * (1 + interestRate / periodsPerYear) ^ periodsPerYear * years
		/// </summary>
		/// <param name="principal"></param>
		/// <param name="rate"></param>
		/// <param name="numberOfPayments"></param>
		/// <returns></returns>
		public decimal CompoundInterest(decimal principal, decimal rate, int numberOfPayments)
	    {
		    var numberOfYears = numberOfPayments / PaymentsPerYear;

			return principal * (decimal)Math.Pow((double)(1 + rate / PaymentsPerYear), PaymentsPerYear * numberOfYears);
		}
    }
}
