using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StockPrices.Data;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace StockPrices.WebUI.Controllers
{
    public class StockController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public StockController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "Stock");
            var client = _clientFactory.CreateClient("stockapi");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var stocks = JsonConvert.DeserializeObject<List<Stock>>(responseString);
                return View(stocks);
            }

            return View(new List<Stock>());
        }

        public async Task<IActionResult> Details(string ticker)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"Stock/{ticker}");
            var client = _clientFactory.CreateClient("stockapi");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var stock = JsonConvert.DeserializeObject<Stock>(responseString);
                return View(stock);
            }

            return View(new Stock());
        }
    }
}
