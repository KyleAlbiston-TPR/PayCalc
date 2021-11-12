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

        T Create(int Id, string Name, string Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate);
        bool Delete(int Id);
        T Update(int Id, string Name, string Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate);
        object Create(int Id, string Name, string Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked);
        object Create(int Id, string Name, string Contract, int WeeksWorked, decimal DayRate);
    }
}
