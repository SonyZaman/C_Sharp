using System;

class Test{

    public static void Main(string[] args){

     
        Console.WriteLine("Circle Area Calculation");
        Console.Write("Enter the size of radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        double area = Math.PI * radius * radius;
        Console.WriteLine($"Area of Circle = {area.ToString("F2")}");

    }
}