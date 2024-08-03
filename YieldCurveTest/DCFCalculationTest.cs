using System;
using NUnit.Framework;
using YieldCurveTraining.Calculation;

namespace YieldCurveTest
{
    [TestFixture]
    public class DCFCalculatorTest
    {
        // 祝日（土日）のテスト
        [Test]
        [TestCase("2024-04-01", false)] // 平日
        [TestCase("2024-04-06", true)] // 土曜
        [TestCase("2024-04-07", true)] // 日曜
        [TestCase("2024-04-29", false)] // 祝日
        public void IsHolidayTest(string date, bool expected)
        {
            var holidaycalender = new HolidayCalendar();
            var result = holidaycalender.IsHoliday(DateTime.Parse(date));

            Assert.That(result, Is.EqualTo(expected));
        }

        // DCFのテスト
        [Test]
        [TestCase("2024-04-01", "2024-04-05", (double)5 / 365)] // 5営業日（月金）
        [TestCase("2024-04-01", "2024-04-07", (double)5 / 365)] // 土日入っても正しいか
        [TestCase("2024-04-29", "2024-05-03", (double)5 / 365)] // 祝日が入っても正しいか
        [TestCase("2024-04-01", "2025-04-01", (double)262 / 365)] // 一年
        public void CalculateDCFTest(string startDate, string endDate, double expected)
        {
            var holidaycalender = new HolidayCalendar();
            var dcfCalculator = new DCFCalculator(holidaycalender);

            var result = dcfCalculator.CalculateDCF(DateTime.Parse(startDate), DateTime.Parse(endDate));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
