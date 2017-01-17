using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerWindowApplication
{
    public class SecurityMaster
    {
        public string ScripNo;
        public string symbol;
        public string exch;
        public string series;
        public string expiry;
        public string opttype; // CE /  PE        
        public string strike;
        public string lot;

        public SecurityMaster(string ScripNo, string exch,
        string series, string symbol, string opttype, string strike, string expiry, string lot)
        {
            this.ScripNo = ScripNo;
            this.symbol = symbol;
            this.exch = exch;
            this.series = series;
            this.expiry = expiry;
            this.opttype = opttype;
            this.strike = strike;
            this.lot = lot;
        }
    }
}
