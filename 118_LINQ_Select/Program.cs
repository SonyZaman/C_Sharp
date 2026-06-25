// 118. LINQ: Projecting with .Select()
/*
    The .Select() method is used to TRANSFORM (or "project") data.
    It takes every item in a list, applies some logic to it, and creates a brand new list!
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Simple Transformation (Numbers) ---");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        
        // Take every number and multiply it by 10
        var multipliedNumbers = numbers.Select(n => n * 10);

        foreach (int num in multipliedNumbers)
        {
            Console.WriteLine(num); // 10, 20, 30, 40, 50
        }

        Console.WriteLine("\n--- 2. Simple Transformation (Strings) ---");
        List<string> words = new List<string> { "hello", "world" };
        
        // Take every string and convert it to UPPERCASE
        var upperWords = words.Select(w => w.ToUpper());
        
        foreach (string word in upperWords)
        {
            Console.WriteLine(word); // HELLO, WORLD
        }

        Console.WriteLine("\n--- 3. Advanced Transformation (Objects) ---");
        // Often, we use Select() to pluck out specific data from complex objects!
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Sony", Department = "IT", Salary = 80000 },
            new Employee { Name = "Maysha", Department = "HR", Salary = 75000 }
        };

        // We have a list of Employees, but we ONLY want a list of their Names
        var justNames = employees.Select(emp => emp.Name);

        foreach (string name in justNames)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n--- 4. Creating Anonymous Objects ---");
        // We can use Select to instantly create brand new, smaller objects!
        var nameAndSalary = employees.Select(emp => new { emp.Name, emp.Salary });

        foreach (var info in nameAndSalary)
        {
            Console.WriteLine($"{info.Name} makes ${info.Salary}");
        }
    }
}
