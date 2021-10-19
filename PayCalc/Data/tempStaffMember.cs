using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class TempStaffMember : ContractType
    {
        public static List<TempStaffInfo> tempStaffInfos = new()
        {
            new TempStaffInfo()
            {
                StaffID = "003",
                Contract = ContractType.contractType.Temporary,
                StaffName = "Clare Jones",
                WeeksWorked = 40,
                DayRate = 350,
            }
        };
    }
}
