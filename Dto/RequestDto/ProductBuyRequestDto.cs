using System;
using FluentValidation;

namespace warehouse.Management.System.Api.Dto.RequestDto
{
    public class ProductBuyRequestDto
    {
      
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductTitle { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductBuyRequestValidator : AbstractValidator<ProductBuyRequestDto>
    {
        public ProductBuyRequestValidator()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
        }
    }
}
