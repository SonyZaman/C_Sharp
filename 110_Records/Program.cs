// 110. Records (Immutable Data Models)
/*
    Introduced in C# 9, a 'record' is a special type of class designed specifically for data.
    1. They are "Immutable" by default (their properties cannot be changed after creation).
    2. They automatically compare objects by their VALUES, not by their memory references!
*/
using System;

// This single line creates a complete class with a Constructor, Read-only Properties, and a ToString() method!
public record Person(string FirstName, string LastName, int Age);

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Creating Records ---");
        Person p1 = new Person("Sony", "Zaman", 22);
        
        // Records have built-in, beautiful ToString() formatting!
        Console.WriteLine(p1); 

        // p1.Age = 25; // ERROR! Records are immutable. You cannot change them.

        Console.WriteLine("\n--- Non-Destructive Mutation ('with' expression) ---");
        // If you want to "change" a record, you create a COPY of it using the 'with' keyword
        // This copies everything from p1, but changes the Age!
        Person p2 = p1 with { Age = 25 }; 
        Console.WriteLine(p2);

        Console.WriteLine("\n--- Value-Based Equality ---");
        Person p3 = new Person("Sony", "Zaman", 22);

        // If these were normal Classes, this would be FALSE because they are different objects in memory.
        // Because they are Records, this is TRUE because their internal values match perfectly!
        Console.WriteLine($"Does p1 equal p3? {p1 == p3}");
    }
}
