using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.DBContexts
{
    public class StockContext: DbContext
    {
        public StockContext(DbContextOptions<StockContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
