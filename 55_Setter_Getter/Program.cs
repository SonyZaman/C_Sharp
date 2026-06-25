// 55. Setter and Getter Methods
/*
    Before we look at "Properties" (which are a modern C# feature), 
    it is important to understand the traditional "Setter" and "Getter" methods.
    
    We use these to protect our variables (making them private) and controlling 
    how outside code can access or change them.
*/
using System;

class Person
{
    // 1. We make the fields PRIVATE so they cannot be accessed directly
    private string name;
    private int age;

    // 2. We create a public SETTER method to assign a value safely
    public void SetName(string n)
    {
        name = n;
    }

    // 3. We create a public GETTER method to retrieve the value
    public string GetName()
    {
        return name;
    }

    // Setter for age with validation logic!
    public void SetAge(int a)
    {
        if (a >= 0)
        {
            age = a;
        }
        else
        {
            Console.WriteLine("Error: Age cannot be negative.");
        }
    }

    // Getter for age
    public int GetAge()
    {
        return age;
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();

        // p1.name = "Sony"; // This would cause an ERROR because 'name' is private!
        
        // Instead, we use the Setter
        p1.SetName("Sony");
        p1.SetAge(22);

        // And we use the Getter to retrieve the values
        Console.WriteLine($"Name is: {p1.GetName()}");
        Console.WriteLine($"Age is: {p1.GetAge()}");

        // The power of Setters: Validation!
        Console.WriteLine("\nTrying to set age to -5...");
        p1.SetAge(-5); 
        
        // The age was protected from invalid data!
        Console.WriteLine($"Age is still: {p1.GetAge()}");
    }
}
