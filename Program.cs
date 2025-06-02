using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student { ID = 1, Name = "Alice" });
            students.Add(new Student { ID = 2, Name = "Bob" });
            students.Add(new Student { ID = 3, Name = "Charlie" });

            Console.WriteLine("All Students:");
            DisplayAll(students);

            Console.Write("\nEnter name to search: ");
            string searchName = Console.ReadLine();
            Student foundStudent = students.FirstOrDefault(
                s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)
            );

            if (foundStudent != null)
            {
                Console.WriteLine($"Found: ID={foundStudent.ID}, Name={foundStudent.Name}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Console.Write("\nEnter name to remove: ");
            string removeName = Console.ReadLine();
            Student studentToRemove = students.FirstOrDefault(
                s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase)
            );

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found to remove.");
            }

            Console.WriteLine("\nUpdated List of Students:");
            DisplayAll(students);

            Console.WriteLine($"\nTotal number of students: {students.Count}");
        }

        static void DisplayAll(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
            }
        }
    }
}
