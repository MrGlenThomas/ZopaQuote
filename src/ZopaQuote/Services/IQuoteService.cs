namespace ZopaQuote.Services
{
    using Model;

    internal interface IQuoteService
    {
        Quote GetQuote(int requestAmount);
    }
}
