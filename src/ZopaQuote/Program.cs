using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ZopaQuote.UnitTests")]

namespace ZopaQuote
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildContainer();

            try
            {
                if (args.Length < 2)
                {
                    throw new ArgumentException("Not enough parameters");
                }

                var offersFilePath = args[0];
                int requestAmount;
                if (!int.TryParse(args[1], out requestAmount))
                {
                    throw new ArgumentException("Invalid request amount");
                }

                var offersProvider = serviceProvider.GetService<IOfferProvider>();
                offersProvider.LoadOffers(offersFilePath);

                var quoteService = serviceProvider.GetService<IQuoteService>();

                var quote = quoteService.GetQuote(requestAmount);

                var quoteFormatter = serviceProvider.GetService<IQuoteFormatter>();
                Console.WriteLine(quoteFormatter.Format(quote));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error retrieving quote: {exception.Message}");
            }

            Console.ReadKey();
        }

        private static IServiceProvider BuildContainer()
        {
            return new ServiceCollection()
                .AddSingleton<IQuoteService, QuoteService>()
                .AddSingleton<IOfferService, OfferService>()
                .AddSingleton<IOfferProvider, CsvOfferProvider>()
                .AddSingleton<IQuoteFormatter, QuoteFormatter>()
                .BuildServiceProvider();
        }
    }
}