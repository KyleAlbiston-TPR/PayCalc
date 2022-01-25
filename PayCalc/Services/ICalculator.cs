using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public interface ICalculator<T> //not working as intended, still needs to hold the temp calcs. 
    {
        decimal PermTotalPay(decimal AnnualSalary, decimal AnnualBonus);

        decimal PermHourlyRate(decimal AnnualSalary, decimal HoursWorked);
    }
}