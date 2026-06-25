// 123. LINQ: Aggregation (.Max, .Min, .Sum, .Average, .Count)
/*
    Aggregation methods are used to calculate a single value from a collection.
    Instead of manually looping to add up numbers or find the highest value, 
    LINQ does it for you in one line of code!
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- 1. Simple Aggregation (Numbers) ---");
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };

        Console.WriteLine($"Total Count:   {numbers.Count()}");
        Console.WriteLine($"Sum:           {numbers.Sum()}");
        Console.WriteLine($"Average:       {numbers.Average()}");
        Console.WriteLine($"Max (Highest): {numbers.Max()}");
        Console.WriteLine($"Min (Lowest):  {numbers.Min()}");


        Console.WriteLine("\n--- 2. Advanced Aggregation (Objects) ---");
        List<Product> cart = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200m },
            new Product { Name = "Mouse", Price = 25m },
            new Product { Name = "Keyboard", Price = 45m },
            new Product { Name = "Monitor", Price = 300m }
        };

        // You must tell LINQ *which* property you want to aggregate!
        
        // Total cost of all items in the cart
        decimal totalPrice = cart.Sum(p => p.Price);
        Console.WriteLine($"Total Cart Value:  ${totalPrice}");

        // The average price of an item in the cart
        decimal averagePrice = cart.Average(p => p.Price);
        Console.WriteLine($"Average Item Cost: ${averagePrice}");

        // The price of the most expensive item
        decimal maxPrice = cart.Max(p => p.Price);
        Console.WriteLine($"Most Expensive:    ${maxPrice}");

        // How many items cost more than $50?
        // Note: .Count() can take a lambda condition directly!
        int expensiveItemsCount = cart.Count(p => p.Price > 50m);
        Console.WriteLine($"Items over $50:    {expensiveItemsCount}");
    }
}
