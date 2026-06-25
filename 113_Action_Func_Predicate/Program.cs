// 113. Built-In Delegates (Action, Func, Predicate)
/*
    Creating custom delegates using the 'delegate' keyword every time is annoying.
    C# provides 3 built-in Generic delegates that cover 99% of use cases:
    
    1. Action<T>: Takes arguments, returns NOTHING (void).
    2. Func<T, TResult>: Takes arguments, returns a VALUE (TResult).
    3. Predicate<T>: Takes ONE argument, returns a BOOLEAN (true/false).
*/
using System;

class Test
{
    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Action (Returns void) ---");
        // Action<string> points to a method that takes a string and returns void
        Action<string> logMessage = PrintMessage;
        logMessage("Hello from Action!");

        Console.WriteLine("\n--- 2. Func (Returns a value) ---");
        // Func<int, int, int> means: takes two ints, and RETURNS an int (the last parameter is always the return type)
        Func<int, int, int> calculate = AddNumbers;
        int result = calculate(50, 25);
        Console.WriteLine($"Result from Func: {result}");

        Console.WriteLine("\n--- 3. Predicate (Returns boolean) ---");
        // Predicate<int> means: takes an int, and ALWAYS returns a boolean
        Predicate<int> checkEven = IsEven;
        Console.WriteLine($"Is 10 even? {checkEven(10)}");
        Console.WriteLine($"Is 7 even? {checkEven(7)}");
    }
}
