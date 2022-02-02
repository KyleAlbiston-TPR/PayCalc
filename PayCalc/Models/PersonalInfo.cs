namespace PayCalc
{
    public abstract class PersonalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContractType Contract { get; set; }
        public decimal TotalPay { get; set; }
        public decimal HourlyPay { get; set; }
    }
}
