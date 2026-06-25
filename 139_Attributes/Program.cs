// 139. Attributes (Metadata)
/*
    Attributes are declarative tags (metadata) that you place above classes or methods.
    They don't change what the code *does*, but they tell the compiler or frameworks 
    *how* to treat the code. You will see this everywhere in ASP.NET Core!
*/
using System;

class Calculator
{
    // 1. The built-in [Obsolete] attribute
    // This tells other developers (and the compiler) that this method is old
    // and they should stop using it! It will draw a green squiggly line under it in VS Code.
    [Obsolete("This method is slow. Please use the AddFast() method instead.")]
    public int AddSlow(int a, int b)
    {
        return a + b;
    }

    public int AddFast(int a, int b)
    {
        return a + b;
    }
}

// 2. Creating a Custom Attribute
// You can define your own tags by inheriting from System.Attribute!
[AttributeUsage(AttributeTargets.Class)] // This means it can ONLY be placed above a Class
public class DeveloperInfoAttribute : Attribute
{
    public string DeveloperName { get; }
    public string LastModified { get; }

    public DeveloperInfoAttribute(string name, string date)
    {
        DeveloperName = name;
        LastModified = date;
    }
}

// Applying our custom attribute to a class
[DeveloperInfo("Sony Zaman", "2026-10-31")]
class AdvancedSystem
{
    public void RunSystem()
    {
        Console.WriteLine("System running...");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        
        // This works, but it will trigger a compiler warning because of [Obsolete]
        int result = calc.AddSlow(5, 5); 
        Console.WriteLine($"Result: {result}");

        Console.WriteLine("\nAttributes are often read by Reflection to automatically wire up APIs!");
    }
}
