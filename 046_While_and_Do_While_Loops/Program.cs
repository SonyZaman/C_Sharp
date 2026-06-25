

class Test
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Using while loop:");
        int i= 1 ;
        while (i <= 10)
        {
            Console.WriteLine(i);
            i++;    
        }

        Console.WriteLine("Using do-while loop:");

        i=1;
        do
        {
            Console.WriteLine(i);
            i++;
        } while (i <= 10);
    }
}