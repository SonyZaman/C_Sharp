
//mathmatical operation

//operators--unary, binary, ternary
//Binary-- Arithmetic, Assignment, Relational, Logical, Bitwise
class Test
{
    
    public static void Main(string [] args)
    {

        int result =25+30;
        Console.WriteLine(result);

        int number1=10;
        int number2=3;

        Console.WriteLine("Addition: "+ number1+number2);
        Console.WriteLine("Subtraction: "+ (number1-number2));
        Console.WriteLine("Multiplication: "+number1*number2);
        // 1. Using .ToString("F3")
        Console.WriteLine("Division (ToString): " + ((double)number1 / number2).ToString("F3"));
        // 2. Using String Interpolation (Modern & Recommended)
        Console.WriteLine($"Division (Interpolation): {((double)number1 / number2):F3}");
        // 3. Using Composite Formatting (Placeholders)
        Console.WriteLine("Division (Placeholders): {0:F3}", (double)number1 / number2);
        Console.WriteLine("Remainder: "+number1%number2);

  

    }
}