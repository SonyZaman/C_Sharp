//largest among three numbers

class Test
{
    public static void Main(string[] args)
    {
        int number1,number2,number3;

        Console.Write("Enter first number: ");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: :");
        number2=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter third number: ");
        number3=Convert.ToInt32(Console.ReadLine());

        if(number1>number2 && number1 > number3)
        {
            Console.WriteLine($"{number1} is the largest number");

        }else if(number2 > number1 && number2 > number3)
        {
            
            Console.WriteLine($"{number2} is the largest number");

        }
        else if(number3 > number1 && number3 > number2)
        {
            Console.WriteLine($"{number3} is the largest number");
        }
        else
        {
            Console.WriteLine("All numbers are equal");
        }
    }
}