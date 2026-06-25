// 60. Value Type vs Reference Type
using System;

class Person
{
    public string Name;
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Value Type Example ---");
        // Value types (like int, double, struct) store the actual data.
        int x = 10;
        int y = x; // A complete copy of the value is assigned to y.
        
        y = 20; // Changing 'y' does NOT affect 'x'.
        
        Console.WriteLine($"x = {x}"); // Output: 10
        Console.WriteLine($"y = {y}"); // Output: 20


        Console.WriteLine("\n--- Reference Type Example ---");
        // Reference types (like class, arrays) store a reference (memory address) to the data.
        Person p1 = new Person();
        p1.Name = "Sony";
        
        Person p2 = p1; // Both p1 and p2 now point to the EXACT same object in memory.
        
        p2.Name = "Maysha"; // Changing 'p2' WILL affect 'p1' because they share the same memory.
        
        Console.WriteLine($"p1 Name = {p1.Name}"); // Output: Maysha
        Console.WriteLine($"p2 Name = {p2.Name}"); // Output: Maysha
    }
}
