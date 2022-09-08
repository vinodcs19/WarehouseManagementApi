using System;
namespace warehouse.Management.System.Api.Dto.RequestDto
{
    public class ProductBuyRequestDto
    {
      
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
