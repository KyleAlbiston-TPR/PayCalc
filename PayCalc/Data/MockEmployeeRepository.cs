using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc;

namespace PayCalc
{
    public class MockEmployeeRepository : IEmployeeRepository<PermantentEmployee>
    {
        public List<PermantentEmployee> _EmployeeList;
        public MockEmployeeRepository()
        {
            _EmployeeList = new List<PermantentEmployee>()
            {
                new PermantentEmployee()
                { Id = 1, Name = "Kyle Albiston", Contract = ContractType.Permanent , AnnualSalary = 15000, AnnualBonus = 4000, HoursWorked = 1820 },
                new PermantentEmployee()
                { Id = 2, Name = "Mark Hammerson", Contract = ContractType.Permanent, AnnualSalary = 18000, AnnualBonus = 2500, HoursWorked = 2000 }
            };

        }

        public PermantentEmployee Create(int Id, string Name, ContractType Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate)
        {
            throw new NotImplementedException();
        }

        public object Create(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            var createNew = new PermantentEmployee()
            {
                Id = Id,
                Name = Name,
                Contract = ContractType.Permanent,
                AnnualSalary = (decimal)AnnualSalary,
                AnnualBonus = (decimal)AnnualBonus,
                HoursWorked = (int)HoursWorked,
            };
            _EmployeeList.Add(createNew);
            return createNew;
        }

        public object Create(int Id, string Name, ContractType Contract, int WeeksWorked, decimal DayRate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            PermantentEmployee perm = _EmployeeList.FirstOrDefault(e => e.Id == Id);
            _EmployeeList.Remove(perm); { return true; }
        }

        public IEnumerable<PermantentEmployee> GetAll()
        {
            return (_EmployeeList);
        }

        public PermantentEmployee GetEmployee(int Id)
        {
            return _EmployeeList.FirstOrDefault(e => e.Id == Id);
        }

        public PermantentEmployee Update(int Id, string Name, ContractType Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate)
        {
            throw new NotImplementedException();
        }

        public object Update(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            var update = GetEmployee(Id);
            update.Name = Name;
            update.Contract = (ContractType)Contract;
            update.AnnualSalary = AnnualSalary;
            update.AnnualBonus = AnnualBonus;
            update.HoursWorked = HoursWorked;
            return update;
        }
    }
}