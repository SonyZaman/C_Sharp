class Test
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a day of the week : ");
        string day=Console.ReadLine();
        switch (day.ToLower())
        {
            case "monday":
            case "tuesday":
            case "wednesday":
            case "thursday":
            case "sunday":
                Console.WriteLine($"{day} is a week day");
                break;
            case "friday":
            case "saturday":
                Console.WriteLine($"{day} is a weekend");
                break;

            default:
                Console.WriteLine("Invalid day");
                break;

        }
    }
}