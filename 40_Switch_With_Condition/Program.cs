//switch with condition (using the 'when' keyword)
class Test
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        // Using switch statement with 'when' conditions
        switch (age)
        {
            case int n when n < 0:
                Console.WriteLine("Invalid age entered.");
                break;
            case int n when n >= 0 && n <= 12:
                Console.WriteLine("You are a child.");
                break;
            case int n when n >= 13 && n <= 19:
                Console.WriteLine("You are a teenager.");
                break;
            case int n when n >= 20:
                Console.WriteLine("You are an adult.");
                break;
        }
    }
}
