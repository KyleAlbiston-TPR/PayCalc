using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc.Services
{
    public interface ITempCalculator
    {
        decimal TotalPay(decimal WeeksWorked, decimal DayRate);

        decimal HourlyRate(decimal DayRate);
    }
}
