class Test
{
    public static void Main(string[] args)
    {
        

        int number ;
        Console.Write("Enter a number: ");
        number=Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            
            Console.WriteLine($"{number} is Even");
        }
        else
        {
            Console.WriteLine($"{number} is Odd");
        }
    }
}