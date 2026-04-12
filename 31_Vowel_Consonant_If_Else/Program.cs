

//vowel or constant

class Test
{
    
    public static void Main(string[] args)
    {
        Console.Write("Enter a character: ");
        char ch=Convert.ToChar(Console.ReadLine());
        //ch=char.ToLower(ch);

        if(ch=='a' || ch=='e' || ch=='i' || ch=='o' || ch=='u' || ch=='A' || ch=='E' || ch=='I' || ch=='O' || ch=='U')
        {
            Console.WriteLine($"{ch} is a vowel");
        }
        else if (ch>='a' && ch<='z' || ch>='A' && ch<='Z')
        {
            Console.WriteLine($"{ch} is a consonant");
        }else{
            Console.WriteLine("Invalid input");
        }
    }
}