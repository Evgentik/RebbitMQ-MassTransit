using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebbitContracts.Configurations;
using RebbitContracts.Defenitions;
using System.Collections.Generic;
using System;
using WebApp3.Consumers;
using MassTransit;

namespace WebApp.Defenitions
{
    public class MassTransitDefenition
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var consumers = new Dictionary<Type, Type>()
            {
                //{ typeof(ProductConsumer), null }
                { typeof(ProductConsumer), typeof(ProductConsumerDefenition) }
            };

            var massTransitSettings = configuration.GetSection(nameof(MassTransitConfig)).Get<MassTransitConfig>();
            ConfigureServicesMassTransit.ConfigureServices(services, massTransitSettings, consumers: consumers);            
        }
    }
}
