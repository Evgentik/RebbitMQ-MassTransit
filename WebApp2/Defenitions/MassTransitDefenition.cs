using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebbitContracts.Configurations;
using RebbitContracts.Defenitions;
using System;
using System.Collections.Generic;
using WebApp2.Consumers;
using static WebApp2.Consumers.ProductConsumer;

namespace WebApp.Defenitions
{
    public class MassTransitDefenition
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var consumers = new Dictionary<Type, Type>()
            {
                { typeof(ProductConsumer), typeof(ProductConsumerDefenition) }
            };

            var massTransitSettings = configuration.GetSection(nameof(MassTransitConfig)).Get<MassTransitConfig>();
            ConfigureServicesMassTransit.ConfigureServices(services, massTransitSettings, consumers: consumers);            
        }
    }
}
