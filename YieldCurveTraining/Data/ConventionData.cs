using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldCurveTraining.Data
{
    public class ConventionData
    {
        public string Key { get; set; }
        public string Product { get; set; }
        public string Bcs { get; set; }
        public string SpotBcs { get; set; }
        public string Dcc { get; set; }
        public string Bdc { get; set; }
        public int SpotLag { get; set; }
        public int FixingLag { get; set; }
        public int PaymentLag { get; set; }
        public int Frequency { get; set; }
        public bool LastOdd { get; set; }
        public bool IgnoreEom { get; set; }
    }
}
