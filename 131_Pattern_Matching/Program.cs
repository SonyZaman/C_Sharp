// 131. Pattern Matching (Modern Switch & 'is' keyword)
/*
    Pattern Matching allows you to test if a variable has a certain type or specific properties,
    and cast it immediately. It replaces massive chunks of 'if/else' and type-casting code.
*/
using System;

// Base class
public class Shape { }

// Derived classes
public class Circle : Shape 
{ 
    public double Radius { get; set; } 
}
public class Rectangle : Shape 
{ 
    public double Width { get; set; }
    public double Height { get; set; } 
}

class Test
{
    public static void Main(string[] args)
    {
        Shape myShape = new Circle { Radius = 5 };

        Console.WriteLine("--- 1. The 'is' Keyword Pattern ---");
        // Old Way: 
        // if (myShape is Circle) { Circle c = (Circle)myShape; Console.WriteLine(c.Radius); }

        // Modern Way: Checks if it's a Circle AND creates the 'c' variable instantly!
        if (myShape is Circle c)
        {
            Console.WriteLine($"It's a circle with radius {c.Radius}");
        }


        Console.WriteLine("\n--- 2. Property Pattern Matching ---");
        // We can even peek INSIDE the object's properties instantly!
        if (myShape is Circle { Radius: 5 })
        {
            Console.WriteLine("This is a circle with EXACTLY a radius of 5!");
        }


       
    }
}
