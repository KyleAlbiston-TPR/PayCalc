namespace PayCalc
{
    public class TempStaffInfo : PersonalInfo
    {
        public int WeeksWorked { get; set; }
        public double DayRate { get; set; }
        public ContractType.contractType Contract { get; internal set; }
    }
}
