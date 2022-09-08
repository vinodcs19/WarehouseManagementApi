using System;
using FluentValidation;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Dto.RequestDto
{
    public class ProductSellRequestDto
    {
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
    public class ProductSellRequestValidator : AbstractValidator<ProductSellRequestDto>
    {
        public ProductSellRequestValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
        }
    }
}
