using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using warehouse.Management.System.Api.Dto.RequestDto;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Interfaces
{
    public interface IStockService
    {
        public  Task<Int64> GetTotalStock();
        public  Task<Boolean> SellStock(ProductSellRequestDto product);
        public  Task<Boolean> BuyStock(ProductBuyRequestDto product);
        public  Task <List<Product>>GetProductList();

    }
}
