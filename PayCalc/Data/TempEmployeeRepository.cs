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

        public TempEmployee Create(TempEmployee Employee)
        {
            _TempEmployees.Add(Employee);
            return Employee;
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

        public TempEmployee Update(TempEmployee Employee)
        {
            if (Employee == null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }
            int index = _TempEmployees.FindIndex(p => p.Id == Employee.Id);
            if (index == -1)
            {
                return null;
            }
            _TempEmployees.RemoveAt(index);
            _TempEmployees.Add(Employee);
            return Employee;
        }
    }
}
