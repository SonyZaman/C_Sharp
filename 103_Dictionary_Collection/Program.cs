// 103. The Dictionary<TKey, TValue> Collection
/*
    A Dictionary stores data in Key-Value pairs.
    Every Key MUST be unique. It is extremely fast for looking up data!
    Think of it like a real dictionary: The 'Key' is the word, the 'Value' is the definition.
*/
using System;
using System.Collections.Generic;

class Test
{
    public static void Main(string[] args)
    {
        // Dictionary where the Key is an int (e.g. Employee ID), and Value is a string (e.g. Name)
        Dictionary<int, string> employees = new Dictionary<int, string>();

        // Adding Key-Value pairs
        employees.Add(101, "Sony");
        employees.Add(102, "Maysha");
        employees.Add(103, "John");

        Console.WriteLine("--- Accessing Values via Key ---");
        // We do NOT use indexes like arrays (0, 1, 2). We use the actual Key!
        Console.WriteLine($"Employee 101 is: {employees[101]}");
        Console.WriteLine($"Employee 103 is: {employees[103]}");

        Console.WriteLine("\n--- Iterating a Dictionary ---");
        // We iterate using KeyValuePair<TKey, TValue>
        foreach (KeyValuePair<int, string> emp in employees)
        {
            Console.WriteLine($"ID: {emp.Key}, Name: {emp.Value}");
        }

        Console.WriteLine("\n--- Safety Checks ---");
        // Always check if a Key exists before accessing it to prevent crashes!
        if (employees.ContainsKey(104))
        {
            Console.WriteLine(employees[104]);
        }
        else
        {
            Console.WriteLine("Employee 104 does not exist!");
        }
    }
}
