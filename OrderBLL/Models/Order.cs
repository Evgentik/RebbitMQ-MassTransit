using System;

namespace OrderBLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
