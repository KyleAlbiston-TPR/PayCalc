using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc.Services
{
    public interface IPermCalculator 
    {
        decimal TotalPay(decimal AnnualSalary, decimal AnnualBonus);

        decimal HourlyRate(decimal AnnualSalary, decimal HoursWork);
    }
}