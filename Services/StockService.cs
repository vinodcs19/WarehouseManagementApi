using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using warehouse.Management.System.Api.Dto.RequestDto;
using warehouse.Management.System.Api.Interfaces;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Services
{

    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly ILogger<StockService> _logger;

        public StockService(IStockRepository stockRepository, ILogger<StockService> logger)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Boolean> SellStock(ProductSellRequestDto product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(ProductSellRequestDto));
            var sellProduct = new Product()
            {
                Id = product.ProductId,
                Price = product.Price,
                Quantity = product.Quantity,
            };

           var result = await _stockRepository.SellProduct(sellProduct);

            return result != 0 ? true : false;
            

        }

        public async Task<Boolean> BuyStock(ProductBuyRequestDto product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(ProductSellRequestDto));
            var sellProduct = new Product()
            {
                Id = product.ProductId,
                Price = product.Price,
                Quantity = product.Quantity,
                Code = product.Code,
                Name = product.ProductName,
                Title = product.ProductTitle
            };

           var result = await _stockRepository.BuyProduct(sellProduct);
            return result != 0 ? true : false;

        }

        public async Task<Int64> GetTotalStock()
        {
             var totalStock = await _stockRepository.GetTotalStock();
            return totalStock;
        }

        public async Task<List<Product>> GetProductList()
        {
            var productList = await _stockRepository.GetAllProduct();
            return productList;
        }

       
    }
}