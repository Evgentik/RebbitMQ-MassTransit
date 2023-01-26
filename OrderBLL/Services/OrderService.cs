using GeneralModels.DTOs;
using MassTransit;
using MassTransit.Transports;
using OrderBLL.Models;
using RebbitContracts.Models.Requests;
using RebbitContracts.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetByIdAsync(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new List<Order>()
        {
            new Order() { Id = 1, DateTime = new DateTime (2021, 10, 15), ProductId = 1, UserId = 1},
            new Order() { Id = 2, DateTime = new DateTime (2021, 09, 11), ProductId = 3, UserId = 2},
            new Order() { Id = 3, DateTime = new DateTime (2021, 11, 05), ProductId = 4, UserId = 2},
            new Order() { Id = 4, DateTime = new DateTime (2021, 06, 21), ProductId = 2, UserId = 1},
        };
        private readonly IRequestClient<ProductRequest> _requestClient;
        public OrderService(IRequestClient<ProductRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            try
            {
                var order = _orders.FirstOrDefault(x => x.Id == id);
                var producResponse = (await _requestClient.GetResponse<ProductResponse>(new ProductRequest() { Id = order.ProductId })).Message;

                var product = new ProductDTO()
                {
                    Id = producResponse.Id,
                    Company = producResponse.Company,
                    Name = producResponse.Name,
                    Price = producResponse.Price
                };

                var result = new OrderDTO()
                {
                    Id = order.Id,
                    DateTime = order.DateTime,
                    Product = product
                };

                return result;
            }
            catch (Exception ex) 
            {
                return null;
            }
            
        }
    }
}
