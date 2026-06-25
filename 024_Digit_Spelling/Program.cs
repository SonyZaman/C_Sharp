class Test
{
    public static void Main(string[] args)
    {
        
        Console.Write("Enter any digit between 0 to 9: ");

        int digit=Convert.ToInt32(Console.ReadLine());

        if (digit == 0)
        {
            Console.WriteLine("Zero");

        }else if (digit == 1)
        {
            Console.WriteLine("One");
        }else if (digit == 2)
        {
            Console.WriteLine("Two");
        }else if (digit == 3)
        {
            Console.WriteLine("Three");
        }else if (digit == 4)
        {
            Console.WriteLine("Four");
        }else if (digit == 5)
        {
            Console.WriteLine("Five");
        }else if (digit == 6)
        {
            Console.WriteLine("Six");
        }else if (digit == 7)
        {
            Console.WriteLine("Seven");
        }else if (digit == 8)
        {
            Console.WriteLine("Eight");
        }else if (digit == 9)
        {
            Console.WriteLine("Nine");
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
    
}