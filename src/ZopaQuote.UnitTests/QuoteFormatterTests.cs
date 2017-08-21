namespace ZopaQuote.UnitTests
{
    using System.Collections;
    using System.Collections.Generic;
    using Model;
    using Services;
    using Xunit;

    public class QuoteFormatterTests
    {
        [Theory]
        public void FormatterCreatesExpectedString(Quote quote, string expectedOutput)
        {
            var quoteFormatter = new QuoteFormatter();
            var output = quoteFormatter.Format(quote);

            Assert.Equal(expectedOutput, output);
        }
    }

    internal class FormatterTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Quote(1000, 0.28397m, 97.8177m, 3521.440m), "Requested amount: £1000\r\nRate: 0.3%\r\nMonthly repayment: £97.82\r\nTotal repayment: £3521.44" },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
