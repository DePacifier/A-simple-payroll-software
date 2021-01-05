using System;
using System.Collections.Generic;

namespace A_Simple_Payroll_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff;
            FileReader fr = new FileReader();
            int month = 0, year = 0;

            while (year == 0)
            {
                Console.Write("\nPlease enter the year: ");
                try
                {
                    string input = Console.ReadLine();
                    year = Convert.ToInt32(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input provided!! Please provide a correct year");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month: ");
                try
                {
                    string input = Console.ReadLine();
                    month = Convert.ToInt32(input);
                    if (month < 1 || month > 12 )
                    {
                        Console.WriteLine("Invalid Input provided! Month should be between 1 and 12");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Enter hours worked for {myStaff[i].NameOfStaff}: ");
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();

        }
    }
}