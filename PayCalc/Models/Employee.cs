using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc;

namespace PayCalc
{
    public class PermanentEmployee : PersonalInfo
    {
        public decimal AnnualSalary { get; set; }
        public decimal AnnualBonus { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} \nName: {Name} \nContract: {Contract} \nAnnual Salary: {AnnualSalary} \nAnnual Bonus: {AnnualBonus} \nHours Worked: {HoursWorked} \n";
        }
    }
}
