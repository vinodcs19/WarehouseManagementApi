using System;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Dto.RequestDto
{
    public class ProductSellRequestDto
    {
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
