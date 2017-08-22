namespace ZopaQuote.Services
{
    using System.Text;
    using Model;

    /// <summary>
    /// Format quotes to string for console output
    /// </summary>
    internal class QuoteFormatter : IQuoteFormatter
    {
        /// <summary>
        /// Get console string format for quote
        /// </summary>
        public string Format(Quote quote)
        {
            var output = new StringBuilder(90);

            output.AppendLine($"Requested amount: £{quote.RequestedAmount}");
            output.AppendLine($"Rate: {quote.Rate:P2}");
            output.AppendLine($"Monthly repayment: £{quote.MonthlyRepayment:0.00}");
            output.AppendLine($"Total repayment: £{quote.TotalRepayment:0.00}");

            return output.ToString();
        }
    }
}
