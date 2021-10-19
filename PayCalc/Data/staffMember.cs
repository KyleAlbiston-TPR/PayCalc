using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class StaffMember
    {

        public static List<StaffInfo> staffInfos = new()
        {
            new StaffInfo()
            {
                StaffID = "001",
                Contract = ContractType.contractType.Permanent,
                StaffName = "Joe Bloggs",
                AnnualSalary = 40000,
                AnnualBonus = 5000,
                HoursWorked = 1820
            },
            new StaffInfo()
            { 
                StaffID = "002",
                Contract = ContractType.contractType.Permanent,
                StaffName = "John Smith",
                AnnualSalary = 45000,
                AnnualBonus = 2500,
                HoursWorked = 1820
            }
        };
    }
}
