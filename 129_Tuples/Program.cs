// 129. Tuples
/*
    A method usually only returns ONE value.
    If you needed to return multiple values (like an ID and a Name), 
    you historically had to use the 'out' keyword, or create a whole new Struct/Class.
    
    Tuples allow you to return multiple values instantly, grouped together in parentheses!
*/
using System;

class Test
{
    // The return type is literally (int, string)
    public static (int, string) GetEmployeeDetails()
    {
        int employeeId = 101;
        string employeeName = "Sony Zaman";

        // Return them packaged together!
        return (employeeId, employeeName);
    }

    // You can even name the return variables so they are easier to read!
    public static (int Id, string Name, double Salary) GetAdvancedDetails()
    {
        return (202, "Maysha", 85000.50);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Basic Tuples ---");
        
        // Storing the returned tuple inside a single variable
        var result = GetEmployeeDetails();
        
        // It defaults to naming them Item1, Item2
        Console.WriteLine($"ID: {result.Item1}, Name: {result.Item2}");


        Console.WriteLine("\n--- 2. Named Tuples ---");
        var advancedResult = GetAdvancedDetails();
        
        // Because we named them in the method signature, we can use their real names!
        Console.WriteLine($"ID: {advancedResult.Id}, Name: {advancedResult.Name}, Salary: ${advancedResult.Salary}");


        Console.WriteLine("\n--- 3. Tuple Deconstruction (The Modern Way) ---");
        // Instead of storing the tuple in one variable, we can instantly split it into 3 separate variables!
        (int empId, string empName, double empSalary) = GetAdvancedDetails();
        
        Console.WriteLine($"Deconstructed -> {empName} makes ${empSalary}");
    }
}
