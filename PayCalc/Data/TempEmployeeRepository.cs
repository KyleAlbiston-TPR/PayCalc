using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class TempEmployeeRepository : IEmployeeRepository<TempEmployee>
    {
        public List<TempEmployee> _TempEmployees;
        public TempEmployeeRepository()
        {
            _TempEmployees = new List<TempEmployee>()
            {
                new TempEmployee()
                { Id = 3, Name = "Clare Jones", Contract = ContractType.Temporary, WeeksWorked = 40, DayRate = 350 }
            };
        }

        public TempEmployee Create(int Id, string Name, ContractType Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate)
        {
            throw new NotImplementedException();
        }

        public object Create(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            throw new NotImplementedException();
        }

        public object Create(int Id, string Name, ContractType Contract, int WeeksWorked, decimal DayRate)
        {
            var createNew = new TempEmployee()
            {
                Id = Id,
                Name = Name,
                Contract = ContractType.Temporary,
                WeeksWorked = (int)WeeksWorked,
                DayRate = (decimal)DayRate,
            };
            _TempEmployees.Add(createNew);
            return createNew;
        }

        public bool Delete(int Id)
        {
            TempEmployee temp = _TempEmployees.FirstOrDefault(e => e.Id == Id);
            _TempEmployees.Remove(temp); { return true; }
        }

        public IEnumerable<TempEmployee> GetAll()
        {
            return (_TempEmployees);
        }

        public TempEmployee GetEmployee(int Id)
        {
            return _TempEmployees.FirstOrDefault(e => e.Id == Id);
        }

        public TempEmployee Update(int Id, string Name, ContractType Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate)
        {
            throw new NotImplementedException();
        }

        public object Update(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            throw new NotImplementedException();
        }

        public object Update(int Id, string Name, ContractType Contract, int WeeksWorked, decimal DayRate)
        {
            var update = GetEmployee(Id);
            update.Name = Name;
            update.Contract = (ContractType)Contract;
            update.WeeksWorked = WeeksWorked;
            update.DayRate = DayRate;
            return update;
        }
    }
}
