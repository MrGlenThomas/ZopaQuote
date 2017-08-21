namespace ZopaQuote.Services
{
    using Model;

    internal interface IQuoteFactory
    {
        Quote Create(int requestAmount, int termMonths, decimal interest);
    }
}
