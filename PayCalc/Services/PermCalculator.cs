using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc.Services
{
    public class PermCalculator : IPermCalculator
    {
        public decimal HourlyRate(decimal AnnualSalary, decimal HoursWorked)
        {
            return AnnualSalary / HoursWorked;
        }

        public decimal TotalPay(decimal AnnualSalary, decimal AnnualBonus)
        {
            return (AnnualSalary + AnnualBonus);
        }
    }
}
