using System;
using System.Collections.Generic;

namespace PayCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateStaffPay();
        }

        public static void GenerateStaffPay()
        {
            Console.WriteLine(Environment.NewLine + "Enter ID: ");
            var inputID = Console.ReadLine();
            for (var i = 0; i < staffMember.staffInfos.Count; i++)
            {
                var staffInfo = staffMember.staffInfos[i];

                if (staffInfo.staffID == inputID)
                {
                    Console.WriteLine($"Staff ID: " + staffInfo.staffID + "\nStaff Name: " + staffInfo.staffName + "\nAnnual Salary: " + staffInfo.annualSalary + "\nAnnual Bonus: " + staffInfo.annualBonus + "\nHours Worked: " + staffInfo.hoursWorked);

                    Console.WriteLine("\nWhat would you like to do next?\n1: Calculate Total\n2: Calculate Hourly\n3: Exit");
                    var Response = Console.ReadLine();
                    double hourly = staffInfo.annualSalary / staffInfo.hoursWorked;
                    if (Response == "1")
                    {
                        Console.WriteLine($"Your total income this year is: £" + (staffInfo.annualSalary + staffInfo.annualBonus));
                    }
                    if (Response == "2")
                    {
                        Console.WriteLine($"Your hourly income is: £" + hourly);
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


//Console.Write("Enter hourly wage: ");
//double wage = Convert.ToDouble(Console.ReadLine());
//Console.Write("Enter hours worked: ");
//double hours = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine($"Money earned today: ", wage + hours);

//Console.ReadLine();

//var fName = "Kyle";
//var lName = "Albiston";
//var annual = 15000;
//var bonus = 950;

//Console.WriteLine($"Your total " + fName + " " + lName + " is: £" + (annual + bonus));

//string inputID;

//Console.WriteLine("Enter staff ID: ");
//inputID = Console.ReadLine();
//if (inputID == staffMember.staffID)
//{
//    Console.WriteLine($"StaffID: " + staffMember.staffID + "\nStaff Name: " + staffMember.staffName + "\nAnnual salary: " + staffMember.annualSalary + "\nAnnual Bonus: " + staffMember.annualBonus);
//}

//staffMember info = new staffMember();

//staffInfo.staffInfos 
//    var inputID = staffMember.staffID;
//    inputID = Console.ReadLine();
//    if (inputID == staffMember.staffID)
//    {
//        Console.WriteLine($"StaffID: " + staffMember.staffID + "\nStaff Name: " + staffMember.staffName + "\nAnnual salary: " + staffMember.annualSalary + "\nAnnual Bonus: " + staffMember.annualBonus);
//    }