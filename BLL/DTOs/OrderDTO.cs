using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
