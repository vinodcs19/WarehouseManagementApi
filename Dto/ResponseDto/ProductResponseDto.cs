using System;
namespace warehouse.Management.System.Api.Dto.ResponseDto
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
    }
}
