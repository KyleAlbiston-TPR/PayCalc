using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class staffMember
    {
        //public static string staffID { get; set; } = "000";
        //public static string staffName { get; set; } = "Test";
        //public static double annualSalary { get; set; } = 40000;
        //public static double annualBonus { get; set; } = 5000;
        //public static double hoursWorked { get; set; } = 1820;

        public static List<staffInfo> staffInfos = new List<staffInfo>()
        {
            new staffInfo()
            {
                staffID = "001",
                staffName = "Joe Bloggs",
                annualSalary = 40000,
                annualBonus = 5000,
                hoursWorked = 1820
            },
            new staffInfo()
            { 
                staffID = "002",
                staffName = "John Smith",
                annualSalary = 45000,
                annualBonus = 2500,
                hoursWorked = 1820
            }
        };
    }
}
