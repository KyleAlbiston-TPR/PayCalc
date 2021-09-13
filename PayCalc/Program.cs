using System;
using System.Collections.Generic;

namespace PayCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            bool quitApp = false;
            do
            {
                Console.WriteLine("\nWhat would you like to do today? \n1: Get staff info \n2: Generate pay report \n3: Exit");
                var selectedOption = Console.ReadLine();

                switch (selectedOption)
                {
                    case "1":
                        generateStaffPay();
                        break;
                    case "2":
                        generateReport();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            while (!quitApp);
        }

        public static void generateReport()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            for (var i = 0; i < staffMember.staffInfos.Count; i++)
            {
                var staffInfo = staffMember.staffInfos[i];

                if (staffInfo.contractType == "Permanent")
                {
                    Console.WriteLine($"Staff ID: " + staffInfo.staffID + "\nContract type: " + staffInfo.contractType + "\nStaff Name: " + staffInfo.staffName + "\nAnnual Salary: " + staffInfo.annualSalary + "\nAnnual Bonus: " + staffInfo.annualBonus + "\nHours Worked: " + staffInfo.hoursWorked + "\n");
                }
                if (staffInfo.contractType == "Temp")
                {
                    Console.WriteLine($"Staff ID: " + staffInfo.staffID + "\nContract type: " + staffInfo.contractType + "\nStaff Name: " + staffInfo.staffName + "\nWeeks Worked: " + staffInfo.weeksWorked + "\nDay Rate: " + staffInfo.dayRate + "\n");
                }
            }
        }

        public static void generateStaffPay()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine(Environment.NewLine + "Enter ID: ");

            var inputID = Console.ReadLine();

            for (var i = 0; i < staffMember.staffInfos.Count; i++)
            {
                var staffInfo = staffMember.staffInfos[i];

                if (staffInfo.staffID == inputID && staffInfo.contractType == "Permanent") 
                {
                    Console.Clear();
                    Console.WriteLine("\t\tTPR Pay calculator program v.1");
                    Console.WriteLine(Environment.NewLine + $"Staff ID: " + staffInfo.staffID + "\nContract type: " + staffInfo.contractType + "\nStaff Name: " + staffInfo.staffName + "\nAnnual Salary: " + staffInfo.annualSalary + "\nAnnual Bonus: " + staffInfo.annualBonus + "\nHours Worked: " + staffInfo.hoursWorked);

                    Console.WriteLine("\nWhat would you like to do next?\n1: Calculate Total\n2: Calculate Hourly\n3: Exit");
                    var Response = Console.ReadLine();
                    double hourly = staffInfo.annualSalary / staffInfo.hoursWorked;
                    if (Response == "1")
                    {
                        Console.WriteLine($"Your total income this year is: £" + (staffInfo.annualSalary + staffInfo.annualBonus));
                    }
                    if (Response == "2")
                    {
                        Console.WriteLine($"Your hourly income is: £" + Math.Round(hourly,2));
                    }
                    if (Response == "3")
                    {
                        Environment.Exit(0);
                    }
                }

                if (staffInfo.staffID == inputID && staffInfo.contractType == "Temp") 
                {
                    Console.Clear();
                    Console.WriteLine("\t\tTPR Pay calculator program v.1");
                    Console.WriteLine(Environment.NewLine + $"Staff ID: " + staffInfo.staffID + "\nContract type: " + staffInfo.contractType + "\nStaff Name: " + staffInfo.staffName + "\nWeeks Worked: " + staffInfo.weeksWorked + "\nDay Rate: " + staffInfo.dayRate);

                    Console.WriteLine("\nWhat would you like to do next?\n1: Calculate Total\n2: Calculate Hourly\n3: Exit");
                    var Response = Console.ReadLine();
                    double tempHourly = staffInfo.dayRate / 7;
                    if (Response == "1")
                    {
                        Console.WriteLine($"Your total income this year is: £" + ((staffInfo.dayRate * 5) * staffInfo.weeksWorked));
                    }
                    if (Response == "2")
                    {
                        Console.WriteLine($"Your hourly income is: £" + Math.Round(tempHourly, 2));
                    }
                    if (Response == "3")
                    {
                        Environment.Exit(0);
                    }
                }
            }

        }
    }
}