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
        [ClassData(typeof(FormatterTestData))]
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
            new object[] { new Quote(1000, 0.09m, 80m, 3500m), "Requested amount: £1000\r\nRate: 9.0%\r\nMonthly repayment: £80.00\r\nTotal repayment: £3500.00\r\n" },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
