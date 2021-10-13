namespace PayCalc
{
    public class tempStaffInfo : personalInfo
    {
        public int weeksWorked { get; set; }
        public double dayRate { get; set; }
        public staffInfo.contractType contract { get; internal set; }

        public enum contractType { Permanent, Temporary, Contract }
    }
}
