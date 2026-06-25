// 119. LINQ: Flattening with .SelectMany()
/*
    While .Select() creates a 1-to-1 transformation, 
    .SelectMany() FLATTENS collections (e.g. turning a List of Lists into a single flat List).
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public List<string> Skills { get; set; } // Notice the nested list!
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Simple Example (List of Lists) ---");
        // We have 3 separate lists of numbers
        List<int> list1 = new List<int> { 1, 2, 3 };
        List<int> list2 = new List<int> { 4, 5, 6 };
        List<int> list3 = new List<int> { 7, 8, 9 };

        // We put them all inside a "Master List"
        List<List<int>> masterList = new List<List<int>> { list1, list2, list3 };

        Console.WriteLine("The Problem using normal .Select():");
        // .Select() just returns exactly what you give it. We give it a List of Lists, so it returns a List of Lists.
        var withSelect = masterList.Select(list => list);
        
        foreach (List<int> sublist in withSelect)
        {
            Console.Write("A sub-list contains: ");
            foreach (int num in sublist) 
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nThe Solution using .SelectMany():");
        // .SelectMany() reaches inside the sub-lists and pulls out all the numbers into ONE flat list!
        var withSelectMany = masterList.SelectMany(list => list);
        
        Console.Write("One beautifully flat list: ");
        foreach (int num in withSelectMany)
        {
            Console.Write($"{num} "); // Prints: 1 2 3 4 5 6 7 8 9
        }
        Console.WriteLine();


        Console.WriteLine("\n\n--- 2. Advanced Example (Objects) ---");
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Sony", Skills = new List<string> { "C#", "SQL" } },
            new Employee { Name = "Maysha", Skills = new List<string> { "Communication", "Excel" } }
        };

        Console.WriteLine("\nThe Problem with .Select():");
        // If we use normal .Select(), we get a List of Lists (List<List<string>>).
        var listOfLists = employees.Select(emp => emp.Skills);
        
        foreach (var list in listOfLists)
        {
            Console.WriteLine("A list of skills:");
            foreach(var skill in list)
            {
                Console.WriteLine($" - {skill}");
            }
        }

        Console.WriteLine("\nThe Solution with .SelectMany():");
        // If we want a single, flat list of all skills across ALL employees, we use .SelectMany()!
        var flatSkillsList = employees.SelectMany(emp => emp.Skills);

        foreach (string skill in flatSkillsList)
        {
            Console.WriteLine($" - {skill}"); // Prints C#, SQL, Communication, Excel in one flat list!
        }
    }
}
