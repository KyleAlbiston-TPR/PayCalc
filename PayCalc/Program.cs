using localPayCalc;
using System;
using System.Linq;

namespace PayCalc
{
    class Program
    {
        private static TempEmployeeRepository temp = new TempEmployeeRepository();
        private static MockEmployeeRepository mock = new MockEmployeeRepository();

        static void Main(string[] args)
        {
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            bool quitApp = false;
            do
            {
                Console.WriteLine("\nWhat would you like to do today? \n1: Get staff info \n2: Generate pay report \n3: Add New Staff \n4: Exit");
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
                        addNewStaff();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            while (!quitApp);
        }

        private static void addNewStaff()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n\tEmployee Data Entry");
            //if statement for emp contract type
            Console.WriteLine("Enter a contract type \t Permanent -- Temporary: ");
            var Contract = Console.ReadLine();
            if (Contract == "Permanent")
            {
                Employee employee = new Employee();
                Console.WriteLine("Staff ID: ");
                employee.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Staff Name: ");
                employee.Name = Console.ReadLine();
                employee.Contract = Contract;
                Console.WriteLine("Annual Salary: ");
                employee.AnnualSalary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Annual Bonus: ");
                employee.AnnualBonus = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Hours Worked: ");
                employee.HoursWorked = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("\n \tNew Employee Data: \n");
                Console.WriteLine(string.Concat(mock.Create(Id: employee.Id, Name: employee.Name, Contract: employee.Contract, AnnualSalary: employee.AnnualSalary, AnnualBonus: employee.AnnualBonus, HoursWorked: employee.HoursWorked)));
            }
            else if (Contract == "Temporary")
            {
                TempEmployee tempEmployee = new TempEmployee();
                Console.WriteLine("Staff ID: ");
                tempEmployee.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Staff Name: ");
                tempEmployee.Name = Console.ReadLine();
                tempEmployee.Contract = Contract;
                Console.WriteLine("Weeks Worked: ");
                tempEmployee.WeeksWorked = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Day Rate: ");
                tempEmployee.DayRate = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("\n \tNew Employee Data: \n");
                Console.WriteLine(string.Concat(temp.Create(Id: tempEmployee.Id, Name: tempEmployee.Name, Contract: tempEmployee.Contract, WeeksWorked: tempEmployee.WeeksWorked, DayRate: tempEmployee.DayRate)));

            }
            else { Console.WriteLine("Invalid Input");}
            //if --- temp

        }

        public static void generateReport()
        {
            Employee employee = new Employee();
            
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n-----------------------Permanent Staff-----------------------\n");
            Console.WriteLine(string.Concat(mock.GetAll()));
            Console.WriteLine("\n-----------------------Temporary Staff-----------------------\n");
            Console.WriteLine(string.Concat(temp.GetAll()));
        }

        public static void generateStaffPay()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine(Environment.NewLine + "Enter ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Concat(mock.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(temp.GetEmployee(inputID)));

            Console.WriteLine("\nWhat would you like to do next? \n1: Calculate Total \n2: Calculate hourly wage \n3: Exit");
            var Response = Console.ReadLine();

            if (Response == "1")
            {
               
            }
            if (Response == "2")
            {
                
            }
            if (Response == "3")
            {
                Environment.Exit(0);
            }
        }

    }
}
