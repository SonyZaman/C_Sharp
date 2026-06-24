class Test
{

    public static int CalcualateSquare(int num)
    {
        return num*num;
    }
    
    public static void Main(string[] args)
    {
        //User input -> num:5 (between 1-10)
        //User input - quit -> loop break

        while (true)
        {
            Console.Write("Enter a number from 1 to 10 or 'quit' to exit: ");

            string input=Console.ReadLine() ?? "";

            input=input.ToLower().Trim();

            if(input == "quit")
            {
                Console.WriteLine("Exiting the program.");
                break;
            }
            if(!int.TryParse(input,out int number))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
                continue;
            }
            if(number < 1 || number > 10)
            {
                Console.WriteLine("Number out of range. Please enter a number between 1 and 10.");
                continue;
            }
            int square=CalculateSquare(number);
            Console.WriteLine($"The square of {number} is {square}.");

        }

    }
}