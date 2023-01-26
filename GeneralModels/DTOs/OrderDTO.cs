using System;

namespace GeneralModels.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        //public User User { get; set; }
        public ProductDTO Product { get; set; }
    }
}
