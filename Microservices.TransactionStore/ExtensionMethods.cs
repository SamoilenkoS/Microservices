using System;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microservices.TransactionStore
{
  public static class ExtensionMethods
  {
    public static IBusControl RegisterRabbitMq(this IServiceProvider serviceProvider, BusOptions options)
    {
      return Bus.Factory.CreateUsingRabbitMq(bfc =>
      {
        bfc.Host(new Uri(options.Host), hostConfigurator =>
        {
          hostConfigurator.Username(options.Username);
          hostConfigurator.Password(options.Password);
        });

        bfc.ReceiveEndpoint(options.Queue, rec =>
        {
          rec.ConfigureConsumer(serviceProvider, typeof(MoneyTransactionConsumer));
        });

        bfc.OverrideDefaultBusEndpointQueueName(options.TemporaryQueue);
        //bfc.UseExtensionsLogging(serviceProvider.GetService<ILoggerFactory>());
      });
    }

    //public static IRestApiClient RestApiClient(string internalApiBaseUrl)
    //{
    //  var client = new RestApiClient(new RestApiClientSettings
    //  {
    //    BaseUrl = new Uri(internalApiBaseUrl)
    //  });

    //  return client;
    //}
  }
}
