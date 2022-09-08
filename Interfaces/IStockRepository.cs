using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Interfaces
{
    public interface IStockRepository
    {
        public Task<int> BuyProduct(Product product);
        public Task<Int64> GetTotalStock();
        public Task<int> SellProduct(Product product);
        public Task<List<Product>> GetAllProduct();
    }
}
