namespace ZopaQuote.Services
{
    using System.Globalization;
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

            //TODO: is there a way to display '£' character in console? Consolas font appears to support it, but is not working..!
            var enCulture = new CultureInfo("en-GB");
            var pound = '\u00A3';

            output.AppendLine($"Requested amount: £{quote.RequestedAmount}");
            output.AppendLine($"Rate: {quote.Rate:0.0}%");
            output.AppendLine($"Monthly repayment: £{quote.MonthlyRepayment:0.00}");
            output.AppendLine($"Total repayment: £{quote.TotalRepayment:0.00}");

            return output.ToString();
        }
    }
}
