// 128. LINQ: Method Syntax vs Query Syntax
/*
    There are TWO ways to write LINQ.
    1. Method Syntax (Lambda): list.Where(...).Select(...)
    2. Query Syntax (SQL-Like): from item in list where ... select ...
    
    Under the hood, the compiler treats them EXACTLY the same. 
    It is entirely personal preference!
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 5, 10, 15, 20, 25 };

        Console.WriteLine("Goal: Find numbers > 10, sorted descending.");

        // 1. METHOD SYNTAX (The modern, most common way using Lambdas)
        var methodSyntaxResult = numbers
                                    .Where(n => n > 10)
                                    .OrderByDescending(n => n);

        Console.Write("Method Syntax: ");
        foreach (int n in methodSyntaxResult) Console.Write($"{n} ");
        
        
        Console.WriteLine("\n\n-----------------------------------");


        // 2. QUERY SYNTAX (Looks exactly like SQL databases!)
        // Great for people coming from a SQL background.
        var querySyntaxResult = from n in numbers
                                where n > 10
                                orderby n descending
                                select n;

        Console.Write("Query Syntax:  ");
        foreach (int n in querySyntaxResult) Console.Write($"{n} ");
        
        Console.WriteLine("\n\nBoth produce the exact same result!");
    }
}
