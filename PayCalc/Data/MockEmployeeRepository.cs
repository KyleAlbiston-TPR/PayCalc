﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCalc;

namespace PayCalc
{
    class MockEmployeeRepository : IEmployeeRepository<PermantentEmployee>
    {
        public List<PermantentEmployee> _EmployeeList;
        public MockEmployeeRepository()
        {
            _EmployeeList = new List<PermantentEmployee>()
            {
                new PermantentEmployee()
                { Id = 1, Name = "Kyle Albiston", Contract = "Permanent" , AnnualSalary = 15000, AnnualBonus = 4000, HoursWorked = 1820 },
                new PermantentEmployee()
                { Id = 2, Name = "Mark Hammerson", Contract = "Permanent", AnnualSalary = 18000, AnnualBonus = 2500, HoursWorked = 2000 }
            };

        }

        public PermantentEmployee Create(int Id, string Name, string Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate)
        {
            throw new NotImplementedException();
            //var createNew = new PermantentEmployee()
            //{
            //    Id = Id,
            //    Name = Name,
            //    Contract = Contract,
            //    AnnualSalary = (decimal)AnnualSalary,
            //    AnnualBonus = (decimal)AnnualBonus,
            //    HoursWorked = (int)HoursWorked,
            //};
            //_EmployeeList.Add(createNew);
            //return createNew;
        }

        public object Create(int Id, string Name, string Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            var createNew = new PermantentEmployee()
            {
                Id = Id,
                Name = Name,
                Contract = Contract,
                AnnualSalary = (decimal)AnnualSalary,
                AnnualBonus = (decimal)AnnualBonus,
                HoursWorked = (int)HoursWorked,
            };
            _EmployeeList.Add(createNew);
            return createNew;
        }

        public object Create(int Id, string Name, string Contract, int WeeksWorked, decimal DayRate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PermantentEmployee> GetAll()
        {
            return (_EmployeeList);
        }

        public PermantentEmployee GetEmployee(int Id)
        {
            return _EmployeeList.FirstOrDefault(e => e.Id == Id);
        }

        public PermantentEmployee Update(int Id, string Name, string Contract, decimal? AnnualSalary, decimal? AnnualBonus, int? HoursWorked, int? WeeksWorked, decimal? DayRate)
        {
            throw new NotImplementedException();
        }
    }
}