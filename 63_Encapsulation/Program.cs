// 63. Encapsulation
/* 
    It refers to the bundling of data (fields) and the methods that operate on that data into a single unit (a class).
    It restricts direct access to some of an object's components (using private access modifiers) 
    and prevents accidental modification of data.
    To access or modify the private data securely, public methods (getters and setters) are provided.
*/
using System;

class Person
{
    // Private fields: data is hidden from outside the class
    private string name;
    private int age;

    // Public setter method for name
    public void SetName(string n)
    {
        name = n;
    }

    // Public getter method for name
    public string GetName()
    {
        return name;
    }

    // Public setter method for age with validation
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

    // Public getter method for age
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
        
        // p1.name = "Sony"; // This would cause an error because 'name' is private
        
        // Using public methods to access private data (Encapsulation)
        p1.SetName("Sony");
        p1.SetAge(22);

        Console.WriteLine($"Name: {p1.GetName()}");
        Console.WriteLine($"Age: {p1.GetAge()}");

        Console.WriteLine("\n--- Attempting invalid data update ---");
        // Trying to set an invalid age
        p1.SetAge(-5); // This will trigger the validation message and won't change the age
        
        Console.WriteLine($"Age remains unchanged: {p1.GetAge()}");
    }
}
