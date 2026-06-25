
class Test
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        int firstTerm = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the last number: ");
         int lastTerm = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the difference: ");
        int difference = Convert.ToInt32(Console.ReadLine());


        for (int count = firstTerm; count <= lastTerm; count += difference)
        {
            Console.WriteLine($" {count}");
        }
    }
}