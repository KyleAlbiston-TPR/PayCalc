using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    class TempEmployeeRepository : ITempEmployeeRepository
    {
        public List<TempEmployee> _TempEmployees;
        public TempEmployeeRepository()
        {
            _TempEmployees = new List<TempEmployee>()
            {
                new TempEmployee()
                { Id = 3, Name = "Clare Jones", Contract = "Temporary", WeeksWorked = 40, DayRate = 350 }
            };
        }

        public TempEmployee Create(int Id, string Name, string Contract, int WeeksWorked, decimal DayRate)
        {
            var createNew = new TempEmployee()
            {
                Id = Id,
                Name = Name,
                Contract = Contract,
                WeeksWorked = WeeksWorked,
                DayRate = DayRate,
            };
            _TempEmployees.Add(createNew);
            return createNew;
        }

        public IEnumerable<TempEmployee> GetAll()
        {
            return (_TempEmployees);
        }

        public TempEmployee GetEmployee(int Id)
        {
            return _TempEmployees.FirstOrDefault(e => e.Id == Id);
        }
    }
}
