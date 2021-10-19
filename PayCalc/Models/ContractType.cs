using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public abstract class ContractType
    {
        public contractType Contract { get; internal set; }
        public enum contractType { Permanent, Temporary, Contract }
    }
}
