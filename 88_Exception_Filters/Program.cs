// 88. Exception Filters ('when' keyword)
/*
    Introduced in C# 6.0, Exception Filters allow you to add a condition to a catch block using the 'when' keyword.
    The catch block will only execute if the 'when' condition evaluates to true.
    This prevents you from having to catch an exception, check a condition inside the block, and rethrow it if it doesn't match.
*/
using System;

class Test
{
    public static void ProcessData(int code)
    {
        if (code == 404)
        {
            throw new Exception("HTTP_404: Not Found error occurred while processing.");
        }
        else if (code == 500)
        {
            throw new Exception("HTTP_500: Internal Server Error occurred.");
        }
        else
        {
            Console.WriteLine("Data processed successfully.");
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a simulation error code (404 or 500): ");
            int code = Convert.ToInt32(Console.ReadLine());
            
            ProcessData(code);
        }
        // This catch block ONLY runs if the exception message contains "404"
        catch (Exception ex) when (ex.Message.Contains("404"))
        {
            Console.WriteLine("Filtered Catch [404]: We couldn't find the resource you requested.");
        }
        // This catch block ONLY runs if the exception message contains "500"
        catch (Exception ex) when (ex.Message.Contains("500"))
        {
            Console.WriteLine("Filtered Catch [500]: The server crashed. Please try again later.");
        }
        // A general fallback catch block for everything else
        catch (Exception ex)
        {
            Console.WriteLine($"General Catch: {ex.Message}");
        }
    }
}
