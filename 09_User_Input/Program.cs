using System;

// take user Input

//take input from user
public class Test
{
    
    public static void Main(string[] args)
    {
        
       Console.Write("Enter your name: ");
       string? studentName=Console.ReadLine();//'?' nullable handle
       Console.WriteLine("Student Name: "+studentName);

       Console.Write("Enter your age: ");
       int? age = Convert.ToInt32(Console.ReadLine());// because we always take input as a string
       Console.WriteLine("Student Age: "+age+" years old");

       Console.Write("Enter your gpa: ");
       double? gpa=Convert.ToDouble(Console.ReadLine());
       Console.WriteLine("Student GPA: "+gpa);

       Console.Write("Have you already registered: ");
       bool isRegistered= Convert.ToBoolean(Console.ReadLine());
       Console.WriteLine("Already registered: "+isRegistered);

    }
}