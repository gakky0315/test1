using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldCurveTraining.Data
{
    public class MarketData
    {
        public string Kind { get; set; }
        public string Product { get; set; }
        public string Currency { get; set; }
        public string Term { get; set; }
        public string Side { get; set; }
        public double Ask { get; set; }
        public double Bid { get; set; }
    }
}
