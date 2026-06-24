//switch with condition shorthand expression (using the 'when' keyword)
class Test
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        // Using switch expression (shorthand) with 'when' conditions
        string category = age switch
        {
            int n when n < 0 => "Invalid age entered.",
            int n when n >= 0 && n <= 12 => "You are a child.",
            int n when n >= 13 && n <= 19 => "You are a teenager.",
            int n when n >= 20 => "You are an adult."
        };

        Console.WriteLine(category);
    }
}
