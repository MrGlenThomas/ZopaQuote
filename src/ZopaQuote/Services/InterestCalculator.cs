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

		/// <summary>
		/// rate = n[(A/P)^(1/(nt)) - 1]
		/// </summary>
		/// <param name="totalRepayment"></param>
		/// <param name="principalAmount"></param>
		/// <param name="numberOfPayments"></param>
		/// <returns></returns>
		public decimal CalculateRate(decimal totalRepayment, decimal principalAmount, int numberOfPayments)
		{
			var numberOfYears = numberOfPayments / PaymentsPerYear;

			var rate = PaymentsPerYear * ((decimal) Math.Pow((double) (totalRepayment / principalAmount), 1.0 / (PaymentsPerYear * numberOfYears)) - 1);

			return rate;
		}
	}
}
