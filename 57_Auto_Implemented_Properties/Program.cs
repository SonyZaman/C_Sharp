// 57. Auto-Implemented Properties
/*
    Auto-Implemented Properties make property-declaration more concise when no additional 
    logic (like validation) is required in the property accessors. 
    The C# compiler automatically creates a private, anonymous backing field 
    that can only be accessed through the property's get and set accessors.
*/
using System;

class Person
{
    // Auto-implemented property
    // Notice how we don't need to declare private fields like 'private string name;'
    public string Name { get; set; }
    
    public int Age { get; set; }

    // Auto-implemented property with an initial default value (C# 6.0 and later)
    public string Country { get; set; } = "Bangladesh";
}

class Test
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();

        // Assigning values to auto-implemented properties
        p1.Name = "Sony";
        p1.Age = 22;

        // Reading values from auto-implemented properties
        Console.WriteLine($"Name: {p1.Name}");
        Console.WriteLine($"Age: {p1.Age}");
        
        // This will print the default initialized value since we haven't changed it
        Console.WriteLine($"Country: {p1.Country}");

        // Updating the property
        p1.Country = "Canada";
        Console.WriteLine($"Updated Country: {p1.Country}");
    }
}
