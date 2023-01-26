using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrderByIdAsync(int id);
    }
}
