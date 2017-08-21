namespace ZopaQuote.Services
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    internal static class ServiceRegistry
    {
        internal static IServiceProvider BuildContainer()
        {
            return new ServiceCollection()
                .AddSingleton<IQuoteService, QuoteService>()
                .AddSingleton<IOfferService, OfferService>()
                .AddSingleton<IOfferProvider, CsvOfferProvider>()
                .AddSingleton<IQuoteFormatter, QuoteFormatter>()
                .AddSingleton<IQuoteFactory, QuoteFactory>()
                .AddSingleton<IInterestCalculator, InterestCalculator>()
                .BuildServiceProvider();
        }
    }
}
