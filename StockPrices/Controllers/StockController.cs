using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StockPrices.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockPrices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // GET: api/<StockController>
        [HttpGet]
        public JsonResult Get()
        {
            var data = Stock.GetSampleStockData();
            //var x = JsonSerializer.Serialize(data);
            return new JsonResult(data);
            //return data;
        }

        // GET api/<StockController>/5
        [HttpGet("{ticker}")]
        public Stock? Get(string ticker)
        {
            var data = Stock.GetSampleStockData().AsQueryable()
                .FirstOrDefault(x => x.Ticker.ToLower() == ticker.ToLower());
            return data;
        }
        [HttpPost("AddStock/{ticker}/{fullName}/{price}")]
        public void Post(string ticker,string fullName,double price)
        {
            Stock stock = new Stock();
            stock.Ticker = ticker;
            stock.FullName = fullName;
            stock.Price = price;
            Stock.Addnew(stock);
        }
    }
}
