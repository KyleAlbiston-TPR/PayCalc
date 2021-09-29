using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class tempStaffMember
    {
        public static List<tempStaffInfo> tempStaffInfos = new List<tempStaffInfo>()
        {
            new tempStaffInfo()
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
