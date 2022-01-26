using System;
using System.Linq;

namespace PayCalc //Multiple fixes need to be made since changes to the API... Research Factory method, or just hard code it
    //into the program itself.
{
    class Program
    {
        private static IEmployeeRepository<TempEmployee> Temp = new TempEmployeeRepository();
        private static IEmployeeRepository<PermanentEmployee> Perm = new MockEmployeeRepository();
        private static ICalculator<PermanentEmployee> Calculator = new Calculator();

        static void Main(string[] args)
        {
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            bool quitApp = false;
            do
            {
                Console.WriteLine("\nWhat would you like to do today? \n1: Get staff info \n2: Generate pay report \n3: Add New Staff \n4: Update Staff Info \n5: Delete \n6: Exit");
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
                        updateStaff();
                        break;
                    case "5":
                        deleteStaff();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            while (!quitApp);
        }

        private static void updateStaff()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n\tEmployee Data Update");
           
            Console.WriteLine("Enter Staff ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Are you sure you want to update this entry?");
            Console.ResetColor();
            Console.WriteLine(string.Concat(Temp.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(Perm.GetEmployee(inputID)));
            Console.WriteLine("Y / N");
            var yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.Clear();
                Console.WriteLine(string.Concat(Perm.GetEmployee(inputID)));
                Console.WriteLine("Select data to update");
                Console.WriteLine("1: StaffID   2: Name   3: Contract   4: AnnualSalary   5: AnnualBonus   6: HoursWorked");
                var input = Console.ReadLine();
                var currentInfo = Perm.GetEmployee(inputID);
                switch (input)
                {
                    case "1":
                        Console.WriteLine("ID can not be changed without Admin approval");
                        break;
                    case "2":
                        Console.WriteLine("Enter new Name: ");
                        var UName = Console.ReadLine();
                        Perm.Update(currentInfo.Id, UName, currentInfo.Contract, currentInfo.AnnualSalary, currentInfo.AnnualBonus, currentInfo.HoursWorked); 
                        break;
                    case "3":
                        Console.WriteLine("Enter new Contract: ");
                        var UContract = Console.ReadLine();
                      //  Perm.Update(currentInfo.Id, currentInfo.Name, UContract, currentInfo.AnnualSalary, currentInfo.AnnualBonus, currentInfo.HoursWorked);
                        break;
                    case "4":
                        Console.WriteLine("Enter new Annual Salary: ");
                        var UAnnualSalary = Convert.ToInt32(Console.ReadLine());
                        Perm.Update(currentInfo.Id, currentInfo.Name, currentInfo.Contract, UAnnualSalary, currentInfo.AnnualBonus, currentInfo.HoursWorked);
                        break;
                    case "5":
                        Console.WriteLine("Enter new Bonus: ");
                        var UAnnualBonus = Convert.ToInt32(Console.ReadLine());
                        Perm.Update(currentInfo.Id, currentInfo.Name, currentInfo.Contract, currentInfo.AnnualSalary, UAnnualBonus, currentInfo.HoursWorked);
                        break;
                    case "6":
                        Console.WriteLine("Enter new Hours Worked: ");
                        var UHoursWorked = Convert.ToInt32(Console.ReadLine());
                        Perm.Update(currentInfo.Id, currentInfo.Name, currentInfo.Contract, currentInfo.AnnualSalary, currentInfo.AnnualBonus, UHoursWorked);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine(string.Concat(Perm.GetEmployee(inputID)));
            }
            else if (yesno == "N" || yesno == "n")
            {
                Console.WriteLine("No data updated");
            }

        }

        private static void deleteStaff()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n\tEmployee Data Removal");

            Console.WriteLine("Enter Staff ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Are you sure you want to delete this entry?");
            Console.ResetColor();
            Console.WriteLine(string.Concat(Temp.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(Perm.GetEmployee(inputID)));
            Console.WriteLine("Y / N");
            var yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Removing entry...");
                Console.WriteLine(string.Concat(Temp.Delete(inputID)));
                Console.WriteLine(string.Concat(Perm.Delete(inputID)));
            }
            else if (yesno == "N" || yesno == "n")
            {
                Console.WriteLine("No entry reomved");
            }
        }

        private static void addNewStaff()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n\tEmployee Data Entry");
            Console.WriteLine("Enter a contract type \t P = Permanent \n\t\t\t T = Temporary");
            var Contract = Console.ReadLine();
            if (Contract == "P" || Contract == "p")
            {
                PermanentEmployee employee = new PermanentEmployee();
                Console.WriteLine("Staff ID: ");
                employee.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Staff Name: ");
                employee.Name = Console.ReadLine();
                employee.Contract = ContractType.Permanent;
                Console.WriteLine("Annual Salary: ");
                employee.AnnualSalary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Annual Bonus: ");
                employee.AnnualBonus = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Hours Worked: ");
                employee.HoursWorked = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("\n \tNew Employee Data: \n");
                Console.WriteLine(string.Concat(Perm.Create(employee.Id,employee.Name,employee.Contract, employee.AnnualSalary, employee.AnnualBonus,  employee.HoursWorked)));
            }
            else if (Contract == "T" || Contract == "t")
            {
                TempEmployee tempEmployee = new TempEmployee();
                Console.WriteLine("Staff ID: ");
                tempEmployee.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Staff Name: ");
                tempEmployee.Name = Console.ReadLine();
                tempEmployee.Contract = ContractType.Temporary;
                Console.WriteLine("Weeks Worked: ");
                tempEmployee.WeeksWorked = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Day Rate: ");
                tempEmployee.DayRate = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("\n \tNew Employee Data: \n");
                Console.WriteLine(string.Concat(Temp.Create(Id: tempEmployee.Id, Name: tempEmployee.Name, Contract: tempEmployee.Contract, WeeksWorked: tempEmployee.WeeksWorked, DayRate: tempEmployee.DayRate)));

            }
            else { Console.WriteLine("Invalid Input");}

        }

        public static void generateReport()
        {
            PermanentEmployee employee = new PermanentEmployee();
            
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n-----------------------Permanent Staff-----------------------\n");
            Console.WriteLine(string.Concat(Perm.GetAll()));
            Console.WriteLine("\n-----------------------Temporary Staff-----------------------\n");
            Console.WriteLine(string.Concat(Temp.GetAll()));
        }

        public static void generateStaffPay()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine(Environment.NewLine + "Enter ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Concat(Perm.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(Temp.GetEmployee(inputID)));

            Console.WriteLine("\nWhat would you like to do next? \n1: Calculate Total \n2: Calculate hourly wage \n3: Exit");
            var Response = Console.ReadLine();
            if ((Perm.GetEmployee(inputID).Contract == ContractType.Permanent))
            {
                switch (Response)
                {
                    case "1":
                        Console.WriteLine(string.Concat(Calculator.PermTotalPay(Perm.GetEmployee(inputID).AnnualSalary, Perm.GetEmployee(inputID).AnnualBonus)));
                        break;
                    case "2":
                        Console.WriteLine(string.Concat(Calculator.PermHourlyRate(Perm.GetEmployee(inputID).AnnualSalary, Perm.GetEmployee(inputID).HoursWorked)));
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
            else if ((Temp.GetEmployee(inputID).Contract == ContractType.Temporary))
            {
                switch (Response)
                {
                    case "1":
                        Console.WriteLine(string.Concat(Calculator.TempTotalPay(Temp.GetEmployee(inputID).WeeksWorked, Temp.GetEmployee(inputID).DayRate)));
                        break;
                    case "2":
                        Console.WriteLine(string.Concat(Calculator.TempHourlyRate(Temp.GetEmployee(inputID).DayRate)));
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }

        }

    }
}