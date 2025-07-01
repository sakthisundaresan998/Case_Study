// Enum for Course Types
enum CourseType {
  Angular = "Angular",
  NodeJS = "Node.js",
  FullStack = "FullStack"
}

// Enum for Course Category
enum CourseCategory {
  FrontEnd = "Front-End",
  BackEnd = "Back-End",
  FullStack = "Full-Stack"
}

// Interface for Student
interface IStudent {
  name: string;
  age: number;
  courseName: CourseType;
  knowsHTML: boolean;
  courseCategory: CourseCategory;
  enrollmentStatus: string;
}

// Class to manage student enrollment
class Student implements IStudent {
  name: string;
  age: number;
  courseName: CourseType;
  knowsHTML: boolean;
  courseCategory: CourseCategory;
  enrollmentStatus: string;

  constructor(name: string, age: number, courseName: CourseType, knowsHTML: boolean) {
    this.name = name;
    this.age = age;
    this.courseName = courseName;
    this.knowsHTML = knowsHTML;
    this.courseCategory = this.determineCategory();
    this.enrollmentStatus = this.checkEligibility();
  }

  private determineCategory(): CourseCategory {
    switch (this.courseName) {
      case CourseType.Angular:
        return CourseCategory.FrontEnd;
      case CourseType.NodeJS:
        return CourseCategory.BackEnd;
      case CourseType.FullStack:
        return CourseCategory.FullStack;
    }
  }

  private checkEligibility(): string {
    if (this.age < 18) {
      return "Not Eligible";
    }

    if (this.courseName === CourseType.Angular && !this.knowsHTML) {
      return "Not Eligible";
    }

    return "Eligible";
  }

  public displaySummary(): void {
    console.log(`Student Name: ${this.name}`);
    console.log(`Age: ${this.age}`);
    console.log(`Course: ${this.courseName}`);
    console.log(`Knows HTML: ${this.knowsHTML}`);
    console.log(`Course Category: ${this.courseCategory}`);
    console.log(`Enrollment Status: ${this.enrollmentStatus}`);
    console.log('------------------------');
  }
}

// Function to display all enrollments
function displayEnrollments(students: Student[]): void {
  for (const student of students) {
    student.displaySummary();
  }
}

// Sample Data
const enrollments: Student[] = [
  new Student("Sneha", 20, CourseType.Angular, true),
  new Student("Karan", 17, CourseType.NodeJS, false),
  new Student("Riya", 22, CourseType.Angular, false),
  new Student("Aman", 25, CourseType.FullStack, true)
];

// Display all enrollment summaries
displayEnrollments(enrollments);
