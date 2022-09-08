using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using warehouse.Management.System.Api.Dto.RequestDto;
using warehouse.Management.System.Api.Interfaces;
using warehouse.Management.System.Api.Models;

namespace warehouse.Management.System.Api.Controllers
{


    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        ILogger<StockController> _logger = null;

        public StockController(IStockService stockService, ILogger<StockController> logger)
        {
            _stockService = stockService ?? throw new ArgumentNullException(nameof(stockService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        [HttpGet]
        [Route("totalstock")]

        public async Task<IActionResult> GetStock()
        {

            var stockBalance = await _stockService.GetTotalStock();
          

            _logger.LogInformation("Fetching stock balance");

            return Ok(  new { totalStock = stockBalance });
        }

        [HttpPost]
        [Route("sell")]
        public async Task<ActionResult<ProductSellRequestDto>> SellStock([FromBody] ProductSellRequestDto sellProduct)
        {
            var result = new ProductSellRequestValidator().Validate(sellProduct);
            if (result.IsValid)
            {
                var response = await _stockService.SellStock(sellProduct);
                if(response)
                    return Ok(new { message = "Stock sold sucessfully" });

                return BadRequest(new { message = $"Product not exist to sell with Product ID : {sellProduct.ProductId}." });

            }

            return BadRequest(result.Errors);


        }

        [HttpPost]
        [Route("buy")]
        public async Task<ActionResult<ProductBuyRequestDto>> BuyStock([FromBody] ProductBuyRequestDto buyProduct)
        {
            var result = new ProductBuyRequestValidator().Validate(buyProduct);
            if (result.IsValid)
            {
                var response =  await _stockService.BuyStock(buyProduct);
                if (response)
                    return Ok(new { message = $"Product bought sucessfully with Product Name : {buyProduct.ProductName}" });

                return BadRequest(new { message = $"Product not bought with Product Name : {buyProduct.ProductName}." });

            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("getallstock")]
        public async Task<ActionResult<List<Product>>> GelAllstockList()
        {
           var productList = await _stockService.GetProductList();

            _logger.LogInformation("Product featched sucessfully");

            return Ok( new { data = productList });

        }

    }
}
