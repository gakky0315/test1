using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YieldCurveTraining.Data;
using YieldCurveTraining.Input;

namespace YieldCurveTraining.Calculation
{

    // スポットラグの調整
    public DateTime getStartDay(DateTime startDate, int spotLag)
    {
        return startDate.AddDays(spotLag);
    }

    // 開始から何日後に満期が来るか
    public DateTime getAdddDate(DateTime startDate,string term)
    {
        DateTime adjustedDate = startDate;

        if (term == "O/N")
        {
            return adjustedDate.AddDays(1);
        }
        char termUnit = term.Last();
        int termValue = int.Parse(term.Substring(0, term.Length - 1));

        switch (termUnit)
        {
            case 'D':
                adjustedDate = adjustedDate.AddDays(termValue);
                break;
            case 'W':
                adjustedDate = adjustedDate.AddDays(termValue * 7);
                break;
            case 'M':
                adjustedDate = adjustedDate.AddMonths(termValue);
                break;
            case 'Y':
                adjustedDate = adjustedDate.AddYears(termValue);
                break;
            default:
                throw new ArgumentException("Invalid term unit");
        }

        return adjustedDate;

    }




    // DCFの計算
    public class DCFCalculator
    {
        public double CalculateDCF(DateTime startaDate,DateTime endDate)
        {
    

            var filePath = ".. / .. / .. / InputData /OisConvention.csv";
            var conventionData = csvDataReader.LoadFromCsv<ConventionData>(filePath, new ConventionData);

            string tempDcc = conventionData[0].Dcc;
            int dcc = 0;

            if(tempDcc == "Act365F")
            {
                dcc = 365;
            }
            else
            {
                throw new NotImplementedException();
            }

            return (double)(endDate - startaDate).TotalDays / dcc;
        }


    }
}
