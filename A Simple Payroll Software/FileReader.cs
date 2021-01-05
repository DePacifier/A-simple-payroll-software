using System;
using System.Collections.Generic;
using System.IO;

namespace A_Simple_Payroll_Software
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = {", "};

            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                while (sr.EndOfStream != true)
                {
                    result = sr.ReadLine().Split(separator,StringSplitOptions.TrimEntries);
                    if (result[1] == "Manager")
                    {
                        myStaff.Add(new Manager(result[0]));
                    }else if (result[1] == "Admin")
                    {
                        myStaff.Add(new Admin(result[0]));
                    }
                }
                
                sr.Close();
            }
            else
            {
                Console.WriteLine("staff.txt was not found!");
            }

            return myStaff;
        }
    }
}