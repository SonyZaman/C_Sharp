// 075. Object Initializers
/*
    Object Initializers let you assign values to any accessible fields or properties 
    of an object at creation time, without having to invoke a constructor with parameters.
    It results in very clean, readable code!
*/
using System;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    // We only have a default constructor! No parameterized constructor needed!
    public Student() { }
}

class Test
{
    public static void Main(string[] args)
    {
        // Creating an object and assigning properties instantly using { } block!
        Student s1 = new Student 
        { 
            Name = "Sony", 
            Age = 22, 
            GPA = 3.8 
        };

        Console.WriteLine($"Student: {s1.Name}, Age: {s1.Age}, GPA: {s1.GPA}");
    }
}
