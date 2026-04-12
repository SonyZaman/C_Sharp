//find largest number from two numbers
class Test
{
    public static void Main(string[] args)
    {
        int number1, number2;
        Console.Write("Enter first number: ");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        number2=Convert.ToInt32(Console.ReadLine());

        if (number1 > number2)
        {
            Console.WriteLine($"{number1} is greater than {number2}");

        }else if(number1 < number2)
        {
            Console.WriteLine($"{number2} is greater than {number1}");

        }
        else
        {
            Console.WriteLine("Both numbers are equal");
        }

    }
}