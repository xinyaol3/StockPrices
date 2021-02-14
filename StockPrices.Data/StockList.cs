using System;
using System.Collections.Generic;
using System.Text;

namespace StockPrices.Data
{
    public class StockList
    {
        public List<Stock> stocklist { get; set; }
        public StockList()
        {
            stocklist = new List<Stock>();
            stocklist.Add(
                new Stock
                {
                    Ticker = "MSFT",
                    FullName = "Microsoft",
                    Price = 108.06
                }
            );
            stocklist.Add(
                new Stock
                {
                    Ticker = "AAPL",
                    FullName = "Apple",
                    Price = 105.01
                });
            stocklist.Add(
                new Stock
                {
                    Ticker = "GOOG",
                    FullName = "Google",
                    Price = 101.14
                });
        }
    }
}
