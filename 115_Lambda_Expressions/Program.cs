// 115. Lambda Expressions (=>)
/*
    Lambda Expressions are just a much shorter, cleaner syntax for Anonymous Methods.
    They use the "goes to" operator (=>).
    This is the foundation of modern C# and LINQ!
*/
using System;
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Lambda Syntax ---");

        // OLD WAY (Anonymous Method):
        // Func<int, int> squareOld = delegate(int x) { return x * x; };

        // NEW WAY (Lambda Expression):
        // Read as: "x goes to x times x"
        Func<int, int> square = x => x * x;
        
        Console.WriteLine($"Square of 5: {square(5)}");

        Console.WriteLine("\n--- Action Lambda (No return) ---");
        // If we have multiple lines, we still need { } braces
        Action<string, string> greet = (firstName, lastName) => 
        {
            Console.WriteLine($"Hello, {firstName} {lastName}!");
        };
        greet("Sony", "Zaman");

        Console.WriteLine("\n--- Lambdas in Collections (Real World Use) ---");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // The FindAll method requires a Predicate (a function that returns true/false)
        // We write a tiny Lambda expression to filter the list!
        List<int> evenNumbers = numbers.FindAll(n => n % 2 == 0);

        Console.WriteLine("Even numbers found:");
        foreach (int n in evenNumbers)
        {
            Console.Write($"{n} ");
        }
        Console.WriteLine();
    }
}
