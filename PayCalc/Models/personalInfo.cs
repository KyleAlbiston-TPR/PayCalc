using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public abstract class PersonalInfo
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public ContractType Contract { get; internal set; }
    }
}
