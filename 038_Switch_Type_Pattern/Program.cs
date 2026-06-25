//switch type pattern (Pattern matching enhancements introduced in C# 9.0)
class Test
{
    public static void Main(string[] args)
    {
        object obj = 15; 

        // Using standard switch-case statement with C# 9.0 type patterns
        // We use the type directly without a variable name
        switch (obj)
        {
            case int and > 0:
                Console.WriteLine("Positive Integer");
                break;
            case int:
                Console.WriteLine("Negative or Zero Integer");
                break;
            case string:
                Console.WriteLine("It is a String");
                break;
            case not null:
                Console.WriteLine("Other non-null type");
                break;
            case null:
                Console.WriteLine("It is null");
                break;
        }
    }
}
