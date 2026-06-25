//switch shorthand expression
class Test
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a day number (1-7): ");
        int dayNumber = Convert.ToInt32(Console.ReadLine());

        // Using Switch Expression (Shorthand) introduced in C# 8.0
        string dayName = dayNumber switch
        {
            1 => "Saturday",
            2 => "Sunday",
            3 => "Monday",
            4 => "Tuesday",
            5 => "Wednesday",
            6 => "Thursday",
            7 => "Friday",
            _ => "Invalid day number" // _ is the discard pattern (default)
        };

        Console.WriteLine($"The day is: {dayName}");
    }
}
