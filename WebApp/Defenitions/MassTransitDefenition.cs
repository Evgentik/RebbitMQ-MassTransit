using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebbitContracts.Configurations;
using RebbitContracts.Defenitions;
using RebbitContracts.Models.Requests;
using System;
using System.Collections.Generic;

namespace WebApp.Defenitions
{
    public class MassTransitDefenition
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var requestTypes = new List<Type>()
            {
                typeof(ProductRequest)
            };

            var massTransitSettings = configuration.GetSection(nameof(MassTransitConfig)).Get<MassTransitConfig>();
            ConfigureServicesMassTransit.ConfigureServices(services, massTransitSettings, requestTypes: requestTypes);            
        }
    }
}
