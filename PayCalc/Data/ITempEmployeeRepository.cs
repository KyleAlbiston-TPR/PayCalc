using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public interface ITempEmployeeRepository
    {
        IEnumerable<TempEmployee> GetAll();

        TempEmployee Create(int Id, string Name, string Contract, int WeeksWorked, decimal DayRate);

        TempEmployee GetEmployee(int Id);

    }
}
