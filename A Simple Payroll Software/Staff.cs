using System;

namespace A_Simple_Payroll_Software
{
    public class Staff
    {
        private float hourlyRate;
        private int hWorked;
        
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        
        public int HoursWorked {
            get
            {
                return hWorked;
            }
            set
            {
                hWorked = value > 0 ? value : 0;
            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay ...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return $"Name: {NameOfStaff}, Hours Worked: {hWorked}, Hourly Rate: {hourlyRate}, " +
                   $"Basic Pay: {BasicPay}, and Total Pay: {TotalPay}";
        }
    }
}