// 120. LINQ: Sorting with .OrderBy()
/*
    Sorting lists manually is a nightmare. LINQ makes it a one-liner!
    - .OrderBy() sorts ascending (A-Z, 0-9)
    - .OrderByDescending() sorts descending (Z-A, 9-0)
    - .ThenBy() allows you to add secondary sorting rules!
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Zack", Grade = 85 },
            new Student { Name = "Alice", Grade = 95 },
            new Student { Name = "Bob", Grade = 85 },
            new Student { Name = "Charlie", Grade = 70 }
        };

        Console.WriteLine("--- OrderBy (Ascending) ---");
        // Sort alphabetically by Name
        var sortedByName = students.OrderBy(s => s.Name);
        foreach (var s in sortedByName) Console.WriteLine($"{s.Name}: {s.Grade}");

        Console.WriteLine("\n--- OrderByDescending (Descending) ---");
        // Sort by Grade (Highest first)
        var sortedByGrade = students.OrderByDescending(s => s.Grade);
        foreach (var s in sortedByGrade) Console.WriteLine($"{s.Name}: {s.Grade}");

        Console.WriteLine("\n--- Chaining Sorts (ThenBy) ---");
        // Sort by Grade descending. If grades are TIED, sort alphabetically by Name!
        var complexSort = students
                            .OrderByDescending(s => s.Grade)
                            .ThenBy(s => s.Name); // Secondary sort!

        foreach (var s in complexSort)
        {
            Console.WriteLine($"{s.Name}: {s.Grade}");
        }
    }
}
