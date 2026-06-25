// 098. The 'params' Keyword (Variable Number of Arguments)
/*
    The 'params' keyword allows a method to accept an unlimited number of arguments.
    Behind the scenes, C# automatically bundles them into an array for you!
    
    Rule: A method can only have ONE 'params' keyword, and it MUST be the very last parameter.
*/
using System;

class Test
{
    // The 'params' keyword lets us pass comma-separated values directly instead of creating an array first!
    public static void PrintNames(params string[] names)
    {
        Console.WriteLine($"You passed {names.Length} names:");
        foreach (string name in names)
        {
            Console.WriteLine("- " + name);
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        // 1. Passing 3 arguments
        PrintNames("Sony", "Maysha", "John");

        // 2. Passing 5 arguments
        PrintNames("Alice", "Bob", "Charlie", "David", "Eve");

        // 3. Passing NO arguments! (It creates an empty array, it doesn't crash)
        PrintNames();
    }
}
