using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A_Simple_Payroll_Software
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public PaySlip(int payMonth,int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year}");
                sw.WriteLine("==============================================");
                sw.WriteLine($"Name of Staff: {f.NameOfStaff}");
                sw.WriteLine($"Hours Worked: {f.HoursWorked}");
                sw.WriteLine("");
                sw.WriteLine($"Basic Pay: {f.BasicPay:C}");
                sw.WriteLine("");
                if (f.GetType() == typeof(Manager))
                {
                    sw.WriteLine($"Allowance: {((Manager)f).Allowance:C}");
                }else if (f.GetType() == typeof(Admin))
                {
                    sw.WriteLine($"Overtime Pay: {((Admin)f).Overtime:C}");
                }
                sw.WriteLine("");
                sw.WriteLine("==============================================");
                sw.WriteLine($"Total Pay: {f.TotalPay:C}");
                sw.WriteLine("==============================================");
                sw.Close();
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result = from staff in myStaff
                where staff.HoursWorked < 10
                orderby staff.NameOfStaff ascending
                select new {staff.NameOfStaff, staff.HoursWorked};

            string path = "summary.txt";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Staff with less than 10 working hours \n");
            foreach (var staff in result)
            {
                sw.WriteLine($"Name of Staff: {staff.NameOfStaff}, Hours Worked: {staff.HoursWorked}");
            }
            sw.Close();
        }

        public override string ToString()
        {
            return $"Month: {month}, Year; {year}";
        }
    }
}