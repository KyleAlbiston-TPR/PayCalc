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
        T Create(T Employee);
        bool Delete(int Id);
        T Update(T Employee);
    }
}
