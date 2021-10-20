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
            Console.WriteLine();
            for (var i = 0; i < StaffMember.staffInfos.Count; i++)
            {
                var staffInfo = StaffMember.staffInfos[i];
                {
                    string permStaff = $"Staff ID: {staffInfo.StaffID} \nContract Type: {ContractType.Permanent} \nStaff Name: {staffInfo.StaffName} \nAnnual Salary: {staffInfo.AnnualSalary} \nAnnual Bonus: {staffInfo.AnnualBonus} \nHours Worked: {staffInfo.HoursWorked} \n";
                    Console.WriteLine(permStaff);
                }
            }
            for (var i = 0; i < TempStaffMember.tempStaffInfos.Count; i++)
            {
                var staffInfo = TempStaffMember.tempStaffInfos[i];
                {
                    string tempStaff = $"Staff ID: {staffInfo.StaffID} \nContract type: {ContractType.Temporary} \nStaff Name: {staffInfo.StaffName} \nWeeks Worked: {staffInfo.WeeksWorked} \nDay Rate: {staffInfo.DayRate} \n";
                    Console.WriteLine(tempStaff);
                }
            }
        }

        public static void generateStaffPay()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine(Environment.NewLine + "Enter ID: ");

            var inputID = Console.ReadLine();

            for (var i = 0; i < StaffMember.staffInfos.Count; i++)
            {
                var staffInfo = StaffMember.staffInfos[i];

                if (staffInfo.StaffID == inputID) 
                {
                    Console.Clear();
                    Console.WriteLine("\t\tTPR Pay calculator program v.1");
                    string permStaff = $"Staff ID: {staffInfo.StaffID} \nContract Type: {ContractType.Permanent} \nStaff Name: {staffInfo.StaffName} \nAnnual Salary: {staffInfo.AnnualSalary} \nAnnual Bonus: {staffInfo.AnnualBonus} \nHours Worked: {staffInfo.HoursWorked} \n";

                    Console.WriteLine(Environment.NewLine + permStaff);

                    Console.WriteLine("\nWhat would you like to do next?\n1: Calculate Total\n2: Calculate Hourly\n3: Exit");
                    var Response = Console.ReadLine();
                    double hourly = staffInfo.AnnualSalary / staffInfo.HoursWorked;
                    if (Response == "1")
                    {
                        Console.WriteLine($"\nYour total income this year is: £" + (staffInfo.AnnualSalary + staffInfo.AnnualBonus));
                    }
                    if (Response == "2")
                    {
                        Console.WriteLine($"\nYour hourly income is: £" + Math.Round(hourly,2));
                    }
                    if (Response == "3")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            
            for (var i = 0; i < TempStaffMember.tempStaffInfos.Count; i++)
            {
                var staffInfo = TempStaffMember.tempStaffInfos[i];

                if (staffInfo.StaffID == inputID)
                {
                    Console.Clear();
                    Console.WriteLine("\t\tTPR Pay calculator program v.1");
                    string tempStaff = $"Staff ID: {staffInfo.StaffID} \nContract type: {ContractType.Temporary} \nStaff Name: {staffInfo.StaffName} \nWeeks Worked: {staffInfo.WeeksWorked} \nDay Rate: {staffInfo.DayRate} \n";
                    Console.WriteLine(Environment.NewLine + tempStaff);

                    Console.WriteLine("\nWhat would you like to do next?\n1: Calculate Total\n2: Calculate Hourly\n3: Exit");
                    var Response = Console.ReadLine();
                    double tempHourly = staffInfo.DayRate / 7;
                    if (Response == "1")
                    {
                        Console.WriteLine($"\nYour total income this year is: £" + ((staffInfo.DayRate * 5) * staffInfo.WeeksWorked));
                    }
                    if (Response == "2")
                    {
                        Console.WriteLine($"\nYour hourly income is: £" + Math.Round(tempHourly, 2));
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