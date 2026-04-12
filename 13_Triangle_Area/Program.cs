using System;

class Test
{
    public static void Main(string[] args)
    {
        //triangle area= 0.5 * base * height

        double baseLength, height, area;


        Console.WriteLine("Triangle Area Calculation");
        Console.Write("Base = ");
        baseLength=Convert.ToDouble(Console.ReadLine());

        Console.Write("Height = ");
        height=Convert.ToDouble(Console.ReadLine());

        area= 0.5 * baseLength * height;
        Console.WriteLine($"Area of Triangle = {area.ToString("F2")}");

    }     
}