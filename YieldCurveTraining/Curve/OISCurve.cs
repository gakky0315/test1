using System;
using System.Collections.Generic;

namespace YieldCurveTraining.Curve
{
    public class OISCurve : ICurve
    {
        public double OisRate { get; set; }
        public double Dcf { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double SumDf { get; set; }
        public string Term { get; set; }
        public Dictionary<DateTime, double> plotDf = new Dictionary<DateTime, double>();

        public OISCurve(double oisRate, double dcf, DateTime startDate, DateTime endDate, double sumDf, string term, Dictionary<DateTime, double> plotDf)
        {
            OisRate = oisRate;
            Dcf = dcf;
            StartDate = startDate;
            EndDate = endDate;
            SumDf = sumDf;
            Term = term;
            this.plotDf = plotDf;
        }

        public void CalculateDF()
        {
            double tempDf = 0;

            // termが1Y未満の場合
            if (Term.EndsWith("M") || Term.EndsWith("W") || Term.EndsWith("D"))
            {
                tempDf = 1 / (1 + OisRate * Dcf);
            }
            // termが1Y以上の場合
            else if (Term.EndsWith("Y"))
            {
                tempDf = (1 - OisRate * Dcf * SumDf) / (1 + OisRate * Dcf);
                SumDf += tempDf;
            }

            // プロットするため
            plotDf[EndDate] = tempDf;

            
        }
    }
}
