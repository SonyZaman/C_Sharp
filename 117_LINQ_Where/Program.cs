// 117. LINQ: Filtering with .Where()
/*
    LINQ (Language Integrated Query) allows you to query collections easily.
    The .Where() method is used to FILTER a collection based on a condition.
    It takes a Predicate (a lambda expression that returns true or false).
    
    You MUST include 'using System.Linq;' to use it!
*/
using System;
using System.Collections.Generic;
using System.Linq; // CRITICAL for LINQ methods!

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Filtering Numbers ---");
        List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

        // Give me all numbers greater than 15
        // Read as: "Where n is greater than 15"
        var largeNumbers = numbers.Where(n => n > 15);

        foreach (var num in largeNumbers)
        {
            Console.WriteLine(num); // 20, 25, 30
        }

        Console.WriteLine("\n--- Filtering Objects ---");
        List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200 },
            new Product { Name = "Mouse", Price = 25 },
            new Product { Name = "Keyboard", Price = 45 },
            new Product { Name = "Monitor", Price = 300 }
        };

        // Give me all products that cost less than $100
        var cheapProducts = products.Where(p => p.Price < 100);

        foreach (var p in cheapProducts)
        {
            Console.WriteLine($"{p.Name} - ${p.Price}");
        }
    }
}
