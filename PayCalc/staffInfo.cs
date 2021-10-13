namespace PayCalc
{
    public class staffInfo : personalInfo
    {
        public double annualSalary { get; set; }
        public double annualBonus { get; set; }
        public double hoursWorked { get; set; }
        public contractType contract { get; internal set; }

        public enum contractType { Permanent, Temporary, Contract }
    }
}