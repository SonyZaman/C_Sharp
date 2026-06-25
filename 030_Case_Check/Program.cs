//capital letter or small letter

class Test
{
    public static void Main(string[] args)
    {
        
        char letter;
        Console.Write("Enter a letter: ");

        letter=Convert.ToChar(Console.ReadLine());

        if(letter>='A' && letter<='Z')
        {
            Console.WriteLine($"{letter} is a capital letter");
        }
        else if(letter>='a' && letter<='z')
        {
            Console.WriteLine($"{letter} is a small letter");
        }
        else
        {
            Console.WriteLine($"{letter} is not a letter");
        }
    }
}