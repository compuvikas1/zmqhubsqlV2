using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerWindowApplication
{
    public class SymbolFilter
    {
        public string symbol;
        public string exch;
        public string series;
        public string expiry;
        public string opttype; // CE /  PE        
        public string strike;
        public double closePrice;
        public double ltp;
        public int quantity;
    }
}
