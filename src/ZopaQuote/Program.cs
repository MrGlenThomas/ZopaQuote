using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ZopaQuote.UnitTests")]
[assembly: InternalsVisibleTo("ZopaQuote.IntegrationTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace ZopaQuote
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ServiceRegistry.BuildContainer();

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
    }
}