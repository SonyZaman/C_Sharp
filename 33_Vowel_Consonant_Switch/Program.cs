

class Test
{
    public static void Main(string[] args)
    {
        
        char input;
        Console.Write("Enter a character: ");

        input=Convert.ToChar(Console.ReadLine());

        

        switch (char.ToLower(input))
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine($"{input} is a vowel");
                break;
            default:
                if (char.IsLetter(input))
                {
                    Console.WriteLine($"{input} is a consonant:");

                }
                else
                {
                    Console.WriteLine($"{input} is not a letter" );
                }
                break;

            
        }

    }
}