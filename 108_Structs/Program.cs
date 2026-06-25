// 108. Structs (Value Types)
/*
    A 'struct' looks exactly like a 'class', but it has one massive difference:
    It is a "Value Type" (stored on the Stack), while a 'class' is a "Reference Type" (stored on the Heap).
    
    Structs are meant to be used for small, lightweight data structures (like Coordinates, Colors, Points)
    because they are created and destroyed much faster than classes.
*/
using System;

// Creating a struct
public struct Point
{
    public int X;
    public int Y;

    // Structs can have constructors, just like classes!
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"Point coordinates: ({X}, {Y})");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // 1. Creating a struct using 'new'
        Point p1 = new Point(10, 20);
        p1.Display();

        // 2. The Magic of Value Types (Deep Copy by default!)
        Console.WriteLine("\n--- Structs vs Classes: Copy Behavior ---");
        Point p2 = p1; // Because Point is a struct, this actually COPIES the data, not just the reference!
        
        p2.X = 999; // Changing p2...

        // p1 remains totally unaffected because p2 is a completely separate copy in memory!
        Console.WriteLine($"p1.X remains: {p1.X}"); // Outputs 10
        Console.WriteLine($"p2.X is now: {p2.X}");  // Outputs 999
    }
}
