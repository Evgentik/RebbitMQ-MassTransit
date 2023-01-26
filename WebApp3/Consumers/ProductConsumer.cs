using MassTransit;
using RebbitContracts.Models.Requests;
using System.Threading.Tasks;
using RebbitContracts.Models.Responses;
using RebbitContracts.Queues;
using Microsoft.Extensions.Logging;

namespace WebApp3.Consumers
{
    public class ProductConsumer : IConsumer<ProductRequest>
    {
        private readonly ILogger<ProductConsumer> _logger;
        public ProductConsumer(ILogger<ProductConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<ProductRequest> context)
        {
            var id = context.Message.Id;
            _logger.LogInformation($"Get Request for ProductID: {id}");
            //await context.RespondAsync(new ProductResponse());
        }
    }

    public class ProductConsumerDefenition : ConsumerDefinition<ProductConsumer>
    {
        public ProductConsumerDefenition()
        {
            EndpointName = Queues.LoggerServece;
        }
    }
}
