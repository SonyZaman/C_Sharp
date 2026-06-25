// 114. Anonymous Methods
/*
    Sometimes you need a tiny method for a delegate, but you don't want to create 
    a formal, named method inside your class. 
    You can create an "Anonymous Method" (a method without a name) directly inside the delegate variable!
*/
using System;

class Test
{
    public delegate void PrintDelegate(string message);

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Anonymous Methods ---");

        // Notice we do NOT have a separate PrintMessage() method in the class!
        // We write the method logic directly here using the 'delegate' keyword.
        PrintDelegate print = delegate (string msg)
        {
            Console.WriteLine($"Anonymous says: {msg}");
        };

        // Execute the anonymous method
        print("Hello World!");

        // Using Action with an anonymous method
        Action<int, int> addAndPrint = delegate (int a, int b)
        {
            Console.WriteLine($"Sum is: {a + b}");
        };

        addAndPrint(100, 250);
    }
}
