// 056. Properties
/*
    Properties provide a flexible mechanism to read, write, or compute the value of a private field.
    Properties can be used as if they are public data members, but they are actually special methods 
    called accessors (get and set). This allows you to add validation logic while keeping the syntax clean.
*/
using System;

class Person
{
    // Private backing fields
    private string name;
    private int age;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; } // 'value' is a special keyword representing the assigned value
    }

    // Property for Age with validation
    public int Age
    {
        get { return age; }
        set 
        { 
            if (value >= 0)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Error: Age cannot be negative.");
            }
        }
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();

        // Using properties looks exactly like using public variables
        p1.Name = "Sony";
        p1.Age = 22;

        Console.WriteLine($"Name: {p1.Name}");
        Console.WriteLine($"Age: {p1.Age}");

        Console.WriteLine("\n--- Attempting invalid data update ---");
        
        // Trying to set an invalid age
        p1.Age = -5; // This triggers the validation inside the 'set' block of the Age property
        
        Console.WriteLine($"Age remains unchanged: {p1.Age}");
    }
}
