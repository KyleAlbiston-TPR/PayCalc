using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public interface IEmployeeRepository<T>
    {
        T GetEmployee(int Id);
        IEnumerable<T> GetAll();

        T Create(int Id, string Name, ContractType Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate);
        bool Delete(int Id);
        //replace Enum Contract with ContractType Contract
        T Update(int Id, string Name, ContractType Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate);
        object Update(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked);
        object Create(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked);
        object Create(int Id, string Name, ContractType Contract, int WeeksWorked, decimal DayRate);
    }
}
