//calculator
class Test
{
    public static void Main(string[] args)
    {
        int number1, number2;
        char operation;
        Console.Write("Enter an operation (+, -, *, /): ");
        operation = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter first number: ");
        number1=Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        number2=Convert.ToInt32(Console.ReadLine());

        switch (operation)
        {
            case '+':
                Console.WriteLine($"Result: {number1 + number2}");
                break;
            case '-':
                Console.WriteLine($"Result: {number1 - number2}");
                break;
            case '*':
                Console.WriteLine($"Result: {number1 * number2}");
                break;
            case '/':
                if (number2 != 0)
                    Console.WriteLine($"Result: {number1 / number2}");
                else
                    Console.WriteLine("Division by zero error");
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
}