using MassTransit;
using RebbitContracts.Models.Requests;
using System.Threading.Tasks;
using RebbitContracts.Models.Responses;
using ProductBLL.Services;
using RebbitContracts.Queues;

namespace WebApp2.Consumers
{
    public class ProductConsumer : IConsumer<ProductRequest>
    {
        private readonly IProductService _productService;

        public ProductConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<ProductRequest> context)
        {
            var id = context.Message.Id;
            var product = _productService.GetById(id);
            var productResponse = new ProductResponse() { Id = product.Id, Company = product.Company, Name= product.Name, Price = product.Price };
            await context.RespondAsync(productResponse);
        }


        public class ProductConsumerDefenition : ConsumerDefinition<ProductConsumer>
        {
            public ProductConsumerDefenition()
            {
                EndpointName = Queues.ProductServece;
            }
        }
    }
}
