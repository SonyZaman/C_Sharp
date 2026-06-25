// 069. Abstract Classes
/*
    An Abstract Class is a restricted class that cannot be used to create objects.
    To access it, it MUST be inherited from another class.
    
    Abstract Methods:
    - Can only be used in an abstract class.
    - They do NOT have a body. The body is provided by the derived class.
*/
using System;

// We use the 'abstract' keyword
public abstract class Shape
{
    // An abstract method (does not have a body)
    public abstract double CalculateArea();

    // A regular method (has a body)
    public void DisplayInfo()
    {
        Console.WriteLine("This is a shape.");
    }
}

public class Circle : Shape
{
    public double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    // The child class MUST provide the body for the abstract method using 'override'
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // Shape myShape = new Shape(); // ERROR! Cannot instantiate an abstract class.

        Circle myCircle = new Circle(5.0);
        
        // We can call both regular and overridden abstract methods
        myCircle.DisplayInfo();
        Console.WriteLine($"The area of the circle is: {myCircle.CalculateArea()}");
    }
}
