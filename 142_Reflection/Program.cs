// 142. Reflection
/*
    Reflection is the ultimate black magic in C#.
    It allows your code to inspect ITSELF while the program is running!
    You can dynamically look at a class, find out what properties it has, 
    and even execute its methods without ever typing their names!
*/
using System;
using System.Reflection; // The magic namespace

public class SecretAgent
{
    public string Name { get; set; } = "James Bond";
    private string _secretCode = "007"; // PRIVATE field!

    public void ExecuteMission()
    {
        Console.WriteLine("Mission Executed!");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Inspecting a Class dynamically ---");
        
        // Get the "Blueprint" (Type) of the SecretAgent class
        Type myType = typeof(SecretAgent);
        
        Console.WriteLine($"Class Name: {myType.Name}");
        
        Console.WriteLine("\nPublic Properties:");
        foreach (PropertyInfo prop in myType.GetProperties())
        {
            Console.WriteLine($" - {prop.Name} (Type: {prop.PropertyType.Name})");
        }

        Console.WriteLine("\nMethods:");
        foreach (MethodInfo method in myType.GetMethods())
        {
            // It will also list built-in methods like ToString() and GetHashCode()
            Console.WriteLine($" - {method.Name}");
        }


        Console.WriteLine("\n--- 2. Breaking the rules (Accessing Private Data) ---");
        
        SecretAgent agent = new SecretAgent();
        // agent._secretCode is normally IMPOSSIBLE to access here because it's private.

        // Use Reflection to hunt down the private field!
        FieldInfo secretField = myType.GetField("_secretCode", BindingFlags.NonPublic | BindingFlags.Instance);
        
        // Extract the value from our specific 'agent' object
        string stolenCode = (string)secretField.GetValue(agent);
        
        Console.WriteLine($"Stolen Private Code: {stolenCode}");
    }
}
