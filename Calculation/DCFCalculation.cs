using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YieldCurveTraining.Data;
using YieldCurveTraining.Input;

namespace YieldCurveTraining.Calculation
{
    public class HolidayCalendar
    {
        public bool IsHoliday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        
    }

    public class DCFCalculator
    {
        private HolidayCalendar holidayCalendar;

        public DCFCalculator(HolidayCalendar calendar) 
        {
            holidayCalendar = calendar;
        }

        public double CalculateDCF(DateTime startaDate,DateTime endDate)
        {
            int actualDay = 0;

            DateTime currentDay = startaDate;

            var filePath = ".. / .. / .. / InputData /OisConvention.csv";
            var conventionData = csvDataReader.LoadFromCsv<ConventionData>(filePath, new ConventionData);

            while (currentDay <= endDate)
            {
                if(!holidayCalendar.IsHoliday(currentDay))
                {
                    actualDay++;
                }
                currentDay = currentDay.AddDays(1);
            }

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

            return (double)actualDay / dcc;
        }


    }
}
