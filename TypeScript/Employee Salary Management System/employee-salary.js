// Enum for departments
var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
// Class to manage Employee data
var Employee = /** @class */ (function () {
    function Employee(name, age, department, baseSalary) {
        this.name = name;
        this.age = age;
        this.department = department;
        this.baseSalary = baseSalary;
        this.netSalary = this.calculateNetSalary();
        this.category = this.categorizeEmployee();
    }
    Employee.prototype.calculateNetSalary = function () {
        var bonusPercentage = 0;
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
    };
    Employee.prototype.categorizeEmployee = function () {
        if (this.netSalary >= 80000) {
            return "High Earner";
        }
        else if (this.netSalary >= 50000) {
            return "Mid Earner";
        }
        else {
            return "Low Earner";
        }
    };
    Employee.prototype.displayDetails = function () {
        console.log("Employee Name: ".concat(this.name));
        console.log("Age: ".concat(this.age));
        console.log("Department: ".concat(this.department));
        console.log("Base Salary: \u20B9".concat(this.baseSalary));
        console.log("Net Salary (with bonus): \u20B9".concat(this.netSalary));
        console.log("Category: ".concat(this.category));
        console.log('------------------------');
    };
    return Employee;
}());
// Function to display report for all employees
function displayEmployeeReport(employees) {
    for (var _i = 0, employees_1 = employees; _i < employees_1.length; _i++) {
        var emp = employees_1[_i];
        emp.displayDetails();
    }
}
// Sample employee data
var employees = [
    new Employee("Ravi", 28, Department.IT, 60000),
    new Employee("Priya", 32, Department.HR, 48000),
    new Employee("Arjun", 26, Department.Sales, 85000),
];
// Show employee report
displayEmployeeReport(employees);
