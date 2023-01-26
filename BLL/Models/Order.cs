using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
