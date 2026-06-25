// 111. Record Structs (C# 10 Feature)
/*
    A normal 'record' is a Reference Type (Class).
    A normal 'struct' is a Value Type (Struct).
    
    A 'record struct' combines the incredible performance of a Value Type 
    with the beautiful syntax and value-based equality of a Record!
*/
using System;

// 1. A Mutable Record Struct (Properties can be changed)
public record struct Point2D(double X, double Y);

// 2. An Immutable Record Struct (Properties CANNOT be changed)
public readonly record struct Color(int R, int G, int B);

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Mutable Record Struct ---");
        Point2D p1 = new Point2D(5.5, 10.2);
        Console.WriteLine(p1); // Free beautifully formatted ToString()
        
        p1.X = 100.5; // Valid! It is mutable.
        Console.WriteLine($"Modified p1: {p1}");

        Console.WriteLine("\n--- Readonly Record Struct ---");
        Color red = new Color(255, 0, 0);
        Console.WriteLine(red);

        // red.R = 0; // ERROR! It is readonly.

        Console.WriteLine("\n--- Value-Based Equality ---");
        Color c1 = new Color(0, 255, 0);
        Color c2 = new Color(0, 255, 0);

        // Even though these are two completely separate structs in memory,
        // they are considered equal because their internal values match exactly!
        Console.WriteLine($"Does c1 equal c2? {c1 == c2}"); // Outputs True
    }
}
