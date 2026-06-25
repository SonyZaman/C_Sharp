// 61. Readonly
/*
    The 'readonly' keyword is a modifier that you can use on fields. 
    When a field declaration includes a readonly modifier, assignments to that field 
    can ONLY occur as part of the declaration or in a constructor of the same class.
    This is very useful for values that shouldn't change once the object is created.
*/
using System;

class Person
{
    // A readonly field assigned at declaration
    public readonly string Species = "Human";

    // A readonly field assigned in the constructor
    public readonly int IdNumber;

    public string Name;

    // Constructor
    public Person(int id, string name)
    {
        IdNumber = id; // This is ALLOWED because we are inside the constructor
        Name = name;
    }

    public void AttemptToChangeId()
    {
        // IdNumber = 999; // ERROR! A readonly field cannot be assigned to from standard methods
        Console.WriteLine($"Cannot change ID from a method. ID is fixed at: {IdNumber}");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // We set the readonly IdNumber via the constructor
        Person p1 = new Person(1001, "Sony");

        Console.WriteLine($"Name: {p1.Name}");
        Console.WriteLine($"ID: {p1.IdNumber}");
        Console.WriteLine($"Species: {p1.Species}");

        Console.WriteLine("\n--- Modifying Fields ---");
        
        // Modifying regular field
        p1.Name = "Anisul";
        Console.WriteLine($"Updated Name: {p1.Name}");

        // Attempting to modify readonly field outside constructor
        // p1.IdNumber = 2002; // This would cause a compile-time error!
        // p1.Species = "Alien"; // This would also cause a compile-time error!
        
        p1.AttemptToChangeId();
    }
}
