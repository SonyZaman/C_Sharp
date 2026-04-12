
public class MyClass
{
    public static void Main(string[] args)
    {
        // Explicit Type Casting (Manual Conversion)
        // double to int: Fractional part will be lost (10.5 becomes 10)
        // string to int not possible with Explicit Type Casting
        double number = 10.5;
        int number2 = (int)number; 

        // Using Convert class for Type Conversion
        // Convert.ToInt32 rounds the value to the nearest integer
        int number3 = Convert.ToInt32(number);

        Console.WriteLine($"number2 (Explicit Casting): {number2}");
        Console.WriteLine($"number3 (Convert.ToInt32): {number3}");

        
        
        // String to Numeric Conversion
        string numberStr = "12345";

        // int.Parse: Converts a string to an integer. 
        // Throws an exception if the string is not a valid number.
        int numberConvert = Convert.ToInt32(numberStr);
        int numberParsed = int.Parse(numberStr);

        Console.WriteLine($"Convert.ToInt32 Value: {numberConvert}");
        Console.WriteLine($"Parsed Value: {numberParsed}");

        // int.TryParse: Safely attempts to convert a string.
        // Returns true if successful, false otherwise. Does not throw exceptions.
        bool isSuccess = int.TryParse(numberStr, out int result);
        Console.WriteLine($"TryParse Success: {isSuccess}, Result: {result}");

        Console.ReadKey();
    }
}