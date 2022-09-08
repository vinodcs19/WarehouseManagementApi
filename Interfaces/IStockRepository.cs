using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Interfaces
{
    public interface IStockRepository
    {
        public Task BuyProduct(Product product);
        public Task<double> GetTotalStock();
        public Task SellProduct(Product product);
        public Task<List<Product>> GetAllProduct();
    }
}
