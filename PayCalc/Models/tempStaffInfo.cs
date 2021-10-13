namespace PayCalc
{
    public class tempStaffInfo : personalInfo
    {
        public int weeksWorked { get; set; }
        public double dayRate { get; set; }
        public ContractType.contractType contract { get; internal set; }
    }
}
