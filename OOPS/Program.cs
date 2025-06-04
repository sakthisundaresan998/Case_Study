using System;

namespace EmployeeManagement
{
    // Step 1: Base Employee class
    public class Employee
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
    }

    // Step 2: Generic Interface
    public interface IEmployee<T> where T : Employee
    {
        string PrintEmployeeDetails(T employee);
    }

    // Step 3: Full Time Interface
    public interface IFullTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Hra { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }

        double CalculateSalary();
    }

    // Step 4: Part Time Interface
    public interface IPartTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }

        double CalculateSalary();
    }

    // Step 5: FullTimeEmployee class
    public class FullTimeEmployee : Employee, IFullTimeEmployee
    {
        public double Basic { get; set; }
        public double Hra { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Hra = Basic * 0.15;
            Da = Basic * 0.10;
            NetSalary = Basic + Hra + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"FTE: {employee.EmpCode}  {employee.EmpName}  {employee.Email}  {employee.DeptName}  {employee.Location}  Net Salary: {NetSalary:C}";
        }
    }

    // Step 6: PartTimeEmployee class
    public class PartTimeEmployee : Employee, IPartTimeEmployee
    {
        public double Basic { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Da = Basic * 0.05;
            NetSalary = Basic + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"PTE: {employee.EmpCode}  {employee.EmpName}  {employee.Email}  {employee.DeptName}  {employee.Location}  Net Salary: {NetSalary:C}";
        }
    }

    // Step 7: Main method
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Employee Management System ===\n");

            // a. Base Employee (just for reference)
            Employee emp = new Employee
            {
                EmpCode = 1,
                EmpName = "Generic Employee",
                Email = "generic@abc.com",
                DeptName = "General",
                Location = "Head Office"
            };

            // b. Part-Time Employee
            PartTimeEmployee pte = new PartTimeEmployee
            {
                EmpCode = 101,
                EmpName = "John Doe",
                Email = "john.pte@abc.com",
                DeptName = "Support",
                Location = "Remote",
                Basic = 8000
            };

            pte.CalculateSalary();
            Console.WriteLine(pte.PrintEmployeeDetails(pte));

            // c. Full-Time Employee
            FullTimeEmployee fte = new FullTimeEmployee
            {
                EmpCode = 201,
                EmpName = "Jane Smith",
                Email = "jane.fte@abc.com",
                DeptName = "Development",
                Location = "Bangalore",
                Basic = 30000
            };

            fte.CalculateSalary();
            Console.WriteLine(fte.PrintEmployeeDetails(fte));
        }
    }
}
