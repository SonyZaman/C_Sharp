// 106. Enums (Enumerations)
/*
    An 'enum' is a special "value type" that lets you define a set of named constants.
    It replaces "magic numbers" or "magic strings" in your code, making it much safer and more readable.
    By default, the underlying type of an enum is 'int', starting at 0.
*/
using System;

// We define the enum outside of the class (usually)
public enum OrderStatus
{
    Pending,     // Underlying value is 0
    Processing,  // Underlying value is 1
    Shipped,     // Underlying value is 2
    Delivered    // Underlying value is 3
}

// You can also assign custom values!
public enum ErrorCode
{
    NotFound = 404,
    ServerError = 500,
    Unauthorized = 401
}

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Using Enums ---");
        
        // We declare a variable of type 'OrderStatus'
        OrderStatus currentStatus = OrderStatus.Processing;
        
        Console.WriteLine($"The current status is: {currentStatus}");

        Console.WriteLine("\n--- Enums with Switch Statements ---");
        // Enums are brilliant when paired with Switch statements
        switch (currentStatus)
        {
            case OrderStatus.Pending:
                Console.WriteLine("We are waiting for payment.");
                break;
            case OrderStatus.Processing:
                Console.WriteLine("Your order is being packed!");
                break;
            case OrderStatus.Shipped:
                Console.WriteLine("Your order is on the way.");
                break;
            case OrderStatus.Delivered:
                Console.WriteLine("Package has arrived.");
                break;
        }

        Console.WriteLine("\n--- Getting the Underlying Integer Value ---");
        // We cast the enum to an 'int' to get its underlying numerical value
        int statusValue = (int)currentStatus;
        Console.WriteLine($"The integer value of {currentStatus} is {statusValue}");

        ErrorCode error = ErrorCode.NotFound;
        Console.WriteLine($"Error {error} has code: {(int)error}");
    }
}
