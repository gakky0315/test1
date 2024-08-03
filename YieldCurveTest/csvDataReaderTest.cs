using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using YieldCurveTraining.Data;
using YieldCurveTraining.Input;
using static YieldCurveTraining.Input.csvDataReader;

namespace YieldCurveTraining.YieldCurveTest
{
    [TestFixture]
    public class csvDataReaderTest
    {
        [Test]
        public void ConventionDataTest()
        {
            var filePath = "../../../InputData/OisConvention.csv";
            var expected = new List<ConventionData>
            {
                new ConventionData
                {
                    Key = "JPY.TONAR",
                    Product = "Ois",
                    Bcs = "TKY",
                    SpotBcs = "TKY",
                    Dcc = "Act365F",
                    Bdc = "ModFollowing",
                    SpotLag = 2,
                    FixingLag = 0,
                    PaymentLag = 2,
                    Frequency = 12,
                    LastOdd = true,
                    IgnoreEom = false
                }
            };

            // csv読み込み
            var result = csvDataReader.LoadFromCsv<ConventionData>(filePath, new ConventionDataMap());

            // Nullでないか、テストと読み込んだデータの行数が正しいか
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                var actual = result[i];
                Assert.That(actual.Key, Is.EqualTo(expected[i].Key));
                Assert.That(actual.Product, Is.EqualTo(expected[i].Product));
                Assert.That(actual.Bcs, Is.EqualTo(expected[i].Bcs));
                Assert.That(actual.SpotBcs, Is.EqualTo(expected[i].SpotBcs));
                Assert.That(actual.Dcc, Is.EqualTo(expected[i].Dcc));
                Assert.That(actual.Bdc, Is.EqualTo(expected[i].Bdc));
                Assert.That(actual.SpotLag, Is.EqualTo(expected[i].SpotLag));
                Assert.That(actual.FixingLag, Is.EqualTo(expected[i].FixingLag));
                Assert.That(actual.PaymentLag, Is.EqualTo(expected[i].PaymentLag));
                Assert.That(actual.Frequency, Is.EqualTo(expected[i].Frequency));
                Assert.That(actual.LastOdd, Is.EqualTo(expected[i].LastOdd));
                Assert.That(actual.IgnoreEom, Is.EqualTo(expected[i].IgnoreEom));
            }
        }

        [Test]
        public void MarketDataTest()
        {
            var filePath = "../../../InputData/Ois.csv";
            var expected = new List<MarketData>
            {
                new MarketData
                {
                    Kind = "OVERNIGHTAVERAGE",
                    Product = "Swap",
                    Currency = "JPY",
                    Term = "O/N",
                    Side = "Mid",
                    Ask = 0.00077,
                    Bid = 0.00077
                },
                new MarketData
                {
                    Kind = "OVERNIGHTAVERAGE",
                    Product = "Swap",
                    Currency = "JPY",
                    Term = "O/N",
                    Side = "Mid",
                    Ask = 0.00058,
                    Bid = 0.00098
                }
            };

            var result = csvDataReader.LoadFromCsv<MarketData>(filePath, new MarketDataMap());
            Assert.That(result, Is.Not.Null);

            // 自作テストと実際に読み込んだデータの行数が一致しているか確認
            // (データ量が巨大な時はコメントアウト)
            // Assert.That(result.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                var actual = result[i];
                Assert.That(actual.Kind, Is.EqualTo(expected[i].Kind));
                Assert.That(actual.Product, Is.EqualTo(expected[i].Product));
                Assert.That(actual.Currency, Is.EqualTo(expected[i].Currency));
                Assert.That(actual.Term, Is.EqualTo(expected[i].Term));
                Assert.That(actual.Side, Is.EqualTo(expected[i].Side));
                Assert.That(actual.Ask, Is.EqualTo(expected[i].Ask));
                Assert.That(actual.Bid, Is.EqualTo(expected[i].Bid));
            }
        }
    }
}
