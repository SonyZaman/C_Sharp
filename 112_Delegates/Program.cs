// 112. Delegates
/*
    A delegate is a "type-safe function pointer". 
    In simple terms: It is a variable that holds a METHOD instead of data!
    This allows you to pass methods around as arguments.
*/
using System;

class Test
{
    // 1. Define the Delegate signature (Must match the methods it will point to)
    public delegate void MathOperation(int a, int b);

    // 2. Define some methods that match that signature (void return, two int parameters)
    public static void Add(int a, int b)
    {
        Console.WriteLine($"Addition: {a} + {b} = {a + b}");
    }

    public static void Multiply(int a, int b)
    {
        Console.WriteLine($"Multiplication: {a} * {b} = {a * b}");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Storing Methods in Variables ---");
        
        // 3. Create a delegate variable and point it to the Add method
        MathOperation operation = Add;
        operation(10, 5); // Executes Add(10, 5)

        // Point the exact same variable to the Multiply method!
        operation = Multiply;
        operation(10, 5); // Executes Multiply(10, 5)

        Console.WriteLine("\n--- Multicast Delegates ---");
        // We can chain multiple methods together using +=
        MathOperation multiOp = Add;
        multiOp += Multiply;

        // This will execute BOTH Add and Multiply sequentially!
        multiOp(20, 2);
    }
}
