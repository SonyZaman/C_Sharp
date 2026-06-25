// 062. The 'this' Keyword
/*
    The 'this' keyword refers to the current instance of the class.
    It is commonly used to distinguish between class fields and method 
    parameters when they have the exact same name.
*/
using System;

class Person
{
    // Class fields
    public string name;
    public int age;

    // Constructor where parameters have the exact same name as the class fields
    public Person(string name, int age)
    {
        // name = name; // If we did this, it would just assign the parameter to itself!
        // age = age;   // The class fields would remain unassigned (null and 0).
        
        // We use 'this' to explicitly tell the compiler we mean the class fields
        this.name = name;
        this.age = age;
    }

    public void Display()
    {
        // 'this' is optional here since there is no naming conflict in this method,
        // but it can still be used for clarity to show it belongs to the class.
        Console.WriteLine($"Name: {this.name}, Age: {this.age}");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        Person p1 = new Person("Sony", 22);
        p1.Display();
    }
}
