using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using YieldCurveTraining.Data;



namespace YieldCurveTraining.Input
{
    public class csvDataReader
    {
        public static List<T> LoadFromCsv<T>(string filePath, ClassMap mapping = null)
        {
            using (var reader = new StreamReader(filePath)) ; 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                if (mapping != null)
                {
                    csv.Context.RegisterClassMap(mapping);
                }
                var records = csv.GetRecords<T>();
                return new List<T>(records);
            }
        }
        public sealed class ConventionDataMap : ClassMap<ConventionData>
        {
            public ConventionDataMap() 
            {
                Map(m => m.Key).Name("Key");
                Map(m => m.Product).Name("Product");
                Map(m => m.Bcs).Name("Bcs");
                Map(m => m.SpotBcs).Name("SpotBcs");
                Map(m => m.Dcc).Name("Dcc");
                Map(m => m.Bdc).Name("Bdc");
                Map(m => m.SpotLag).Name("SpotLag");
                Map(m => m.FixingLag).Name("FixingLag");
                Map(m => m.PaymentLag).Name("PaymentLag");
                Map(m => m.Frequency).Name("Frequency");
                Map(m => m.LastOdd).Name("LastOdd");
                Map(m => m.IgnoreEom).Name("IgnoreEom");
            }

        }

        public sealed class MarketDataMap : ClassMap<MarketData>
        {
            public MarketDataMap()
            {
                Map(m => m.Kind).Name("kind");
                Map(m => m.Product).Name("Product");
                Map(m => m.Currency).Name("Currency");
                Map(m => m.Term).Name("Term");
                Map(m => m.Side).Name("Side");
                Map(m => m.Ask).Name("Ask");
                Map(m => m.Bid).Name("Bid");
            }
        }
    }
}
