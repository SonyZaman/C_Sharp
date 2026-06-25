// 137. JSON Serialization
/*
    JSON (JavaScript Object Notation) is the universal language of the internet.
    If your C# code needs to talk to a React website, an iPhone app, or a database,
    it must convert its C# Objects into JSON strings. 
    
    This is called "Serialization" (Object -> String) and "Deserialization" (String -> Object).
*/
using System;
using System.Text.Json; // The modern, ultra-fast built-in JSON library

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
        Console.WriteLine("--- 1. Serialization (Object to JSON) ---");
        Employee myEmp = new Employee { Name = "Sony Zaman", Department = "Engineering", Salary = 95000 };

        // Convert the C# Object into a raw JSON string
        var options = new JsonSerializerOptions { WriteIndented = true }; // Makes it look pretty!
        string jsonString = JsonSerializer.Serialize(myEmp, options);
        
        Console.WriteLine("This is what we send over the internet:");
        Console.WriteLine(jsonString);


        Console.WriteLine("\n--- 2. Deserialization (JSON to Object) ---");
        // Imagine we just received this raw string from a Web API over the internet.
        string receivedJson = @"{ ""Name"": ""Maysha"", ""Department"": ""HR"", ""Salary"": 85000 }";

        // Convert the raw string back into a real C# Object!
        Employee reconstructedEmp = JsonSerializer.Deserialize<Employee>(receivedJson);

        Console.WriteLine("Successfully converted string back to an object!");
        Console.WriteLine($"Accessing properties: {reconstructedEmp.Name} works in {reconstructedEmp.Department}.");
    }
}
