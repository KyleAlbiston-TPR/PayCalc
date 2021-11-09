using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace localPayCalc
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAll();

        Employee Create(int Id, string Name, string Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked);
        bool Delete(int Id);

        Employee Update(int Id, string Name, string ContractType, decimal? DayRate, int? WeeksWorked, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked);
    }
}
