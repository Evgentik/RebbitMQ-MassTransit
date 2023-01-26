using GeneralModels.DTOs;
using System.Collections.Generic;
using System.Linq;
namespace ProductBLL.Services
{
    public interface IProductService
    {
        ProductDTO GetById(int id);
    }

    public class ProductService : IProductService
    {
        private readonly List<ProductDTO> _products = new List<ProductDTO>()
            {
                new ProductDTO() { Id =1, Company = "test1", Name = "test1", Price = 100 },
                new ProductDTO() { Id =2, Company = "test2", Name = "test2", Price = 200 },
                new ProductDTO() { Id =3, Company = "test3", Name = "test3", Price = 300 },
                new ProductDTO() { Id =4, Company = "test4", Name = "test4", Price = 400 },
                new ProductDTO() { Id =5, Company = "test5", Name = "test5", Price = 500 }
            };

        public ProductDTO GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }
    }
}
