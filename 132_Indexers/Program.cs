// 132. Indexers
/*
    Indexers allow an instance of a custom class to be indexed just like an array.
    Instead of writing:  company.GetEmployee("Sony");
    You can write:       company["Sony"];
    
    You define it using the 'this' keyword!
*/
using System;
using System.Collections.Generic;

public class Company
{
    // A private dictionary to store employees and their salaries
    private Dictionary<string, double> _employees = new Dictionary<string, double>();

    // This is the INDEXER! 
    // It acts exactly like a Property, but it takes a parameter (string name) in brackets.
    public double this[string name]
    {
        get
        {
            // If the employee exists, return their salary. Otherwise return 0.
            if (_employees.ContainsKey(name))
                return _employees[name];
            else
                return 0.0;
        }
        set
        {
            // Set the salary for the given employee name
            _employees[name] = value;
        }
    }
}

class Test
{
    public static void Main(string[] args)
    {
        // We instantiate the custom class
        Company myCompany = new Company();

        // Normally, we can't use [] on a class object.
        // But because we defined an Indexer, we can treat the object like a Dictionary!
        
        // Using the 'set' block of the indexer
        myCompany["Sony"] = 120000.50;
        myCompany["Maysha"] = 115000.00;

        // Using the 'get' block of the indexer
        Console.WriteLine($"Sony's Salary: ${myCompany["Sony"]}");
        Console.WriteLine($"Maysha's Salary: ${myCompany["Maysha"]}");
        
        // Testing an employee that doesn't exist
        Console.WriteLine($"John's Salary: ${myCompany["John"]}"); // Returns 0.0
    }
}
