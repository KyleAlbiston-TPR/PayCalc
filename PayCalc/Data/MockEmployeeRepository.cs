using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc;

namespace PayCalc
{
    public class MockEmployeeRepository : IEmployeeRepository<PermanentEmployee>
    {
        public List<PermanentEmployee> _EmployeeList;
        public MockEmployeeRepository()
        {
            _EmployeeList = new List<PermanentEmployee>()
            {
                new PermanentEmployee()
                { Id = 1, Name = "Kyle Albiston", Contract = ContractType.Permanent , AnnualSalary = 15000, AnnualBonus = 4000, HoursWorked = 1820 },
                new PermanentEmployee()
                { Id = 2, Name = "Mark Hammerson", Contract = ContractType.Permanent, AnnualSalary = 18000, AnnualBonus = 2500, HoursWorked = 2000 }
            };

        }

        public PermanentEmployee Create(PermanentEmployee Employee)
        {
            _EmployeeList.Add(Employee);
            return Employee;
        }

        public bool Delete(int Id)
        {
            PermanentEmployee perm = _EmployeeList.FirstOrDefault(e => e.Id == Id);
            if (_EmployeeList.Remove(perm)) ;
            { return true; }
        }

        public IEnumerable<PermanentEmployee> GetAll()
        {
            return (_EmployeeList);
        }

        public PermanentEmployee GetEmployee(int Id)
        {
            return _EmployeeList.FirstOrDefault(e => e.Id == Id);
        }

        public PermanentEmployee Update(PermanentEmployee Employee)
        {
            if (Employee == null)
            { 
                throw new ArgumentNullException(nameof(Employee));
            }
            int index = _EmployeeList.FindIndex(p => p.Id == Employee.Id);
            if (index == -1)
            {
                return null;
            }
            _EmployeeList.RemoveAt(index);
            _EmployeeList.Add(Employee);
            return Employee;
        }
    }
}