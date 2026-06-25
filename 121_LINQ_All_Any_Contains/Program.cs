// 121. LINQ: Quantifiers (.All, .Any, .Contains)
/*
    Quantifiers return a simple 'bool' (true or false).
    They are incredibly fast ways to check if data exists in a collection
    without having to loop through the whole thing yourself.
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public int Score { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 2, 4, 6, 8, 10 };

        Console.WriteLine("--- 1. Contains() ---");
        // .Contains checks if an EXACT value exists in a simple list.
        bool hasEight = numbers.Contains(8);
        bool hasNine = numbers.Contains(9);
        
        Console.WriteLine($"Contains 8? {hasEight}"); // True
        Console.WriteLine($"Contains 9? {hasNine}"); // False


        Console.WriteLine("\n--- 2. Any() ---");
        // .Any checks if AT LEAST ONE item matches a condition (using a lambda).
        List<Student> classA = new List<Student>
        {
            new Student { Name = "Alice", Score = 85 },
            new Student { Name = "Bob", Score = 40 }, // Bob failed!
            new Student { Name = "Charlie", Score = 95 }
        };

        // Does ANY student have a score below 50?
        bool anyoneFailed = classA.Any(s => s.Score < 50);
        Console.WriteLine($"Did anyone fail? {anyoneFailed}"); // True (Because of Bob)


        Console.WriteLine("\n--- 3. All() ---");
        // .All checks if EVERY SINGLE item matches a condition.
        List<Student> classB = new List<Student>
        {
            new Student { Name = "Dave", Score = 80 },
            new Student { Name = "Eve", Score = 90 },
            new Student { Name = "Frank", Score = 85 }
        };

        // Did ALL students get a score of 80 or higher?
        bool everyonePassed = classB.All(s => s.Score >= 80);
        Console.WriteLine($"Did everyone pass? {everyonePassed}"); // True
    }
}
