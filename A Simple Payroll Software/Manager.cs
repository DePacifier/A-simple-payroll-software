namespace A_Simple_Payroll_Software
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        
        public int Allowance { get; private set; }
        
        public Manager(string name) : base(name, managerHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
            {
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return $"Name: {NameOfStaff}, Hours Worked: {HoursWorked}, Hourly Rate: {managerHourlyRate}, " +
                   $"Allowance: {Allowance}, Basic Pay: {BasicPay}, and Total Pay: {TotalPay}";
        }
    }
}