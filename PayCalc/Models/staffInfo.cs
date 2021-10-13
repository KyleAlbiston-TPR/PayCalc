namespace PayCalc
{
    public class staffInfo : personalInfo
    {
        public double annualSalary { get; set; }
        public double annualBonus { get; set; }
        public double hoursWorked { get; set; }
        public ContractType.contractType contract { get; internal set; }
    }
}