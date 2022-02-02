using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc.Services
{
    public class TempCalculator : ITempCalculator
    {
        public decimal HourlyRate(decimal DayRate)
        {
            return DayRate / 7;
        }

        public decimal TotalPay(decimal WeeksWorked, decimal DayRate)
        {
            return DayRate * 5 * (WeeksWorked);
        }
    }
}
