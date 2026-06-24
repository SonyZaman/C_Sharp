//switch type pattern with shorthand expression
class Test
{
    public static void Main(string[] args)
    {
        object obj = 15; 

        // Using switch expression (shorthand) 
        string result = obj switch
        {
            int and > 0 => "Positive Integer",
            int => "Negative or Zero Integer",
            string => "It is a String",
            not null => "Other non-null type",
            null => "It is null"
        };

        Console.WriteLine(result);
    }
}
