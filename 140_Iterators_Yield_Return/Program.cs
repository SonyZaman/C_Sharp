// 140. Iterators (yield return)
/*
    'yield return' is the black-magic behind LINQ.
    Normally, a method returns once and dies. 
    A method with 'yield return' pauses its execution, hands a value back to the caller,
    and then RESUMES from exactly where it left off the next time it's asked!
*/
using System;
using System.Collections.Generic;

class Test
{
    // The Old Way: Building an entire list in memory before returning it.
    // If we wanted 1 Million numbers, this would crash our RAM!
    public static List<int> GenerateNumbersNormally()
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"[Normal] Generating {i}");
            numbers.Add(i);
        }
        return numbers;
    }

    // The Modern Way: Using Iterators (yield return)
    // This returns an IEnumerable. It calculates exactly ONE number, pauses, and waits.
    public static IEnumerable<int> GenerateNumbersWithYield()
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"[Yield] Generating {i}");
            yield return i; // Pause here! Hand the number back, and wait to be called again!
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Normal Return ---");
        // It generates ALL the numbers immediately, BEFORE the foreach loop even starts!
        var normalList = GenerateNumbersNormally();
        foreach (var num in normalList)
        {
            Console.WriteLine($"Main Method Received: {num}");
        }

        Console.WriteLine("\n--- 2. Yield Return (Deferred Execution) ---");
        // It generates NOTHING until the foreach loop specifically asks for it!
        var yieldList = GenerateNumbersWithYield();
        foreach (var num in yieldList)
        {
            // It ping-pongs back and forth between this loop and the Generate method!
            Console.WriteLine($"Main Method Received: {num}");
        }
    }
}
