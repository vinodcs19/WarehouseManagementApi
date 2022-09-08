using System;
namespace warehouse.Management.System.Api.Models
{
    public class Product
    {
       
        public Guid?   Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
