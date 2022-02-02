using PayCalc.Services;

namespace PayCalc
{
    class Program
    {
        private static IEmployeeRepository<TempEmployee> _temp = new TempEmployeeRepository();
        private static IEmployeeRepository<PermanentEmployee> _perm = new MockEmployeeRepository();
        private static IPermCalculator _permCalc = new PermCalculator();
        private static ITempCalculator _tempCalc = new TempCalculator();

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
            Console.WriteLine(string.Concat(_temp.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(_perm.GetEmployee(inputID)));
            Console.WriteLine("Y / N");
            var yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.Clear();
                Console.WriteLine(string.Concat(_perm.GetEmployee(inputID)));
                Console.WriteLine("Select data to update");
                Console.WriteLine("1: StaffID   2: Name   3: Contract   4: AnnualSalary   5: AnnualBonus   6: HoursWorked");
                var input = Console.ReadLine();
                var currentInfo = _perm.GetEmployee(inputID);
                switch (input)
                {
                    case "1":
                        Console.WriteLine("ID can not be changed without Admin approval");
                        break;
                    case "2":
                        Console.WriteLine("Enter new Name: ");
                        var UName = Console.ReadLine();
                        _perm.GetEmployee(inputID).Name = UName;
                        _perm.Update(currentInfo);
                        break;
                    case "3":
                        Console.WriteLine("Enter new Contract: ");
                        var UContract = Console.ReadLine();
                        if (UContract == "P" || UContract == "p")
                        {_perm.GetEmployee(inputID).Contract = ContractType.Permanent;}
                        else if (UContract == "T" || UContract == "t")
                        { _perm.GetEmployee(inputID).Contract = ContractType.Temporary;}
                        _perm.Update(currentInfo);
                        break;
                    case "4":
                        Console.WriteLine("Enter new Annual Salary: ");
                        var UAnnualSalary = Convert.ToInt32(Console.ReadLine());
                        _perm.GetEmployee(inputID).AnnualSalary = UAnnualSalary;
                        _perm.Update(currentInfo); 
                        break;
                    case "5":
                        Console.WriteLine("Enter new Bonus: ");
                        var UAnnualBonus = Convert.ToInt32(Console.ReadLine());
                        _perm.GetEmployee(inputID).AnnualBonus = UAnnualBonus;
                        _perm.Update(currentInfo);
                        break;
                    case "6":
                        Console.WriteLine("Enter new Hours Worked: ");
                        var UHoursWorked = Convert.ToInt32(Console.ReadLine());
                        _perm.GetEmployee(inputID).HoursWorked = UHoursWorked;
                        _perm.Update(currentInfo);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine(string.Concat(_perm.GetEmployee(inputID)));
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
            Console.WriteLine(string.Concat(_temp.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(_perm.GetEmployee(inputID)));
            Console.WriteLine("Y / N");
            var yesno = Console.ReadLine();
            if (yesno == "Y" || yesno == "y")
            {
                Console.WriteLine("Removing entry...");
                Console.WriteLine(string.Concat(_temp.Delete(inputID)));
                Console.WriteLine(string.Concat(_perm.Delete(inputID)));
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
                employee.Id = new Random().Next(0, 100);
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

                Console.WriteLine(_perm.Create(employee));             
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

                Console.WriteLine(_temp.Create(tempEmployee));
            }
            else { Console.WriteLine("Invalid Input"); }

        }

        public static void generateReport()
        {
            PermanentEmployee employee = new PermanentEmployee();

            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine("\n-----------------------Permanent Staff-----------------------\n");
            Console.WriteLine(string.Concat(_perm.GetAll()));
            Console.WriteLine("\n-----------------------Temporary Staff-----------------------\n");
            Console.WriteLine(string.Concat(_temp.GetAll()));
        }

        public static void generateStaffPay()
        {
            Console.Clear();
            Console.WriteLine("\t\tTPR Pay calculator program v.1");
            Console.WriteLine(Environment.NewLine + "Enter ID: ");
            int inputID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Concat(_perm.GetEmployee(inputID)));
            Console.WriteLine(string.Concat(_temp.GetEmployee(inputID)));

            Console.WriteLine("\nWhat would you like to do next? \n1: Calculate Total \n2: Calculate hourly wage \n3: Exit");
            var Response = Console.ReadLine();
            if ((_perm.GetEmployee(inputID).Contract == ContractType.Permanent))
            {
                switch (Response)
                {
                    case "1":
                        Console.WriteLine(string.Concat(_permCalc.TotalPay(_perm.GetEmployee(inputID).AnnualSalary, _perm.GetEmployee(inputID).AnnualBonus)));
                        break;
                    case "2":
                        Console.WriteLine(string.Concat(_permCalc.HourlyRate(_perm.GetEmployee(inputID).AnnualSalary, _perm.GetEmployee(inputID).HoursWorked)));
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
            else if ((_temp.GetEmployee(inputID).Contract == ContractType.Temporary))
            {
                switch (Response)
                {
                    case "1":
                        Console.WriteLine(string.Concat(_tempCalc.TotalPay(_temp.GetEmployee(inputID).WeeksWorked, _temp.GetEmployee(inputID).DayRate)));
                        break;
                    case "2":
                        Console.WriteLine(string.Concat(_tempCalc.HourlyRate(_temp.GetEmployee(inputID).DayRate)));
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