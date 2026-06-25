// 127. LINQ: Joining Data (.Join)
/*
    Just like an SQL INNER JOIN!
    It allows you to combine two different lists based on a common matching key.
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; } // The Foreign Key
}

public class Department
{
    public int Id { get; set; } // The Primary Key
    public string DeptName { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        // List 1: Departments
        List<Department> departments = new List<Department>
        {
            new Department { Id = 1, DeptName = "Computer Science" },
            new Department { Id = 2, DeptName = "Mathematics" }
        };

        // List 2: Students
        List<Student> students = new List<Student>
        {
            new Student { Id = 101, Name = "Sony", DepartmentId = 1 },
            new Student { Id = 102, Name = "Alice", DepartmentId = 2 },
            new Student { Id = 103, Name = "Bob", DepartmentId = 1 }
        };

        // We want a list of Students with their ACTUAL Department Name, not just the ID!
        var studentDetails = students.Join(
            departments,                           // 1. The list to join with
            student => student.DepartmentId,       // 2. The key from List 1 (Student)
            dept => dept.Id,                       // 3. The key from List 2 (Department)
            (student, dept) => new                 // 4. The result we want to project
            {
                StudentName = student.Name,
                DepartmentName = dept.DeptName
            }
        );

        Console.WriteLine("--- Student Directory ---");
        foreach (var item in studentDetails)
        {
            Console.WriteLine($"{item.StudentName} studies {item.DepartmentName}");
        }
    }
}
