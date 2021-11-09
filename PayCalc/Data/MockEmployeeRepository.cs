using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc;

namespace localPayCalc
{
    class MockEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> _EmployeeList;
        public MockEmployeeRepository()
        {
            _EmployeeList = new List<Employee>()
            {
                new Employee()
                { Id = 1, Name = "Kyle Albiston", AnnualSalary = 15000, AnnualBonus = 4000, HoursWorked = 1820 },
                new Employee()
                { Id = 2, Name = "Mark Hammerson", AnnualSalary = 18000, AnnualBonus = 2500, HoursWorked = 2000 }
            };

        }

        public Employee Create(int Id, string Name, string ContractType, decimal? DayRate, int? WeeksWorked, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            var createNew = new Employee()
            {
                Id = Id,
                Name = Name,
                ContractType = ContractType,
                DayRate = (decimal)DayRate,
                WeeksWorked = (int)WeeksWorked,
                AnnualSalary = AnnualSalary,
                AnnualBonus = AnnualBonus,
                HoursWorked = HoursWorked,
            };
            _EmployeeList.Add(createNew);
            return createNew;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            return (_EmployeeList);
        }

        public Employee GetEmployee(int Id)
        {
            return _EmployeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(int Id, string Name, string ContractType, decimal? DayRate, int? WeeksWorked, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            throw new NotImplementedException();
        }
    }
}