// Enum for Course Types
var CourseType;
(function (CourseType) {
    CourseType["Angular"] = "Angular";
    CourseType["NodeJS"] = "Node.js";
    CourseType["FullStack"] = "FullStack";
})(CourseType || (CourseType = {}));
// Enum for Course Category
var CourseCategory;
(function (CourseCategory) {
    CourseCategory["FrontEnd"] = "Front-End";
    CourseCategory["BackEnd"] = "Back-End";
    CourseCategory["FullStack"] = "Full-Stack";
})(CourseCategory || (CourseCategory = {}));
// Class to manage student enrollment
var Student = /** @class */ (function () {
    function Student(name, age, courseName, knowsHTML) {
        this.name = name;
        this.age = age;
        this.courseName = courseName;
        this.knowsHTML = knowsHTML;
        this.courseCategory = this.determineCategory();
        this.enrollmentStatus = this.checkEligibility();
    }
    Student.prototype.determineCategory = function () {
        switch (this.courseName) {
            case CourseType.Angular:
                return CourseCategory.FrontEnd;
            case CourseType.NodeJS:
                return CourseCategory.BackEnd;
            case CourseType.FullStack:
                return CourseCategory.FullStack;
        }
    };
    Student.prototype.checkEligibility = function () {
        if (this.age < 18) {
            return "Not Eligible";
        }
        if (this.courseName === CourseType.Angular && !this.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    };
    Student.prototype.displaySummary = function () {
        console.log("Student Name: ".concat(this.name));
        console.log("Age: ".concat(this.age));
        console.log("Course: ".concat(this.courseName));
        console.log("Knows HTML: ".concat(this.knowsHTML));
        console.log("Course Category: ".concat(this.courseCategory));
        console.log("Enrollment Status: ".concat(this.enrollmentStatus));
        console.log('------------------------');
    };
    return Student;
}());
// Function to display all enrollments
function displayEnrollments(students) {
    for (var _i = 0, students_1 = students; _i < students_1.length; _i++) {
        var student = students_1[_i];
        student.displaySummary();
    }
}
// Sample Data
var enrollments = [
    new Student("Sneha", 20, CourseType.Angular, true),
    new Student("Karan", 17, CourseType.NodeJS, false),
    new Student("Riya", 22, CourseType.Angular, false),
    new Student("Aman", 25, CourseType.FullStack, true)
];
// Display all enrollment summaries
displayEnrollments(enrollments);
