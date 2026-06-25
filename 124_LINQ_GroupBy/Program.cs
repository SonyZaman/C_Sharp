// 124. LINQ: Grouping Data (.GroupBy)
/*
    .GroupBy() organizes data into "buckets" based on a specific key.
    It returns an 'IEnumerable<IGrouping<TKey, TElement>>'.
    This is extremely similar to the SQL 'GROUP BY' clause.
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
}

class Test
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Sony", Department = "IT" },
            new Employee { Name = "John", Department = "HR" },
            new Employee { Name = "Alice", Department = "IT" },
            new Employee { Name = "Bob", Department = "Sales" },
            new Employee { Name = "Charlie", Department = "HR" }
        };

        // We want to group employees by their Department!
        // group.Key will be the Department name.
        // group itself acts like a List containing all employees in that department.
        var groupedByDept = employees.GroupBy(emp => emp.Department);

        foreach (var group in groupedByDept)
        {
            Console.WriteLine($"--- Department: {group.Key} ---");
            
            // Loop through the employees INSIDE this specific group
            foreach (var emp in group)
            {
                Console.WriteLine($" - {emp.Name}");
            }
            Console.WriteLine();
        }
    }
}
