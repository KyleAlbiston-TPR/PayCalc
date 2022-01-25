using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class Calculator : ICalculator<PermanentEmployee>
    {
        public decimal PermHourlyRate(decimal AnnualSalary, decimal HoursWorked)
        {
            return AnnualSalary / HoursWorked;
        }

        public decimal PermTotalPay(decimal AnnualSalary, decimal AnnualBonus)
        {
            return (AnnualSalary + AnnualBonus);
        }
    }
}
