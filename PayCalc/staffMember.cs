using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class staffMember
    {

        public static List<staffInfo> staffInfos = new List<staffInfo>()
        {
            new staffInfo()
            {
                staffID = "001",
                contractType = "Permanent",
                staffName = "Joe Bloggs",
                annualSalary = 40000,
                annualBonus = 5000,
                hoursWorked = 1820
            },
            new staffInfo()
            { 
                staffID = "002",
                contractType = "Permanent",
                staffName = "John Smith",
                annualSalary = 45000,
                annualBonus = 2500,
                hoursWorked = 1820
            },
            new staffInfo()
            { 
                staffID = "003",
                contractType = "Temp",
                staffName = "Clare Jones",
                weeksWorked = 40,
                dayRate = 350,
            }
        };
    }
}
