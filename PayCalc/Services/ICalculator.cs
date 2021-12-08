using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public interface ICalculator
    {
        decimal PermTotalPay(decimal AnnualSalary, decimal AnnualBonus);

        decimal PermHourlyRate(decimal AnnualSalary, decimal HoursWorked);

        decimal TempTotalPay(int WeeksWorked, decimal DayRate);

        decimal TempHourlyRate(decimal DayRate);
    }
}
