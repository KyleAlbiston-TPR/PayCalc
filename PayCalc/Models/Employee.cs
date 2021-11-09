using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc;

namespace localPayCalc
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public decimal DayRate { get; set; }
        public int WeeksWorked { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal AnnualBonus { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} \nName: {Name} \nContract: {ContractType} \nDay Rate: {DayRate} \nWeeks Worked: {WeeksWorked} \nAnnual Salary: {AnnualSalary} \nAnnual Bonus: {AnnualBonus} \nHours Worked: {HoursWorked} \n";
        }
    }
}
