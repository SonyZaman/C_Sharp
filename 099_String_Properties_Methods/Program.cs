// 099. String Properties and Methods
/*
    A 'string' in C# is essentially an array of characters. 
    Because of this, strings have many powerful built-in methods similar to arrays!
*/
using System;

class Test
{
    public static void Main(string[] args)
    {
        string text = "   Hello C# Developers!   ";
        Console.WriteLine($"Original Text: '{text}'");

        Console.WriteLine("\n--- Basic String Properties ---");
        Console.WriteLine($"Length: {text.Length}");

        Console.WriteLine("\n--- Formatting Methods ---");
        Console.WriteLine($"ToUpper: {text.ToUpper()}");
        Console.WriteLine($"ToLower: {text.ToLower()}");
        
        // Trim() removes all leading and trailing whitespace (very useful for user input!)
        string trimmed = text.Trim();
        Console.WriteLine($"Trimmed: '{trimmed}'");

        Console.WriteLine("\n--- Searching Methods ---");
        Console.WriteLine($"Contains 'C#': {trimmed.Contains("C#")}");
        Console.WriteLine($"Starts with 'Hello': {trimmed.StartsWith("Hello")}");
        Console.WriteLine($"Index of 'D': {trimmed.IndexOf("D")}");

        Console.WriteLine("\n--- Modification Methods ---");
        // Replace 'Hello' with 'Welcome'
        string replaced = trimmed.Replace("Hello", "Welcome");
        Console.WriteLine($"Replaced: '{replaced}'");

        // Substring(startIndex, length) extracts a portion of the string
        string substring = trimmed.Substring(6, 2); 
        Console.WriteLine($"Substring (index 6, length 2): '{substring}'"); // Extracts "C#"
    }
}
