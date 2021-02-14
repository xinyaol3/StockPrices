using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StockPrices.Data
{
    public class Stock
    {
        public string Id { get; set; }
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }

        public static StockList std = new StockList();
        public Stock()
        {
            if (Id == null)
                Id = Guid.NewGuid().ToString();
        }

        public Stock(string ticker, string fullName, double price)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Ticker = ticker;
            this.FullName = fullName;
            this.Price = price;
        }

        public static List<Stock> GetSampleStockData()
        {
           // Console.WriteLine(std.stocklist.Count);
            
            return std.stocklist;
        }
        public static void Addnew(Stock stock)
        {
            GetSampleStockData().Add(stock);
  
        }
    }
}
