namespace ZopaQuote.Services
{
    using Model;

    /// <summary>
    /// Formats quotes to string for console output
    /// </summary>
    internal interface IQuoteFormatter
    {
        /// <summary>
        /// Get console string format for quote
        /// </summary>
        string Format(Quote quote);
    }
}
