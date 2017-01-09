using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerWindowApplication
{
    public class Feed
    {
        public string symbol;
        public string feedtime;
        public string expiry;
        public string callput;
        public string strike;        
        public string exch;
        public string closePrice;
        public string ltp;
        public string quantity;
        public string series;
        public string openRate;
        public string highRate;
        public string lowRate;
        public string avgRate;

        public Feed(string symbol, string feedtime, string expiry, string callput, string strike,
            string exch, string closePrice, string ltp, string quantity, string series, 
            string openRate, string highRate, string lowRate, string avgRate)
        {
            this.symbol = symbol;
            this.feedtime = feedtime;
            this.expiry = expiry;
            this.callput = callput;
            this.strike = strike;
            this.exch = exch;
            this.closePrice = closePrice;
            this.ltp = ltp;
            this.quantity = quantity;
            this.series = series;
            this.openRate = openRate;
            this.highRate = highRate;
            this.lowRate = lowRate;
            this.avgRate = avgRate;
        }
    }
}
