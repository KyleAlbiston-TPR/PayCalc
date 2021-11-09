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

        public IEnumerable<TempEmployee> GetAll()
        {
            return (_TempEmployees);
        }
    }
}
