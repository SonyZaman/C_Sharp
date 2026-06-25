// 73. Partial Classes
/*
    The 'partial' keyword allows you to split the definition of a single class, 
    struct, or interface into multiple physical files. 
    When the program is compiled, all the parts are combined into a single class.
    
    This is extremely useful when working with auto-generated code (like Windows Forms or WPF)
    so you don't overwrite generated code with your custom code.
*/
using System;

// Part 1 of the class (Imagine this is in File1.cs)
public partial class Employee
{
    public string Name;
    public int Salary;
}

// Part 2 of the class (Imagine this is in File2.cs)
public partial class Employee
{
    public void DisplayDetails()
    {
        Console.WriteLine($"Employee Name: {Name}");
        Console.WriteLine($"Salary: ${Salary}");
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // The compiler automatically merged the two parts!
        Employee emp = new Employee();
        emp.Name = "Kamruzzaman Sony";
        emp.Salary = 50000;
        
        // We can access properties from Part 1 and methods from Part 2 seamlessly
        emp.DisplayDetails();
    }
}
