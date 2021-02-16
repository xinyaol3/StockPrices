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
        public async Task<IActionResult> Filter(string ticker)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "Stock");
            var client = _clientFactory.CreateClient("stockapi");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var stocks = JsonConvert.DeserializeObject<List<Stock>>(responseString);
                List<Stock> res = new List<Stock>();
                for (int i = 0; i < stocks.Count; i++)
                {
                    if (stocks[i].Ticker==ticker)
                    {
                        res.Add(stocks[i]);
                    }
                }
                return View(res);
            }
            return View(new List<Stock>());
        }
        public async void CreateNew(string ticker,string fullname,double price)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"Stock/AddStock/{ticker}/{fullname}/{price}");
            var client = _clientFactory.CreateClient("stockapi");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var stock = JsonConvert.DeserializeObject<List<Stock>>(responseString);
                Stock st = new Stock();
                st.Ticker = ticker;
                st.FullName = fullname;
                st.Price = price;
                stock.Add(st);
            }

        }
    }
}
