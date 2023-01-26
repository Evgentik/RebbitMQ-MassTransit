using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RebbitContracts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RebbitContracts.Defenitions
{
    public class ConfigureServicesMassTransit
    {
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services, MassTransitConfig massTransitSettings, Dictionary<Type, Type> consumers = null, List<Type> requestTypes = null)
        {
            if (massTransitSettings == null || massTransitSettings.Url == null || massTransitSettings.VirtualHost == null)
            {
                throw new Exception("Section 'mass-transit' configuration settings are not found in appSettings.json");
            }
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(massTransitSettings.Url, massTransitSettings.VirtualHost, h =>
                    {
                        h.Username(massTransitSettings.UserName);
                        h.Password(massTransitSettings.Password);
                    });

                    //cfg.ClearMessageDeserializers();
                    //cfg.UseRawJsonSerializer();
                    //cfg.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);
                    cfg.ConfigureEndpoints(context);
                });

                if(consumers != null && consumers.Count>0)
                {
                    var keys = consumers.Keys.ToList();
                    keys.ForEach(consumer => 
                    {
                        if(consumers.TryGetValue(consumer, out var value) && value != null)
                        {
                            x.AddConsumer(consumer, value);
                        }
                        else
                        {
                            x.AddConsumer(consumer);
                        }                        
                    });
                }

                if (requestTypes != null && requestTypes.Count>0)
                {
                    requestTypes.ForEach(type => x.AddRequestClient(type));
                }
            });

            var httpClient = new HttpClient();
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{massTransitSettings.UserName}:{massTransitSettings.Password}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            var response = httpClient.PutAsync($"http://{massTransitSettings.Url}:{massTransitSettings.Port}/api/vhosts/{massTransitSettings.VirtualHost}", null);
        }
    }

    

    
}
