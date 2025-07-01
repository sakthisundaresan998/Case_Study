enum Department {
  HR = "HR",
  IT = "IT",
  Sales = "Sales"
}

// Interface for Employee
interface IEmployee {
  name: string;
  age: number;
  department: Department;
  baseSalary: number;
  netSalary: number;
  category: string;
}

// Class to manage Employee data
class Employee implements IEmployee {
  name: string;
  age: number;
  department: Department;
  baseSalary: number;
  netSalary: number;
  category: string;

  constructor(name: string, age: number, department: Department, baseSalary: number) {
    this.name = name;
    this.age = age;
    this.department = department;
    this.baseSalary = baseSalary;
    this.netSalary = this.calculateNetSalary();
    this.category = this.categorizeEmployee();
  }

  private calculateNetSalary(): number {
    let bonusPercentage = 0;

    switch (this.department) {
      case Department.HR:
        bonusPercentage = 0.10;
        break;
      case Department.IT:
        bonusPercentage = 0.15;
        break;
      case Department.Sales:
        bonusPercentage = 0.12;
        break;
    }

    return this.baseSalary + this.baseSalary * bonusPercentage;
  }

  private categorizeEmployee(): string {
    if (this.netSalary >= 80000) {
      return "High Earner";
    } else if (this.netSalary >= 50000) {
      return "Mid Earner";
    } else {
      return "Low Earner";
    }
  }

  public displayDetails(): void {
    console.log(`Employee Name: ${this.name}`);
    console.log(`Age: ${this.age}`);
    console.log(`Department: ${this.department}`);
    console.log(`Base Salary: ₹${this.baseSalary}`);
    console.log(`Net Salary (with bonus): ₹${this.netSalary}`);
    console.log(`Category: ${this.category}`);
    console.log('------------------------');
  }
}

// Function to display report for all employees
function displayEmployeeReport(employees: Employee[]): void {
  for (const emp of employees) {
    emp.displayDetails();
  }
}

// Sample employee data
const employees: Employee[] = [
  new Employee("Ravi", 28, Department.IT, 60000),
  new Employee("Priya", 32, Department.HR, 48000),
  new Employee("Arjun", 26, Department.Sales, 85000),
];

// Show employee report
displayEmployeeReport(employees);
