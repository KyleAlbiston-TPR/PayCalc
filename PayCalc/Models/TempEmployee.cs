using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalc
{
    public class TempEmployee : PersonalInfo
    {
        public decimal DayRate { get; set; }
        public int WeeksWorked { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} \nName: {Name} \nContract: {Contract} \nDayRate: {DayRate} \nWeeksWorked: {WeeksWorked} \n";
        }
    }
}
