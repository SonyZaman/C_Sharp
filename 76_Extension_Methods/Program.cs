// 76. Extension Methods
/*
    Extension methods allow you to "add" new methods to existing types 
    (like 'string' or 'int' or even classes you didn't write!) without modifying the original code.
    
    Rules:
    1. The method must be inside a 'static class'.
    2. The method itself must be 'static'.
    3. The first parameter uses the 'this' keyword followed by the type you are extending.
*/
using System;

// 1. Must be a static class
public static class StringExtensions
{
    // 2. Must be a static method
    // 3. 'this string' means we are attaching this method to the built-in C# string type!
    public static int WordCount(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        
        string[] words = text.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}

class Test
{
    public static void Main(string[] args)
    {
        string sentence = "Hello world! I am learning advanced C# programming.";
        
        // WOW! We just added our own .WordCount() method directly to standard C# strings!
        int count = sentence.WordCount();
        
        Console.WriteLine($"The sentence is: {sentence}");
        Console.WriteLine($"It contains {count} words.");
    }
}
