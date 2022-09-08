using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using warehouse.Management.System.Api.Dto.RequestDto;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Interfaces
{
    public interface IStockService
    {
        public  Task<double> GetStockBanlance();
        public  Task SellStock(ProductSellRequestDto product);
        public  Task BuyStock(ProductBuyRequestDto product);
        public  Task <List<Product>>GetProductList();

    }
}
