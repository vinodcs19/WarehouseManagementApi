using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using warehouse.Management.System.Api.DBContexts;
using warehouse.Management.System.Api.Interfaces;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.DbRepository
{
    public class StockRepository:IStockRepository
    {
        private readonly StockContext _context;
        private readonly ILogger<StockRepository> _logger;
        public StockRepository(StockContext context, ILogger<StockRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> BuyProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(Product));

            var existingProduct = _context.Products.Where(x => x.Id == product.Id).SingleOrDefault();
              if (existingProduct != null)
               {
                  existingProduct.Quantity += product.Quantity;
                  existingProduct.Price += product.Quantity * product.Price;
                 _context.Products.Update(existingProduct);

            }

         else { 

                 product.Id = product.Id ?? Guid.NewGuid();
                 product.Price = product.Quantity * product.Price;

                  await _context.Products.AddAsync(product);
              }

            return await _context.SaveChangesAsync();
           

        }

        public async Task<List<Product>> GetAllProduct()
        {

            var productList = await _context.Products.ToListAsync();

            return productList;


        }

        public async Task<Int64> GetTotalStock()
        {

            var product =  await _context.Products.ToListAsync();
            var totalStock = product.Sum(x => x.Quantity);


            return await Task.FromResult(totalStock);
        }

        public async Task<int> SellProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(Product));

            var existingProduct = _context.Products.Where(x => x.Id == product.Id && x.Quantity >= product.Quantity ).SingleOrDefault();
            if (existingProduct != null)
            {
                existingProduct.Quantity -= product.Quantity;
                existingProduct.Price -= product.Quantity * product.Price;
                 _context.Products.Update(existingProduct);
                 var result = await _context.SaveChangesAsync();
                return result;
            }
            return 0;
         

        }

    }
}
