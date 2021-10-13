using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    abstract public class ContractType
    {
        public contractType contract { get; internal set; }
        public enum contractType { Permanent, Temporary, Contract }
    }
}
